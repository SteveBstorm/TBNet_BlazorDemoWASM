using System.ComponentModel.DataAnnotations;

namespace BlazorDemoWASM.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [MinLength(50)]
        public string Synopsis { get; set; }
        [Range(1970, int.MaxValue)]
        public int ReleaseYear { get; set; }
        [Required]
        public string Realisator { get; set; }
    }
}
