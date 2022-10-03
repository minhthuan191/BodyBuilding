using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodyBuildingApp.Models
{
    public enum Status
    {
        DONE = 1, 
        PROCESS = 0
    }
    [Table("Schedule")]
    public class Schedule
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string ScheduleId { set; get; }

        [Required]
        [StringLength(50)]
        public string StartDate { set; get; }

        [Required]
        [StringLength(50)]
        public string EndDate { set; get; }

        [Required]
        public Status Status { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("Customer")]
        public string UserId { get; set; }

        public virtual Customer Customer { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("Trainer")]
        public string TrainerId { get; set; }

        public virtual Trainer Trainer { set; get; }

    }
}
