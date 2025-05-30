namespace AutoLife.Lib.Interfaces;

public interface IRepository<T>
{
	Task<bool> Create(T entity);
	Task<bool> Update(T entity);
	Task<bool> Remove(T entity);
	Task<List<T>> GetAll();
}