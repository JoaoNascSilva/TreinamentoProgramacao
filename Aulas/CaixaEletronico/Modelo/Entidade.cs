using System;

namespace CaixaEletronico
{
    public class Entidade
    {
        public string Identificador { get; private set; }

        public Entidade()
        {
             this.Identificador = Guid.NewGuid().ToString().Substring(0, 2);
        }
    }
}