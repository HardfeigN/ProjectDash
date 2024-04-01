using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectDash.Application.Employees.Commands.CreateEmployee;
using ProjectDash.Application.Employees.Commands.DeleteEmployee;
using ProjectDash.Application.Employees.Commands.UpdateEmployee;
using ProjectDash.Application.Employees.Queries.GetEmployeeDetails;
using ProjectDash.Application.Employees.Queries.GetEmployeeList;
using ProjectDash.Web.Models;

namespace ProjectDash.Web.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : BaseController
    {
        private readonly IMapper _mapper;
        public EmployeeController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<EmployeeListVm>> GetAll()
        {
            var query = new GetEmployeeListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetailsVm>> Get(Guid id)
        {
            var query = new GetEmployeeDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query); 
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(createEmployeeDto);
            var employeeId = await Mediator.Send(command);
            return Ok(employeeId);
        }

        public async Task<IActionResult> Update([FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            var command = _mapper.Map<UpdateEmployeeCommand>(updateEmployeeDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteEmployeeCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
