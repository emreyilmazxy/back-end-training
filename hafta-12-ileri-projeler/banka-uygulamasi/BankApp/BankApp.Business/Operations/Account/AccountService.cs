using BankApp.Business.Helpers;
using BankApp.Business.Operations.Account.Dtos;
using BankApp.Business.Type;
using BankApp.Data.Entities;
using BankApp.Data.Enums;
using BankApp.Data.Repositories;
using BankApp.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Account
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AccountEntity> _repository;
        private readonly IRepository<MoneyTransactionEntity> _transactionRepository;
        private readonly IRepository<UserEntity> _userRepository;
        public AccountService(IRepository<AccountEntity> repository, IUnitOfWork unitOfWork, IRepository<MoneyTransactionEntity> transactionRepo, IRepository<UserEntity> userRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _transactionRepository = transactionRepo;
            _userRepository = userRepository;
        }

        public async Task<ServiceMessage<AccountInfoDto>> AddAccountAsync(int userId, AccountInfoDto request) // method beginning
        {
            var userExists = await _userRepository.AnyAsync(x => x.Id == userId);
            if (!userExists)
            {
                return new ServiceMessage<AccountInfoDto>
                {
                    IsSuccess = false,
                    Message = "Kullanıcı bulunamadı"
                };
            }

            // uniq generate account number 
            string newAccountNumber;
            do
            {
                newAccountNumber = AccountRandomNumber.GenerateRandomNumber(24); // Örn: TR1234567890
            }
            while (await _repository.AnyAsync(x => x.AccountNumber == newAccountNumber));


            var newAccount = new AccountEntity
            {
                UserId = userId,
                AccountNumber = newAccountNumber,
                Currency = request.Currency,
                Balance = 0
            };

            await _repository.AddAsync(newAccount);
            await _unitOfWork.SaveChangesAsync();


            return new ServiceMessage<AccountInfoDto>
            {
                IsSuccess = true,
                Data = new AccountInfoDto
                {
                    Id = newAccount.Id,
                    UserId = newAccount.UserId,
                    AccountNumber = newAccount.AccountNumber,
                    Currency = newAccount.Currency,
                    Balance = newAccount.Balance,
                    CreatedDate = newAccount.CreatedDate,
                }
            };
        } // end of AddAcountAsync


        public async Task<ServiceMessage<AccountListDto>> AllAccountAsync(int userId) // method beginning
        {
            var accounts = await _repository.GetAll(x => x.UserId == userId)
                                            .Select(a => new AccountInfoDto()
                                            {
                                                Id = a.Id,
                                                UserId = a.UserId,
                                                AccountNumber = a.AccountNumber,
                                                Currency = a.Currency,
                                                CreatedDate = a.CreatedDate,
                                                Balance = a.Balance

                                            }).ToListAsync();
            if (!accounts.Any())
            {
                return new ServiceMessage<AccountListDto>
                {
                    IsSuccess = false,
                    Message = "Bu kullanıcıya ait hesap bulunamadı."
                };
            }

            return new ServiceMessage<AccountListDto>
            {
                IsSuccess = true,
                Data = new AccountListDto()
                {
                    UserId = userId,
                    Accounts = accounts
                }
            };
        } // end of AllAccountAsync

        public async Task<ServiceMessage> DeleteAccountAsync(int id, int userId) // method beginning
        {
            var account = await _repository.GetByIdAsync(id);
            if (account is null || account.UserId != userId)
            {
                return new ServiceMessage
                {
                    IsSuccess = false,
                    Message = account is null ? "hesap bulunamadı" : "Bu hesaba erişiminiz yok"
                };
            }

            await _repository.DeleteAsync(account);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceMessage
            {
                IsSuccess = true,
                Message = "hesap başarıyla silindi"
            };
        } // end of DeleteAccountAsync

        public async Task<ServiceMessage<TransferResultDto>> DepositAsync(DepositRequestDto request) // method beginning
        {

            var account = await _repository
                .GetAll(x => x.Id == request.AccountId && x.UserId == request.UserId)
                .Include(x => x.User)
                .FirstOrDefaultAsync();

            if (account == null)
            {
                return new ServiceMessage<TransferResultDto>
                {
                    IsSuccess = false,
                    Message = "Hesap bulunamadı veya bu hesaba erişiminiz yok."
                };
            }





            var transaction = new MoneyTransactionEntity
            {
                SenderUserId = null,
                ReceiverUserId = account.UserId,
                SenderAccountId = null,
                ReceiverAccountId = account.Id,
                Amount = request.Amount,
                Description = string.IsNullOrWhiteSpace(request.Description)
                                ? "Para yatırma"
                                : request.Description,
                Timestamp = DateTime.Now,
                TransactionType = TransactionType.Deposit,

            };

            await _transactionRepository.AddAsync(transaction);
            account.Balance += request.Amount;

            await _repository.UpdateAsync(account);

            await _unitOfWork.SaveChangesAsync();


            return new ServiceMessage<TransferResultDto>
            {
                IsSuccess = true,
                Data = new TransferResultDto
                {
                    SenderAccountId = 0,
                    ReceiverAccountId = account.Id,
                    Amount = request.Amount,
                    Currency = account.Currency,
                    Description = transaction.Description,
                    Timestamp = transaction.Timestamp,
                    SenderFullName = "Sistem",
                    ReceiverFullName = account.User.FirstName + " " + account.User.LastName
                }
            };
        } // end of depositAsync


        public async Task<ServiceMessage<AccountBalanceDto>> GetBalanceAsync(int id, int userId) // method Beginning
        {
            if (userId <= 0)
            {
                return new ServiceMessage<AccountBalanceDto>
                {
                    IsSuccess = false,
                    Message = "Kullanıcı doğrulanamadı."
                };
            }

            var userBalance = await _repository.GetAll(x => x.Id == id && x.UserId == userId)
                                                .Select(a => new AccountBalanceDto()
                                                {
                                                    AccountNumber = a.AccountNumber,
                                                    Balance = a.Balance
                                                }).FirstOrDefaultAsync();

            if (userBalance == null)
            {
                return new ServiceMessage<AccountBalanceDto>()
                {
                    IsSuccess = false,
                    Message = "hesap bulunamadı veya size ait değil"
                };
            }

            return new ServiceMessage<AccountBalanceDto>()
            {
                IsSuccess = true,
                Data = userBalance
            };
        } // end of GetBalanceAsync

        public async Task<ServiceMessage<List<TransactionListDto>>> GetUserTransactionsAsync(int userId) // method beginning
        {
            // Fetch all transactions where the user is either the sender or the receiver.
            // Includes related users and accounts for richer transaction info.
            var accountTransactions = await _transactionRepository
                .GetAll(x => x.SenderUserId == userId || x.ReceiverUserId == userId)
                .Include(x => x.SenderUser)
                .Include(x => x.ReceiverUser)
                .Include(x => x.SenderAccount)
                .Include(x => x.ReceiverAccount)
                .OrderByDescending(x => x.Timestamp)
                .Select(a => new TransactionListDto
                {
                    Id = a.Id,
                    Amount = a.Amount,
                    Currency = a.SenderAccount != null ? a.SenderAccount.Currency : "-", // Get currency from sender's account

                    TransactionType = a.TransactionType.ToString(),
                    Timestamp = a.Timestamp,
                    Description = a.Description,

                    // Full name of the sender, or "System" if null
                    SenderFullName = a.SenderUser != null
                                     ? a.SenderUser.FirstName + " " + a.SenderUser.LastName
                                     : "System",

                    // Full name of the receiver, or "System" if null
                    ReceiverFullName = a.ReceiverUser != null
                                     ? a.ReceiverUser.FirstName + " " + a.ReceiverUser.LastName
                                     : "System",

                    // Account number of the sender, or "-" if null (e.g. system-initiated transaction)
                    SenderAccountNumber = a.SenderAccount != null
                                     ? a.SenderAccount.AccountNumber
                                     : "-",

                    // Account number of the receiver, or "-" if null
                    ReceiverAccountNumber = a.ReceiverAccount != null
                                     ? a.ReceiverAccount.AccountNumber
                                     : "-",

                    // Indicates whether the current user was the sender
                    IsSender = a.SenderUserId == userId,

                    // Displays the full name of the "other party" in the transaction
                    OtherPartyFullName = a.SenderUserId == userId
                                        ? (a.ReceiverUser != null
                                            ? a.ReceiverUser.FirstName + " " + a.ReceiverUser.LastName
                                            : "System")
                                        : (a.SenderUser != null
                                            ? a.SenderUser.FirstName + " " + a.SenderUser.LastName
                                            : "System")
                })
                .ToListAsync();

            return new ServiceMessage<List<TransactionListDto>>()
            {
                IsSuccess = true,
                Data = accountTransactions
            };
        } // end of GetUserTransactionsAsync

        public async Task<ServiceMessage<TransferResultDto>> TransferAsync(TransferRequestDto request) // method beginning
        {
            //  Fetch sender account, including related User
            var sender = await _repository
                .GetAll(x => x.Id == request.SenderAccountId)
                .Include(x => x.User)
                .FirstOrDefaultAsync();

            if (sender == null)
            {
                return new ServiceMessage<TransferResultDto>
                {
                    IsSuccess = false,
                    Message = "gönderici hesabı bulunamadı"
                };
            }

            //  Prevent sending money to your own account
            if (sender.AccountNumber == request.ReceiverAccountNumber)
            {
                return new ServiceMessage<TransferResultDto>
                {
                    IsSuccess = false,
                    Message = "Kendi hesabınıza para gönderemezsiniz."
                };
            }

            //  Fetch receiver account by account number, including related User
            var receiver = await _repository
                .GetAll(x => x.AccountNumber == request.ReceiverAccountNumber)
                .Include(x => x.User)
                .FirstOrDefaultAsync();

            if (receiver == null)
            {
                return new ServiceMessage<TransferResultDto>
                {
                    IsSuccess = false,
                    Message = "Alıcı hesap bulunamadı."
                };
            }


            if (sender.Currency != receiver.Currency)
            {
                return new ServiceMessage<TransferResultDto>
                {
                    IsSuccess = false,
                    Message = "Hesaplar arasında para birimi uyuşmazlığı var."
                };
            }


            if (sender.Balance < request.Amount)
            {
                return new ServiceMessage<TransferResultDto>
                {
                    IsSuccess = false,
                    Message = "Yetersiz bakiye."
                };
            }

            // 6. Perform balance update
            sender.Balance -= request.Amount;
            receiver.Balance += request.Amount;

            // Create transaction record
            var transaction = new MoneyTransactionEntity
            {
                SenderUserId = sender.UserId,
                ReceiverUserId = receiver.UserId,
                SenderAccountId = sender.Id,
                ReceiverAccountId = receiver.Id,
                Amount = request.Amount,
                Description = request.Description,
                Timestamp = DateTime.Now,
                TransactionType = TransactionType.Transfer
            };

            await _repository.UpdateAsync(sender);
            await _repository.UpdateAsync(receiver);
            await _transactionRepository.AddAsync(transaction);
            await _unitOfWork.SaveChangesAsync();


            return new ServiceMessage<TransferResultDto>
            {
                IsSuccess = true,
                Data = new TransferResultDto
                {
                    SenderAccountId = sender.Id,
                    ReceiverAccountId = receiver.Id,
                    Amount = request.Amount,
                    Currency = sender.Currency,
                    Description = request.Description,
                    Timestamp = transaction.Timestamp,
                    SenderFullName = sender.User != null
                        ? sender.User.FirstName + " " + sender.User.LastName
                        : "System",
                    ReceiverFullName = receiver.User != null
                        ? receiver.User.FirstName + " " + receiver.User.LastName
                        : "System"
                }
            };
        }

    }// end of class AccountService
}