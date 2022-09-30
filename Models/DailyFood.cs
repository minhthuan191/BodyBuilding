using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodyBuildingApp.Models
{
    public enum Recommend
    {
        RECOMMEND = 1,
        NOTRECOMMEND = 0
    }
    [Table("DailyFood")]
    public class DailyFood
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string DailyFoodId { set; get; }


        [Required]
        [StringLength(50)]
        public string TimetoEat { set; get; }

        
        public  Recommend Recommend { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("Target")]
        public string FoodName { set; get; }

        public virtual FoodDetail FoodDetail { set; get; }
    }
}
