using System;
using TreinamentoProgramacao.Model.Enums;

namespace TreinamentoProgramacao.Model.Entities
{
    public class CurrentAccount : Account
    {
        private decimal _balance=0;
        private readonly decimal _rate = 0.02M;
        public override ETypeAccount TypeAccount => ETypeAccount.CURRENTACCOUNT;        

        public Bank Bank { get; private set; }
        public Customer Customer { get; private set; }
        public string NumberAccount { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public decimal Limit { get; private set; }

        public CurrentAccount(Bank bank, Customer customer)
        {
            this.Bank = bank;
            this.Customer = customer;
            this.NumberAccount = new Random().Next(999999).ToString("00000-0");
            this.CreateDate = DateTime.Now;
            this.DueDate = DateTime.Now.AddYears(5);
            this.Limit = 100.00M;
        }

        public override bool Withdraw(decimal value)
        {
            if (value <= 0)
            {
                Console.WriteLine("Valor informado é inválido.");
                return false;
            }
            if ((this._balance - value) < this.Limit)
            {
                Console.WriteLine($"Você não tem limite disponível para realizar este saque, seu saldo atual é de R$ {this.Balance()}.");
                Console.ReadKey();
            }

            this._balance -= value;
            this._balance -= (value * _rate);
            Console.WriteLine("Saque realizado com sucesso.");
            Console.WriteLine($"Valor de taxa sobre operação realizada: {(value * _rate)}");
            Console.ReadKey();
            return true;
        }        

        public override bool Deposity(decimal value)
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

        public override decimal Balance()
        {
            return _balance;
        }

        public override void Extract()
        {
            Console.WriteLine($"********************************");
            Console.WriteLine($"Nome.......: {this.Customer.Name}");
            Console.WriteLine($"Banco......: {this.Bank.Name.ToUpperCase()}");
            Console.WriteLine($"Tipo Conta.: Corrente ");
            Console.WriteLine($"Saldo......: {this.Balance()}");            
            Console.WriteLine($"********************************");
            Console.ReadKey();
        }
    }
}