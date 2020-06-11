namespace TreinamentoProgramacao.Model.Entities
{
    public class Entity
    {
        public string Id { get; private set; }

        public Entity()
        {
            this.Id = System.Guid.NewGuid().ToString();
        }
    }
}