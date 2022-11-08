using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeSettings2.Models
{
    public class Bike
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [DisplayName("Front Tyre PSI")]
        public int FrontTyrePSI { get; set; }
        [DisplayName("Rear Tyre PSI")]
        public int RearTyrePSI { get; set; }
        [DisplayName("Fork PSI")]
        public int ForkPSI { get; set; }
        [DisplayName("Fork Rebound")]
        public int ForkRebound { get; set; }
        [DisplayName("Shock PSI")]
        public int? ShockPSI { get; set; }
        [DisplayName("Shock Rebound")]
        public int? ShockRebound { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
