using AutoMapper;
using Domain.Dto.Layer;
using Repositories.Layer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Layer
{
    public interface IGenericService
    {
        Task<ServiceResponse> GetMenu();
        Task<ServiceResponse> GetMenus(int IdUser);
        Task<ServiceResponse> GetRol(int idRol);
        ServiceResponse GetRoles();
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

        public async Task<ServiceResponse> GetMenu()
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<MenuDto>(await _repositoryGeneric.GetMenu());
            }
            catch (Exception ex)
            {
                sr.AddError(ex);
            }

            return sr;
        }

        public async Task<ServiceResponse> GetMenus(int iduser)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<IEnumerable<MenuDto>>(await _repositoryGeneric.GetMenus(iduser));
            }
            catch (Exception ex)
            {
                sr.AddError(ex);
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
                sr.AddError(ex);
            }

            return sr;

        }
        public ServiceResponse GetRoles()
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<IEnumerable<RolDto>>(_repositoryGeneric.GetRoles());
            }
            catch (Exception ex)
            {
                sr.AddError(ex);
            }

            return sr;
        }
    }
}
