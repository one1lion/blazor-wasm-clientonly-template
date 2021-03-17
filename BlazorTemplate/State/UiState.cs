using Blazored.LocalStorage;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTemplate.State {
  public class UiState {
    private readonly ILocalStorageService localStorage;
    private readonly IJSRuntime jsRuntime;

    public UiState(ILocalStorageService localStorage, IJSRuntime jsRuntime) {
      this.localStorage = localStorage;
      this.jsRuntime = jsRuntime;
    }

    public event Action OnNotifyStateChanged;

    public bool DarkModeEnabled { get; private set; }

    public async Task InitializeAsync() {
      DarkModeEnabled = await localStorage.GetItemAsync<bool>("dark-mode");
      await SetDarkModeCssAsync();
      NotifyStateChanged();
    }

    public ValueTask SetDarkModeCssAsync() {
      if (!DarkModeEnabled) {
        return JsFunInterop.RemoveCssClass(jsRuntime, "body", "dark-theme");
      } else {
        return JsFunInterop.AddCssClass(jsRuntime, "body", "dark-theme");
      }
    }

    public async Task SetDarkModeAsync(bool enabled) {
      DarkModeEnabled = enabled;
      await localStorage.SetItemAsync("dark-mode", enabled);
      await SetDarkModeCssAsync();
      NotifyStateChanged();
    }

    public void NotifyStateChanged() {
      OnNotifyStateChanged?.Invoke();
    }

    public Task NotifyStateChangedAsync() {
      return Task.Run(() => OnNotifyStateChanged.Invoke());
    }
  }
}
