using System;
using CaixaEletronico.Enumerador;
using CaixaEletronico.Modelo;

namespace CaixaEletronico
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoa = new Pessoa("Joao Silva", "SBO");
            var banco = new Banco("Itau", "1578");
            var contaCorrente = new ContaCorrente(banco, pessoa);

            contaCorrente.Depositar(1000.00M);
            contaCorrente.Depositar(500.00M);
            contaCorrente.Extrato();

            contaCorrente.Sacar(800.00M);
            contaCorrente.Extrato();

            
        }
    }
}