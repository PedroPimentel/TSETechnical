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

        public GetComprasQueryHandler(IRepository<Compra> compraRepository)
        {
            _compraRepository = compraRepository;
        }

        public async Task<IEnumerable<CompraDTO>> Handle(GetComprasQuery request, CancellationToken cancellationToken)
        {
            var (compras, total) = await _compraRepository.GetPagedProjectedAsync<CompraDTO>(
                x => true,
                request.PageNumber,
                request.PageSize
            );

            return compras;
        }
    }
}
