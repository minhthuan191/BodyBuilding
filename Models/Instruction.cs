using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodyBuildingApp.Models
{
    [Table("Instruction")]
    public class Instruction
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string InstructionId { set; get; }

        [Required]
        [StringLength(150)]
        public string Comment { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("Trainer")]
        public string TrainerId { get; set; }

        public virtual Trainer Trainer { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("Session")]
        public string SessionId { get; set; }

        public virtual Session Session { set; get; }

    }
}
