using MachinegoAPI.DataAccess.Data;
using MachinegoAPI.DataAccess.Models;
using MachinegoAPI.DataAccess.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<CategoryRepo> _logger;
        public CategoryRepo(ILogger<CategoryRepo> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public ICollection<MachineCategory> GetAllCategories()
        {
            return _dataContext.MachineCategories.AsNoTracking().ToList();
        }



        public ICollection<String> GetTypesByCategory(string category)
        {

            var categories = _dataContext.MachineCategories.Where(e => String.Equals(e.Name, category)).Include(e => e.Types).ThenInclude(e => e.MachineType).AsNoTracking().FirstOrDefault();
            if (categories != null)
            {
                var types = categories.Types.Select(x => x.MachineType).Select(x => x.Name).ToList();
                return types;
            }
            return null;

        }

        public ICollection<String> GetBrandByCategory(string category)
        {
            var categories = _dataContext.MachineCategories.Where(e => String.Equals(e.Name, category)).Include(e => e.Brands).ThenInclude(e => e.Brand).AsNoTracking().FirstOrDefault();
            if (categories != null)
            {
                var brands = categories.Brands.Select(x => x.Brand).Select(x => x.Name).ToList();
                return brands;
            }
            return null;
        }

        public ICollection<string> GetAttachmentsByType(string typeName)
        {
            var machineType = _dataContext.MachineTypes.Where(e => String.Equals(e.Name, typeName)).Include(e => e.Attachments).ThenInclude(e => e.Attachment).AsNoTracking().FirstOrDefault();
            if (machineType != null)
            {
                var attachments = machineType.Attachments.Select(e => e.Attachment).Select(e => e.Name).ToList();
                return attachments;
            }
            return null;
        }

        public MachineCategory? GetByName(string name)
        {
            var category = _dataContext.MachineCategories.FirstOrDefault(c => String.Equals(c.Name, name));
            return category;
        }

        public MachineCategory? GetById(int id)
        {
            return _dataContext.MachineCategories.FirstOrDefault(e => e.Id == id);
        }

        public ICollection<string> GetBrandByCategoryId(int categoryId)
        {
            var category = _dataContext.MachineCategories.Include(e => e.Brands).ThenInclude(e => e.Brand).AsNoTracking().FirstOrDefault(e => e.Id == categoryId);
            return category.Brands.Select(e => e.Brand).Select(e => e.Name).ToList();
        }
    }
}
