using BankApp.Business.Operations.User.Dtos;
using BankApp.Business.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.User
{
    public interface IUserService
    {
        Task<ServiceMessage<UserInfoDto>> RegisterAsync(RegisterDto request);

        Task<ServiceMessage<UserInfoDto>> GetUserIdAsync(int id);

        Task<ServiceMessage<UserInfoDto>> LoginUserAsync(LoginRequestDto request);

        Task<ServiceMessage> UpdateUserAsync(UserInfoDto userInfo);

        Task<ServiceMessage> DeleteUserIdAsync(int id);

        Task<ServiceMessage> PatchUserAsync(int id, UserPatchDto dto);

    } // end of interface IUserService
}
