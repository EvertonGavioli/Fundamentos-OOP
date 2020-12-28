using FundamentosOOP.Herança;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosOOP
{
    public static class ExecutarHeranca
    {
        public static void Executar()
        {
            PessoaFisica pessoaFisica = new PessoaFisica("Nome Pessoa 1", "123456");
            pessoaFisica.ValidarCPF();

            PessoaJuridica pessoaJuridica = new PessoaJuridica("Nome Pessoa 2", "1111");
            pessoaJuridica.ValidarCNPJ();

            Console.WriteLine(pessoaFisica.ToString());
            Console.WriteLine(pessoaJuridica.ToString());
        }
    }
}
