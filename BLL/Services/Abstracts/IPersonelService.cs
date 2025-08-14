using BLL.DTOs;
using DAL.Entities.Concretes;
using DAL.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstracts
{
    public interface IPersonelService
    {
        Task<ServiceResponse<PersonelDTO>> CreateAsync(PersonelDTO personelDto);
        Task<ServiceResponse<PersonelDTO?>> GetByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<PersonelDTO>>> GetAllAsync();
        Task<ServiceResponse<PersonelDTO?>> UpdateAsync(int id, PersonelDTO personelDto);
        Task<ServiceResponse<bool>> DeleteAsync(int id);

        Task<ServiceResponse<IEnumerable<PersonelDTO>>> GetByConditionAsync(Func<Personel, bool> predicate);
    }
}
