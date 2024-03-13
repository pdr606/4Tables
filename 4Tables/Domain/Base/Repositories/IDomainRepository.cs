namespace _4Tables.Domain.Base.Repositories
{
    public interface IDomainRepository<TEntity> where TEntity : class
    {
        public Task Add(TEntity entity);
    }
}
