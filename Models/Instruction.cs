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
        public string TotalTime { get; set; }

        [Required]
        [StringLength(50)]
        public string TotalCalo { get; set; }

        [Required]
        public Recommend Recommend { get; set; }

        [Required]
        [StringLength(50)]
        [ForeignKey("Trainer")]
        public string TrainerId { get; set; }


        [Required]
        [StringLength(50)]
        [ForeignKey("InstructionDetail")]
        public string InstructionDetailId { get; set; }

        [Required]
        [StringLength(50)]
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }


    }
}
