using GuieMe.Interfaces;
using GuieMe.Models;
using System.Text.Json;

namespace GuieMe.Services
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
