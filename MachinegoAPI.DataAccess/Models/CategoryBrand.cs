using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.Models
{
    public  class CategoryBrand
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        public MachineCategory MachineCategory { get; set; }
        public Brand Brand { get; set; }
    }
}
