using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQPATE.DB.Models
{
    public class CountryStates
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateID { get; set; }
        public string? StateName { get; set; }
        [ForeignKey("Country")]
        public int CountryID { get; set; }

        public Countries Country { get; set; }

        public CountryStates(string stateName, int countryID)
        {
            StateName = stateName;
            CountryID = countryID;
        }
    }
}
