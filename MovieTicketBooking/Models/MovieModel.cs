using MovieTicketBooking.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MovieTicketBooking.Models
{
    public class MovieViewModels
    {
        public int NoOfScreen { get; set; }

        public List<MovieModel> MovieModels { get; set; }
    }
    public enum Language
        {
        Tamil,
        English,
        Telugu,
        Malayalam,
        Kannada,
        Hindi
    }
    public enum Certificate
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
        public DateTime MovieHour { get; set; }
        [Required]
        //[RegularExpression("[A-Z][a-zA-Z]*", ErrorMessage = "Invalid Movie Type")]
        public string MovieType { get; set; }
        [Required]
        public string MovieLanguage { get; set; }
        [Required]
        public string MovieCertificate { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        //[DataType(DataType.MultilineText)]
        public string MovieDescription { get; set; }

        public int TheatreId { get; set; }
        public Theatre Theatres { get; set; }
    }
}