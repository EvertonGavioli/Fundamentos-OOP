using Features.Clientes;
using System;
using Xunit;

namespace AplicacaoDemo.Tests.TestesFeatures
{
    public class ClienteTests
    {
        [Fact(DisplayName = "Novo Cliente deve ser válido")]
        [Trait("Categoria", "1 - Traits")]
        public void Cliente_NovoCliente_DeveSerValido()
        {
            // Arrange
            var cliente = new Cliente(
                Guid.NewGuid(),
                "Everton",
                "Gavioli",
                DateTime.Now.AddYears(-30),
                "everton@yahoo.com",
                true,
                DateTime.Now);

            // Act
            var resultado = cliente.EhValido();

            // Assert
            Assert.True(resultado);
            Assert.Equal(0, cliente.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Novo Cliente deve ser inválido")]
        [Trait("Categoria", "1 - Traits")]
        public void Cliente_NovoCliente_DeveSerInvalido()
        {
            // Arrange
            var cliente = new Cliente(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                "",
                false,
                DateTime.Now);

            // Act
            var resultado = cliente.EhValido();

            // Assert
            Assert.False(resultado);
            Assert.NotEqual(0, cliente.ValidationResult.Errors.Count);
        }
    }
}
