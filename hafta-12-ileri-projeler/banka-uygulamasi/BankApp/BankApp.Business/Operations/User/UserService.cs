using BankApp.Business.DataProtection;
using BankApp.Business.Operations.TwoFactor;
using BankApp.Business.Operations.User.Dtos;
using BankApp.Business.Type;
using BankApp.Data.Entities;
using BankApp.Data.Repositories;
using BankApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataProtection _dataProtection;
        private readonly ITwoFactorService _twoFactorService;

        public UserService(IRepository<UserEntity> repository, IUnitOfWork unitOfWork, IDataProtection dataProtection, ITwoFactorService twoFactorService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _dataProtection = dataProtection;
            _twoFactorService = twoFactorService;
        }

        public async Task<ServiceMessage> DeleteUserIdAsync(int id) // method beginning
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ServiceMessage()
                {
                    IsSuccess = false,
                    Message = "kullanıcı bulunamadı"
                };
            }

            await _repository.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceMessage()
            {
                IsSuccess = true,
                Message = "kullanıcı başarıyla silindi"
            };

        } //end of DeleteuserAsync

        public async Task<ServiceMessage<UserInfoDto>> GetUserIdAsync(int id) // method begining
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSuccess = false,
                    Message = "Kullanıcı bulunamadı"
                };
            }

            return new ServiceMessage<UserInfoDto>()
            {
                IsSuccess = true,
                Data = new UserInfoDto
                {
                    Id = id,
                    BirthDate = user.BirthDate,
                    UserType = user.UserType,
                    Email = user.Email,
                    IsTwoFactorEnable = user.IsTwoFactorEnable,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    PhoneNumber = user.PhoneNumber,

                }
            };
        } // end of getUserId

        public async Task<ServiceMessage<UserInfoDto>> LoginUserAsync(LoginRequestDto request)   // method beginning
        {
            var userEntity = await _repository.GetAsync(x => x.Email.ToLower().Trim() == request.Email.ToLower().Trim());

            if (userEntity == null)
            {
                return new ServiceMessage<UserInfoDto>()
                {
                    IsSuccess = false,
                    Message = "kullacı adı veya şifre hatalı"
                };
            }

            var unProtectedPassword = _dataProtection.Unprotect(userEntity.Password);
            if (unProtectedPassword != request.Password)
            {
                return new ServiceMessage<UserInfoDto>()
                {
                    IsSuccess = false,
                    Message = "kullanıcı adı veya şifre hatalı"
                };
            }

            if (userEntity.IsTwoFactorEnable) // if twoFactor enable go to verifyOtp end point
            {

                var otpCode = _twoFactorService.GenerateOtpCode();
                await _unitOfWork.GetRepository<UserTwoFactorEntity>().AddAsync(new UserTwoFactorEntity
                {
                    UserId = userEntity.Id,
                    OtpCode = otpCode,
                    ExpireAt = DateTime.Now.AddMinutes(5),
                    IsUsedCode = false,
                    Provider = "Email", 
                });
                await _unitOfWork.SaveChangesAsync();

               
                return new ServiceMessage<UserInfoDto>
                {
                    IsSuccess = true,
                    Message = "İki faktörlü doğrulama kodu gönderildi.",
                    Data = new UserInfoDto
                    {
                        Id = userEntity.Id,
                        IsTwoFactorEnable = true
                    }
                };
            }

            return new ServiceMessage<UserInfoDto>()
            {
                IsSuccess = true,
                Message = "giriş başarılı",
                Data = new UserInfoDto()
                {
                    BirthDate = userEntity.BirthDate,
                    UserType = userEntity.UserType,
                    Email = userEntity.Email,
                    Id = userEntity.Id,
                    IsTwoFactorEnable = userEntity.IsTwoFactorEnable,
                    LastName = userEntity.LastName,
                    PhoneNumber = userEntity.PhoneNumber,
                    FirstName = userEntity.FirstName,
                }
            };
        } // end of loginUserAsync

        public async Task<ServiceMessage> PatchUserAsync(int id, UserPatchDto dto) // method beginning
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ServiceMessage<UserPatchDto>
                {
                    IsSuccess = false,
                    Message = "Kullanıcı bulunamadı"
                };
            }

            
            if (!string.IsNullOrWhiteSpace(dto.FirstName))
                entity.FirstName = dto.FirstName;

            if (!string.IsNullOrWhiteSpace(dto.LastName))
                entity.LastName = dto.LastName;

            if (!string.IsNullOrWhiteSpace(dto.PhoneNumber))
                entity.PhoneNumber = dto.PhoneNumber;

            if (!string.IsNullOrWhiteSpace(dto.email))
                entity.Email = dto.email;

            entity.IsTwoFactorEnable = dto.IstwoFactorEnable;

            await _repository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceMessage
            {
                IsSuccess = true,
                Message = "Kullanıcı bilgileri güncellendi."
            };

        }  // end of PatchUserAsync

        public async Task<ServiceMessage<UserInfoDto>> RegisterAsync(RegisterDto request) // method beginning
        {
            var entity = await _repository.GetAsync(u => u.Email == request.Email);
            if (entity != null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSuccess = false,
                    Message = "Bu email adresi zaten mevcut"
                };
            }

            var newUser = new UserEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Password = _dataProtection.Protect(request.Password),
                IsTwoFactorEnable = request.IsTwoFactorEnable,
            };

            await _repository.AddAsync(newUser);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceMessage<UserInfoDto>()
            {
                IsSuccess = true,
                Message = "kullanıcı başarıyla oluşturuldu",
                Data = new UserInfoDto()
                {
                    Id = newUser.Id,
                    BirthDate = newUser.BirthDate,
                    Email = newUser.Email,
                    IsTwoFactorEnable = newUser.IsTwoFactorEnable,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    PhoneNumber = newUser.PhoneNumber,
                    UserType = newUser.UserType
                }
            };
        } // end of  Register Async

        public async Task<ServiceMessage> UpdateUserAsync(UserInfoDto userInfo) // method beginning
        {
            var user = await _repository.GetByIdAsync(userInfo.Id);

            if (user == null)
            {
                return new ServiceMessage()
                {
                    IsSuccess = false,
                    Message = "kullanıcı bulunamadı"
                };
            }

            user.FirstName = userInfo.FirstName;
            user.LastName = userInfo.LastName;
            user.PhoneNumber = userInfo.PhoneNumber;
            user.BirthDate = userInfo.BirthDate;
            user.Email = userInfo.Email;

            await _repository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceMessage()
            {
                IsSuccess = true,
                Message = "kullanıcı başarıyla güncellendi"
            };
        } // end of class UserService
    }
}