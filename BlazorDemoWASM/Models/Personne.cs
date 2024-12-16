using System.ComponentModel.DataAnnotations;

namespace BlazorDemoWASM.Models
{
    public class Personne
    {
        [Range(1, 1000, ErrorMessage = "Pas bien !!! Doit être compris en 1 et 1000")]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Nom { get; set; }
        [Required]
        [MinLength(2)]
        public string Prenom { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime DateNaissance { get; set; }
        public bool IsAdmin { get; set; }
        public string Genre { get; set; }
        //Microsoft.AspNetCore.Components.DataAnnotations.Validation
        [ValidateComplexType]
        public Job Emploi { get; set; }
    }

    public class Job
    {
        [Required]
        public string Label { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
    }
}
