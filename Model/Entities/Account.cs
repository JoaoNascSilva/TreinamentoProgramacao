namespace TreinamentoProgramacao.Model.Entities
{
    public abstract class Account
    {
        public abstract bool Withdraw(decimal value);
        public abstract bool Deposity(decimal value);
        public abstract decimal Balance();
        public abstract void Extract();
    }
}