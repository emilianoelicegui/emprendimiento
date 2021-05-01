using AutoMapper;
using Domain.Dto.Layer;
using Emprendimiento.API.Repositories;
using Shared.Layer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emprendimiento.API.Services
{
    public interface IGenericService
    {
        Task<ServiceResponse> GetMenus(int idRol);
        Task<ServiceResponse> GetRol(int idRol);
        Task<ServiceResponse> GetRoles();
    }
    public class GenericService : IGenericService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryGeneric _repositoryGeneric;

        public GenericService(IRepositoryGeneric repositoryGeneric, IMapper mapper)
        {
            _repositoryGeneric = repositoryGeneric;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> GetMenus(int idrol)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<IEnumerable<MenuDto>>(await _repositoryGeneric.GetMenus(idrol));
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetMenu;
                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        public async Task<ServiceResponse> GetRol(int idRol)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<RolDto>(await _repositoryGeneric.GetRol(idRol));
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetRol;
                sr.AddErrorException(errCode, ex);
            }

            return sr;

        }

        public async Task<ServiceResponse> GetRoles()
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<IEnumerable<RolDto>>(await _repositoryGeneric.GetRoles());
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetRoles;
                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }
    }
}
