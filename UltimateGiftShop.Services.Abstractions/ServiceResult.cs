using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace UltimateGiftShop.Services.Abstractions
{
    public class ServiceResult<T>
    {
        public bool HasError { get; }
        public ErrorMessage ErrorMessage { get; }
        public Exception InnerException { get; }
        public T Data { get; }
        public bool Exists { get; }

        public ServiceResult(T deserialized, bool exists = false ,bool hasError = false, ErrorMessage error = null,
            Exception innerException = null)
        {
            Data = deserialized;
            HasError = hasError;
            ErrorMessage = error;
            InnerException = innerException;
            Exists = exists;
        }

        public static ServiceResult<T> Failed(ErrorMessage error = null, Exception innerException = null) => new(default(T), false,true, error, innerException);
    }
}
