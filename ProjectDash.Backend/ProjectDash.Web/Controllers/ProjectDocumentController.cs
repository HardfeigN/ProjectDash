using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectDash.Application.ProjectDocuments.Commands.CreateProjectDocument;
using ProjectDash.Application.ProjectDocuments.Commands.DeleteProjectDocument;
using ProjectDash.Application.ProjectDocuments.Commands.UpdateProjectDocument;
using ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentDetails;
using ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentList;
using ProjectDash.Web.Models;

namespace ProjectDash.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProjectDocumentController : BaseController
    {
        private readonly IMapper _mapper;
        public ProjectDocumentController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<ProjectDocumentListVm>> GetAll()
        {
            var query = new GetProjectDocumentListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDocumentDetailsVm>> Get(Guid id)
        {
            var query = new GetProjectDocumentDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProjectDocumentDto createProjectDto)
        {
            var command = _mapper.Map<CreateProjectDocumentCommand>(createProjectDto);
            var employeeId = await Mediator.Send(command);
            return Ok(employeeId);
        }

        public async Task<IActionResult> Update([FromBody] UpdateProjectDocumentDto updateProjectDto)
        {
            var command = _mapper.Map<UpdateProjectDocumentCommand>(updateProjectDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProjectDocumentCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
