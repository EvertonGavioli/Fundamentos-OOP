using FundamentosOOP.Abstração;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosOOP.Polimorfismo
{
    public class Cafeteira : Eletrodomestico
    {
        public Cafeteira(string nome, int voltagem) 
            : base(nome, voltagem) { }

        public Cafeteira() 
            : base("Padrão", 220) { }

        private void AquecerAgua()
        {
            Console.WriteLine("Aquecendo água...");
        }

        private void MoerGraos()
        {
            Console.WriteLine("Moendo Grãos...");
        }

        public override void Desligar()
        {
            Console.WriteLine("Desligando Cafeteira...");
        }

        public override void Ligar()
        {
            Console.WriteLine("Ligando Cafeteira...");
        }

        public override void Testar()
        {
            base.Testar();
            Console.WriteLine("Executando teste específico para cafeteira...");
        }

        public void FazerCafe()
        {
            Testar();
            AquecerAgua();
            MoerGraos();

            Console.WriteLine("Café Pronto!!!");
        }
    }
}
