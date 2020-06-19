using System.Linq;
using System.Collections.Generic;
using System;
using TreinamentoProgramacao.Model.Entities;
using TreinamentoProgramacao.Model.Enums;

namespace TreinamentoProgramacao
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Customer> listCustomer = new List<Customer>();
            List<Bank> listBank = new List<Bank>();
            List<CustomerAccount> listCustomerAccount = new List<CustomerAccount>();

            ExecuteMenu(listBank, listCustomer, listCustomerAccount);

            // //  Realiza Depósito
            // customerAccount.Account.Deposity(1000);
            // customerAccount.Account.Deposity(1000);
            // Console.WriteLine($"Saldo atual é: {customerAccount.Account.Balance()}");

            // //  Realiza Saque
            // customerAccount.Account.Withdraw(100);
            // Console.WriteLine($"Saldo atual é: {customerAccount.Account.Balance()}");
            // customerAccount.Account.Extract();
        }

        public static void AddCustomer(IList<Customer> listCustomer)
        {
            Console.WriteLine("Informe os dados de Cliente na respectiva sequencia pressionando enter: Nome, Endereco, Numero, Cidade");
            var customerName = Console.ReadLine();
            var customerEndereco = Console.ReadLine();
            var customerNumero = Console.ReadLine();
            var customerCidade = Console.ReadLine();

            listCustomer.Add(new Customer(customerName, customerEndereco, customerNumero, customerCidade));
        }

        public static void AddBank(IList<Bank> listBank)
        {
            Console.WriteLine("Informe os dados do banco na respectiva sequencia pressionando enter: Nome, Agencia");
            var bankName = Console.ReadLine();
            var bankAgency = Console.ReadLine();
            listBank.Add(new Bank(bankName, bankAgency));
        }

        public static void AddCustomerAccount(IList<CustomerAccount> listCustomerAccount, IList<Customer> listCustomer, IEnumerable<Bank> listBank)
        {
            Func<string, Customer, Bank, CustomerAccount> createCustomerAccountForType = (typeAccount, customer, bank) =>
            {
                CustomerAccount localCustomerAccount;

                if (typeAccount == "1")
                    localCustomerAccount = new CustomerAccount(customer, new CurrentAccount(bank, customer), ETypeAccount.CURRENTACCOUNT);
                else
                    localCustomerAccount = new CustomerAccount(customer, new SavingAccount(bank, customer), ETypeAccount.SAVINGACCOUNT);

                return localCustomerAccount;
            };

            Func<string, IList<Customer>, Customer> selectCustomer = (idCustomer, _listCustomer) =>
            {
                var customer = _listCustomer.FirstOrDefault(x => x.Id == idCustomer);
                return customer;
            };

            Func<string, IEnumerable<Bank>, Bank> selectBank = (idBank, _listBank) =>
            {
                var bank = _listBank.FirstOrDefault(x => x.Id == idBank);
                return bank;
            };

            Console.WriteLine("Deseja criar conta para qual cliente ?\nInforme o identificador do cliente.");
            var idCustomer = Console.ReadLine();
            var customer = selectCustomer(idCustomer, listCustomer);
            if (customer == null)
            {
                Console.WriteLine("Não Foi encontrado nenhum cliente com o identificador informado.");
                return;
            }
            Console.WriteLine("Deseja criar conta para qual cliente ?\nInforme o identificador do cliente.");
            var idBank = Console.ReadLine();
            var bank = selectBank(idBank, listBank);
            if (bank == null)
            {
                Console.WriteLine("Não Foi encontrado nenhum Banco com o identificador informado.");
                return;
            }

            Console.WriteLine("Selecione o tipo de conta que deseja criar: [ 1 ] Conta Corrente [ 2 ] Conta Poupança");
            listCustomerAccount.Add(createCustomerAccountForType(Console.ReadLine(), customer, bank));
        }

        public static void GetListCustomer(IList<Customer> listCustomer)
        {
            Console.Clear();
            foreach (var customer in listCustomer)
            {
                Console.WriteLine(string.Format($"Identificador: {customer.Id} Nome: {customer.Name}"));
            }
        }

        public static void ExecuteMenu(IList<Bank> listBank, IList<Customer> listCustomer, IList<CustomerAccount> listCustomerAccount)
        {
            bool cancelLoop = false;
            do
            {
                Console.Clear();
                Console.WriteLine("**********************");
                Console.WriteLine("** Menu **************");
                Console.WriteLine("** 1. Adicionar Banco");
                Console.WriteLine("** 2. Adicionar Cliente");

                if (listCustomer != null && listBank != null)
                {
                    Console.WriteLine("** 3. Criar Conta Cliente");
                    //AddCustomerAccount(listCustomerAccount);
                }

                if (listCustomerAccount != null)
                {
                    Console.WriteLine("** 4. Depositar");
                    Console.WriteLine("** 5. Sacar");
                    Console.WriteLine("** 6. Extrato");
                }

                Console.WriteLine("** 7. Listar Clientes");
                Console.WriteLine("** 8. Informações");
                Console.WriteLine("** 9. Sair");

                switch (Console.ReadLine())
                {
                    case "1":
                        cancelLoop = false;
                        break;
                    case "2":
                        AddCustomer(listCustomer);
                        break;
                    case "7":
                        GetListCustomer(listCustomer);
                        Console.ReadKey();
                        break;
                    case "9":
                        cancelLoop = true;
                        Console.WriteLine("Programa Finalizado...");
                        break;
                }
            } while (!cancelLoop);
        }
    }
}