namespace BlazorDemoWASM.Pages.Exercices
{
    public partial class Exo1
    {
        public string Prenom { get; set; }
        public List<string> Reponses { get; set; }
        public bool PartieTerminee { get; set; }

        protected override void OnInitialized()
        {
            Reponses = new List<string>();
        }

        public void EnregistrerReponse(string reponse)
        {
            Reponses.Add(reponse);
            if(Reponses.Count > 2)
            {
                PartieTerminee = true;
            }
        }
    }
}
