using MediatR;
using Microsoft.AspNetCore.Mvc;
using TCE.Application.Commands.CompraCommands;
using TCE.Application.Queries.CompraQueries;
using TCE.Application.Queries.ComprasQuerie;

namespace TCE.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompraController(IMediator mediator) { _mediator = mediator; }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var query = new GetComprasQuery(pageNumber, pageSize);
            var compras = await _mediator.Send(query, cancellationToken);
            return Ok(compras);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompraCommand command, CancellationToken cancellationToken)
        {
            var clienteId = await _mediator.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = clienteId }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var compra = await _mediator.Send(new GetCompraByIdQuery(id));

            if (compra == null) return NotFound();

            return Ok(compra);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCompraCommand command)
        {
            if (id != command.Id) return BadRequest("O id da compra na URL não corresponde ao id no comando.");

            var compraAtualizado = await _mediator.Send(command);

            return Ok(compraAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteCompraCommand { Id = id });

            return Ok(response);
        }
    }
}
