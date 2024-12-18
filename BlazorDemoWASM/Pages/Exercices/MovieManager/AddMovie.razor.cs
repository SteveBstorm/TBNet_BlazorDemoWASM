using BlazorDemoWASM.Models;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace BlazorDemoWASM.Pages.Exercices.MovieManager
{
    public partial class AddMovie
    {
        public Movie NewMovie { get; set; } = new Movie();

        [Parameter]
        public EventCallback<Movie> RegisterEvent { get; set; }

        private void OnValidSubmit()
        {
            Console.WriteLine(JsonSerializer.Serialize(NewMovie));
            RegisterEvent.InvokeAsync(this.NewMovie);
        }
    }
}
