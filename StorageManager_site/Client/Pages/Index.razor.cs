using StorageManager_site.Shared;

namespace StorageManager_site.Client.Pages
{
    public partial class Index
    {
        public ValueToStore? LocalValueToWrite { get; set; } = new ValueToStore();
        public ValueToStore? SessionValueToWrite { get; set; } = new ValueToStore();

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                localStorage.Init();
                sessionStorage.Init();
            }

            return base.OnAfterRenderAsync(firstRender);
        }

        #region SessionStorage
        private void SubmitSession()
        {
            SaveSessionStorage();
        }

        private void SaveSessionStorage()
        {
            if (SessionValueToWrite is not null && SessionValueToWrite.MyKey is not null && SessionValueToWrite.MyValue is not null)
                sessionStorage.SaveStorage(SessionValueToWrite.MyKey, SessionValueToWrite.MyValue);
        }

        private async void ReadSessionStorage()
        {
            if (SessionValueToWrite is not null && SessionValueToWrite.MyKey is not null && SessionValueToWrite.MyValue is not null)
            {
                SessionValueToWrite.MyValue = await sessionStorage.ReadStorage(SessionValueToWrite.MyKey);
                StateHasChanged();
            }
        }

        private void DeleteSessionStorage()
        {
            if (SessionValueToWrite is not null && SessionValueToWrite.MyKey is not null && SessionValueToWrite.MyValue is not null)
            {
                SessionValueToWrite.MyValue = string.Empty;
                sessionStorage.SaveStorage(SessionValueToWrite.MyKey, SessionValueToWrite.MyValue);
                StateHasChanged();
            }
        }
        #endregion

        #region LocalStorage
        private void Submit()
        {
            SaveLocalStorage();
        }

        private void SaveLocalStorage()
        {
            if (LocalValueToWrite is not null && LocalValueToWrite.MyKey is not null && LocalValueToWrite.MyValue is not null)
                localStorage.SaveStorage(LocalValueToWrite.MyKey, LocalValueToWrite.MyValue);
        }

        private async void ReadLocalStorage()
        {
            if (LocalValueToWrite is not null && LocalValueToWrite.MyKey is not null && LocalValueToWrite.MyValue is not null)
            {
                LocalValueToWrite.MyValue = await localStorage.ReadStorage(LocalValueToWrite.MyKey);
                StateHasChanged();
            }
        }

        private void DeleteLocalStorage()
        {
            if (LocalValueToWrite is not null && LocalValueToWrite.MyKey is not null && LocalValueToWrite.MyValue is not null)
            {
                LocalValueToWrite.MyValue = string.Empty;
                localStorage.SaveStorage(LocalValueToWrite.MyKey, LocalValueToWrite.MyValue);
                StateHasChanged();
            }
        }
        #endregion
    }
}
