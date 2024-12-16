using System.Reflection.Metadata.Ecma335;

namespace BlazorDemoWASM.Pages.Demo2
{
    public partial class Demo2
    {
        public int Value { get; set; }
        public int ValueFromChildren { get; set; }

        private void ReceiveResponse(int x)
        {
            ValueFromChildren = x;
        }
        protected override bool ShouldRender()
        {
            return Value != 43;
        }
        protected override void OnInitialized()
        {
            Value = 42;
            Console.WriteLine("on init");
        }

        protected override void OnAfterRender(bool firstRender)
        {
            Console.WriteLine("on render");
            if (!firstRender) { 
                Value *=2 ; 
            }
        }

        private void Increment() { Value += 1; }
    }
}
