﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCE.Application.DTOs;
using TCE.Domain.Core.IRepository;
using TCE.Domain.Entities;

namespace TCE.Application.Queries
{
    public class GetClientesQueryHandler : IRequestHandler<GetClientesQuery, IEnumerable<ClienteDTO>>
    {
        private readonly IRepository<Cliente> _clienteRepository;
        private readonly IMapper _mapper;

        public GetClientesQueryHandler(IRepository<Cliente> clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> Handle(GetClientesQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }
    }
}
