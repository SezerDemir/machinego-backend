using AutoMapper;
using MachinegoAPI.DataAccess.DTOs;
using MachinegoAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Machine, MachineDto>()
                .ForMember(dest => dest.Attachments, 
                    opts => opts.MapFrom(src => src.Attachments.Select(s=> s.Attachment).Select(s=> s.Name).ToList()))
                .ForMember(dest => dest.MachineType,
                    opts => opts.MapFrom(src => src.MachineType.Name))
                .ForMember(dest => dest.Brand,
                    opts => opts.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.Category,
                    opts => opts.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.ProductionYear,
                    opts => opts.MapFrom(src => src.ProductionYear))
                .ForMember(dest => dest.Model,
                    opts => opts.MapFrom(src => src.Model));
        }
    }
}
