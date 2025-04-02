﻿using MediatR;
using TCE.Application.DTOs;
using TCE.Domain.Core.IRepository;
using TCE.Domain.Entities;

public class PagarCompraCommandHandler : IRequestHandler<PagarCompraCommand, MessageDTO<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;

    public PagarCompraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<MessageDTO<Guid>> Handle(PagarCompraCommand request, CancellationToken cancellationToken)
    {
        var compra = await _unitOfWork.GetRepository<Compra>().GetByIdAsync(request.Id);

        if (compra is null)
        {
            return new MessageDTO<Guid>
            {
                IsSuccess = false,
                Description = "Compra não encontrada",
                Data = Guid.Empty
            };
        }

        try
        {
            compra.Pagar(request.ValorPago);
            await _unitOfWork.GetRepository<Compra>().UpdateAsync(compra);
            await _unitOfWork.SaveChangesAsync();

            return new MessageDTO<Guid>
            {
                IsSuccess = true,
                Description = "Compra paga com sucesso",
                Data = compra.Id
            };
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
