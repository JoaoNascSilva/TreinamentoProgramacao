namespace TreinamentoProgramacao.Model.Interfaces
{
    public interface IAccount
    {
        bool Withdraw(decimal value);
        bool  Deposity(decimal value);
        decimal Balance();
    }
}