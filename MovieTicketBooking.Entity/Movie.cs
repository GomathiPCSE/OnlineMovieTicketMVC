using System;
using System.ComponentModel.DataAnnotations;
namespace MovieTicketBooking.Entity
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [MaxLength(40)]
        public string MovieName { get; set; }
        [Required]
        [MaxLength(30)]
        public string MovieType { get; set; }
        [Required]
        [MaxLength(15)]
        public string Language { get; set; }
        [Required]
        [MaxLength(3)]
        public string Certificate { get; set; }
        [Required]
        public DateTime MovieHour { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string MovieDescription { get; set; }
        public int TheatreId { get; set; }

        public Theatre TheatreDetails { get; set; }
    }
}
