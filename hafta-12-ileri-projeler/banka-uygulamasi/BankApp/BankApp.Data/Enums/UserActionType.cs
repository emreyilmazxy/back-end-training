using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Enums
{
    public enum UserActionType
    {
        Login,
        Logout,
        PasswordChange,
        AccountViewed,
        BalanceViewed,
        TransactionsViewed,
        AccountCreated,
        TransferMade,
        DepositMade,
        AccountDeleted,
        ProfileUpdate,
        BillViewed,
        BillPaid,
        BillCreated,
        TwoFactorUpdated,

    }

}
