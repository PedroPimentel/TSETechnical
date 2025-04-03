using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TCE.Application.Commands.CompraCommands;
using TCE.Application.DTOs;
using TCE.Application.Queries.ClienteQueries;
using TCE.Domain.Entities;
using TCE.Presentation.Controllers;

public class PresentationTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly CompraController _controller;

    public PresentationTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new CompraController(_mediatorMock.Object);
    }

    [Fact]
    public async Task Create_ShouldReturnCreatedAtActionResult_WhenPurchaseIsSuccessful()
    {
        // Arrange
        var command = new CreateCompraCommand
        {
            ClienteId = Guid.NewGuid(),
            IdempotencyKey = Guid.NewGuid()
        };

        var expectedResponse = new MessageDTO<Guid>
        {
            IsSuccess = true,
            Data = Guid.NewGuid(),
            Description = "Compra realizada com sucesso"
        };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<CreateCompraCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResponse);

        var cancellationToken = new CancellationToken();

        // Act
        var result = await _controller.Create(command, cancellationToken);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var messageDto = Assert.IsType<MessageDTO<Guid>>(createdAtActionResult.Value);

        messageDto.Data.Should().Be(expectedResponse.Data);
        messageDto.Description.Should().Be(expectedResponse.Description);
        messageDto.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task GetById_ShouldReturnNotFound_WhenClienteIsNull()
    {
        // Arrange
        var clienteId = Guid.NewGuid();

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetClienteByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((ClienteDTO)null);

        // Act
        var result = await _controller.GetById(clienteId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }










}