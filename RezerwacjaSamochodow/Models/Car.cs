using System.ComponentModel.DataAnnotations;

namespace RezerwacjaSamochodow.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Range(1900, 2100)]
        public int Year { get; set; }

        [Range(1, 10000)]
        public decimal PricePerDay { get; set; }

    }
}
