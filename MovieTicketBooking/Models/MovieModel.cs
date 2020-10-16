using MovieTicketBooking.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
namespace MovieTicketBooking.Models
{
    public class MovieViewModels
    {
        public int NoOfScreen { get; set; }

        public List<MovieModel> MovieModels { get; set; }
    }
    public enum MovieLanguage
    {
        Tamil,
        English,
        Telugu,
        Malayalam,
        Kannada,
        Hindi
    }
    public enum MovieCertificate
    {
        U,
        UA,
        A,
        S
    }
    public class MovieModel
    {
        public int MovieId { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        [RegularExpression("[A-Z][a-zA-Z]*", ErrorMessage = "Invalid Movie Type")]
        public string MovieType { get; set; }
        [Required]
        public MovieLanguage Language { get; set; }
        [Required]
        public MovieCertificate Certificate { get; set; }
        [Required]
        public DateTime MovieHour { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string MovieDescription { get; set; }
        [DisplayName("Upload Img")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public int TheatreId { get; set; }
        public Theatre Theatres { get; set; }

        public ICollection<BookingTableModel> Booking { get; set; }
    }
}