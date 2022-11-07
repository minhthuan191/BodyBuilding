using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodyBuildingApp.Models
{
    [Table("DailyFoodDetail")]
    public class DailyFoodDetail
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string DailyFoodDetailId { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("DailyFood")]
        public string DailyFoodId { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("FoodDetail")]
        public string FoodName { set; get; }
        [Required]
        [StringLength(50)]
        public string TimetoEat { set; get; }


        public Recommend Recommend { set; get; }
    }
}
