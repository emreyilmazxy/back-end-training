using BankApp.Business.Type;
using BankApp.Data.Entities;
using BankApp.Data.Repositories;
using BankApp.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.TwoFactor
{
    public class TwoFactorService : ITwoFactorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserTwoFactorEntity> _twoFactorRepository;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IOtpSender _otpSender;

        public TwoFactorService(IUnitOfWork unitOfWork,
                                IRepository<UserTwoFactorEntity> twoFactorRepository,
                                IRepository<UserEntity> userRepository,
                                IOtpSender otpSender)
        {
            _unitOfWork = unitOfWork;
            _twoFactorRepository = twoFactorRepository;
            _userRepository = userRepository;
            _otpSender = otpSender;
        }

        public string GenerateOtpCode()
        {
            var bytes = new byte[4];
            RandomNumberGenerator.Fill(bytes);
            var value = BitConverter.ToUInt32(bytes, 0) % 900000 + 100000;
            return value.ToString("D6");
        }

        public async Task<ServiceMessage> GenerateOtpAsync(int userId, string provider)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return new ServiceMessage
                {
                    IsSuccess = false,
                    Message = "Kullanıcı bulunamadı."
                };
            }

            var destination = provider switch
            {
                "Email" => user.Email,
                "SMS" => user.PhoneNumber,
                _ => null
            };

            if (string.IsNullOrEmpty(destination))
            {
                return new ServiceMessage
                {
                    IsSuccess = false,
                    Message = "Geçersiz sağlayıcı."
                };
            }

            var otpCode = GenerateOtpCode();
            var expireAt = DateTime.Now.AddMinutes(5);

            var entity = new UserTwoFactorEntity
            {
                UserId = userId,
                OtpCode = otpCode,
                Provider = provider,
                ExpireAt = expireAt,
                IsUsedCode = false
            };

            await _twoFactorRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            await _otpSender.SendOtpAsync(provider, destination, otpCode);

            return new ServiceMessage
            {
                IsSuccess = true
            };
        }

        public async Task<ServiceMessage<bool>> VerifyOtpAsync(int userId, string otpCode)
        {
            var otpEntity = await _twoFactorRepository.GetAll(x => x.UserId == userId && x.OtpCode == otpCode)
                                                      .OrderByDescending(x => x.ExpireAt)
                                                      .FirstOrDefaultAsync();

            if (otpEntity == null)
            {
                return new ServiceMessage<bool>
                {
                    IsSuccess = false,
                    Message = "OTP kodu bulunamadı."
                };
            }

            if (otpEntity.IsUsedCode)
            {
                return new ServiceMessage<bool>
                {
                    IsSuccess = false,
                    Message = "Bu OTP kodu zaten kullanılmış."
                };
            }

            if (otpEntity.ExpireAt < DateTime.Now)
            {
                return new ServiceMessage<bool>
                {
                    IsSuccess = false,
                    Message = "OTP kodunun süresi dolmuş."
                };
            }

            otpEntity.IsUsedCode = true;

            await _twoFactorRepository.UpdateAsync(otpEntity);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceMessage<bool>
            {
                IsSuccess = true,
                Data = true
            };
        }
    }
}

