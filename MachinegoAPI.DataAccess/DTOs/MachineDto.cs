using MachinegoAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.DTOs
{
    public class MachineDto
    {
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string Brand { get; set; }
        public List<string> Attachments { get; set; }
        public string Category { get; set; }
        public string MachineType { get; set; }
    }
}
