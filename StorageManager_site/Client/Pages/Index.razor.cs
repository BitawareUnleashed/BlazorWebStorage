using StorageManager_site.Shared;

namespace StorageManager_site.Client.Pages;
public partial class Index
{
    /// <summary>
    /// Gets or sets the local storage value to write.
    /// </summary>
    /// <value>
    /// The local value to write.
    /// </value>
    public ValueToStore? LocalValueToWrite { get; set; } = new ValueToStore();

    /// <summary>
    /// Gets or sets the session storage value to write.
    /// </summary>
    /// <value>
    /// The session value to write.
    /// </value>
    public ValueToStore? SessionValueToWrite { get; set; } = new ValueToStore();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await webStorage.LocalStorage.Init();
            await webStorage.SessionStorage.Init();
        }
    }

    #region SessionStorage        
    private void SubmitSession()
    {
        SaveSessionStorage();
    }

    private async void SaveSessionStorage()
    {
        if (SessionValueToWrite is not null && SessionValueToWrite.MyKey is not null && SessionValueToWrite.MyValue is not null)
            await webStorage.SessionStorage.Save(SessionValueToWrite.MyKey, SessionValueToWrite.MyValue);
    }

    private async void ReadSessionStorage()
    {
        if (SessionValueToWrite is not null && SessionValueToWrite.MyKey is not null && SessionValueToWrite.MyValue is not null)
        {
            SessionValueToWrite.MyValue = await webStorage.SessionStorage.Read(SessionValueToWrite.MyKey);
            StateHasChanged();
        }
    }

    private async void ClearSessionStorage()
    {
        if (SessionValueToWrite is not null && SessionValueToWrite.MyKey is not null && SessionValueToWrite.MyValue is not null)
        {
            await webStorage.SessionStorage.Clear();

            if (SessionValueToWrite is null)
            {
                SessionValueToWrite = new ValueToStore();
            }
            else
            {
                SessionValueToWrite.MyKey = String.Empty;
                SessionValueToWrite.MyValue = String.Empty;
            }

            StateHasChanged();
        }
    }
    #endregion

    #region LocalStorage
    private void Submit()
    {
        SaveLocalStorage();
    }

    private async void SaveLocalStorage()
    {
        if (LocalValueToWrite is not null && LocalValueToWrite.MyKey is not null && LocalValueToWrite.MyValue is not null)
        {
            await webStorage.LocalStorage.Save(LocalValueToWrite.MyKey, LocalValueToWrite.MyValue);
        }
    }

    private async void ReadLocalStorage()
    {
        if (LocalValueToWrite is not null && LocalValueToWrite.MyKey is not null && LocalValueToWrite.MyValue is not null)
        {
            LocalValueToWrite.MyValue = await webStorage.LocalStorage.Read(LocalValueToWrite.MyKey);
            StateHasChanged();
        }
    }

    private async void ClearLocalStorage()
    {
        if (LocalValueToWrite is not null && LocalValueToWrite.MyKey is not null && LocalValueToWrite.MyValue is not null)
        {
            await webStorage.LocalStorage.Clear();
            if (LocalValueToWrite is null)
            {
                LocalValueToWrite = new ValueToStore();
            }
            else
            {
                LocalValueToWrite.MyKey = String.Empty;
                LocalValueToWrite.MyValue = String.Empty;
            }
            StateHasChanged();
        }
    }
    #endregion
}

