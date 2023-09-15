using MariyaCompany.Application.Abstractions.Entity;
using MariyaCompany.Application.Abstractions.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MariyaCompany.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public EmployeesController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [Route("")]
        [HttpGet]
        public async Task<Employee[]> GetEmployees([FromQuery] GetEmployeesRequest request)
        {
            var result = await _mediatr.Send(request);

            return result;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] CreateEmployeeRequest request)
        {
            var result = await _mediatr.Send(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            
            return BadRequest(result);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee([FromRoute] int id)
        {
            var result = await _mediatr.Send(new DeleteEmployeeRequest(id));

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [Route("update")]
        [HttpPut]
        public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequest request)
        {
            var result = await _mediatr.Send(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [Route("departments")]
        [HttpGet]
        public async Task<Department[]> GetDepartments()
        {
            var result = await _mediatr.Send(new GetDepartmentsRequest());

            return result;
        }

        [Route("companypositions")]
        [HttpGet]
        public async Task<CompanyPosition[]> GetCompanyPositions()
        {
            var result = await _mediatr.Send(new GetCompanyPositionsRequest());

            return result;
        }
    }
}
