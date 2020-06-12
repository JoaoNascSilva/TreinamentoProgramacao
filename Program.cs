using System;
using TreinamentoProgramacao.Model.Entities;

namespace TreinamentoProgramacao
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe um nome de Banco...");
            var nameBank = Console.ReadLine();
            
            Console.WriteLine("Informe um número de Agência...");
            var agency = Convert.ToInt32(Console.ReadLine());

            //  Banco
            var bank = new Bank("Banco Itaú", "1578");

            //  Cliente
            var customer = new Customer("João Silva", "Rua São Paulo", "4095", "Santa Bárbara DOeste");

            RunBank();

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

        public static void RunBank()
        {
            bool close = false;
            do
            {
                Console.Clear();
                Console.WriteLine("**********************");
                Console.WriteLine("** Menu **************");
                // Console.WriteLine("** 1. Adicionar Banco");
                // Console.WriteLine("** 2. Adicionar Cliente");
                Console.WriteLine("** 3. Criar Conta Cliente");
                Console.WriteLine("** 4. Depositar");
                Console.WriteLine("** 5. Sacar");
                Console.WriteLine("** 6. Extrato");
                Console.WriteLine("** 7. Informações");
                Console.WriteLine("** 8. Sair");

                var optionMenu = Convert.ToInt32(Console.ReadLine());

                switch (optionMenu)
                {
                    case 6: 
                        
                        break;
                    case 8: 
                        close = true;
                        break;
                }

            } while (!close);
        }
    }
}