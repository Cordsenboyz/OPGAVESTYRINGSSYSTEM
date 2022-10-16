using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPGAVESTYRINGSSYSTEM.Model
{
    public class Worker
    {
        public int? WorkerId { get; set; }
        public string? Name { get; set; }
        public List<TeamWorker>? TeamWorker { get; set; } = new List<TeamWorker>();
        public Todo? CurrentTodo { get; set; }
        public List<Todo> Todos { get; set; } = new List<Todo>();

        public Worker(string name)
        {
            Name = name;
        }

        public Worker()
        {
        }
    }
}