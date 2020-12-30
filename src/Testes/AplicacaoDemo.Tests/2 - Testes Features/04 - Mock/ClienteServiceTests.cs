using AplicacaoDemo.Tests.TestesFeaturesFake;
using Features.Clientes;
using MediatR;
using Moq;
using System.Linq;
using System.Threading;
using Xunit;

namespace AplicacaoDemo.Tests.Mock
{
    [Collection(nameof(ClienteFakeCollection))]
    public class ClienteServiceTests
    {
        private readonly ClienteTestsFakeFixture _clienteTestsFakeFixture;

        public ClienteServiceTests(ClienteTestsFakeFixture clienteTestsFakeFixture)
        {
            _clienteTestsFakeFixture = clienteTestsFakeFixture;
        }

        [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
        [Trait("Categoria", "4 - Cliente Service Testes com Mock")]
        public void ClienteService_Adicionar_DeveSerExecutadoComSucesso()
        {
            // Arrange
            var cliente = _clienteTestsFakeFixture.GerarClienteValido();
            var clienteRepo = new Mock<IClienteRepository>();
            var mediatr = new Mock<IMediator>();

            var clienteService = new ClienteService(clienteRepo.Object, mediatr.Object);

            // Act
            clienteService.Adicionar(cliente);

            // Assert
            Assert.True(cliente.EhValido());
            clienteRepo.Verify(r => r.Adicionar(cliente), Times.Once);
            mediatr.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Retornar todos os clientes ativos")]
        [Trait("Categoria", "4 - Cliente Service Testes com Mock")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarTodosClientesAtivos()
        {
            // Arrange
            var clienteRepo = new Mock<IClienteRepository>();
            var mediatr = new Mock<IMediator>();

            clienteRepo.Setup(c => c.ObterTodos())
                .Returns(_clienteTestsFakeFixture.GerarClientesVariados());

            var clienteService = new ClienteService(clienteRepo.Object, mediatr.Object);

            // Act
            var clientes = clienteService.ObterTodosAtivos();

            // Assert
            Assert.True(clientes.Any());
            Assert.False(clientes.Count(clientes => !clientes.Ativo) > 0);
            clienteRepo.Verify(r => r.ObterTodos(), Times.Once);
        }
    }
}
