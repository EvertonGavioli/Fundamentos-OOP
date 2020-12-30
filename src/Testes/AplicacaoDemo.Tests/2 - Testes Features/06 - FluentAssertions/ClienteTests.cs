using AplicacaoDemo.Tests.AutoMock;
using FluentAssertions;
using Xunit;

namespace AplicacaoDemo.Tests.FluentAssertions
{
    [Collection(nameof(ClienteAutoMockerCollection))]
    public class ClienteTests
    {
        private readonly ClienteAutoMockerFixture _clienteAutoMockerFixture;

        public ClienteTests(ClienteAutoMockerFixture clienteAutoMockerFixture)
        {
            _clienteAutoMockerFixture = clienteAutoMockerFixture;
        }

        [Fact(DisplayName = "Novo Cliente deve ser válido")]
        [Trait("Categoria", "6 - Com Fluent Assertions")]
        public void Cliente_NovoCliente_DeveSerValido()
        {
            // Arrange
            var cliente = _clienteAutoMockerFixture.GerarClienteValido();

            // Act
            var resultado = cliente.EhValido();

            // Assert
            resultado.Should().BeTrue();
            cliente.ValidationResult.Errors.Count.Should().BeLessOrEqualTo(0);
        }

        [Fact(DisplayName = "Novo Cliente deve ser inválido")]
        [Trait("Categoria", "6 - Com Fluent Assertions")]
        public void Cliente_NovoCliente_DeveSerInvalido()
        {
            // Arrange
            var cliente = _clienteAutoMockerFixture.GerarClienteInvalido();

            // Act
            var resultado = cliente.EhValido();

            // Assert
            resultado.Should().BeFalse();
            cliente.ValidationResult.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
