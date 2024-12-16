namespace BlazorDemoWASM.Pages
{
    public partial class Demo3
    {
        public List<string> MaListe { get; set; }

        protected override void OnInitialized()
        {
            MaListe = new List<string>();

            for(int i = 0; i < 50; i++)
            {
                MaListe.Add(Guid.NewGuid().ToString());
            }
        }
    }
}
