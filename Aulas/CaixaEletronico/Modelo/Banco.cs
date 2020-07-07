namespace CaixaEletronico.Modelo
{
    public class Banco : Entidade
    {
        public string Nome { get; private set; }
        public string Agencia { get; private set; }
       
        public Banco(string name, string agency)
        {
            this.Nome = name;
            this.Agencia = agency;
        }
    }
}