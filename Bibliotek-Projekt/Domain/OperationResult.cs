using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OperationResult<T>
    {
        public bool IsSuccesfull {  get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }
        public string ErrorMessage { get; private set; }
        private OperationResult(bool isSuccesfull,T data, string message, string errorMessage)
        {
            IsSuccesfull = isSuccesfull;
            Message = message;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public static OperationResult<T> Successfull(T data, string message = "Operation Succesfull")
        {
            return new OperationResult<T> (true, data, message, null);
        }
        
        public static OperationResult<T> Failure(string errorMessage , string message = "Operation Failed")
        {
            return new OperationResult<T> (false, default ,message, errorMessage);
        }
    }
}
