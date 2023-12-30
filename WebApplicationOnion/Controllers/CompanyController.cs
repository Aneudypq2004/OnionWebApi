using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace WebApplicationOnion.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager service;

        public CompaniesController(IServiceManager service)
        {
            this.service = service;
        }

        [HttpGet(Name = "GetCompanies")]
        public ActionResult GetAllCompanies()
        {
            var companies = service.CompanyService.GetCompanies(tranckChanges: false);
            return Ok(companies);
        }


        [HttpGet("{Id:Guid}", Name = "GetCompany")]
        public ActionResult GetCompany(Guid Id)
        {
            var company = service.CompanyService.GetCompany(Id, tranckChanges: false);
            return Ok(company);
        }

        [HttpPost(Name = "CreateCompany")]
        public IActionResult CreateCompany([FromBody] CompanyForCreacionDto company)
        {
            if (company == null)
            {
                return BadRequest(new { msg = "The company data is required" });
            }

            var companyDto = service.CompanyService.CreateCompany(company);


            return CreatedAtRoute("GetCompany", new { companyDto.Id }, companyDto);

        }

        [HttpDelete("{Id}")]
        public ActionResult DeleteCompany(Guid Id)
        {

            if (service.CompanyService.DeleteCompany(Id))
            {
                return Ok(new { msg = $"The company with id = {Id} was deleted" });
            }

            return BadRequest(new { msg = "The company doesnt existe" });

        }

    }
}
