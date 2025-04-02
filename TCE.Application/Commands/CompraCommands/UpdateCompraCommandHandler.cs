using AutoMapper;
using MediatR;
using TCE.Application.DTOs;
using TCE.Domain.Core.IRepository;
using TCE.Domain.Entities;

namespace TCE.Application.Commands.CompraCommands
{
    public class UpdateCompraCommandHandler : IRequestHandler<UpdateCompraCommand, CompraDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCompraCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CompraDTO> Handle(UpdateCompraCommand request, CancellationToken cancellationToken)
        {
            var compra = await _unitOfWork.GetRepository<Compra>().GetByIdAsync(request.Id);

            _mapper.Map(request, compra);

            await _unitOfWork.GetRepository<Compra>().UpdateAsync(compra);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CompraDTO>(compra);
        }
    }
}
