using MovieTicketBooking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTicketBooking.Models
{
    public class MultipleModel
    {
        public IEnumerable<MovieModel> Movies { get; set; }
        public IEnumerable<SignUpNextModel> Theatres { get; set;}
    }
}