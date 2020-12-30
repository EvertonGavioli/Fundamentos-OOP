using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID._1___SRP.Solucao
{
    public class DebitoContaCorrente
    {
        public void DebitarConta(decimal valor) { }
    }

    public class SaldoContaCorrente
    {
        public void ValidarSaldo(decimal valor) { }
    }

    public class ComprovanteContaCorrente
    {
        public void ImprimirComprovante(string NumeroTransacao) { }
    }
}
