using System;
using System.Collections.Generic;
using TreinamentoProgramacao.Model.Enums;
using TreinamentoProgramacao.Model.Interfaces;

namespace TreinamentoProgramacao.Model.Entities
{
    public class CustomerAccount : Entity
    {
        public Customer Customer { get; private set; }
        public ETypeAccount TypeAccount { get; private set; }
        public IAccount Account { get; private set; }

        public CustomerAccount(Customer customer, IAccount account)
        {
            this.Customer = customer;
            this.Account = account;

            if (account.GetType() == typeof(CurrentAccount))
                this.TypeAccount = ETypeAccount.CURRENTACCOUNT;
            else
                this.TypeAccount = ETypeAccount.SAVINGSACCOUNT;

            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            var typeAccount = ETypeAccount.CURRENTACCOUNT == this.TypeAccount ? " corrente " : " poupança ";
            return $"Conta { typeAccount } criada para: {this.Customer.Name}.";
        }

        public void Extract()
        {
            var typeAccount = ETypeAccount.CURRENTACCOUNT == this.TypeAccount ? "Corrente" : "Poupança";

            Console.WriteLine($"********************************");
            Console.WriteLine($"Nome.......: {this.Customer.Name}");
            Console.WriteLine($"Tipo Conta.: {typeAccount}");
            Console.WriteLine($"Saldo......: {this.Account.Balance()}");
            Console.WriteLine($"********************************");
        }
    }
}