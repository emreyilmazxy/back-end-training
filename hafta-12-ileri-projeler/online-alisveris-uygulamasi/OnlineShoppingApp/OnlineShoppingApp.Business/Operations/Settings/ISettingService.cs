using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Settings
{
    public interface ISettingService
    {
        Task ToggleMaintenanceAsync(); // Switches the maintenance mode on or off

        Task<bool> GetMaintenanceStateAsync(); // Retrieves the current maintenance mode state
    }// ISettingService interface done
}
