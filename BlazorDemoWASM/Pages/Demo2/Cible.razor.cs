using Microsoft.AspNetCore.Components;

namespace BlazorDemoWASM.Pages.Demo2
{
    public partial class Cible
    {
        [Parameter]
        public int ValueFromParent { get; set; }
        [Parameter]
        public EventCallback<int> ResponseEvent { get; set; }

        protected override void OnParametersSet()
        {
            ValueFromParent += 20;
        }
        private void SendResponse()
        {
            ResponseEvent.InvokeAsync(ValueFromParent);
        }
    }
}
