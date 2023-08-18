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
    public class OrderManager : IOrderService
    {
        IOrderRepository _orderRepository;
        ICompanyService _companyService;
        IProductService _productService;
       
        public OrderManager(IOrderRepository orderRepository, ICompanyService companyService, IProductService productService)
        {
            _orderRepository = orderRepository;
            _companyService = companyService;
            _productService = productService;
        }

        public IResult Add(Order order)
        {
          int productId =  order.Product == null ? order.ProductId : order.Product.Id;
           Product product =  _productService.GetProduct(productId).Result;
            if (CompanyApprovalStatusControl(product.CompanyId))
            {
                if (CompanyOrderConfirmationTimeControl(product.CompanyId))
                {
                    _orderRepository.Add(order);    
                    return new Result(true);
                }
                else
                {
                    return new Result(false , "Bu firma şuan sipariş almıyor");
                }
            }
            else
            {
                return new Result(false, "Bu firma onaylı değil");
            }
           
        }

        bool CompanyApprovalStatusControl(int companyId)
        {
            Company company = _companyService.GetById(companyId).Result;
            return company.ApprovalStatus;
        }

        bool CompanyOrderConfirmationTimeControl(int companyId)
        {
            Company company = _companyService.GetById(companyId).Result;
            string[] startTimeItems = company.OrderConfirmationStartTime.Split(".");
            string[] finishTimeItems = company.OrderConfirmationFinishTime.Split(".");
            int startTimeHour  = 0 , startTimeMinute  =  0 ,finishTimeHour = 0, finishTimeMinute  = 0;
            for (int i = 0; i < startTimeItems.Length; i++)
            {
                if (i == 0)
                {
                    startTimeHour = int.Parse(startTimeItems[i]);
                }
                else if (i == 1)
                {
                   startTimeMinute = int.Parse(startTimeItems[i]);
                }
            }

            for (int i = 0; i < finishTimeItems.Length; i++)
            {
                if (i == 0)
                {
                    finishTimeHour = int.Parse(finishTimeItems[i]);
                }
                else if (i == 1)
                {
                    finishTimeMinute = int.Parse(finishTimeItems[i]);
                }
            }



            DateTime companyOrderConfirmationStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTimeHour, startTimeMinute, 0);
            DateTime companyOrderConfirmationFinishTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, finishTimeHour, finishTimeMinute, 0);

            if (DateTime.Compare(DateTime.Now , companyOrderConfirmationStartTime) >= 0 && DateTime.Compare(DateTime.Now, companyOrderConfirmationFinishTime) <=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
