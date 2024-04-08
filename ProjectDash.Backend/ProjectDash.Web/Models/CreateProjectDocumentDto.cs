using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Application.ProjectDocuments.Commands.CreateProjectDocument;

namespace ProjectDash.Web.Models
{
    public class CreateProjectDocumentDto : IMapWith<CreateProjectDocumentCommand>
    {
        public string? Name { get; set; }
        public Guid ProjectId { get; set; }
        public string? Extension { get; set; }
        public IFormFileCollection Documents { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectDocumentDto, CreateProjectDocumentCommand>()
                .ForMember(createPDCommand => createPDCommand.Name,
                    opt => opt.MapFrom(createPDDto => createPDDto.Name))
                .ForMember(createPDCommand => createPDCommand.ProjectId,
                    opt => opt.MapFrom(createPDDto => createPDDto.ProjectId))
                .ForMember(createPDCommand => createPDCommand.Extension,
                    opt => opt.MapFrom(createPDDto => createPDDto.Extension));
        }
    }
}
