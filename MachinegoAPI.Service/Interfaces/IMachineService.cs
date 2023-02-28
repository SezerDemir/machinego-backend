using MachinegoAPI.DataAccess.DTOs;
using MachinegoAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.Service.Interfaces
{
    public interface IMachineService
    {
        public ICollection<MachineCategory> GetAllCategories();
        public ICollection<String> GetAttachmentsByType(string typeName);
        public ICollection<String> GetBrandsByCategory(string category);
        public ICollection<String> GetTypesByCategory(string category);
        public MachineDto? AddMachine(MachineDto machineDto);
        public MachineDto? GetMachineById(int id);
        public ICollection<String> GetBrandsByCategoryId(int categoryId);
    }
}
