using NetChallenge.Application.Abstractions;
using NetChallenge.Domain.Entities;
using NetChallenge.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Persistence.Concretes
{
    public class ProductRepository :  EntityRepository<Product , NetChallengeDbContext> , IProductRepository
    {
       
    }
}
