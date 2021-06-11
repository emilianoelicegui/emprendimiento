}using AutoMapper;
using Domain.Dto.Layer;
using Emprendimiento.API.Repositories;
using Shared.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Services
{
    public interface IPAymentService
    {
        Task<ServiceResponse> GetAllByCompany(string nombre, int idUser, int? idCompany, int start, int length);
    }
    public class PaymentService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryPayment _repositoryPayment;

        public PaymentService(IRepositoryPayment repositoryPayment, IMapper mapper)
        {
            _repositoryPayment = repositoryPayment;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> GetAllByCompany(string name, int idUser, int? idCompany, int start, int length)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<PaymentListDto>(await _repositoryPayment.GetAllByCompany(name, idUser, idCompany, start, length));
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetAllPaymentsByCompany;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }
    }
}
