using Microsoft.EntityFrameworkCore;
using OnlineShoppingApp.Data.Entities;
using OnlineShoppingApp.Data.Repositories;
using OnlineShoppingApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Settings
{
    public class SettingManager : ISettingService
    {
        private readonly IRepository<SettingEntity> _settingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SettingManager(IRepository<SettingEntity> settingRepository, IUnitOfWork unitOfWork)
        {
            _settingRepository = settingRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> GetMaintenanceStateAsync()
        {
            var maintanenceState = await _settingRepository.GetAll()
                .Select(s => s.MaintenanceMode)
                .FirstOrDefaultAsync();
            return maintanenceState;
        }

        public async Task ToggleMaintenanceAsync()
        {
            var setting = await _settingRepository.GetByIdAsync(1);
            setting.MaintenanceMode = !setting.MaintenanceMode; // Toggle the current maintenance mode
           await _settingRepository.UpdateAsync(setting);
            await _unitOfWork.SaveChangesAsync();
        }
    } // SettingServise done
}
