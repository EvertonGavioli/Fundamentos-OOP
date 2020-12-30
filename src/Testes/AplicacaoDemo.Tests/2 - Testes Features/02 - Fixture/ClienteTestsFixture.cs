using Features.Clientes;
using System;
using Xunit;

namespace AplicacaoDemo.Tests.TestesFeatures
{
    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection : ICollectionFixture<ClienteTestsFixture> { }

    public class ClienteTestsFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            var cliente = new Cliente(
                    Guid.NewGuid(),
                    "Everton",
                    "Gavioli",
                    DateTime.Now.AddYears(-30),
                    "everton@yahoo.com",
                    true,
                    DateTime.Now);

            return cliente;
        }

        public Cliente GerarClienteInvalido()
        {
            var cliente = new Cliente(
                    Guid.NewGuid(),
                    "",
                    "",
                    DateTime.Now,
                    "",
                    false,
                    DateTime.Now);

            return cliente;
        }

        public void Dispose()
        {
        }
    }
}
