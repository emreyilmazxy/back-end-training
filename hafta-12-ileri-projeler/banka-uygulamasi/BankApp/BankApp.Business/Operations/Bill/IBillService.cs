using BankApp.Business.Operations.Bill.Dtos;
using BankApp.Business.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Bill
{
    public interface IBillService
    {
        Task<ServiceMessage<List<InfoBillDto>>> GetAllBills(int id);

        Task<ServiceMessage<string>> PayBillAsync(int userId, PayBillDto dto);

        Task<ServiceMessage<int>> CreateBillAsync(CreateBillDto dto);
    } // end of interface
}
