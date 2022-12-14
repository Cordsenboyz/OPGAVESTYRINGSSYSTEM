using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPGAVESTYRINGSSYSTEM.Model
{
    public class Team
    {
        public int? TeamId { get; set; }
        public string? Name { get; set; }
        public List<TeamWorker>? TeanWorkers { get; set; } = new List<TeamWorker>();
        public Task? CurrentTask { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();

        public Team(string name)
        {
            Name = name;
        }

        public Team()
        {
        }
    }
}