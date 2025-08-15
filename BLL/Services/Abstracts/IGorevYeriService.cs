using BLL.DTOs;
using DAL.Entities.Concretes.Organizasyon;
using DAL.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstracts
{
    public interface IGorevYeriService
    {
        Task<ServiceResponse<GorevYeriDTO>> CreateAsync(GorevYeriDTO gorevYeriDto);
        Task<ServiceResponse<GorevYeriDTO?>> GetByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<GorevYeriDTO>>> GetAllAsync();
        Task<ServiceResponse<GorevYeriDTO?>> UpdateAsync(int id, GorevYeriDTO gorevYeriDto);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
        
        Task<ServiceResponse<IEnumerable<GorevYeriDTO>>> GetByConditionAsync(Func<GorevYeri, bool> predicate);
    }
}
