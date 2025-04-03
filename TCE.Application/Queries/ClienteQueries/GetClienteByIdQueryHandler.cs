using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TCE.Application.DTOs;
using TCE.Domain.Core.IRepository;
using TCE.Domain.Entities;

namespace TCE.Application.Queries.ClienteQueries
{
    public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, ClienteDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetClienteByIdQueryHandler(IRepository<Cliente> clienteRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = await _unitOfWork.GetRepository<Cliente>()
                    .GetByIdAsync(request.Id, query => query.Include(c => c.Compras));

                if (cliente is null) return null;

                var compras = await _unitOfWork.GetRepository<Compra>()
                    .GetProjectedAsync<Compra>(x => x.ClienteId == request.Id);

                cliente.Compras.ToList().AddRange(compras);

                return _mapper.Map<ClienteDTO>(cliente);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }

}
