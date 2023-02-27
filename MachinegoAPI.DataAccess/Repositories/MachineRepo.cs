using MachinegoAPI.DataAccess.Data;
using MachinegoAPI.DataAccess.Models;
using MachinegoAPI.DataAccess.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.Repositories
{
    public class MachineRepo : IMachineRepo
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<MachineRepo> _logger;

        public MachineRepo(DataContext dataContext, ILogger<MachineRepo> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public Machine AddMachine(Machine machine, List<MachiceAttachment> machiceAttachments)
        {
            var m = _dataContext.Machines.Add(machine);
            _dataContext.SaveChanges();
            int id = m.Entity.Id;
            foreach(var attachment in machiceAttachments)
            {
                attachment.MachineId = id;
                _dataContext.MachineAttachments.Add(attachment);
            }
            _dataContext.SaveChanges();
            return machine;
        }

        public ICollection<Machine>? GetAll()
        {
            throw new NotImplementedException(); //TODO implement
        }

        public int GetNewId()
        {
            var machine = _dataContext.Machines.OrderByDescending(e=>e.Id).AsNoTracking().FirstOrDefault();
            if (machine != null)
            {
                _logger.LogInformation("ıd:" + machine.Id);

            }else
            {
                _logger.LogInformation("ıd:" + 1);

            }
            if (machine == null) { return 1; }
            return machine.Id + 1;
        }
    }
}
