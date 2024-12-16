using BlazorDemoWASM.Models;
using System.Text.Json;

namespace BlazorDemoWASM.Pages
{
    public partial class Demo5
    {
        public Personne MyForm { get; set; } = new Personne();

        protected override void OnInitialized()
        {
            MyForm.Emploi = new Job();
        }

        public List<string> listeGenre { get; set; } = new List<string>
        {
            "Femme", "Homme", "Chèvre", "Ananas", "Ne se prononce pas"
        };
        public void Submit()
        {
            Console.WriteLine(JsonSerializer.Serialize(MyForm));
        }
    }
}
