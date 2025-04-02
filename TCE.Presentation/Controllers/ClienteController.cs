using MediatR;
using Microsoft.AspNetCore.Mvc;
using TCE.Application.Commands;
using TCE.Application.Commands.ClienteCommands;
using TCE.Application.Queries.ClienteQueries;

namespace TCE.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var query = new GetClientesQuery(pageNumber, pageSize);
            var clientes = await _mediator.Send(query, cancellationToken);
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClienteCommand command, CancellationToken cancellationToken)
        {
            var clienteId = await _mediator.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = clienteId }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cliente = await _mediator.Send(new GetClienteByIdQuery(id));

            if (cliente == null) return NotFound();

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateClienteCommand command)
        {
            if (id != command.Id) return BadRequest("O id do cliente na URL não corresponde ao id no comando.");

            var clienteAtualizado = await _mediator.Send(command);

            return Ok(clienteAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteClienteCommand { Id = id });

            return Ok(response);
        }
    }
}
