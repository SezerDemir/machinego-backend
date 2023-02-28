using MachinegoAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.RepoInterfaces
{
    public interface ICategoryRepo
    {
        public ICollection<MachineCategory> GetAllCategories();
        public MachineCategory? GetById(int id);
        public MachineCategory? GetByName(string name);
        public ICollection<string> GetAttachmentsByType(string typeName);
        public ICollection<String> GetBrandByCategory(string category);
        public ICollection<String> GetTypesByCategory(string category);
        public ICollection<string> GetBrandByCategoryId(int categoryId);
    }
}
