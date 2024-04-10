using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectDash.Application.Employees.Commands.CreateEmployee;
using ProjectDash.Application.Employees.Commands.DeleteEmployee;
using ProjectDash.Application.Employees.Commands.UpdateEmployee;
using ProjectDash.Application.Employees.Queries.GetEmployeeDetails;
using ProjectDash.Application.Employees.Queries.GetEmployeeList;
using ProjectDash.Application.Projects.Queries.GetProjectList;
using ProjectDash.Web.Models;

namespace ProjectDash.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IMapper _mapper;
        public EmployeeController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of Employees
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/Employee/GetAll/
        /// {
        ///     ProjectId: "ba17ab91-b58b-4833-ae41-98eb055111d0",
        ///     Name: "Name",
        ///     Surname: "Surname",
        ///     Patronymic: "Patronymic", 
        ///     Email: "email@gmail.com"
        /// }
        /// </remarks>
        /// <returns>Returns EmployeeListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EmployeeListVm>> GetAll([FromQuery] GetEmployeeListDto getEmployeeListDto)
        {
            var query = _mapper.Map<GetEmployeeListQuery>(getEmployeeListDto);
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the Employee details
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/Employee/Get/D14F9508-FAF7-49EC-8203-B84B0CE66B71
        /// </remarks>
        /// <param name="id">Employee id (Guid)</param>
        /// <returns>Returns EmployeeDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EmployeeDetailsVm>> Get(Guid id)
        {
            var query = new GetEmployeeDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query); 
            return Ok(vm);
        }

        /// <summary>
        /// Creates the Employee
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/Employee/Create/
        /// {   
        ///     Name: "John",
        ///     Surname: "Potter",
        ///     Patronymic: "Fitzpatrick",
        ///     Email: "jh.pot@gmail.com"
        /// }
        /// </remarks>
        /// <param name="createEmployeeDto">CreateEmployeeDto object</param>
        /// <returns>Returns Employee Id</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(createEmployeeDto);
            var employeeId = await Mediator.Send(command);
            return Ok(employeeId);
        }

        /// <summary>
        /// Updates the Employee 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /api/Employee/Update/
        /// {   
        ///     Id: "D14F9508-FAF7-49EC-8203-B84B0CE66B71",
        ///     Name: "John",
        ///     Surname: "Potter",
        ///     Patronymic: "Fitzpatrick",
        ///     Email: "jh.pot@gmail.com"
        /// }
        /// </remarks>
        /// <param name="updateEmployeeDto">UpdateEmployeeDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            var command = _mapper.Map<UpdateEmployeeCommand>(updateEmployeeDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the Employee by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /api/Employee/Delete/D14F9508-FAF7-49EC-8203-B84B0CE66B71
        /// </remarks>
        /// <param name="id">Employee id (Guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="500">Error. Is the Employee a Project Leader?</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
