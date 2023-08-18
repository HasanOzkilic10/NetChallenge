using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.ServiceResults
{
    public interface IResult
    {
        string Message { get; }
        bool IsSuccess { get; }
    }
}
