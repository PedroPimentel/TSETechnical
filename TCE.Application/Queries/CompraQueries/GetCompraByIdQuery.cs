using MediatR;
using TCE.Application.DTOs;

namespace TCE.Application.Queries.CompraQueries
{
    public class GetCompraByIdQuery : IRequest<CompraDTO> 
    {
        public Guid Id { get; set; }

        public GetCompraByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
