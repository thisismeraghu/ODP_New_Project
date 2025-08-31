using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<string> Errors { get; }

        public ValidationException(string message, IEnumerable<string> errors = null) : base(message)
        {
            Errors = errors ?? Array.Empty<string>();
        }
    }
}
