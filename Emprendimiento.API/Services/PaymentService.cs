using AutoMapper;
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
    public interface IPaymentService
    {
        Task<ServiceResponse> Save(SavePaymentRequest rq);
        Task<ServiceResponse> GetAllByCompany(string name, int idUser, int? idCompany, int start, int length);
    }
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryPayment _repositoryPayment;

        public PaymentService(IRepositoryPayment repositoryPayment, IMapper mapper)
        {
            _repositoryPayment = repositoryPayment;
            _mapper = mapper;
        }

        #region POST 
        public async Task<ServiceResponse> Save(SavePaymentRequest rq)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = await _repositoryPayment.Save(_mapper.Map<Payment>(rq));

                sr.AddSuccess(OKResponse.SavePayment);
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.SavePayment;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }
        #endregion

        public async Task<ServiceResponse> GetAllByCompany(string name, int idUser, int? idCompany, int start, int length)
        {
            var sr = new ServiceResponse();

            try
            {
                var results = _mapper.Map<IEnumerable<PaymentListDto>>(await _repositoryPayment.GetAllByCompany(name, idUser, idCompany, start, length));

                sr.Data = new
                {
                    recordsTotal = results.Count(),
                    recordsFiltered = results.Count(),
                    data = results
                };
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
