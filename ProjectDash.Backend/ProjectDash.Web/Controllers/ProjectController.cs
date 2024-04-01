using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectDash.Application.Projects.Commands.CreateProject;
using ProjectDash.Application.Projects.Commands.DeleteProject;
using ProjectDash.Application.Projects.Commands.UpdateProject;
using ProjectDash.Application.Projects.Queries.GetProjectDetails;
using ProjectDash.Application.Projects.Queries.GetProjectList;
using ProjectDash.WebAPI.Models;

namespace ProjectDash.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : BaseController
    {
        private readonly IMapper _mapper;
        public ProjectController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<ProjectListVm>> GetAll()
        {
            var query = new GetProjectListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDetailsVm>> Get(Guid id)
        {
            var query = new GetProjectDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProjectDto createProjectDto)
        {
            var command = _mapper.Map<CreateProjectCommand>(createProjectDto);
            var employeeId = await Mediator.Send(command);
            return Ok(employeeId);
        }

        public async Task<IActionResult> Update([FromBody] UpdateProjectDto updateProjectDto)
        {
            var command = _mapper.Map<UpdateProjectCommand>(updateProjectDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProjectCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }


    }
}
