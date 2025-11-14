using BankApp.Business.DataProtection;
using BankApp.Business.Operations.Security.Dtos;
using BankApp.Business.Type;
using BankApp.Data.Entities;
using BankApp.Data.Repositories;
using BankApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Security
{
    public class SecurityService : ISecurityService 
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataProtection _dataProtection;

        public SecurityService(IRepository<UserEntity> userRepository, IUnitOfWork unitOfWork,IDataProtection dataProtection )
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _dataProtection = dataProtection;
        }

        public async Task<ServiceMessage<string>> SetTwoFactorAsync(TwoFactorDto dto) // method beginning
        {
            var user = await _userRepository.GetAsync(x => x.Id == dto.UserId);

            if (user == null)
            {
                return new ServiceMessage<string>
                {
                    IsSuccess = false,
                    Message = "Kullanıcı bulunamadı."
                };
            }

            user.IsTwoFactorEnable = dto.IsTwoFactorEnabled;
            await _unitOfWork.SaveChangesAsync();

            return new ServiceMessage<string>
            {
                IsSuccess = true,
                Data = dto.IsTwoFactorEnabled
                       ? "İki faktörlü doğrulama etkinleştirildi."
                       : "İki faktörlü doğrulama devre dışı bırakıldı."
            };
        } // end of SettwoFActorAsync

        public async Task<ServiceMessage<string>> ChangePasswordAsync(ChangePasswordDto dto) // method beginning
        {
            var user = await _userRepository.GetAsync(x => x.Id == dto.UserId);
            if (user == null)
            {
                return new ServiceMessage<string>
                {
                    IsSuccess = false,
                    Message = "Kullanıcı bulunamadı."
                };
            }

            var decryptedPassword = _dataProtection.Unprotect(user.Password);
            if (decryptedPassword != dto.CurrentPassword)
            {
                return new ServiceMessage<string>
                {
                    IsSuccess = false,
                    Message = "Mevcut şifre yanlış."
                };
            }

            user.Password = _dataProtection.Protect(dto.NewPassword);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceMessage<string>
            {
                IsSuccess = true,
                Data = "Şifre başarıyla güncellendi."
            };
        } // end of ChangePassword

    }  // end of class
} 

