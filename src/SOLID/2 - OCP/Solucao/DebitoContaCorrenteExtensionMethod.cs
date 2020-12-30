using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID._2___OCP.Solucao
{
    public static class DebitoContaCorrenteExtensionMethod
    {
        public static string DebitarContaCorrente(this DebitoConta debitoConta)
        {
            // Debitar Conta Corrente

            // Gerar Número Transação
            return debitoConta.GerarNumeroTransacao();
        }
    }
}
