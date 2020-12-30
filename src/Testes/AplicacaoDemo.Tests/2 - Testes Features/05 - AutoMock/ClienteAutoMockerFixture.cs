using Bogus;
using Bogus.DataSets;
using Features.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AplicacaoDemo.Tests.AutoMock
{
    [CollectionDefinition(nameof(ClienteAutoMockerCollection))]
    public class ClienteAutoMockerCollection : ICollectionFixture<ClienteAutoMockerFixture>
    {
    }

    public class ClienteAutoMockerFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            return GerarClientes(1, true).FirstOrDefault();
        }

        public IEnumerable<Cliente> GerarClientesVariados()
        {
            var clientes = new List<Cliente>();

            clientes.AddRange(GerarClientes(50, true));
            clientes.AddRange(GerarClientes(50, false));

            return clientes;
        }

        private IEnumerable<Cliente> GerarClientes(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var clientes = new Faker<Cliente>("pt_BR")
                .CustomInstantiator(f => new Cliente(
                    Guid.NewGuid(),
                    f.Name.FirstName(genero),
                    f.Name.LastName(genero),
                    f.Date.Past(70, DateTime.Now.AddYears(-18)),
                    "",
                    ativo,
                    DateTime.Now))
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()));

            return clientes.Generate(quantidade);
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
