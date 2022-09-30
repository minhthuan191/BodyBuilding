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

        public virtual Customer Customer { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("DailyFood")]
        public string DailyFoodId { set; get; }

        public virtual DailyFood DailyFood { set; get; }
        [Required]
        [StringLength(50)]
        [ForeignKey("Session")]
        public string SessionId { set; get; }

    }
}
