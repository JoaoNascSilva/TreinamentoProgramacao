using TreinamentoProgramacao.Model.Enums;

namespace TreinamentoProgramacao.Model.Entities
{
    public class CustomerAccount
    {
        public Customer Customer { get; private set; }
        public Account Account { get; private set; }
        public ETypeAccount TypeAccount { get; private set; }

        public CustomerAccount(Customer customer, Account account, ETypeAccount typeAccount)
        {
            this.Customer = customer;
            this.Account = account;
            this.TypeAccount = typeAccount;
        }
    }
}