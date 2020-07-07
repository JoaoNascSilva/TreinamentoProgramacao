using System;
using CaixaEletronico.Enumerador;

namespace CaixaEletronico.Modelo
{
    public class ContaCorrente : Conta
    {
        private decimal _balance = 0;
        private readonly decimal _rate = 0.02M;

        public override TipoConta TipoConta => TipoConta.ContaCorrente;
        public Banco Banco { get; private set; }
        public Pessoa Pessoa { get; private set; }
        public string NumeroConta { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public decimal Limite { get; private set; }

        public ContaCorrente(Banco banco, Pessoa pessoa)
        {
            this.Banco = banco;
            this.Pessoa = pessoa;
            this.NumeroConta = new Random().Next(999999).ToString("00000-0");
            this.DataCriacao = DateTime.Now;
            this.DataVencimento = DateTime.Now.AddYears(5);
            this.Limite = 100.00M;
        }

        public override bool Sacar(decimal value)
        {
            if (value <= 0)
            {
                Console.WriteLine("Valor informado é inválido.");
                return false;
            }

            if ((this._balance - value) < this.Limite)
            {
                Console.WriteLine($"Você não tem limite disponível para realizar este saque, seu saldo atual é de R$ {this.Saldo()}.");
                Console.ReadKey();
            }

            this._balance -= value;
            this._balance -= (value * _rate);
            Console.WriteLine("Saque realizado com sucesso.");
            Console.WriteLine($"Valor de taxa sobre operação realizada: {(value * _rate)}");
            Console.ReadKey();
            return true;
        }

        public override bool Depositar(decimal value)
        {
            if (value <= 0)
            {
                Console.WriteLine("Valor informado é inválido.");
                return false;
            }

            this._balance += value;
            Console.WriteLine($"Depósito no valor de R$ {value} realizado com sucesso.");
            Console.ReadKey();
            return true;
        }

        public override decimal Saldo()
        {
            return _balance;
        }

        public override void Extrato()
        {
            Console.WriteLine($"********************************");
            Console.WriteLine($"Nome.......: {this.Pessoa.Nome}");
            Console.WriteLine($"Banco......: {this.Banco.Nome}");
            Console.WriteLine($"Tipo Conta.: Corrente ");
            Console.WriteLine($"Saldo......: {this.Saldo()}");
            Console.WriteLine($"********************************");
            Console.ReadKey();
        }
    }
}