using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Application.ProjectDocuments.Commands.UpdateProjectDocument;

namespace ProjectDash.Web.Models
{
    public class UpdateProjectDocumentDto : IMapWith<UpdateProjectDocumentCommand>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProjectDocumentDto, UpdateProjectDocumentCommand>()
                .ForMember(updatePDCommand => updatePDCommand.Id,
                    opt => opt.MapFrom(updatePDDto => updatePDDto.Id))
                .ForMember(updatePDCommand => updatePDCommand.Name,
                    opt => opt.MapFrom(updatePDDto => updatePDDto.Name));
        }
    }
}
