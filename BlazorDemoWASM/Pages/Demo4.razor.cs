using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorDemoWASM.Pages
{
    public partial class Demo4
    {
        [Inject]
        public IJSRuntime js { get; set; }
        public IJSObjectReference jsRef { get; set; }

        public string Value { get; set; }
        public string ValueFromStorage { get; set; }

        protected async override Task OnInitializedAsync()
        {
            jsRef = await js.InvokeAsync<IJSObjectReference>("import", "./script/script.js");
            await jsRef.InvokeVoidAsync("masuperfonction", "Mon message de fou");
        }

        public async Task SaveValue()
        {
            await js.InvokeVoidAsync("localStorage.setItem", "macle", Value);
        }
        public async Task GetValue()
        {
            ValueFromStorage = await js.InvokeAsync<string>("localStorage.getItem", "macle");
        }
    }
}
