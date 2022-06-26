using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace LocalStorageManager
{
    public class LocalStorageService: ILocalStorageService
    {
        private IJSObjectReference? module = null;

        /// <summary>
        /// The js runtime
        /// </summary>
        private readonly IJSRuntime? jsRuntime;

        /// <summary>
        /// The key name of saved token
        /// </summary>
        //private const string KeyName = "machinetoken";

        #region Constructors

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }
        #endregion

        #region Local storage management    
        public async Task Init()
        {
            module = await jsRuntime.InvokeAsync<IJSObjectReference>
                ("import", "./_content/LocalStorageManager/scripts/localStorage.js");
        }

        /// <summary>
        /// Saves values to storage.
        /// </summary>
        /// <param name="token">The token.</param>
        public async Task SaveStorage(string keyName, string token)
        {
            if (module is not null)
                await module!.InvokeVoidAsync("BlazorSetLocalStorage", keyName, token);
        }

        /// <summary>
        /// Reads the storage value.
        /// </summary>
        /// <returns></returns>
        public async Task<string> ReadStorage(string keyName)
        {
            if (module is not null)
                return await module!.InvokeAsync<string>("BlazorGetLocalStorage", keyName);
            else
            {
                return string.Empty;
            }
        }

        #endregion
    }
}
