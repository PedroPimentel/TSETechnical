using AutoMapper;
using MediatR;
using TCE.Application.DTOs;
using TCE.Domain.Core.IRepository;
using TCE.Domain.Entities;

namespace TCE.Application.Queries.CompraQueries
{
    public class GetCompraByIdQueryHandler : IRequestHandler<GetCompraByIdQuery, CompraDTO>
    {
        private readonly IRepository<Compra> _compraRepository;
        private readonly IMapper _mapper;

        public GetCompraByIdQueryHandler(IRepository<Compra> compraRepository, IMapper mapper)
        {
            _compraRepository = compraRepository;
            _mapper = mapper;
        }

        public async Task<CompraDTO> Handle(GetCompraByIdQuery request, CancellationToken cancellationToken)
        {
            var compra = await _compraRepository.GetByIdAsync(request.Id);

            if (compra == null) return null;
            
            return _mapper.Map<CompraDTO>(compra);
        }
    }
}
