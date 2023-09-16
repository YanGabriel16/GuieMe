namespace GuieMe.Domain.Interfaces
{
    public interface IDataStorageService
    {
        Task SetValueAsync(string key, object value);
    }
}
