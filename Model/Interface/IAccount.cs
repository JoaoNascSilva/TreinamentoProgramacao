using TreinamentoProgramacao.Model.Enums;

namespace TreinamentoProgramacao.Model.Interface
{
    public interface IAccount
    {
        ETypeAccount TypeAccount { get; }

        bool Deposity(decimal value);
        bool Withdraw(decimal value);
        decimal Balance();
        void Extract();
    }
}