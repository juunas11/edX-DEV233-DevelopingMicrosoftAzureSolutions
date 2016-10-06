using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contoso.Events.Models
{
    public class Registration
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Your first name is required.")]
        [StringLength(150)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Your last name is required.")]
        [StringLength(150)]
        public string LastName { get; set; }

        [Display(Name = "E-Mail Address")]
        [Required(ErrorMessage = "Your e-mail address is required.")]
        [EmailAddress]
        [StringLength(500)]
        public string EmailAddress { get; set; }

        [Display(Name = "How did you learn about this event?")]
        [Range(1, int.MaxValue, ErrorMessage = "Please indicate how you learned about this event.")]
        public Referrers Referrer { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Timestamp { get; set; }

        [ScaffoldColumn(false)]
        public virtual Event Event { get; set; }
    }
}
