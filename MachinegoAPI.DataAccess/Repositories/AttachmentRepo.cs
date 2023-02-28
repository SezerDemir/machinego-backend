using MachinegoAPI.DataAccess.Data;
using MachinegoAPI.DataAccess.Models;
using MachinegoAPI.DataAccess.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.Repositories
{
    public class AttachmentRepo : IAttachmentRepo
    {
        private readonly DataContext _dataContext;

        public AttachmentRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Attachment? GetById(int id)
        {
            return _dataContext.Attachments.FirstOrDefault(x => x.Id == id);
        }

        public Attachment? GetByName(string name)
        {
            return _dataContext.Attachments.FirstOrDefault(a =>  String.Equals(a.Name , name));
        }
    }
}
