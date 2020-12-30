using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID._2___OCP.Violacao
{
    public class DebitoConta
    {
        public void Debitar(decimal valor, string numeroConta, TipoConta tipoConta)
        {
            if (tipoConta == TipoConta.Corrente)
            {
                // Debitar da Conta Corrente
            }

            if (tipoConta == TipoConta.Poupanca)
            {
                // Debitar da Conta Poupança
            }
        }
    }
}
