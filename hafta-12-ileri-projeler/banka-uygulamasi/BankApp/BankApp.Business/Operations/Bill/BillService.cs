using BankApp.Business.Operations.Bill.Dtos;
using BankApp.Business.Type;
using BankApp.Data.Entities;
using BankApp.Data.Enums;
using BankApp.Data.Repositories;
using BankApp.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Bill
{
    public class BillService : IBillService
    {
        private readonly IRepository<BillEntity> _billRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AccountEntity> _accountRepository;
        private readonly IRepository<MoneyTransactionEntity> _transactionRepository;

        public BillService(IRepository<BillEntity> billRepository, IUnitOfWork  unitOfWork, IRepository<AccountEntity> accountRepository, IRepository<MoneyTransactionEntity> transactionRepository)
        {
            _unitOfWork = unitOfWork;
            _billRepository = billRepository;
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<ServiceMessage<int>> CreateBillAsync(CreateBillDto dto) // method beginning
        {
            var entity = new BillEntity
            {
                UserId = dto.UserId,
                BillType = dto.BillType,
                Amount = dto.Amount,
                DueDate = dto.DueDate,
                IsPaid = false,
                CreatedDate = DateTime.Now
            };

            await _billRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceMessage<int>
            {
                IsSuccess = true,
                Data = entity.Id
            };
        } // end of CreateBillAsync

        public async Task<ServiceMessage<List<InfoBillDto>>> GetAllBills(int id) // method beginning
        {
            var bills = await _billRepository.GetAll(x=>x.UserId == id)
                                             .Include(x => x.User)
                                             .OrderByDescending(x => x.DueDate)
                                             .Select(x => new InfoBillDto()
                                             {
                                                 Amount = x.Amount,
                                                 DueDate = x.DueDate,
                                                 BillType = x.BillType.ToString(),
                                                 Id = x.Id,
                                                 IsPaid = x.IsPaid,
                                                 PaymentDate = x.PaymentDate,
                                                 UserId = x.UserId,
                                                 FullName = x.User.FirstName + " " + x.User.LastName
                                             }).ToListAsync();
            if (!bills.Any())
            {
                return new ServiceMessage<List<InfoBillDto>>()
                {
                    IsSuccess = false,
                    Message = "fatura bulunamadı"
                };
            }

            return new ServiceMessage<List<InfoBillDto>>()
            {
                IsSuccess = true,
                Data = bills
            };
        }// end of GetAllBills

     

        public async Task<ServiceMessage<string>> PayBillAsync(int userId, PayBillDto dto) // method beginning
        {

            var bill = await _billRepository
                              .GetAll(x => x.Id == dto.BillId && x.UserId == userId && !x.IsPaid)
                              .FirstOrDefaultAsync();

            if (bill == null)
            {
                return new ServiceMessage<string>
                {
                    IsSuccess = false,
                    Message = "Fatura bulunamadı veya zaten ödenmiş."
                };
            }

            var account = await _accountRepository
                                  .GetAll(x => x.Id == dto.AccountId && x.UserId == userId)
                                  .FirstOrDefaultAsync();

            if (account == null)
            {
                return new ServiceMessage<string>
                {
                    IsSuccess = false,
                    Message = "Seçilen hesap bulunamadı veya aktif değil."
                };
            }

            if (account.Balance < bill.Amount)
            {
                return new ServiceMessage<string>
                {
                    IsSuccess = false,
                    Message = "Yetersiz bakiye."
                };
            }

            if (dto.Amount != bill.Amount)
            {
                return new ServiceMessage<string>
                {
                    IsSuccess = false,
                    Message = $"Fatura tutarı {bill.Amount} TL'dir. Lütfen tam tutarı giriniz."
                };
            }

            bill.IsPaid = true;
            bill.PaymentDate = DateTime.Now;

            account.Balance -= bill.Amount;

            var transaction = new MoneyTransactionEntity
            {
                SenderUserId = userId,
                SenderAccountId = account.Id,
                ReceiverUserId = null, 
                ReceiverAccountId = null,
                Amount = bill.Amount,
                Description = $"{bill.BillType} faturası ödemesi",
                TransactionType = TransactionType.BillPayment, 
                Timestamp = DateTime.Now
            };

            await _transactionRepository.AddAsync(transaction);

            await _unitOfWork.SaveChangesAsync();

            return new ServiceMessage<string>
            {
                IsSuccess = true,
                Data = $"Fatura başarıyla ödendi. Yeni bakiye: {account.Balance} TL"
            };
        } // end of PayBillAsync

    } // end of class BillServise
}
