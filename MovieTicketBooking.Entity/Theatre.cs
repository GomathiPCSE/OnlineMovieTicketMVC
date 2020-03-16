using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketBooking.Entity
{
    public class Theatre
    {
        [Key]
        public int TheatreId { get; set; }

        public int UserId { get; set; }    
        public UserAccount User { get; set; }
        [Required]
        [MaxLength(30)]
        [Index(IsUnique=true)]
        public string TheatreName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [Required]
        public int NoOfScreen { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
