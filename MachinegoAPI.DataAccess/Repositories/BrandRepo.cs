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
    public class BrandRepo : IBrandRepo
    {
        private readonly DataContext _dataContext;

        public BrandRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Brand? GetById(int id)
        {
            return _dataContext.Brands.FirstOrDefault(b => b.Id == id);
        }

        public Brand? GetByName(string name)
        {
            return _dataContext.Brands.FirstOrDefault(b => String.Equals(b.Name, name));
        }
    }
}
