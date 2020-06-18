using System;

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
            }

            this._balance -= value;

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
            Console.WriteLine($"Tipo Conta.: Poupança ");
            Console.WriteLine($"Saldo......: {this.Balance()}");
            Console.WriteLine($"********************************");
        }
    }
}