using System;

namespace FundamentosOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("### Fundamentos OOP ###");
            Console.WriteLine("#######################");
            Console.WriteLine();
            Console.WriteLine("1 - Herança");
            Console.WriteLine("2 - Abstração, Polimorfismo e Encapsulamento");
            Console.WriteLine();
            Console.WriteLine("Dígite o número para efetuar execução ");

            var value = Console.ReadLine();
            
            Console.WriteLine();

            switch (value)
            {
                case "1":
                    ExecutarHeranca.Executar();
                    break;
                case "2":
                    ExecutarAutomacao.ServirCafe();
                    break;
                default:
                    break;
            }


            Console.ReadKey();
        }
    }
}
