namespace Domain.Shared.Models
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }
    }
}
