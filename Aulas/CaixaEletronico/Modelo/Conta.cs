using CaixaEletronico.Enumerador;
using CaixaEletronico.Interface;

namespace CaixaEletronico.Modelo
{
    public abstract class Conta : IConta
    {

        public virtual TipoConta TipoConta { get; private set; }

        public virtual bool Depositar(decimal value)
        {
            if (value <= 0)
                return false;

            return true;
        }

        public virtual void Extrato() {}

        public virtual bool Sacar(decimal value)
        {
            if (value <= 0.00M)
                return false;
            
            return true;
        }

        public virtual decimal Saldo()
        {
            return 0.00M;
        }
    }
}