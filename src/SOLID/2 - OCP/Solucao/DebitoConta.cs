using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID._2___OCP.Solucao
{
    public abstract class DebitoConta
    {
        public string NumeroTransacao { get; set; }

        public abstract string Debitar(decimal valor, string conta);

        public string GerarNumeroTransacao()
        {
            return DateTime.Now.ToString();
        }
    }
}
