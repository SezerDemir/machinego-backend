using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.Models
{
    public class MachineCategory
    {
        
        public int Id { get; set; }
       
        public string Name { get; set; }

        public ICollection<CategoryBrand> Brands { get; set; }
        public ICollection<CategoryType> Types { get; set; }
    }
}
