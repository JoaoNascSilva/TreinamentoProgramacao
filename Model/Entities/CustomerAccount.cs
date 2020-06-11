using System;
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
    }
}