namespace CaixaEletronico.Interface
{
    public interface IConta
    {
        void Extrato();
        bool Depositar(decimal value);
        bool Sacar(decimal value);
        decimal Saldo();
    }
}