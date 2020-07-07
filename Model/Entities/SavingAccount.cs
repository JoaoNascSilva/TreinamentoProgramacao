using System;
using TreinamentoProgramacao.Model.Enums;

namespace TreinamentoProgramacao.Model.Entities
{
    public class SavingAccount : Account
    {
        private decimal _balance;

        public Bank Bank { get; private set; }
        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public string NumberAccount { get; private set; }
        public override ETypeAccount TypeAccount => ETypeAccount.SAVINGACCOUNT;

        public SavingAccount(Bank bank, Customer customer)
        {
            this.Bank = bank;
            this.Customer = customer;
            this.CreateDate = DateTime.Now;
            this.DueDate = DateTime.Now.AddYears(10);
            this.NumberAccount = new Random().Next(99999999).ToString("00.0000-00");
        }

        public override  bool Withdraw(decimal value)
        {
            if (value <= 0)
            {
                Console.WriteLine("Valor informado é inválido.");
                return false;
            }
            if ( (this._balance - value) < 0 )
            {
                Console.WriteLine($"Saldo insuficiente, seu saldo atual é de R$ {this.Balance()}.");
                Console.ReadKey();
            }

            this._balance -= value;
            Console.WriteLine("Saque realizado com sucesso.");
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
            return this._balance;
        }

        public override void Extract()
        {
            Console.WriteLine($"********************************");
            Console.WriteLine($"Nome.......: {this.Customer.Name}");
            Console.WriteLine($"Banco......: {this.Bank.Name}");            
            Console.WriteLine($"Tipo Conta.: Poupança ");
            Console.WriteLine($"Saldo......: {this.Balance()}");
            Console.WriteLine($"********************************");
            Console.ReadKey();
        }
    }
}