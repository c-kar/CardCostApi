using AutoMapper;
using CardCost.Application.Interfaces;
using CardCost.Core.Models.Base;
using CardCost.Core.Entities;
using CardCost.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardCost.Application.Services
{
    public class CCMatrixService : ICCMatrixService
    {
        #region Fields

        private readonly ICCMatrixRepository _clearingCostRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public CCMatrixService(ICCMatrixRepository clearingCostRepository, IMapper mapper)
        {
            _clearingCostRepository = clearingCostRepository;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods

        public async Task<BaseModel> CreateClearingCost(BaseModel request)
        {
            var entity = _mapper.Map<Ccmatrix>(request);
            try
            {
                await _clearingCostRepository.AddAsync(entity);
                return request;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task DeleteClearingCost(int id)
        {
            var entity = await _clearingCostRepository.GetByIdAsync(id);
            if (entity != null)
                await _clearingCostRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Ccmatrix>> GetAllClearingCosts()
        {
            return await _clearingCostRepository.GetAllAsync();
        }

        public async Task<Ccmatrix> GetClearingCost(int id)
        {
            return await _clearingCostRepository.GetByIdAsync(id);
        }

        public async Task UpdateClearingCost(int id, BaseModel request)
        {
            var entity = await _clearingCostRepository.GetByIdAsync(id);
            if (entity != null)
            {
                var updatedEntity = _mapper.Map<Ccmatrix>(request);
                updatedEntity.Id = id;
                await _clearingCostRepository.UpdateAsync(updatedEntity);
            }
        }

        #endregion
    }
}
