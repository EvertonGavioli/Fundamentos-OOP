using System;

namespace FundamentosOOP.Herança
{
    public class PessoaJuridica : Pessoa
    {
        public string CNPJ { get; set; }

        public PessoaJuridica(string nome, string cnpj)
        {
            this.Nome = nome;
            this.CNPJ = cnpj;
            Console.WriteLine("Criando uma intância de Pessoa Jurídica");
        }

        public bool ValidarCNPJ()
        {
            if (CNPJ.Length != 14)
            {
                Console.WriteLine("CNPJ inválido");
                return false;
            }

            Console.WriteLine("CNPJ válido");
            return true;
        }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
