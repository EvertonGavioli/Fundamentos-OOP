using System;

namespace FundamentosOOP.Herança
{
    public class PessoaFisica : Pessoa
    {
        public string CPF { get; set; }

        public PessoaFisica(string nome, string cpf)
        {
            this.Nome = nome;
            this.CPF = cpf;
            Console.WriteLine("Criando uma intância de Pessoa Física");
        }

        public bool ValidarCPF()
        {
            if (CPF.Length != 11)
            {
                Console.WriteLine("CPF inválido");
                return false;
            }

            Console.WriteLine("CPF válido");
            return true;
        }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
