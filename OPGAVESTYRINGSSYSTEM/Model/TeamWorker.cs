using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPGAVESTYRINGSSYSTEM.Model
{
    public class TeamWorker
    {
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
        public int? WorkerId { get; set; }
        public Worker? Worker { get; set; }
    }
}