using System;
using TreinamentoProgramacao.Model.Interfaces;

namespace TreinamentoProgramacao.Model.Entities
{
    public class SavingsAccount : Entity, IAccount
    {
        private decimal _balance;

        public Bank Bank { get; private set; }
        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public string NumberAccount { get; private set; }

        public SavingsAccount(Bank bank, Customer customer)
        {
            this.Bank = bank;
            this.Customer = Customer;
            this.CreateDate = DateTime.Now;
            this.DueDate = DateTime.Now.AddYears(10);
            this.NumberAccount = new Random().Next(99999999).ToString("00.0000-00");
        }

        public bool Withdraw(decimal value)
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

        public bool Deposity(decimal value)
        {
            if (value <= 0)
            {
                Console.WriteLine("Valor informado é inválido.");
                return false;
            }

            this._balance += value;
            return true;            
        }

        public decimal Balance()
        {
            return this._balance;
        }
    }
}