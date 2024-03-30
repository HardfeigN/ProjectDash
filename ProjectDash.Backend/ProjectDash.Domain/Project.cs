using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDash.Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Performer { get; set; }
        public string Customer { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int Priority { get; set; }
        public Guid ProjectLeaderId { get; set; }
        public Employee ProjectLeader { get; set; }
    }
}
