using System;
using TreinamentoProgramacao.Model.Entities;

namespace TreinamentoProgramacao
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Banco
            var bank = new Bank("Banco Itaú", "1578");

            //  Cliente
            var customer = new Customer("João Silva", "Rua São Paulo", "4095", "Santa Bárbara DOeste");

            //  ContaCorrente
            var currentAccount = new CurrentAccount(bank, customer);

            //  Conta Cliente
            var customerAccount = new CustomerAccount(customer, currentAccount);

            //  Realiza Depósito
            customerAccount.Account.Deposity(1000);
            customerAccount.Account.Deposity(1000);
            Console.WriteLine($"Saldo atual é: {customerAccount.Account.Balance()}");

            //  Realiza Saque
            customerAccount.Account.Withdraw(100);
            Console.WriteLine($"Saldo atual é: {customerAccount.Account.Balance()}");

            Console.WriteLine($"Ag.: {currentAccount.Bank.Agency} - Ct.: {currentAccount.NumberAccount}");
            customerAccount.Extract();
        }
    }
}