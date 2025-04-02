using AutoMapper;
using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;
using TCE.Application.DTOs;
using TCE.Domain.Core.IRepository;
using TCE.Domain.Entities;

namespace TCE.Application.Commands.CompraCommands
{
    public class CreateCompraCommandHandler : IRequestHandler<CreateCompraCommand, Guid>
    {
        private readonly IRepository<Compra> _compraRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCompraCommand> _validator;

        public CreateCompraCommandHandler(IRepository<Compra> compraRepository, IMapper mapper,
            IUnitOfWork unitOfWork, IValidator<CreateCompraCommand> validator)
        {
            _compraRepository = compraRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateCompraCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new FluentValidation.ValidationException(validationResult.Errors);

            var sameIdempotencyKey = await _compraRepository.GetProjectedAsync<CompraDTO>
                (c => c.IdempotencyKey == request.IdempotencyKey);

            if (sameIdempotencyKey.Any()) return sameIdempotencyKey.FirstOrDefault().Id;

            var compra = _mapper.Map<Compra>(request);
            
            await _compraRepository.AddAsync(compra);
            await _unitOfWork.SaveChangesAsync();

            return compra.Id;
        }
    }
}
