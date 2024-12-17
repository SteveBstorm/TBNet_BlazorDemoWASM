using BlazorDemoWASM.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorDemoWASM.Pages.Exercices.MovieManager
{
    public partial class AddMovie
    {
        public Movie NewMovie { get; set; } = new Movie();

        [Parameter]
        public EventCallback<Movie> RegisterEvent { get; set; }

        private void OnValidSubmit()
        {
            RegisterEvent.InvokeAsync(this.NewMovie);
        }
    }
}
