using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodyBuildingApp.Models
{

    [Table("Session")]
    public class Session
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string SessionId { set; get; }

        [Required]
        public float TotalCalo { set; get; }

        [Required]
        [StringLength(50)]
        public string Time { set; get; }

        public Recommend Recommend { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("Exercise")]
        public string ExerciseId { get; set; }



    }
}
