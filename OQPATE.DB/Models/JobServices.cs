using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQPATE.DB.Models
{
    public class JobServices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobServiceID { get; set; }
        [Required]
        [ForeignKey("user")]
        public int UserID { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        [Required]
        public string? JobServiceDescription { get; set; }
        [Required]
        [ForeignKey("Country")]
        public int CountryID { get; set; }
        [Required]
        [ForeignKey("State")]
        public int StateID { get; set; }
        public float MinPrice { get; set; }
        public float MaxPrice { get; set; }
        public Countries Country { get; set; }
        public CountryStates State { get; set; }
        public ServiceCategory Category { get; set; }
        public Users user { get; set; }

    }
}
