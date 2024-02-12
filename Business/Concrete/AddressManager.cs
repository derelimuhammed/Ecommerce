using AutoMapper;
using Business.Abstarct;
using Business.Constants;
using Business.DTOs;
using Business.ValidationRules.FluentValidation.AdressValidator;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions;
using Core.Ultilities.Responses.Abstract;
using Core.Ultilities.Responses.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private IAddressRepository _addressRepository;
        private IHttpContextAccessor _httpContextAccessor;
        private IMapper _mapper;
        public AddressManager(IAddressRepository addressRepository,IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IResponse> GetByIdAsync(Guid id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            if (address == null)
            {
                throw new ApiException(404, Messages.NotFound);
            }
            return new DataResponse<Address>(address, 200);
        }

        public async Task<IResponse> GetAllAsync()
        {
            var addresses = await _addressRepository.GetAllAsync();
            return new DataResponse<IEnumerable<Address>>(addresses, 200);
        }

        public async Task<IResponse> GetUserAddresses()
        {
            string userid = _httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var addresses = await _addressRepository.GetAllAsync(x=>x.UserId==Guid.Parse(userid));
            return new DataResponse<IEnumerable<Address>>(addresses, 200);
        }
        [ValidationAspect(typeof(AddAddressValidator))]
        public async Task<IResponse> AddAsync(AddressDTO model)
        {
            string? userid = _httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var address = _mapper.Map<Address>(model);
            address.UserId =Guid.Parse(userid);
            var addedaddress = await _addressRepository.AddAsync(address);
            return new DataResponse<Address>(addedaddress, 200, Messages.AddedSuccesfully);
        }
        [ValidationAspect(typeof(UpdateAddressValidator))]
        public async Task<IResponse> UpdateAsync(AddressDTO model)
        {
            var address = await _addressRepository.GetByIdAsync(model.Id);
            if (address == null)
            {
                throw new ApiException(404, Messages.NotFound);
            }
            var updatedaddress = _mapper.Map(model, address);
            await _addressRepository.UpdateAsync(updatedaddress);
            return new SuccessResponse(204, Messages.UpdatedSuccessfully);
        }

        public async Task<IResponse> RemoveAsync(Guid id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            if (address == null)
            {
                throw new ApiException(404, Messages.NotFound);
            }
            await _addressRepository.RemoveAsync(address);
            return new SuccessResponse(200, Messages.DeletedSuccessfully);
        }
    }
}
