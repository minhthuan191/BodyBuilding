using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodyBuildingApp.Models
{
    [Table("BodyStatus")]
    public class BodyStatus
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string BodyStatusId { set; get; }

        [Required]
        public float Weight { set; get; }

        [Required]
        public float Height { set; get; }

        [Required]
        [StringLength(50)]
        public string Date { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("Customer")]
        public string UserId { set; get; }

}
}
