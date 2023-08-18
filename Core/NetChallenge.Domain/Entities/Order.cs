using NetChallenge.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.Entities
{
    public class Order : BaseEntity
    {
        
       // public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public string NameOfThePersonPlacingTheOrder { get; set; }  
        public DateTime OrderDate { get; set; } 
        //public Company Company { get; set; }
        public Product Product { get; set; }
    }
}
