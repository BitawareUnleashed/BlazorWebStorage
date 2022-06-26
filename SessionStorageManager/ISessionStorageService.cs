using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionStorageManager
{
    public interface ISessionStorageService
    {
        Task Init();

        Task SaveStorage(string keyName, string token);

        Task<string> ReadStorage(string keyName);
    }
}
