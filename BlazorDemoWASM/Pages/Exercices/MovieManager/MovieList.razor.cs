using BlazorDemoWASM.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BlazorDemoWASM.Pages.Exercices.MovieManager
{
    public partial class MovieList
    {
        //[Inject]
        //public IHttpClientFactory Factory { get; set; }

        //public HttpClient Client2 { get; set; }

        [Inject]
        public IJSRuntime jsRuntime { get; set; }
        public List<Movie> Movies { get; set; }

        public Movie SelectedMovie { get; set; }

        [Inject]
        public HttpClient Client { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //Client2 = Factory.CreateClient("");
            await LoadData();
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

        private async Task LoadData()
        {
            Movies = new List<Movie>();
            Movies = await Client.GetFromJsonAsync<List<Movie>>("movie");
        }

        private async Task Detail(Movie m)
        {
            SelectedMovie = await Client.GetFromJsonAsync<Movie>("movie/"+m.Id);
        }

        private async Task Delete(Movie m)
        {
            //string token = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");
            //Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Client.DeleteAsync("movie/"+m.Id);
            await LoadData();
        }

        private async Task Add(Movie m)
        {
            //string json = JsonSerializer.Serialize(m);
            //HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            //string token = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");
            //Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            await Client.PostAsJsonAsync("movie", m);
            await LoadData();

            //int id = Movies.Max(x => x.Id) + 1;
            //m.Id = id;
            //Movies.Add(m);
        }
    }
}
