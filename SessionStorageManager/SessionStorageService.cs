using Microsoft.JSInterop;

namespace SessionStorageManager
{
    public class SessionStorageService : ISessionStorageService
    {
        private IJSObjectReference? module = null;

        /// <summary>
        /// The js runtime
        /// </summary>
        private readonly IJSRuntime? jsRuntime;

        public SessionStorageService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task Init()
        {
            module = await jsRuntime.InvokeAsync<IJSObjectReference>
                ("import", "./_content/SessionStorageManager/scripts/sessionStorage.js");
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
    }
}
