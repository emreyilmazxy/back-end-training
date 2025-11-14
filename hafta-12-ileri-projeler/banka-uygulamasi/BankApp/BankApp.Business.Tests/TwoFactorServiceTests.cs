using System.Threading.Tasks;
using BankApp.Business.Operations.TwoFactor;
using BankApp.Data.Entities;
using BankApp.Data.Repositories;
using BankApp.Data.UnitOfWork;
using Moq;
using Xunit;

namespace BankApp.Business.Tests
{
    public class TwoFactorServiceTests
    {
        [Fact]
        public void GenerateOtpCode_ShouldReturnSixDigits()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var twoFactorRepo = new Mock<IRepository<UserTwoFactorEntity>>();
            var userRepo = new Mock<IRepository<UserEntity>>();
            var sender = new Mock<IOtpSender>();

            var service = new TwoFactorService(unitOfWork.Object, twoFactorRepo.Object, userRepo.Object, sender.Object);

            var code = service.GenerateOtpCode();

            Assert.Equal(6, code.Length);
            Assert.True(int.TryParse(code, out _));
        }

        [Fact]
        public async Task GenerateOtpAsync_ShouldSendOtpToProvider()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var twoFactorRepo = new Mock<IRepository<UserTwoFactorEntity>>();
            var userRepo = new Mock<IRepository<UserEntity>>();
            var sender = new Mock<IOtpSender>();

            userRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync(new UserEntity { Id = 1, Email = "test@example.com", PhoneNumber = "1234567890" });

            var service = new TwoFactorService(unitOfWork.Object, twoFactorRepo.Object, userRepo.Object, sender.Object);

            var result = await service.GenerateOtpAsync(1, "Email");

            Assert.True(result.IsSuccess);
            sender.Verify(s => s.SendOtpAsync("Email", "test@example.com", It.IsAny<string>()), Times.Once);
            twoFactorRepo.Verify(r => r.AddAsync(It.IsAny<UserTwoFactorEntity>()), Times.Once);
            unitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        }
    }
}

