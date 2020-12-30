using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID._1___SRP.Violacao
{
    public class DebitoContaCorrente
    {
        public void ValidarSaldo(decimal valor) { }
        public void DebitarConta(decimal valor) { }
        public void ImprimirComprovante(string NumeroTransacao) { }
    }
}
