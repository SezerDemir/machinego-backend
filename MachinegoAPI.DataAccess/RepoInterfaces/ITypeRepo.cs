using MachinegoAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.RepoInterfaces
{
    public interface ITypeRepo
    {
        public MachineType? GetByName(string name);
        public MachineType? GetById(int id);
    }
}
