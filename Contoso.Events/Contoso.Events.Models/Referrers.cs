using System.ComponentModel.DataAnnotations;

namespace Contoso.Events.Models
{
    public enum Referrers
    {
        [Display(Name = "Search Engine")]
        SearchEngine = 1,
        [Display(Name = "Word of Mouth")]
        WordofMouth = 2,
        [Display(Name = "Targeted E-mail")]
        Email = 3,
        [Display(Name = "Social Media")]
        SocialMedia = 4,
        [Display(Name = "Other")]
        Other = 5
    }
}