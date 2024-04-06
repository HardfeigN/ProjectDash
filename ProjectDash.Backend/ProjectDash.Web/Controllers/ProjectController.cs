using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProjectDash.Application.Projects.Commands.CreateProject;
using ProjectDash.Application.Projects.Commands.DeleteProject;
using ProjectDash.Application.Projects.Commands.UpdateProject;
using ProjectDash.Application.Projects.Queries.GetProjectDetails;
using ProjectDash.Application.Projects.Queries.GetProjectList;
using ProjectDash.Domain;
using ProjectDash.Web.Models;
using ProjectDash.WebAPI.Models;

namespace ProjectDash.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        public ProjectController(IMapper mapper, IWebHostEnvironment webHostEnvironment) =>
            (_mapper, _webHostEnvironment) = (mapper, webHostEnvironment);

        /// <summary>
        /// Gets the list of Projects
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/Project/GetAll/
        /// {
        ///     Name: "Name",
        ///     Performer: "Performer",
        ///     Customer: "Customer",
        ///     CreationDateStart: "2023-07-09T00:00:00",
        ///     CreationDateEnd: "2023-08-09T00:00:00",
        ///     CompletionDateStart: "2024-02-015T00:00:00",
        ///     CompletionDateEnd: "2024-02-20T00:00:00",
        ///     Priority: 10,
        ///     ProjectLeaderId: "D14F9508-FAF7-49EC-8203-B84B0CE66B71",
        ///     EmployeeId: "0165D5CB-ADB6-43C1-B80C-6E7DB142515A" 
        /// }
        /// </remarks>
        /// <returns>Returns ProjectListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProjectListVm>> GetAll([FromQuery] GetProjectListDto getProjectListDto)
        {
            var query = _mapper.Map<GetProjectListQuery>(getProjectListDto);
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the Project details
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/Project/Get/D14F9508-FAF7-49EC-8203-B84B0CE66B71
        /// </remarks>
        /// <param name="id">Project id (Guid)</param>
        /// <returns>Returns ProjectDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProjectDetailsVm>> Get(Guid id)
        {
            var query = new GetProjectDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the Project
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/ProjectCreate/
        /// {   
        ///     Name: "Project",
        ///     Performer: "BigBoys Developers Center",
        ///     Customer: "Flor2U",
        ///     Priority: "10",
        ///     ProjectLeaderId: "D14F9508-FAF7-49EC-8203-B84B0CE66B71"
        /// }
        /// </remarks>
        /// <param name="createProjectDto">CreateProjectDto object</param>
        /// <returns>Returns Project Id</returns>
        /// <response code="200">Employee Id</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProjectDto createProjectDto)
        {
            var command = _mapper.Map<CreateProjectCommand>(createProjectDto);
            var projectId = await Mediator.Send(command);
            return Ok(projectId);
        }

        /// <summary>
        /// Updates the Project 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /api/Project/Update/
        /// {   
        ///     Id: "D14F9508-FAF7-49EC-8203-B84B0CE66B71",
        ///     Performer: "BigBoys Developers Center",
        ///     Customer: "Flor2U",
        ///     Priority: "10",
        ///     ComplationDate: "2024-11-16T04:25:03",
        ///     ProjectLeaderId: "D14F9508-FAF7-49EC-8203-B84B0CE66B71"
        /// }
        /// </remarks>
        /// <param name="updateProjectDto">UpdateProjectDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateProjectDto updateProjectDto)
        {
            var command = _mapper.Map<UpdateProjectCommand>(updateProjectDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the Project by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /api/Project/Delete/D14F9508-FAF7-49EC-8203-B84B0CE66B71
        /// </remarks>
        /// <param name="id">Project id (Guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProjectCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            string webRootPath = _webHostEnvironment.WebRootPath;
            string filesFolder = webRootPath + $"\\uploads\\{nameof(ProjectDocument)}\\" + $"{id}\\";
            if (Directory.Exists(filesFolder))
            {
                Directory.Delete(filesFolder, true);
            }

            return NoContent();
        }
    }
}
