using AutoMapper;
using MediatR;
using TCE.Application.DTOs;
using TCE.Application.Queries.ComprasQuerie;
using TCE.Domain.Core.IRepository;
using TCE.Domain.Entities;

namespace TCE.Application.Queries.CompraQueries
{
    public class GetComprasQueryHandler : IRequestHandler<GetComprasQuery, IEnumerable<CompraDTO>>
    {
        private readonly IRepository<Compra> _compraRepository;
        private readonly IMapper _mapper;

        public GetComprasQueryHandler(IRepository<Compra> compraRepository, IMapper mapper)
        {
            _compraRepository = compraRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompraDTO>> Handle(GetComprasQuery request, CancellationToken cancellationToken)
        {
            var compras = await _compraRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CompraDTO>>(compras);
        }
    }
}
