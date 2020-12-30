using AplicacaoDemo.Tests.AutoMock;
using Features.Clientes;
using FluentAssertions;
using MediatR;
using Moq;
using Moq.AutoMock;
using System.Threading;
using Xunit;

namespace AplicacaoDemo.Tests.FluentAssertions
{
    [Collection(nameof(ClienteAutoMockerCollection))]
    public class ClienteServiceTests
    {
        private readonly ClienteAutoMockerFixture _clienteAutoMockerFixture;

        public ClienteServiceTests(ClienteAutoMockerFixture clienteAutoMockerFixture)
        {
            _clienteAutoMockerFixture = clienteAutoMockerFixture;
        }

        [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
        [Trait("Categoria", "6 - Com Fluent Assertions")]
        public void ClienteService_Adicionar_DeveSerExecutadoComSucesso()
        {
            // Arrange
            var cliente = _clienteAutoMockerFixture.GerarClienteValido();
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ClienteService>();

            // Act
            clienteService.Adicionar(cliente);

            // Assert
            cliente.EhValido().Should().BeTrue();
            mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), Times.Once);
            mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Retornar todos os clientes ativos")]
        [Trait("Categoria", "6 - Com Fluent Assertions")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarTodosClientesAtivos()
        {
            // Arrange
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ClienteService>();

            mocker.GetMock<IClienteRepository>().Setup(c => c.ObterTodos())
                .Returns(_clienteAutoMockerFixture.GerarClientesVariados());

            // Act
            var clientes = clienteService.ObterTodosAtivos();

            // Assert
            clientes.Should().HaveCountGreaterOrEqualTo(1).And.OnlyHaveUniqueItems();
            clientes.Should().NotContain(c => !c.Ativo);
            mocker.GetMock<IClienteRepository>().Verify(r => r.ObterTodos(), Times.Once);
        }
    }
}
