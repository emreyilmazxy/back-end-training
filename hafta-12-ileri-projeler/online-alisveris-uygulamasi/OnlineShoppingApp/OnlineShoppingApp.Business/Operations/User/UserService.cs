using OnlineShoppingApp.Business.DataProtection;
using OnlineShoppingApp.Business.Operations.User.Dtos;
using OnlineShoppingApp.Business.Types;
using OnlineShoppingApp.Data.Entities;
using OnlineShoppingApp.Data.Repositories;
using OnlineShoppingApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.User
{

    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataProtection _dataProtection;

        public UserService(IRepository<UserEntity> userRepository, IUnitOfWork unitOfWork, IDataProtection dataProtection)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _dataProtection = dataProtection;
        }
        public async Task<ServiceMessage> AddUserAsync(AddUserDto userDto)
        {
            var hasMail = _userRepository.GetAll(x => x.Email.ToLower() == userDto.Email.ToLower());

            if (hasMail.Any())
            {
                return new ServiceMessage
                {
                    IsSuccess = false,
                    Message = "bu email zaten mevcut."
                };
            }
            if (userDto.BirthDate > DateTime.Today)
            {
                return new ServiceMessage
                {
                    IsSuccess = false,
                    Message = "Doğum tarihi bugünden ileri bir tarih olamaz."
                };
            }


            var userEntity = new UserEntity()
            {
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Password = _dataProtection.protect(userDto.Password),
                BirthDate = userDto.BirthDate,
                UserType = userDto.UserType
                    
            };

            await _userRepository.AddAsync(userEntity);

            await _unitOfWork.SaveChangesAsync();
            return new ServiceMessage
            {
                IsSuccess = true,
                Message = "kullanıcı başarıyla eklendi"
            };
        }

        public async Task<ServiceMessage<UserInfoDto>> LoginUserAsync(LoginUserDto user)
        {
            var userEntity = _userRepository.GetAsync(x => x.Email.ToLower().Trim() == user.Email.ToLower().Trim());
            

            if (userEntity == null)
            {
                return  new ServiceMessage<UserInfoDto>
                {
                    IsSuccess = false,
                    Message = "Kullanıcı adı veya şifre hatalı"
                };
            }

            var unProtectedPassword = _dataProtection.Unprotect(userEntity.Result.Password);
           
            if (unProtectedPassword != user.Password)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSuccess = false,
                    Message = "Kullanıcı adı veya şifre hatalı"
                };
            }

            return new ServiceMessage<UserInfoDto>
            {
                IsSuccess = true,
                Message = "Giriş başarılı",
                Data = new UserInfoDto
                {
                    Id = userEntity.Result.Id,
                   Email = userEntity.Result.Email,
                   FirstName = userEntity.Result.FirstName,
                     LastName = userEntity.Result.LastName,
                     UserType = userEntity.Result.UserType,
                }
            };
        }// end of UserService class
    }
}