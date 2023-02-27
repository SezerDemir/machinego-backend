
using MachinegoAPI.DataAccess.DTOs;
using MachinegoAPI.Service.Interfaces;
using MachinegoAPI.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MachinegoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly ILogger<MachineController> _logger;
        private readonly IMachineService _machineService;

        public MachineController(ILogger<MachineController> logger, IMachineService machineService)
        {
            _logger = logger;
            _machineService = machineService;
        }

        [HttpGet("categories")]
        public ActionResult GetAllCategories()
        {
            return Ok(_machineService.GetAllCategories());
        }

        [HttpGet("brand/{category}")]
        public ActionResult GetAllCategories(string category)
        {
            var res = _machineService.GetBrandsByCategory(category);
            if(res != null) { return Ok(res); }
            else { return NotFound(); }
        }

        [HttpGet("type/{category}")]
        public ActionResult GetTypes(string category)
        {
            var res = _machineService.GetTypesByCategory(category);
            if (res != null) { return Ok(res); }
            else { return NotFound(); }
        }

        [HttpGet("attachment/{typeName}")]
        public ActionResult GetAttachments(string typeName)
        {
            var res = _machineService.GetAttachmentsByType(typeName);
            if (res != null) { return Ok(res); }
            else { return NotFound(); }
        }
        [HttpPost("machine/add")]
        public ActionResult MachineAdd(MachineDto machineDto)
        {
            var res = _machineService.AddMachine(machineDto);
            if (res != null) { return Ok(res); }
            else { return NotFound(); }
        }
        [HttpGet("machine/{id}")]
        public ActionResult MachineGetById(int id)
        {
            var res = _machineService.GetMachineById(id);
            if (res != null) { return Ok(res); }
            else { return NotFound(); }
        }
    }
}
