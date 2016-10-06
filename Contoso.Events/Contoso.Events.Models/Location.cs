using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Events.Models
{
    public class Location
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(500)]
        public string StreetAddress { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(2)]
        public string State { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [StringLength(10)]
        public string ZipCode { get; set; }

        [ScaffoldColumn(false)]
        public string PrintAddress
        {
            get
            {
                return String.Format("{0}, {1}, {2} {3}", this.StreetAddress, this.City, this.State, this.ZipCode);
                
            }
        }
    }
}
