using NetChallenge.Application.Abstractions;
using NetChallenge.Application.ServiceResults;
using NetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Persistence.Concretes
{
    public class ProductManager : IProductService
    {
        IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IResult Add(Product product)
        {
          
            _productRepository.Add(product);
            return new Result(true);
              
        }

        public IDataResult<Product> GetProduct(int productId)
        {
           Product product =  _productRepository.GetById(p => p.Id == productId);
            return new DataResult<Product>(product, true);
        }
    }
}
