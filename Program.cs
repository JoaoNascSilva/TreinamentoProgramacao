using System;
using TreinamentoProgramacao.Model.Entities;
using TreinamentoProgramacao.Model.Enums;

namespace TreinamentoProgramacao
{
    public class Program
    {
        static void Main(string[] args)
        {
            //  Cliente
            var customer = new Customer("João Silva", "Rua São Paulo", "4095", "Santa Bárbara DOeste");

            Console.WriteLine("Informe: [1] Para - Conta Corrente [2] Para - Conta Poupança");

            CustomerAccount customerAccount;
            if (Console.ReadLine() == "1")
                customerAccount = new CustomerAccount(customer, new CurrentAccount(new Bank("Banco Itaú", "1578"), customer), ETypeAccount.CURRENTACCOUNT);
            else
                customerAccount = new CustomerAccount(customer, new SavingAccount(new Bank("Caixa Econômica Federal", "5455"), customer), ETypeAccount.SAVINGACCOUNT);


            //ExecuteMenu();

            //  Realiza Depósito
            customerAccount.Account.Deposity(1000);
            customerAccount.Account.Deposity(1000);
            Console.WriteLine($"Saldo atual é: {customerAccount.Account.Balance()}");

            //  Realiza Saque
            customerAccount.Account.Withdraw(100);
            Console.WriteLine($"Saldo atual é: {customerAccount.Account.Balance()}");
            customerAccount.Account.Extract();
        }


        public static void ExecuteMenu()
        {
            bool cancelLoop = false;
            do
            {
                Console.Clear();
                Console.WriteLine("**********************");
                Console.WriteLine("** Menu **************");
                Console.WriteLine("** 1. Adicionar Banco");
                Console.WriteLine("** 2. Adicionar Cliente");
                Console.WriteLine("** 3. Criar Conta Cliente");
                Console.WriteLine("** 4. Depositar");
                Console.WriteLine("** 5. Sacar");
                Console.WriteLine("** 6. Extrato");
                Console.WriteLine("** 7. Informações");
                Console.WriteLine("** 8. Sair");

                switch (Console.ReadLine())
                {
                    case "1":
                        cancelLoop = false;
                        break;
                    case "8":
                        cancelLoop = true;
                        break;
                }                
            }while (!cancelLoop);
        }
    }
}