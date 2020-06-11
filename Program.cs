using System;
using TreinamentoProgramacao.Model.Entities;

namespace TreinamentoProgramacao
{
    class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank("Banco Itaú", "1578");

            var customer = new Customer("João Silva", "Rua São Paulo", "4095", "Santa Bárbara DOeste");

            var currentAccount = new SavingsAccount(bank, customer);
            var customerAccount = new CustomerAccount(customer, currentAccount);

            customerAccount.Account.Deposity(1000);
            Console.WriteLine($"Saldo atual é: {customerAccount.Account.Balance()}");

            customerAccount.Account.Deposity(1000);
            customerAccount.Account.Withdraw(100);
            Console.WriteLine($"Saldo atual é: {customerAccount.Account.Balance()}");
        }
    }
}
