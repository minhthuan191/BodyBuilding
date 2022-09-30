using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodyBuildingApp.Models
{
    [Table("Exercise")]
    public class Exercise
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string ExerciseId { set; get; }

        [Required]
        public int Set{ set; get; }

        [Required]
        [StringLength(50)]
        public string BodyPart { set; get; }

        [Required]
        [StringLength(50)]
        public string Step { set; get; }

        [Required]
        public int Rep { set; get; }


        [Required]
        public float CaloBurn { set; get; }
    }
}
