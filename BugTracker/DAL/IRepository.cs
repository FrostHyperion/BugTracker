namespace BugTracker.DAL;

public interface IRepository<T> where T : class {
	List<T> GetList(Func<T, bool> whereFunction);
	T? Get(Func<T, bool> firstFunction);
	void Create(T? entity);
	void Update(T? entity);
	void Delete(T? entity);
}
