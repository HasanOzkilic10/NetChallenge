using NetChallenge.Application.ServiceResults;
using NetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.Abstractions
{
    public interface IProductService
    {
        IResult Add(Product product);
        IDataResult<Product> GetProduct(int productId);
    }
}
