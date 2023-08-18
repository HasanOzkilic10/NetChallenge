using NetChallenge.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.Entities
{
    public class Company : BaseEntity
    {
        public Company()
        {
            Products = new List<Product>();
        }
        public string Name { get; set; }
        public bool ApprovalStatus { get; set; }
        public string OrderConfirmationStartTime { get; set; }            
        public string OrderConfirmationFinishTime { get; set; }   
        public List<Product> Products { get; set; }
        

    }
}
