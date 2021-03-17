using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorTemplate {
  public static class JsFunInterop {
    public static ValueTask AddCssClass(IJSRuntime jsRuntime, string selector, string cssClass) {
      return jsRuntime.InvokeVoidAsync("jsFuns.addCssClass", selector, cssClass);
    }

    public static ValueTask RemoveCssClass(IJSRuntime jsRuntime, string selector, string cssClass) {
      return jsRuntime.InvokeVoidAsync("jsFuns.removeCssClass", selector, cssClass);
    }

    public static ValueTask<bool> ElementExists(this IJSRuntime jsRuntime, string elementId) {
      return jsRuntime.InvokeAsync<bool>("jsFuns.elementExists", elementId);
    }

    public static ValueTask<bool> SetInputValue(IJSRuntime jsRuntime, string elementId, object val) {
      return jsRuntime.InvokeAsync<bool>("jsFuns.setInputValueById", elementId, val);
    }

    public static ValueTask<bool> SetInputValue(IJSRuntime jsRuntime, ElementReference element, object val) {
      return jsRuntime.InvokeAsync<bool>("jsFuns.setInputValue", element, val);
    }
  }
}
