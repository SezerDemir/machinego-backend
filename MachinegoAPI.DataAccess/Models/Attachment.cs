using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Attachment
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TypeAttachment> Types { get; set; }
        public ICollection<MachiceAttachment> Machines { get; set; }
    }
}
