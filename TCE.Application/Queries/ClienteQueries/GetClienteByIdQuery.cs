using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCE.Application.DTOs;

namespace TCE.Application.Queries.ClienteQueries
{
    public class GetClienteByIdQuery : IRequest<ClienteDTO> // Retorna o DTO do cliente
    {
        public Guid Id { get; set; }

        public GetClienteByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
