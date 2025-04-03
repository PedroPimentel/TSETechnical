using AutoMapper;
using FluentValidation;
using MediatR;
using TCE.Application.DTOs;
using TCE.Domain.Core.IRepository;
using TCE.Domain.Entities;

namespace TCE.Application.Commands.CompraCommands
{
    public class CreateCompraCommandHandler : IRequestHandler<CreateCompraCommand, MessageDTO<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCompraCommand> _validator;

        public CreateCompraCommandHandler(IMapper mapper, IUnitOfWork unitOfWork,
            IValidator<CreateCompraCommand> validator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<MessageDTO<Guid>> Handle(CreateCompraCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return new MessageDTO<Guid>
                {
                    IsSuccess = false,
                    Description = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage)),
                    Data = Guid.Empty
                };

            var existingCompra = await _unitOfWork.GetRepository<Compra>().GetProjectedAsync<Guid>(
                c => c.IdempotencyKey == request.IdempotencyKey);

            if (existingCompra.Any())
            {
                return new MessageDTO<Guid>
                {
                    IsSuccess = false,
                    Description = "Compra já realizada com essa IdempotencyKey",
                    Data = existingCompra.First()
                };
            }

            var cliente = await _unitOfWork.GetRepository<Cliente>().GetByIdAsync(request.ClienteId);

            if (cliente is null)
                return new MessageDTO<Guid>
                {
                    IsSuccess = false,
                    Description = "Cliente não encontrado",
                    Data = Guid.Empty
                };

            _unitOfWork.GetRepository<Cliente>().Attach(cliente);

            try
            {
                var compra = _mapper.Map<Compra>(request);
                cliente.AdicionarCompra(compra);
                await _unitOfWork.GetRepository<Compra>().AddAsync(compra);
                await _unitOfWork.SaveChangesAsync();

                return _mapper.Map<MessageDTO<Guid>>(compra);
            }
            catch (Exception ex)
            {
                return new MessageDTO<Guid>
                {
                    IsSuccess = false,
                    Description = ex.Message,
                    Data = Guid.Empty
                };
            }
        }
    }
}
