using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

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
        [StringLength(100)]
        public string ExerciseName { set; get; }

        [Required]
        public string Set{ set; get; }

        [Required]
        [StringLength(50)]
        public string BodyPart { set; get; }

        [Required]
        [StringLength(50)]
        public string Step { set; get; }

        [Required]
        public string Rep { set; get; }


        [Required]
        public string CaloBurn { set; get; }
    }
}
