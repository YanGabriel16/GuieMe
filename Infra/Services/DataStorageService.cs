using GuieMe.Domain.Interfaces;
using System.Text.Json;

namespace GuieMe.Infra.Services
{
    internal class DataStorageService : IDataStorageService
    {
        public async Task SetValueAsync(string key, object value)
        {
            try
            {
                string json = JsonSerializer.Serialize(value);
                await SecureStorage.SetAsync(key, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
