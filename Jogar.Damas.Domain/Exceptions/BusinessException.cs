using System;
using System.Collections.Generic;
using System.Text;

namespace Jogar.Damas.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public List<BrokenRule> Errors { get; protected set; }

        public BusinessException(string message) : base(message)
        {

        }

        public BusinessException(List<BrokenRule> errors, string message) : base(message)
        {
            Errors = errors;
        }
    }
}
