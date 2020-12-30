using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID._2___OCP.Solucao
{
    public class DebitoContaCorrente : DebitoConta
    {
        public override string Debitar(decimal valor, string conta)
        {
            // Efetuar Débito

            // Gerar Número Transaçao
            return GerarNumeroTransacao();
        }
    }
}
