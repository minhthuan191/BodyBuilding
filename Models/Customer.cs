using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodyBuildingApp.Models
{
    public enum Gender
    {
        MALE = 1,
        FEMALE = 0
    }
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string UserId { set; get; }

        [Required]
        [StringLength(50)]
        public string Name { set; get; }

        [Required]
        [StringLength(50)]
        public string Username { set; get; }

        [StringLength(50)]
        public string Password { set; get; }

        [Required]
        [StringLength(250)]
        public string Email { set; get; }

        [Required]
        [StringLength(10)]
        public string Phone { set; get; }

        [Required]
        public Gender Gender { set; get; }

        [StringLength(250)]
        public string Address { set; get; }

    

        [Required]
        [StringLength(50)]
        [ForeignKey("Target")]
        public string TargetId { get; set; }

        public virtual Target Target { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("BodyStatus")]
        public string BodyStatusId { get; set; }

        public virtual BodyStatus BodyStatus { set; get; }
    }
}
