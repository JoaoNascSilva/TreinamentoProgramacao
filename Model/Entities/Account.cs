using TreinamentoProgramacao.Model.Enums;
using TreinamentoProgramacao.Model.Interface;

namespace TreinamentoProgramacao.Model.Entities
{
    public abstract class Account : IAccount
    {
        public virtual ETypeAccount TypeAccount => ETypeAccount.CURRENTACCOUNT;

        public virtual decimal Balance()
        {
            return 0.00M;
        }

        public virtual bool Deposity(decimal value)
        {
            if (value == 0.00M)
                return false;

            return false;
        }

        public virtual bool Withdraw(decimal value)
        {
            if (value == 0.00M)
                return false;

            return true;
        }

        public virtual void Extract() { }
    }
}