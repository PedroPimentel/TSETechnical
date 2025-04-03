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
            CreateMap<Cliente, ClienteDTO>()
                .ForMember(dest => dest.Compras, opt => opt.MapFrom(src => src.Compras));
            CreateMap<Compra, Compra>();
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<UpdateClienteCommand, Cliente>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UpdateCompraCommand, Compra>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<CreateCompraCommand, Compra>();
            CreateMap<CreateClienteCommand, Cliente>();
            CreateMap<Compra, CompraDTO>();
            CreateMap<Compra, Guid>().ConvertUsing(src => src.Id);
            CreateMap<Compra, MessageDTO<Guid>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Id)) 
                .ForMember(dest => dest.IsSuccess, opt => opt.MapFrom(_ => true))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(_ => "Compra realizada com sucesso"));
        }
    }
}
