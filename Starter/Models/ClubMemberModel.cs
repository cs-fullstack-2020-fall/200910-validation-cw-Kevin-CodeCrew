using System.ComponentModel.DataAnnotations;

namespace Starter.Models
{
    public class ClubMemberModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Please enter a nickname")]
        [Display(Name = "Nickname")]
        public string nickName { get; set; }
        [Required(ErrorMessage = "Please enter a first name")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter a last name")] 
        public string lastName { get; set; }
        [Required(ErrorMessage = "Please enter a club role")]
        [Display(Name = "Club Role")]
        public string clubRole { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email Address")]
        public string email { get; set; }
        [Phone(ErrorMessage = "Please enter a valid phone number to reach you at")]
        [Display(Name = "Phone Number")]
        public string phone { get; set; }

    }
}