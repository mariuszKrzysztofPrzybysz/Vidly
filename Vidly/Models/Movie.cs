using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public Genre Genre { get; set; }

        public byte GenreId { get; set; }

        [Required]
        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        public short NumberInStock { get; set; }
    }
}