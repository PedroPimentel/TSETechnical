using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TCE.Domain.Entities;
using AutoMapper;
using TCE.Application.DTOs;
using TCE.Application.Commands.ClienteCommands;
using TCE.Application.Commands.CompraCommands;

namespace TCE.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Compra, CompraDTO>();
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<UpdateClienteCommand, Cliente>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UpdateCompraCommand, Compra>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<CreateCompraCommand, Compra>();
            CreateMap<CreateClienteCommand, Cliente>();
        }
    }
}
