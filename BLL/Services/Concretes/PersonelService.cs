using AutoMapper;
using BLL.DTOs;
using BLL.Services.Abstracts;
using DAL.Entities.Concretes;
using DAL.Entities.Utilities;
using DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concretes
{
    public class PersonelService : IPersonelService
    {
        private readonly IBaseRepository<Personel> _repository;
        private readonly IMapper _mapper;
        public PersonelService(IBaseRepository<Personel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
       

        public async Task<ServiceResponse<PersonelDTO>> CreateAsync(PersonelDTO personelDto)
        {
            var response = new ServiceResponse<PersonelDTO>();
            try
            {
                var entity = _mapper.Map<Personel>(personelDto);
                var createdEntity = await _repository.AddAsync(entity);
                response.Data = _mapper.Map<PersonelDTO>(createdEntity);
                response.StatusMessage = "Personel created successfully.";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.StatusMessage = $"Error creating personel: {ex.Message}";
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var deleted = await  _repository.DeleteAsync(id);
                if (deleted == null)
                {
                    response.StatusMessage = "Personel bulunamadı yada silinemiyor.";
                    response.Success = false;
                    response.Data = false;
                    return response;
                }
                response.StatusMessage = "Personel silindi.";
                response.Success = true;
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.StatusMessage = $"Error deleting personel: {ex.Message}";
                response.Success = false;
                response.Data = false;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<PersonelDTO>>> GetAllAsync()
        {
            var response = new ServiceResponse<IEnumerable<PersonelDTO>>();
            try
            {
                var entities = await _repository.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<PersonelDTO>>(entities);
                response.StatusMessage = "Personel list retrieved successfully.";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.StatusMessage = $"Error retrieving personel list: {ex.Message}";
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<PersonelDTO>>> GetByConditionAsync(Func<Personel, bool> predicate)
        {
            var response = new ServiceResponse<IEnumerable<PersonelDTO>>();

            try
            {
                
                var entities = (await _repository.GetAllAsync()).Where(predicate);

                if (!entities.Any())
                {
                    response.Data = Enumerable.Empty<PersonelDTO>();
                    response.Success = false;
                    response.StatusMessage = "No personel found matching the condition.";
                    return response;
                }

                response.Data = _mapper.Map<IEnumerable<PersonelDTO>>(entities);
                response.Success = true;
                response.StatusMessage = "Personel retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Data = Enumerable.Empty<PersonelDTO>();
                response.Success = false;
                response.StatusMessage = $"Error retrieving personel by condition: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<PersonelDTO?>> GetByIdAsync(int id)
        {
            var response = new ServiceResponse<PersonelDTO?>();
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                {
                    response.StatusMessage = "Personel not found.";
                    response.Success = false;
                    response.Data = null;
                    return response;
                }
                response.Data = _mapper.Map<PersonelDTO>(entity);
                response.StatusMessage = "Personel retrieved successfully.";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.StatusMessage = $"Error retrieving personel: {ex.Message}";
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<PersonelDTO?>> UpdateAsync(int id, PersonelDTO personelDto)
        {
            var response = new ServiceResponse<PersonelDTO?>();
            try
            {
                var existingEntity = await _repository.GetByIdAsync(id);
                if (existingEntity == null)
                {
                    response.StatusMessage = "Personel not found.";
                    response.Success = false;
                    response.Data = null;
                    return response;
                }

                _mapper.Map(personelDto, existingEntity);
                var updatedEntity = await _repository.UpdateAsync(existingEntity);
                response.Data = _mapper.Map<PersonelDTO>(updatedEntity);
                response.StatusMessage = "Personel updated successfully.";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.StatusMessage = $"Error updating personel: {ex.Message}";
                response.Success = false;
            }
            return response;
        }
    }
}
