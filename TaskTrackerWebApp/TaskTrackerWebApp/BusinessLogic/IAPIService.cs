namespace TaskTrackerWebApp.BusinessLogic
{
    public interface IAPIService<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task Post(T model);
        Task Update(Guid id, T model);
        Task Delete(Guid id);
    }
}
