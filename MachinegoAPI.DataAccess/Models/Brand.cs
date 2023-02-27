using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.Models
{
    public class Brand
    {
     
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CategoryBrand> Categories { get; set; }
    }
}
