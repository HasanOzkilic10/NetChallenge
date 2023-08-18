using NetChallenge.Application.ServiceResults;
using NetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.Abstractions
{
    public interface ICompanyService
    {
        IDataResult<Company> GetById(int id);
        IResult Add(Company company);
        IResult Update(Company company);
        IResult UpdateForOrderConfirmationTime(int companyId , string orderConfirmationStartTime , string orderConfirmationFinishTime);
        IResult UpdateForApprovalStatus(int companyId , bool approvalStatus);
        IDataResult<List<Company>> GetAll();
    }
}
