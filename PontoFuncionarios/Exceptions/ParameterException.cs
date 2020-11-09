using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoFuncionarios.Exceptions
{
    public class ParameterException : Exception
    {
        public new string Message { get; set; }
        public ParameterException(string message)
        {
            Message = message;
        }
    }
}
