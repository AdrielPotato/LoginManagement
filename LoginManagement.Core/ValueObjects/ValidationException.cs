using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace LoginManagement.Core.ValueObjects
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new List<string>();
        }

        public ValidationException(string message) : base(message)
        { }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures.Select(x => x.ErrorMessage).ToList();
        }

        public List<string> Errors { get; }
    }
}
