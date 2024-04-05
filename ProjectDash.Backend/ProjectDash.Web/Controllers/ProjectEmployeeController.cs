using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectDash.Application.ProjectEmployees.Commands.CreateProjectEmployee;
using ProjectDash.Application.ProjectEmployees.Commands.DeleteProjectEmployee;
using ProjectDash.Application.ProjectEmployees.Queries.GetProjectEmployeeList;
using ProjectDash.Web.Models;

namespace ProjectDash.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectEmployeeController : BaseController
    {
        private readonly IMapper _mapper;
        public ProjectEmployeeController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of ProjectEmployees
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /ProjectEmployee
        /// </remarks>
        /// <returns>Returns ProjectEmployeeListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProjectEmployeeListVm>> GetAll()
        {
            var query = new GetProjectEmployeeListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the ProjectEmployee
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /ProjectEmployee
        /// {   
        ///     EmployeeId: "A61F45F0-3FC5-41EA-8A93-BCEF300BAD01",
        ///     ProjectId: "D14F9508-FAF7-49EC-8203-B84B0CE66B71"
        /// }
        /// </remarks>
        /// <param name="createProjectEmployeeDto">CreateProjectEmployeeDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Create([FromBody] CreateProjectEmployeeDto createProjectEmployeeDto)
        {
            var command = _mapper.Map<CreateProjectEmployeeCommand>(createProjectEmployeeDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the ProjectEmployee
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /ProjectEmployee
        /// </remarks>
        /// <param name="deleteProjectEmployeeDto">DeleteProjectEmployeeDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(DeleteProjectEmployeeDto deleteProjectEmployeeDto)
        {
            var command = _mapper.Map<DeleteProjectEmployeeCommand>(deleteProjectEmployeeDto);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
