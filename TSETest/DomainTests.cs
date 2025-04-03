using FluentAssertions;
using TCE.Domain.Entities;

namespace TSETest
{
    public class DomainTests
    {
        [Fact]
        public void AddPurchase_ShouldAddPurchase_WhenPurchaseIsValid()
        {
            // Arrange
            var cliente = new Cliente("Pedro", "teste@teste.com", "31989457863");
            var compra = new Compra("Descricao da compra", 100m, Guid.NewGuid());

            // Act
            cliente.AdicionarCompra(compra);

            // Assert
            cliente.Compras.ToList().Should().ContainSingle().And.Contain(compra);
        }

        [Fact]
        public void AddPurchase_ShouldThrowException_WhenCompraIsNull()
        {
            // Arrange
            var cliente = new Cliente("Pedro", "teste@teste.com", "31989457863");

            // Act
            Action act = () => cliente.AdicionarCompra(null);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithMessage("Compra não pode ser nula (Parameter 'compra')");
        }

        [Fact]
        public void Purchase_ShouldBeReadOnly()
        {
            // Arrange
            var cliente = new Cliente("Pedro", "teste@teste.com", "31989457863");

            // Act & Assert
            typeof(Cliente).GetProperty(nameof(Cliente.Compras))
                .CanWrite.Should().BeFalse();
        }

        [Fact]
        public void Pay_ShouldThrowException_WhenPaidAmountIsLessThanOrEqualToZero()
        {
            // Arrange
            var compra = new Compra("Descricao da compra", 100m, Guid.NewGuid());

            // Act
            Action act = () => compra.Pagar(0);

            // Assert
            act.Should().Throw<ArgumentException>()
               .WithMessage("O valor pago deve ser maior que zero.*");
        }

        [Fact]
        public void Pay_ShouldMarkAsPaidAndReturnChange_WhenAmountPaidIsGreaterThanOrEqualToTotalAmount()
        {
            // Arrange
            var compra = new Compra("Descricao da compra", 100m, Guid.NewGuid());
            var valorPago = 120m;

            // Act
            var troco = compra.Pagar(valorPago);

            // Assert
            compra.Pago.Should().BeTrue();
            compra.ValorPago.Should().Be(100);
            troco.Should().Be(20); // Troco esperado
            compra.DataPagamento.Should().NotBeNull();
        }
    }
}