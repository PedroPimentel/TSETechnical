using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCE.Application.DTOs;

namespace TCE.Application.Queries
{
    public class GetClientesQuery : IRequest<IEnumerable<ClienteDTO>> { }
}
