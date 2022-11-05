using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodyBuildingApp.Models
{

    [Table("InstructionDetail")]
    public class InstructionDetail
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string InstructionDetailId { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("Exercise")]
        public string ExerciseId { get; set; }

        [Required]
        [StringLength(50)]
        [ForeignKey("Instruction")]
        public string InstructionId { get; set; }


    }
}
