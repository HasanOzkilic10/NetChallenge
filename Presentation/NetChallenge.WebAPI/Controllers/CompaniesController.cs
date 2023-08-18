using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.Abstractions;
using NetChallenge.Domain.Entities;

namespace NetChallenge.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        ICompanyService _companyService;
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        [HttpPost("add")]
        public IActionResult Add(string companyName ,bool approvalStatus , string orderConfirmationStartTime , string orderConfirmationFinishTime) //View model kullanılabilir.
        {
            var company = new Company()
            {
                Name = companyName,
                ApprovalStatus = approvalStatus,
                OrderConfirmationStartTime = orderConfirmationStartTime,
                OrderConfirmationFinishTime = orderConfirmationFinishTime
            };
            var result = _companyService.Add(company);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updatefororderconfirmationtime")]
        public IActionResult UpdateForOrderConfirmationTime(int companyId , string orderConfirmationStartTime, string orderConfirmationFinishTime)
        {
            var result = _companyService.UpdateForOrderConfirmationTime(companyId, orderConfirmationStartTime, orderConfirmationFinishTime);
            if (result.IsSuccess)
            { 
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updateforapprovalstatus")]
        public IActionResult UpdateForApprovalStatus(int companyId, bool approvalStatus)
        {
            var result = _companyService.UpdateForApprovalStatus(companyId, approvalStatus);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _companyService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
