using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Layer.Dto
{
    public class ServiceError
    {
        public ServiceError()
        {
        }

        public ServiceError(Exception ex)
        {
            var finalException = ex;

            if (ex.InnerException != null)
                finalException = ex.InnerException;

            ErrorMessage = finalException.Message;
            ErrorDetail = finalException.ToString();
            ErrorLevel = ServiceErrorLevel.EXCEPTION;
            ErrorCode = "";
        }

        public ServiceError(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ErrorLevel = ServiceErrorLevel.VALIDATION_ERROR;
            ErrorCode = "N/A";
        }

        public ServiceError(string errorCode, string errorMessage)
        {
            ErrorMessage = errorMessage;
            ErrorLevel = ServiceErrorLevel.VALIDATION_ERROR;
            ErrorCode = errorCode;
        }

        public ServiceError(string errorCode, string errorMessage, ServiceErrorLevel errorLevel)
        {
            ErrorMessage = errorMessage;
            ErrorLevel = errorLevel;
            ErrorCode = errorCode;
        }

        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetail { get; set; }
        public ServiceErrorLevel ErrorLevel { get; set; }
    }

    public enum ServiceErrorLevel
    {
        VALIDATION_ERROR,
        VALIDATION_WARNING,
        EXCEPTION
    }
}
