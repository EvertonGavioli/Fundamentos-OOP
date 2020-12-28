using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosOOP.Abstração
{
    public abstract class Eletrodomestico
    {
        private readonly string _nome;
        private readonly int _voltagem;

        protected Eletrodomestico(string nome, int voltagem)
        {
            _nome = nome;
            _voltagem = voltagem;
        }

        public abstract void Ligar();
        public abstract void Desligar();

        public virtual void Testar()
        {
            Console.WriteLine("Efetuando teste padrão");
        }
    }
}
