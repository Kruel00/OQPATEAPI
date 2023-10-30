using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQPATE.DB.Models
{
    public class Cities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityID { get; set; }
        public string CityName { get; set; }
        [ForeignKey("StatesCountryState")]
        public int StateID { get; set; }

        public CountryStates StatesCountryState { get; set; }

        public Cities(string cityName, int stateID)
        {
            CityName = cityName;
            StateID = stateID;
        }
    }
}
