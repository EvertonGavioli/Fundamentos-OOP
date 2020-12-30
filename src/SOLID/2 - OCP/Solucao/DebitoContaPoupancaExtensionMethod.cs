using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID._2___OCP.Solucao
{
    public static class DebitoContaPoupancaExtensionMethod
    {
        public static string DebitarContaPoupanca(this DebitoConta debitoConta)
        {
            // Debitar Conta Poupança

            // Gerar Número Transação
            return debitoConta.GerarNumeroTransacao();
        }
    }
}
