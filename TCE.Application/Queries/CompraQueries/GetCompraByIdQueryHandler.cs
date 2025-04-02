using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCE.Application.DTOs;
using TCE.Domain.Core.IRepository;
using TCE.Domain.Entities;

namespace TCE.Application.Queries.CompraQueries
{
    public class GetCompraByIdQueryHandler : IRequestHandler<GetCompraByIdQuery, CompraDTO>
    {
        private readonly IRepository<Compra> _CompraRepository;
        private readonly IMapper _mapper;

        public GetCompraByIdQueryHandler(IRepository<Compra> CompraRepository, IMapper mapper)
        {
            _CompraRepository = CompraRepository;
            _mapper = mapper;
        }

        public async Task<CompraDTO> Handle(GetCompraByIdQuery request, CancellationToken cancellationToken)
        {
            var Compra = await _CompraRepository.GetByIdAsync(request.Id);

            if (Compra == null) return null;
            
            return _mapper.Map<CompraDTO>(Compra);
        }
    }
}
