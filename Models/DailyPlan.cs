using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodyBuildingApp.Models
{
    [Table("DailyPlan")]
    public class DailyPlan
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string PlanId { set; get; }

        [Required]
        [StringLength(50)]
        public string Date { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("Customer")]
        public string UserId { set; get; }


        [Required]
        [StringLength(50)]
        [ForeignKey("DailyFoodDetail")]
        public string DailyFoodDetailId { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("Instruction")]
        public string InstructionId { set; get; }

    }
}
