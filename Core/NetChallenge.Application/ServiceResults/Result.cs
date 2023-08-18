using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.ServiceResults
{
    public class Result : IResult
    {
        public string Message { get; }

        public bool IsSuccess { get; }

        public Result(bool isSuccess)
        {
            IsSuccess= isSuccess;
        }
        public Result(bool isSuccess , string message) :this(isSuccess)
        {
            Message= message;
        }
    }
}
