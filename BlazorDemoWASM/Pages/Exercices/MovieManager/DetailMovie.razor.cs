using BlazorDemoWASM.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorDemoWASM.Pages.Exercices.MovieManager
{
    public partial class DetailMovie
    {
        [Parameter]
        public Movie CurrentMovie { get; set; }
    }
}
