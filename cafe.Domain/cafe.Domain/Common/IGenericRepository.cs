namespace cafe.Domain.Common
{
	public interface IGenericRepository<T> where T : class
	{
        Task<ICollection<T>> GetAllRecords();

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task Delete(T entity);
    }
}

