using AutoMapper;
using BLL.DTOs;
using BLL.Services.Abstracts;
using DAL.Entities.Concretes;
using DAL.Entities.Concretes.Organizasyon;
using DAL.Entities.Utilities;
using DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concretes
{
    public class GorevYeriService : IGorevYeriService
    {

        private readonly IBaseRepository<GorevYeri> _repository;
        private readonly IMapper _mapper;

        public GorevYeriService(IBaseRepository<GorevYeri> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GorevYeriDTO>> CreateAsync(GorevYeriDTO gorevYeriDto)
        {
            var response = new ServiceResponse<GorevYeriDTO>();
            try
            {
                var entity = _mapper.Map<GorevYeri>(gorevYeriDto);
                var createdEntity = await _repository.AddAsync(entity);
                response.Data = _mapper.Map<GorevYeriDTO>(createdEntity);
                response.StatusMessage = "Görevyeri created successfully.";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.StatusMessage = $"Error creating görevyeri: {ex.Message}";
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var deleted = await _repository.DeleteAsync(id);
                if (deleted == null)
                {
                    response.StatusMessage = "Görevyeri bulunamadı yada silinemiyor.";
                    response.Success = false;
                    response.Data = false;
                    return response;
                }
                response.StatusMessage = "Görevyeri silindi.";
                response.Success = true;
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.StatusMessage = $"Error deleting görevyeri: {ex.Message}";
                response.Success = false;
                response.Data = false;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GorevYeriDTO>>> GetAllAsync()
        {
            var response = new ServiceResponse<IEnumerable<GorevYeriDTO>>();
            try
            {
                var entities = await _repository.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<GorevYeriDTO>>(entities);
                response.StatusMessage = "Görevyeri list retrieved successfully.";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.StatusMessage = $"Error retrieving görevyeri list: {ex.Message}";
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GorevYeriDTO>>> GetByConditionAsync(Func<GorevYeri, bool> predicate)
        {
            var response = new ServiceResponse<IEnumerable<GorevYeriDTO>>();

            try
            {

                var entities = (await _repository.GetAllAsync()).Where(predicate);

                if (!entities.Any())
                {
                    response.Data = Enumerable.Empty<GorevYeriDTO>();
                    response.Success = false;
                    response.StatusMessage = "No Görevyeri found matching the condition.";
                    return response;
                }

                response.Data = _mapper.Map<IEnumerable<GorevYeriDTO>>(entities);
                response.Success = true;
                response.StatusMessage = "GörevYeri retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Data = Enumerable.Empty<GorevYeriDTO>();
                response.Success = false;
                response.StatusMessage = $"Error retrieving GörevYeri by condition: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<GorevYeriDTO?>> GetByIdAsync(int id)
        {
            var response = new ServiceResponse<GorevYeriDTO?>();
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                {
                    response.StatusMessage = "GörevYeri not found.";
                    response.Success = false;
                    response.Data = null;
                    return response;
                }
                response.Data = _mapper.Map<GorevYeriDTO>(entity);
                response.StatusMessage = "GörevYeri  retrieved successfully.";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.StatusMessage = $"Error retrieving personel: {ex.Message}";
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<GorevYeriDTO?>> UpdateAsync(int id, GorevYeriDTO gorevYeriDto)
        {
            var response = new ServiceResponse<GorevYeriDTO>();
            try
            {
                var existingEntity = await _repository.GetByIdAsync(id);
                if (existingEntity == null)
                {
                    response.StatusMessage = "GörevYeri not found.";
                    response.Success = false;
                    response.Data = null;
                    return response;
                }

                _mapper.Map(gorevYeriDto, existingEntity);
                var updatedEntity = await _repository.UpdateAsync(existingEntity);
                response.Data = _mapper.Map<GorevYeriDTO>(updatedEntity);
                response.StatusMessage = "GörevYeri updated successfully.";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.StatusMessage = $"Error updating GörevYeri: {ex.Message}";
                response.Success = false;
            }
            return response;
        }
    }
}
