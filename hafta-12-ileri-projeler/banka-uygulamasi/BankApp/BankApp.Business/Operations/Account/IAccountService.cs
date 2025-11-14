using BankApp.Business.Operations.Account.Dtos;
using BankApp.Business.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Account
{
    public interface IAccountService
    {
        Task<ServiceMessage<AccountListDto>> AllAccountAsync(int userId);

        Task<ServiceMessage<AccountBalanceDto>> GetBalanceAsync(int id, int userId);

        Task<ServiceMessage<List<TransactionListDto>>> GetUserTransactionsAsync(int userId);

        Task<ServiceMessage<AccountInfoDto>> AddAccountAsync(int id ,AccountInfoDto request);

        Task<ServiceMessage<TransferResultDto>> TransferAsync(TransferRequestDto request);

        Task<ServiceMessage<TransferResultDto>> DepositAsync(DepositRequestDto request);

        Task<ServiceMessage> DeleteAccountAsync(int id, int userId);


    }
}
