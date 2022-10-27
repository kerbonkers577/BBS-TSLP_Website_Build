using System.ComponentModel.DataAnnotations;

namespace TSLP_Website_Merge.Models
{
    public class Sellers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firsrtName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime dob { get; set; }
        [Required]
        [Display(Name = "Previous Address")]
        public string perviousAddress { get; set; }
        [Required]
        [Display(Name = "Current Address")]
        public string currentAddress { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Date Added")]
        public DateTime createAt { get; set; } = DateTime.Now;

    }
}
