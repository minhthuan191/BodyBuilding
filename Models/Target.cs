using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodyBuildingApp.Models
{
    [Table("Target")]
    public class Target
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string TargetId { set; get; }

        [Required]
        [StringLength(50)]
        public string TargetName { set; get; }

        
        [StringLength(50)]
        [ForeignKey("Customer")]
        public string UserId { set; get; }

    }
}
