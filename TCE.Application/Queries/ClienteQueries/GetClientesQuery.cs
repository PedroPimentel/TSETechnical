using MediatR;
using TCE.Application.DTOs;

namespace TCE.Application.Queries.ClienteQueries
{
    public class GetClientesQuery : IRequest<IEnumerable<ClienteDTO>> 
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetClientesQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
