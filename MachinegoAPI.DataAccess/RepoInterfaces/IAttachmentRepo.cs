using MachinegoAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.RepoInterfaces
{
    public interface IAttachmentRepo
    {
        public Attachment? GetByName(string name);
        public Attachment? GetById(int id);
    }
}
