using System.ComponentModel.DataAnnotations;


namespace TSLP_Website_Merge.Models
{
    public class Partner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Partner")]
        public string partnerName { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Date Added")]
        public DateTime createAt { get; set; } = DateTime.Now;

    }
}
