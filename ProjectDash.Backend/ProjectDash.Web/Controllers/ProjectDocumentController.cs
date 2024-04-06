using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectDash.Application.ProjectDocuments.Commands.CreateProjectDocument;
using ProjectDash.Application.ProjectDocuments.Commands.DeleteProjectDocument;
using ProjectDash.Application.ProjectDocuments.Commands.UpdateProjectDocument;
using ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentDetails;
using ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentList;
using ProjectDash.Domain;
using ProjectDash.Web.Models;

namespace ProjectDash.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectDocumentController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        public ProjectDocumentController(IMapper mapper, IWebHostEnvironment webHostEnvironment) =>
            (_mapper, _webHostEnvironment) = (mapper, webHostEnvironment);

        /// <summary>
        /// Gets the list of ProjectDocuments
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/ProjectDocument/GetAll/
        /// </remarks>
        /// <returns>Returns ProjectDocumentListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProjectDocumentListVm>> GetAll(Guid? id)
        {
            var query = new GetProjectDocumentListQuery
            {
                ProjectId = id.GetValueOrDefault()
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the ProjectDocument details
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/ProjectDocument/Get/D14F9508-FAF7-49EC-8203-B84B0CE66B71
        /// </remarks>
        /// <param name="id">ProjectDocument id (Guid)</param>
        /// <returns>Returns ProjectDocumentDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProjectDocumentDetailsVm>> Get(Guid id)
        {
            var query = new GetProjectDocumentDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Gets the file of ProjectDocument
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/ProjectDocument/GetFile/D14F9508-FAF7-49EC-8203-B84B0CE66B71
        /// </remarks>
        /// <param name="id">ProjectDocument id (Guid)</param>
        /// <returns>Returns file</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile(Guid id)
        {
            var query = new GetProjectDocumentDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            string webRootPath = _webHostEnvironment.WebRootPath;
            string filePath = webRootPath + $"\\uploads\\{nameof(ProjectDocument)}\\" + $"{vm.ProjectId}\\{vm.Id}{vm.Extension}";
            if (System.IO.File.Exists(filePath))
                return File(System.IO.File.ReadAllBytes(filePath), "multipart/form-data", System.IO.Path.GetFileName(filePath));
            else return NotFound();
        }

        /// <summary>
        /// Creates the ProjectDocument
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/ProjectDocument/Create/
        /// curl -X 'POST' \
        /// 'https://{ip_address}/api/ProjectDocument/Create' \
        /// -H 'accept: application/json' \
        /// -H 'Content-Type: multipart/form-data' \
        /// -F 'Name=qaasd' \
        /// -F 'ProjectId=ba17ab91-b58b-4833-ae41-98eb055111d0' \
        /// -F 'Extension=' \
        /// -F 'Document=@e00c6299-054b-4527-88fb-b6329d5e7cce.txt;type=text/plain'
        /// </remarks>
        /// <param name="createProjectDocumentDto">CreateProjectDocumentDto object</param>
        /// <returns>Returns Project Document Id</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromForm] CreateProjectDocumentDto createProjectDocumentDto)
        {
            string extension = Path.GetExtension(createProjectDocumentDto.Document.FileName);
            string webRootPath = _webHostEnvironment.WebRootPath;
            string fileFolder = webRootPath + $"\\uploads\\{nameof(ProjectDocument)}\\" + $"{createProjectDocumentDto.ProjectId}\\";
            createProjectDocumentDto.Extension = extension;

            var command = _mapper.Map<CreateProjectDocumentCommand>(createProjectDocumentDto);
            var projectDocumentId = await Mediator.Send(command);
            
            if(projectDocumentId != Guid.Empty)
            {
                if (!Directory.Exists(fileFolder))
                {
                    Directory.CreateDirectory(fileFolder);
                }
                using (var fileStrem = new FileStream(Path.Combine(fileFolder, projectDocumentId + extension), FileMode.Create))
                {
                    createProjectDocumentDto.Document.CopyTo(fileStrem);
                };
            }

            return Ok(projectDocumentId);
        }

        /// <summary>
        /// Updates the ProjectDocument 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /api/ProjectDocument/Update/
        /// {   
        ///     Id: "D14F9508-FAF7-49EC-8203-B84B0CE66B71",
        ///     Name: "new file name",
        ///     ProjectId: "D14F9508-FAF7-49EC-8203-B84B0CE66B71"
        /// }
        /// </remarks>
        /// <param name="updateProjectDocumentDto">UpdateProjectDocumentDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateProjectDocumentDto updateProjectDocumentDto)
        {
            var command = _mapper.Map<UpdateProjectDocumentCommand>(updateProjectDocumentDto);
            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes the ProjectDocument by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /api/ProjectDocument/Delete/D14F9508-FAF7-49EC-8203-B84B0CE66B71
        /// </remarks>
        /// <param name="id">ProjectDocument id (Guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProjectDocumentCommand
            {
                Id = id
            };

            var projectDocument = await Mediator.Send(command);

            if(projectDocument != null)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                string fileFolder = webRootPath + $"\\uploads\\{nameof(ProjectDocument)}\\" + $"{projectDocument.ProjectId}\\";
                var filePath = Path.Combine(fileFolder, projectDocument.Id + projectDocument.Extension);
                if (System.IO.File.Exists(Path.Combine(fileFolder, projectDocument.Id + projectDocument.Extension)))
                {
                    System.IO.File.Delete(filePath);
                }
                if (Directory.GetFiles(fileFolder).Length < 1)
                {
                    Directory.Delete(fileFolder);
                }
            }

            return NoContent();
        }
    }
}
