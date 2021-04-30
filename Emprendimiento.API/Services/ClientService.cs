﻿using AutoMapper;
using Domain.Dto.Layer;
using Domain.Layer;
using Emprendimiento.API.Repositories;
using Shared.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Services
{
    public interface IClientService
    {
        Task<ServiceResponse> Get(int idClient);
        Task<ServiceResponse> GetAllByUser(int idUser);
        Task<ServiceResponse> GetAllByCompany(string name, int? idCompany, int idUser, int start, int length);

        Task<ServiceResponse> Save(SaveClientRequest rq);

        Task<ServiceResponse> Delete(int idClient);
    }
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryClient _repositoryClient;

        public ClientService(IRepositoryClient repositoryClient, IMapper mapper)
        {
            _repositoryClient = repositoryClient;
            _mapper = mapper;
        }

        #region GET

        public async Task<ServiceResponse> Get(int idClient)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<ClientDto>(await _repositoryClient.Get(idClient));
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetClient;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        public async Task<ServiceResponse> GetAllByUser(int idUser)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<IEnumerable<ClientDto>>(await _repositoryClient.GetAllByUser(idUser));
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetAllClientsByUser;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        public async Task<ServiceResponse> GetAllByCompany(string name, int? idCompany, int idUser, int start, int length)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<IEnumerable<ClientDto>>(await _repositoryClient.GetAllByCompany(idCompany.Value));
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetAllClientsByCompany;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        #endregion GET

        #region POST

        public async Task<ServiceResponse> Save(SaveClientRequest rq)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = await _repositoryClient.Save(_mapper.Map<Client>(rq));

                sr.AddSuccess(OKResponse.SaveClient);
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.SaveClient;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        #endregion POST

        #region PUT 

        public async Task<ServiceResponse> Delete(int idClient)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = await _repositoryClient.Delete(idClient);

                sr.AddSuccess(OKResponse.DeleteClient);
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.DeleteClient;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        #endregion PUT
    }
}