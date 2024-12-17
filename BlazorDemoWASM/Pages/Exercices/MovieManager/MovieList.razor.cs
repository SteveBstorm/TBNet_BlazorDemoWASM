using BlazorDemoWASM.Models;

namespace BlazorDemoWASM.Pages.Exercices.MovieManager
{
    public partial class MovieList
    {
        public List<Movie> Movies { get; set; }

        public Movie SelectedMovie { get; set; }

        protected override void OnInitialized()
        {
            Movies = new List<Movie>();
            Movies.Add(new Movie
            {
                Id = 1, 
                Title = "Star Wars : New Hope",
                ReleaseYear = 1977,
                Realisator = "George Lucas",
                Synopsis = "Un pirate et un wookie court après la princesse pour ..."
            });
        }

        private void Detail(Movie m)
        {
            SelectedMovie = m;
        }

        private void Delete(Movie m)
        {
            Movies.Remove(m);
        }

        private void Add(Movie m)
        {
            int id = Movies.Max(x => x.Id) + 1;
            m.Id = id;
            Movies.Add(m);
        }
    }
}
