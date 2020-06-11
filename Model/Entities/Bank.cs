namespace TreinamentoProgramacao.Model.Entities
{
    public class Bank : Entity
    {
        public string Name { get; private set; }
        public string Agency { get; private set; }
       
        public Bank(string name, string agency)
        {
            this.Name = name;
            this.Agency = agency;
        }
    }
}