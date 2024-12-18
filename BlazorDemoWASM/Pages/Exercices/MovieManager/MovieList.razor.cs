using BlazorDemoWASM.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BlazorDemoWASM.Pages.Exercices.MovieManager
{
    public partial class MovieList
    {
        public List<Movie> Movies { get; set; }

        public Movie SelectedMovie { get; set; }

        [Inject]
        public HttpClient Client { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Movies = new List<Movie>();
            Movies = await Client.GetFromJsonAsync<List<Movie>>("movie");
            //Movies = new List<Movie>();
            //Movies.Add(new Movie
            //{
            //    Id = 1, 
            //    Title = "Star Wars : New Hope",
            //    ReleaseYear = 1977,
            //    Realisator = "George Lucas",
            //    Synopsis = "Un pirate et un wookie court après la princesse pour ..."
            //});
        }

        private void Detail(Movie m)
        {
            SelectedMovie = m;
        }

        private void Delete(Movie m)
        {
            Movies.Remove(m);
        }

        private async Task Add(Movie m)
        {
            //string json = JsonSerializer.Serialize(m);
            //HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            await Client.PostAsJsonAsync("movie", m);
            //int id = Movies.Max(x => x.Id) + 1;
            //m.Id = id;
            //Movies.Add(m);
        }
    }
}
