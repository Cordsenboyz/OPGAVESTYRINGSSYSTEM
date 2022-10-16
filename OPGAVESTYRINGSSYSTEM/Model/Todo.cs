using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPGAVESTYRINGSSYSTEM.Model
{
    public class Todo
    {
        [Key]
        public int? TodoId { get; set; }

        public string? Name { get; set; }
        public bool? IsComplete { get; set; }

        public Todo(string name, bool isComplete)
        {
            Name = name;
            IsComplete = isComplete;
        }

        public Todo()
        {
        }
    }
}