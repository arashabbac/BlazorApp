namespace BlazorApp.Services
{
    public interface IBookStoreService<T>
    {
        System.Threading.Tasks.Task<System.Collections.Generic.List<T>> GetAllAsync(string requestUri);
        System.Threading.Tasks.Task<T> GetAllByIdAsync(string requestUri, int Id);
        System.Threading.Tasks.Task<T> SaveAsync(string requestUri, T obj);
        System.Threading.Tasks.Task<T> UpdateAsync(string requestUri, int Id, T obj);
        System.Threading.Tasks.Task<bool> DeleteAsync(string requestUri, int Id);
    }
}
