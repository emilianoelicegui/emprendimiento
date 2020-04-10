using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Layer.Dto
{
    public interface IServiceResponse
    {
        List<ServiceError> Errors { get; set; }
        int ReturnValue { get; set; }
        string ReturnCode { get; set; }
        string ReturnName { get; set; }
        bool Status { get; }
        string WarningMessage { get; set; }
    }

    public interface IServiceResponse<T> : IServiceResponse
    {
        T Data { get; set; }
    }

    public class ServiceResponse : ServiceResponse<object>
    {
    }

    public class ServiceResponse<T> : IServiceResponse<T>
    {
        #region Constructors

        public ServiceResponse()
        {
            Errors = new List<ServiceError>();
            ReturnValue = 0;
            ReturnCode = "";
            ReturnName = "";
        }

        public ServiceResponse(ServiceResponse sr)
        {
            Errors = sr.Errors;
            ReturnCode = sr.ReturnCode;
            ReturnName = sr.ReturnName;
            WarningMessage = sr.WarningMessage;
        }

        public ServiceResponse(T data) : this()
        {
            Data = data;
        }

        #endregion

        #region Properties

        public int ReturnValue { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnName { get; set; }
        public string WarningMessage { get; set; }
        public string SuccessMessage { get; set; }
        public T Data { get; set; }
        public List<ServiceError> Errors { get; set; }

        public bool Status
        {
            get { return (!Errors.Any(x => x.ErrorLevel == ServiceErrorLevel.VALIDATION_ERROR || x.ErrorLevel == ServiceErrorLevel.EXCEPTION)); }
        }

        #endregion

        #region Methods

        public void AddWarning(string warningMessage)
        {
            WarningMessage = warningMessage;
        }

        public void AddError(Exception ex)
        {
            Errors.Add(new ServiceError(ex));
        }

        public void AddError(string errorMessage)
        {
            Errors.Add(new ServiceError(errorMessage));
        }

        public void AddError(string errorCode, string errorMessage)
        {
            Errors.Add(new ServiceError(errorCode, errorMessage));
        }

        public void AddError(string errorCode, string errorMessage, ServiceErrorLevel errorLevel)
        {
            Errors.Add(new ServiceError(errorCode, errorMessage, errorLevel));
        }

        public void AddError(ServiceError serviceError)
        {
            Errors.Add(serviceError);
        }

        public void AddErrors(List<ServiceError> serviceErrorList)
        {
            foreach (var e in serviceErrorList)
                Errors.Add(e);
        }

        public void AddErrors(List<string> serviceErrorList)
        {
            foreach (var e in serviceErrorList)
                AddError(e);
        }

        public override string ToString()
        {
            var rsp = "";

            rsp += $"Status: {Status}";
            rsp += $"\nData: {Data}";
            rsp += $"\nReturn Code: {ReturnCode}";
            rsp += $"\nReturn Name: {ReturnName}";
            rsp += $"\nErrors:\n";

            foreach (var error in Errors)
                rsp += $"  >{error.ErrorMessage} / {error.ErrorDetail}";

            rsp += "\n";

            return rsp;
        }

        #endregion
    }
}
