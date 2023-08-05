using GuieMe.Interfaces;
using System.Text.Json;

namespace GuieMe.Services
{
    internal class DataStorageService : IDataStorageService
    {
        public async Task<object> GetValueAsync(string key)
        {
            try
            {
                var result = await SecureStorage.GetAsync(key);
                return JsonSerializer.Deserialize<object>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return null;
            }
        }

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
