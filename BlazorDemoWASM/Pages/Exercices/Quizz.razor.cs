using Microsoft.AspNetCore.Components;

namespace BlazorDemoWASM.Pages.Exercices
{
    public partial class Quizz
    {
        [Parameter]
        public string Prenom { get; set; }
        [Parameter]
        public EventCallback<string> RepondreEvent { get; set; }
        public List<string> Questions { get; set; }
        public int compteur { get; set; }

        protected override void OnInitialized()
        {
            Questions = new List<string>();
            Questions.Add("Avez vous bien mangé à midi ?");
            Questions.Add("La sieste était bonne ?");
            Questions.Add("C'est pas l'heure de l'apéro ?");

            compteur = 0;
        }

        public void Repondre(string reponse)
        {
            RepondreEvent.InvokeAsync(reponse);
            compteur++;
        }
    }
}
