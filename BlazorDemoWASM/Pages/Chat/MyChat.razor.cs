using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorDemoWASM.Pages.Chat
{
    public partial class MyChat
    {
        //Microsoft.AspNetCore.SignalR.Client
        public List<string> MessageList { get; set; }

        public HubConnection Connection { get; set; }

        public string NewMessage { get; set; }

        protected async override Task OnInitializedAsync()
        {
            MessageList = new List<string>();

            Connection = new HubConnectionBuilder()
                    .WithUrl("https://localhost:7010/chathub").Build();

            await Connection.StartAsync();

            Connection.On("notifyNewMessage", (string message) =>
            {
                MessageList.Add(message);
                StateHasChanged();
            });
        }

        public async Task SendNewMessage()
        {
            await Connection.SendAsync("SendMessage", NewMessage);
        }

        public async Task JoinGroup()
        {
            await Connection.SendAsync("JoinGroup", "blazorgroup");
            Connection.On("notifyTo_blazorgroup", (string message) =>
            {
                MessageList.Add(message);
                StateHasChanged();
            });
        }

        public async Task SendToGroup()
        {
            await Connection.SendAsync("SendToGroup", "blazorgroup", NewMessage);
        }
    }
}
