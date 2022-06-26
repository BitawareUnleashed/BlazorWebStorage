using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageManager
{
    public interface ILocalStorageService
    {
        Task Init();

        Task SaveStorage(string keyName, string token);
        
        Task<string> ReadStorage(string keyName);
    }
}
