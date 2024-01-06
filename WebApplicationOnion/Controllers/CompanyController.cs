using Domain.Models;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using WebApplicationOnion.ActionFilters;

namespace WebApplicationOnion.Controllers
{
    [ApiVersion("1.0")]
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
        public async Task<ActionResult> GetAllCompanies()
        {
            var companies = await service.CompanyService.GetAllCompaniesAsync(trackChanges: false);
            return Ok(companies);
        }


        [HttpGet("{Id:Guid}", Name = "GetCompany")]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
        [HttpCacheValidation(MustRevalidate = false)]

        public async Task<ActionResult> GetCompany(Guid Id)
        {
            var company = await service.CompanyService.GetCompanyAsync(Id, trackChanges: false);
            return Ok(company);
        }

        [HttpPost(Name = "CreateCompany")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
        {

            var companyDto = await service.CompanyService.CreateCompanyAsync(company);

            return CreatedAtRoute("GetCompany", new { companyDto.Id }, companyDto);

        }
        [HttpPut]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<ActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {
            await service.CompanyService.UpdateCompanyAsync(id, company, trackChanges: true);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteCompany(Guid Id)
        {

            await service.CompanyService.DeleteCompanyAsync(Id);

            return NoContent();

        }

    }
}
