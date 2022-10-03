using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodyBuildingApp.Models
{
  
    [Table("Trainer")]
    public class Trainer
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string TrainerId { set; get; }

        [Required]
        [StringLength(50)]
        public string Name { set; get; }

        [Required]
        [StringLength(10)]
        public string Phone { set; get; }

        [Required]
        public Status Status { set; get; }

    }
}
