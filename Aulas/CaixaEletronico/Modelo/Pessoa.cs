using System;

namespace CaixaEletronico.Modelo
{
    public class Pessoa : Entidade
    {
        public string Nome {get; set; }
        public string Endereco  {get; set; }
        public DateTime DataCriacao { get; set;}
        public bool Ativo  { get; set; }

        public Pessoa(string nome, string endereco)
        {
            this.Nome = nome;
            this.Endereco = endereco;
            this.Ativo  = true;
            this.DataCriacao = DateTime.Now;
        }
    }
}