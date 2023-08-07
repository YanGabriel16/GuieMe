using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuieMe.Interfaces
{
    public interface IDataStorageService
    {
        Task SetValueAsync(string key, object value);
    }
}
