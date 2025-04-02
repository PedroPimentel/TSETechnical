using MediatR;
using TCE.Application.DTOs;

namespace TCE.Application.Queries.ComprasQuerie
{
    public class GetComprasQuery : IRequest<IEnumerable<CompraDTO>> { }
}
