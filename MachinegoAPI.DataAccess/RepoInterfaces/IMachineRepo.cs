using MachinegoAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.RepoInterfaces
{
    public interface IMachineRepo
    {
        public ICollection<Machine>? GetAll();
        public Machine AddMachine(Machine machine, List<MachiceAttachment> machineAttachments);
        public int GetNewId();
    }
}
