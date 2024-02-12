using AutoMapper;
using Business.Abstarct;
using Business.Constants;
using Business.DTOs;
using Business.ValidationRules.FluentValidation.OptionValueValidators;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions;
using Core.Ultilities.Responses.Abstract;
using Core.Ultilities.Responses.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OptionValueManager : IOptionValueService
    {
        private IOptionValueRepository _optionValueRepository;
        private IMapper _mapper;
        public OptionValueManager(IOptionValueRepository optionValueRepository, IMapper mapper)
        {
            _optionValueRepository = optionValueRepository;
            _mapper = mapper;
        }

        public async Task<IResponse> GetByIdAsync(Guid id)
        {
            var optionvalue = await _optionValueRepository.GetByIdAsync(id);
            if (optionvalue == null)
            {
                throw new ApiException(404, Messages.NotFound);
            }
            return new DataResponse<OptionValue>(optionvalue, 200);
        }

        public async Task<IResponse> GetAllAsync()
        {
            var optionvalues = await _optionValueRepository.GetAllAsync();
            return new DataResponse<IEnumerable<OptionValue>>(optionvalues, 200);
        }

        [ValidationAspect(typeof(AddOptionValueValidator))]
        public async Task<IResponse> AddAsync(OptionValueDTO model)
        {
            var optionvalue = _mapper.Map<OptionValue>(model);
            var addedoptionvalue = await _optionValueRepository.AddAsync(optionvalue);
            return new DataResponse<OptionValue>(addedoptionvalue, 200, Messages.AddedSuccesfully);
        }

        [ValidationAspect(typeof(UpdateOptionValueValidator))]
        public async Task<IResponse> UpdateAsync(OptionValueDTO model)
        {
            var optionvalue = await _optionValueRepository.GetByIdAsync(model.Id);
            if (optionvalue == null)
            {
                throw new ApiException(404, Messages.NotFound);
            }
            var updatedoptionvalue = _mapper.Map(model, optionvalue);
            await _optionValueRepository.UpdateAsync(updatedoptionvalue);
            return new SuccessResponse(204, Messages.UpdatedSuccessfully);
        }

        public async Task<IResponse> RemoveAsync(Guid id)
        {
            var optionvalue = await _optionValueRepository.GetByIdAsync(id);
            if (optionvalue == null)
            {
                throw new ApiException(404, Messages.NotFound);
            }
            await _optionValueRepository.RemoveAsync(optionvalue);
            return new SuccessResponse(200, Messages.DeletedSuccessfully);
        }

        public async Task<IResponse> GetOptionValuesWithOption()
        {
            var optionvalueswithoption = await _optionValueRepository.GetOptionValuesWithOption();
            var mappedoptionvalueswithoption = _mapper.Map<IEnumerable<OptionValuesWithOptionDTO>>(optionvalueswithoption);
            return new DataResponse<IEnumerable<OptionValuesWithOptionDTO>>(mappedoptionvalueswithoption, 200);
        }

        public async Task<IResponse> GetOptionValuesByProductOptionIdAsync(Guid optionid)
        {
            var optionvaluesbyoptionid = await _optionValueRepository.GetOptionValuesByOptionIdAsync(optionid);
            if (optionvaluesbyoptionid == null)
            {
                throw new ApiException(404, Messages.NotFound);
            }
            var mappedoptionvaluesbyoptionid = _mapper.Map<IEnumerable<OptionValue>>(optionvaluesbyoptionid);
            return new DataResponse<IEnumerable<OptionValue>>(mappedoptionvaluesbyoptionid, 200);
        }
    }
}
