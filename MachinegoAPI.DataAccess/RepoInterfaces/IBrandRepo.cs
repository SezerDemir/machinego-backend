using MachinegoAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.RepoInterfaces
{
    public interface IBrandRepo
    {
        public Brand? GetByName(string name);
        public Brand? GetById(int id);
    }
}
