using FundamentosOOP.Polimorfismo;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosOOP
{
    public static class ExecutarAutomacao
    {
        public static void ServirCafe()
        {
            Cafeteira cafeteira = new Cafeteira("Café Expresso", 110);

            cafeteira.Ligar();
            cafeteira.FazerCafe();
            cafeteira.Desligar();
        }
    }
}
