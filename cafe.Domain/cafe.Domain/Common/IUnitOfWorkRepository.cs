namespace cafe.Domain.Common
{
	public interface IUnitOfWorkRepository<T>
	{
        Task<ICollection<T>> GetAllRecords();

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task Delete(T entity);
    }
}

