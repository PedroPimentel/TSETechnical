using MediatR;
using Microsoft.AspNetCore.Mvc;
using TCE.Application.Queries;

namespace TCE.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes(CancellationToken cancellationToken)
        {
            var query = new GetClientesQuery();
            var clientes = await _mediator.Send(query, cancellationToken);
            return Ok(clientes);
        }
    }
}
