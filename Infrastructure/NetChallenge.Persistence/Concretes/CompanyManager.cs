using NetChallenge.Application.Abstractions;
using NetChallenge.Application.ServiceResults;
using NetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NetChallenge.Persistence.Concretes
{
    public class CompanyManager : ICompanyService
    {
        ICompanyRepository _companyRepository;
        public CompanyManager(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public IResult Add(Company company)
        {
            if (CompanyOrderTimeValuesValidation(company))
            {
                _companyRepository.Add(company);
                return new Result(true); //geri dönüş mesajları yazılabilir . Ürün başarılı bir şekilde eklendi gibi.
            }
            else
            {
                return new Result(false , "Lütfen doğru bir saat giriniz . Örneğin : 18.30");   
            }


         
          
        }

        public IDataResult<List<Company>> GetAll()
        {
            List<Company> getAllCompanies = _companyRepository.GetAll();
            return new DataResult<List<Company>>(getAllCompanies, true);
        }

        public IDataResult<Company> GetById(int id)
        {
            Company company = _companyRepository.GetById(c => c.Id == id);
            return new DataResult<Company>(company, true);
        }

        public IResult Update(Company company)
        {
            _companyRepository.Update(company);
            return new Result(true);
        }

        public IResult UpdateForApprovalStatus(int companyId, bool approvalStatus)
        {
            Company company = _companyRepository.GetById(c => c.Id == companyId);
            company.ApprovalStatus = approvalStatus;
            Update(company);
            return new Result(true);
        }

        public IResult UpdateForOrderConfirmationTime(int companyId, string orderConfirmationStartTime, string orderConfirmationFinishTime)
        {
            var companyCheck = new Company() { OrderConfirmationFinishTime = orderConfirmationFinishTime  , OrderConfirmationStartTime = orderConfirmationStartTime};

            if (CompanyOrderTimeValuesValidation(companyCheck))
            {
                Company company = _companyRepository.GetById(c => c.Id == companyId);
                company.OrderConfirmationStartTime = orderConfirmationStartTime;
                company.OrderConfirmationFinishTime = orderConfirmationFinishTime;
                Update(company);
                return new Result(true);
            }
            else
            {
                return new Result(false, "Lütfen doğru bir saat giriniz . Örneğin : 18.30");
            }


           
        }
        bool CompanyOrderTimeValuesValidation(Company company)
        {
            company.OrderConfirmationStartTime = company.OrderConfirmationStartTime.Trim();
            company.OrderConfirmationFinishTime = company.OrderConfirmationFinishTime.Trim();
            string[] times = company.OrderConfirmationStartTime.Split('.');
            if (times.Length == 2)
            {
                for (int i = 0; i < times.Length; i++)
                {
                   

                    if (!int.TryParse(times[i], out _))
                    {
                        return false;

                    }
                    else
                    {
                        if (i == 0)
                        {
                            if (!(0<=int.Parse(times[i]) && int.Parse(times[i])<24))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (!(0 <= int.Parse(times[i]) && int.Parse(times[i]) < 60))
                            {
                                return false;
                            }
                        }

                    }

                }
                return true;

            }
            else
            {
                return false;

            }
        }
    }
}
