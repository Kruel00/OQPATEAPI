using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQPATE.DB.Models
{
    public class Countries
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string PhoneCode { get; set; }

        public Countries(string countryName, string phoneCode)
        {
            CountryName = countryName;
            PhoneCode = phoneCode;
        }
    }
}
