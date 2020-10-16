using System;
using System.ComponentModel.DataAnnotations;
namespace MovieTicketBooking.Entity
{
    public class BookingTable
    {
        [Key]
        public int BookingTableId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int Show { get; set; }
        [Required]
        public DateTime DateToPresent { get; set; }
        [Required]
        public int Amount { get; set; }

        public int MovieId { get; set; }
        public Movie Movies { get; set; }

    }
}
