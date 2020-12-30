using AplicacaoDemo.TestesBasicos;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AplicacaoDemo.Tests.Basicos
{
    public class CalculadoraTests
    {
        [Fact]
        public void Calculadora_Somar_DeveRetornarASomaDosValores()
        {
            // Arrange
            Calculadora calculadora = new Calculadora();

            // Act
            var resultado = calculadora.Somar(2, 2);

            // Assert
            Assert.Equal(4, resultado);
        }

        [Fact]
        public void Calculadora_Multiplicar_DeveRetornarOValorDaMultiplicacao()
        {
            // Arrange
            Calculadora calculadora = new Calculadora();

            // Act
            var resultado = calculadora.Multiplicar(5, 5);

            // Assert
            Assert.Equal(25, resultado);
        }

        [Theory]
        [InlineData(1,1,2)]
        [InlineData(3, 3, 6)]
        [InlineData(5, 5, 10)]
        [InlineData(10, 10, 20)]
        [InlineData(100, 100, 200)]
        public void Calculadora_Somar_DeveRetornarASomaDosValoresCorretos(double v1, double v2, double resultado)
        {
            // Arrange
            Calculadora calculadora = new Calculadora();

            // Act
            var retorno = calculadora.Somar(v1, v2);

            // Assert
            Assert.Equal(resultado, retorno);
        }
    }
}
