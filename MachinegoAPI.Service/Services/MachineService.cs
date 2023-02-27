using MachinegoAPI.DataAccess.Data;
using MachinegoAPI.DataAccess.DTOs;
using MachinegoAPI.DataAccess.Models;
using MachinegoAPI.DataAccess.RepoInterfaces;
using MachinegoAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.Service.Services
{
    public class MachineService : IMachineService
    {

        private readonly ICategoryRepo _categoryRepo;
        private readonly IBrandRepo _brandRepo;
        private readonly ITypeRepo _typeRepo;
        private readonly IAttachmentRepo _attachmentRepo;
        private readonly IMachineRepo _machineRepo;

        public MachineService(ICategoryRepo categoryRepo, IBrandRepo brandRepo, ITypeRepo typeRepo, IAttachmentRepo attachmentRepo, IMachineRepo machineRepo )
        {
            _categoryRepo = categoryRepo;
            _brandRepo = brandRepo;
            _typeRepo = typeRepo;   
            _attachmentRepo = attachmentRepo;   
            _machineRepo = machineRepo;
        }

        public ICollection<MachineCategory> GetAllCategories()
        {
            return _categoryRepo.GetAllCategories();
        }

        public ICollection<String> GetTypesByCategory(string category)
        {
           return _categoryRepo.GetTypesByCategory(category);
        }

        public ICollection<String> GetBrandsByCategory(string category)
        {
            return _categoryRepo.GetBrandByCategory(category);
        }

        public ICollection<string> GetAttachmentsByType(string typeName)
        {
            return _categoryRepo.GetAttachmentsByType(typeName);
        }

        public Machine? AddMachine(MachineDto machineDto)
        {

            string model = machineDto.Model;
            int year = machineDto.ProductionYear;
            string category = machineDto.Category;
            string brand = machineDto.Brand;
            string machineType = machineDto.MachineType;
            if (String.Equals(model, "")) { return null; }
            if (year < 1600 || year > DateTime.Now.Year) { return null; }
            var cat = _categoryRepo.GetByName(category);
            if (cat == null) { return null; }
            var br = _brandRepo.GetByName(brand);
            if (br == null) { return null; }
            var ty = _typeRepo.GetByName(machineType);
            if (ty == null) { return null; }
            ICollection<Attachment> attachmentsList = new List<Attachment>();
            foreach (var a in machineDto.Attachments)
            {
                var att = _attachmentRepo.GetByName(a);
                if (att == null) { return null; }
                attachmentsList.Add(att);
            }

            Machine machine = new Machine();
            machine.Model = model;
            machine.ProductionYear = year;
            machine.Category = cat;
            machine.Brand = br;
            machine.MachineType = ty;
            List<MachiceAttachment> machineAttachments = new List<MachiceAttachment>();
            foreach (var a in attachmentsList)
            {
                machineAttachments.Add(new MachiceAttachment() { AttachmentId = a.Id});
            }

            var addedMachine = _machineRepo.AddMachine(machine, machineAttachments);
           
            return addedMachine;

        }
    }
}
