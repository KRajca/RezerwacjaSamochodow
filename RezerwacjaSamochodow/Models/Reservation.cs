using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace RezerwacjaSamochodow.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public string UserId { get; set; } // Identity User ID

        // Navigation properties
        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }
    }
}