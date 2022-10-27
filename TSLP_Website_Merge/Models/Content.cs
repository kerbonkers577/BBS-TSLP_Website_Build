using System.ComponentModel.DataAnnotations;


namespace TSLP_Website_Merge.Models
{
    public class Content
    {
        [Key]
        [Display(Name ="Content ID")]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Title")]
        public string title { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Date Added")]
        public DateTime createdDate = DateTime.Now;
    }
}
