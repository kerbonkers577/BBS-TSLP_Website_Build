using System.ComponentModel.DataAnnotations;


namespace TSLP_Website_Merge.Models
{
    public class Roster
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Checked")]
        public bool check { get; set; }
        [Required]
        [Display(Name = "Seller ID")]
        public int sellerId { get; set; }
        [Required]
        [Display(Name ="Date Checked")]
        public DateTime rosterDate { get; set; }
    }
}
