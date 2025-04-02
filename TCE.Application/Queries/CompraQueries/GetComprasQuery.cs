using MediatR;
using TCE.Application.DTOs;

namespace TCE.Application.Queries.ComprasQuerie
{
    public class GetComprasQuery : IRequest<IEnumerable<CompraDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetComprasQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
