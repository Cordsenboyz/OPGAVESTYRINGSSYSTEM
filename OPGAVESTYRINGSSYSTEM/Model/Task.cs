using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPGAVESTYRINGSSYSTEM.Model
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        public string Name { get; set; }
        public List<Todo> Todos { get; set; } = new List<Todo>();

        public Task(string name, List<Todo> todos)
        {
            Name = name;
            Todos = todos;
        }

        public Task()
        {
        }
    }
}