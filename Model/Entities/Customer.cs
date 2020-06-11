namespace TreinamentoProgramacao.Model.Entities
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public bool Active { get; private set; }

        public Customer(string name, string address, string number, string city)
        {
            this.Name = name;
            this.Address = address;
            this.Number = number;
            this.City = city;
            this.Active = true;
        }

    }
}