namespace OnlineStore.Entities.Entities
{
    public interface IBaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
    public interface IBaseEntity : IBaseEntity<int>
    {
    }

    public interface ISoftDeleteEnabledBase
    {
        public bool IsDeleted { get; set; }
    }
}
