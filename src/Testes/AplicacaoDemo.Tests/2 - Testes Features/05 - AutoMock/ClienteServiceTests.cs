using Features.Clientes;
using MediatR;
using Moq;
using Moq.AutoMock;
using System.Linq;
using System.Threading;
using Xunit;

namespace AplicacaoDemo.Tests.AutoMock
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
        [Trait("Categoria", "5 - Cliente Service Testes com AutoMock")]
        public void ClienteService_Adicionar_DeveSerExecutadoComSucesso()
        {
            // Arrange
            var cliente = _clienteAutoMockerFixture.GerarClienteValido();
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ClienteService>();

            // Act
            clienteService.Adicionar(cliente);

            // Assert
            Assert.True(cliente.EhValido());
            mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), Times.Once);
            mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Retornar todos os clientes ativos")]
        [Trait("Categoria", "5 - Cliente Service Testes com AutoMock")]
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
            Assert.True(clientes.Any());
            Assert.False(clientes.Count(clientes => !clientes.Ativo) > 0);
            mocker.GetMock<IClienteRepository>().Verify(r => r.ObterTodos(), Times.Once);
        }
    }
}
