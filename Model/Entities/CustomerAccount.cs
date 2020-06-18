using TreinamentoProgramacao.Model.Enums;
using TreinamentoProgramacao.Model.Interface;

namespace TreinamentoProgramacao.Model.Entities
{
    public class CustomerAccount
    {
        public Customer Customer { get; private set; }
        public IAccount Account { get; private set; }

        public CustomerAccount(Customer customer, IAccount account, ETypeAccount typeAccount)
        {
            this.Customer = customer;
            this.Account = account;
        }
    }
}