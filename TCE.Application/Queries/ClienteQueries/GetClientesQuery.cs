using MediatR;
using TCE.Application.DTOs;

namespace TCE.Application.Queries.ClienteQueries
{
    public class GetClientesQuery : IRequest<IEnumerable<ClienteDTO>> { }
}
