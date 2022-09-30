using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodyBuildingApp.Models
{
    [Table("FoodDetail")]
    public class FoodDetail
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string FoodName { set; get; }

        [Required]
        public float Calories { set; get; }

        [Required]
        [StringLength(255)]
        public string Image { set; get; }

    }
}
