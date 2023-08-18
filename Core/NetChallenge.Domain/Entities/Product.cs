using NetChallenge.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Orders = new List<Order>();
        }
        public int CompanyId { get; set; }  
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public int UnitPrice { get; set; }
        public Company Company { get; set; }
        public List<Order> Orders { get; set;}

    }
}
