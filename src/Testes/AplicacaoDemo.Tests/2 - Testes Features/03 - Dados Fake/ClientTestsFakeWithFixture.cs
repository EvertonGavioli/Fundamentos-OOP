using Xunit;

namespace AplicacaoDemo.Tests.TestesFeaturesFake
{
    [Collection(nameof(ClienteFakeCollection))]
    public class ClientTestsFakeWithFixture
    {
        private readonly ClienteTestsFakeFixture _clienteTestsFakeFixture;

        public ClientTestsFakeWithFixture(ClienteTestsFakeFixture clienteTestsFakeFixture)
        {
            _clienteTestsFakeFixture = clienteTestsFakeFixture;
        }

        [Fact(DisplayName = "Novo Cliente deve ser válido")]
        [Trait("Categoria", "3 - Dados Fake")]
        public void Cliente_NovoCliente_DeveSerValido()
        {
            // Arrange
            var cliente = _clienteTestsFakeFixture.GerarClienteValido();

            // Act
            var resultado = cliente.EhValido();

            // Assert
            Assert.True(resultado);
            Assert.Equal(0, cliente.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Novo Cliente deve ser inválido")]
        [Trait("Categoria", "3 - Dados Fake")]
        public void Cliente_NovoCliente_DeveSerInvalido()
        {
            // Arrange
            var cliente = _clienteTestsFakeFixture.GerarClienteInvalido();

            // Act
            var resultado = cliente.EhValido();

            // Assert
            Assert.False(resultado);
            Assert.NotEqual(0, cliente.ValidationResult.Errors.Count);
        }
    }
}
