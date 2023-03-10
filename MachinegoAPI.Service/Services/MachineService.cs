using AutoMapper;
using MachinegoAPI.DataAccess.Data;
using MachinegoAPI.DataAccess.DTOs;
using MachinegoAPI.DataAccess.Models;
using MachinegoAPI.DataAccess.RepoInterfaces;
using MachinegoAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MachinegoAPI.Service.Services
{
    public class MachineService : IMachineService
    {

        private readonly ICategoryRepo _categoryRepo;
        private readonly IBrandRepo _brandRepo;
        private readonly ITypeRepo _typeRepo;
        private readonly IAttachmentRepo _attachmentRepo;
        private readonly IMachineRepo _machineRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<MachineService> _logger;

        public MachineService(ICategoryRepo categoryRepo, IBrandRepo brandRepo, ITypeRepo typeRepo,
            IAttachmentRepo attachmentRepo, IMachineRepo machineRepo, IMapper mapper, ILogger<MachineService> logger)
        {
            _categoryRepo = categoryRepo;
            _brandRepo = brandRepo;
            _typeRepo = typeRepo;   
            _attachmentRepo = attachmentRepo;   
            _machineRepo = machineRepo;
            _mapper = mapper;
            _logger = logger;
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

        public MachineDto? AddMachine(MachineDto machineDto)
        {
            ICollection<Attachment> attachmentsList = new List<Attachment>();
            var cat = _categoryRepo.GetByName(machineDto.Category);
            var br = _brandRepo.GetByName(machineDto.Brand);
            var ty = _typeRepo.GetByName(machineDto.MachineType);
            foreach (var a in machineDto.Attachments)
            {
                var att = _attachmentRepo.GetByName(a);
                if (att == null)
                {
                    return null;
                }
                attachmentsList.Add(att);
            }
            if(cat == null || br == null || ty == null)
            {
                return null;
            }

            Machine machine = new Machine();
            machine.Model = machineDto.Model;
            machine.ProductionYear = machineDto.ProductionYear;
            machine.Category = cat;
            machine.Brand = br;
            machine.MachineType = ty;
            List<MachiceAttachment> machineAttachments = new List<MachiceAttachment>();
            foreach (var a in attachmentsList)
            {
                machineAttachments.Add(new MachiceAttachment() { AttachmentId = a.Id});
            }

            var addedMachine = _machineRepo.AddMachine(machine, machineAttachments);

            return _mapper.Map<MachineDto>(addedMachine);

        }

        public MachineDto? GetMachineById(int id)
        {
            return _mapper.Map<MachineDto>(_machineRepo.GetById(id));
        }

        public ICollection<string> GetBrandsByCategoryId(int categoryId)
        {
            return _categoryRepo.GetBrandByCategoryId(categoryId);
        }
    }
}
