using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class MachineType
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryType> Categories { get; set; }
        public ICollection<TypeAttachment> Attachments { get; set; }
    }
}
