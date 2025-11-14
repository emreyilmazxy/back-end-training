using System.Threading.Tasks;
using BankApp.Business.Operations.Account;
using BankApp.Data.Entities;
using BankApp.Data.Repositories;
using BankApp.Data.UnitOfWork;
using Moq;
using Xunit;

namespace BankApp.Business.Tests
{
    public class AccountServiceTests
    {
        [Fact]
        public async Task DeleteAccountAsync_Should_Fail_When_UserIdDoesNotMatch()
        {
            var repository = new Mock<IRepository<AccountEntity>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var transactionRepository = new Mock<IRepository<MoneyTransactionEntity>>();
            var userRepository = new Mock<IRepository<UserEntity>>();

            repository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new AccountEntity { Id = 1, UserId = 1 });

            var service = new AccountService(repository.Object, unitOfWork.Object, transactionRepository.Object, userRepository.Object);

            var result = await service.DeleteAccountAsync(1, 2);

            Assert.False(result.IsSuccess);
            repository.Verify(r => r.DeleteAsync(It.IsAny<AccountEntity>()), Times.Never);
        }
    }
}
