﻿using MediatR;

namespace ProjectDash.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Performer { get; set; }
        public string Customer { get; set; }
        public DateTime CreationDate { get; set; }
        public int Priority { get; set; }
        public Guid ProjectLeaderId { get; set; }
    }
}
