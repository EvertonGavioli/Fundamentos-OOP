using Xunit;

namespace AplicacaoDemo.Tests.TestesFeatures
{
    [Collection(nameof(ClienteCollection))]
    public class ClientTestsFakeWithFixture
    {
        private readonly ClienteTestsFixture _clienteTestsFixture;

        public ClientTestsFakeWithFixture(ClienteTestsFixture clienteTestsFixture)
        {
            _clienteTestsFixture = clienteTestsFixture;
        }

        [Fact(DisplayName = "Novo Cliente deve ser válido")]
        [Trait("Categoria", "2 - Fixture")]
        public void Cliente_NovoCliente_DeveSerValido()
        {
            // Arrange
            var cliente = _clienteTestsFixture.GerarClienteValido();

            // Act
            var resultado = cliente.EhValido();

            // Assert
            Assert.True(resultado);
            Assert.Equal(0, cliente.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Novo Cliente deve ser inválido")]
        [Trait("Categoria", "2 - Fixture")]
        public void Cliente_NovoCliente_DeveSerInvalido()
        {
            // Arrange
            var cliente = _clienteTestsFixture.GerarClienteInvalido();

            // Act
            var resultado = cliente.EhValido();

            // Assert
            Assert.False(resultado);
            Assert.NotEqual(0, cliente.ValidationResult.Errors.Count);
        }
    }
}
