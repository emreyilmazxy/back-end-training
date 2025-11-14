using BankApp.Data.Entities;
using BankApp.Data.Repositories;
using BankApp.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Setting
{
    public class SettingService : ISettingService
    {
        private readonly IRepository<SettingEntity> _settingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SettingService(IUnitOfWork unitOfWork, IRepository<SettingEntity> settingRepository)
        {
            _unitOfWork = unitOfWork;
            _settingRepository = settingRepository;
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
    }
}
