namespace BlazorDemoWASM.Pages
{
    public partial class Demo1
    {
        public int Value { get; set; } = 42;

        private void Increment()
        {
            Value++;
        }
        private void Retrait(int x)
        {
            Value -= x;
        }
    }
}
