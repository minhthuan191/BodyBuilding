using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BodyBuildingApp.Models
{
    [Table("SessionExercise")]
    public class SessionExercise
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string SessionExerciseId { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("Exercise")]
        public string ExerciseId { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("Session")]
        public string SessionId { set; get; }
    }
}
