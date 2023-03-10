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
    public class TypeRepo : ITypeRepo
    {
        private readonly DataContext _dataContext;

        public TypeRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public MachineType? GetById(int id)
        {
            return _dataContext.MachineTypes.FirstOrDefault(t => t.Id == id);
        }

        public MachineType? GetByName(string name)
        {
            return _dataContext.MachineTypes.FirstOrDefault(t => String.Equals(t.Name, name));
        }
    }
}
