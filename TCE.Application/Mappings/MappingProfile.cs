using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TCE.Domain.Entities;
using AutoMapper;
using TCE.Application.DTOs;

namespace TCE.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Compra, CompraDTO>();
            CreateMap<Cliente, ClienteDTO>();
        }
    }
}
