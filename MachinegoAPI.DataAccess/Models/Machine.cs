using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public Brand Brand { get; set; }
        public ICollection<MachiceAttachment> Attachments { get; set; }
        public MachineCategory Category { get; set; }
        public MachineType MachineType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now.Date;
    }
}
