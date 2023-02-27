using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.Models
{
    public class CategoryType
    {
        public int CategoryId { get; set; }
        public int TypeId { get; set; }

        public MachineCategory MachineCategory { get; set; }
        public MachineType MachineType { get; set; }
    }
}
