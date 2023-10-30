using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQPATE.DB.Models
{
    public class Users
    {
        private readonly MySQLContext _context;

        public Users(MySQLContext context)
        {
            _context = context;
        }

        public Users(string userName, string firstName, string? lastName, string phone, string email, string userPassword, string salt, string adreesLine1, string? adressLine2, string zipCode, int countryid, int countryStateid, int cityId, float? saldo, int userState, string? userLocation, byte? userPicture)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            UserPassword = userPassword;
            Salt = salt;
            AddressLine1 = adreesLine1;
            AddressLine2 = adressLine2;
            ZipCode = zipCode;
            CountryID = countryid;
            StateID = countryStateid;
            CityID = cityId;
            Balance = saldo;
            UserState = userState;
            UserLocation = userLocation;
            UserPicture = userPicture;

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }  
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserPassword { get; set; }
        public string Salt { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        [ForeignKey("Country")]
        public int CountryID { get; set; }
        [ForeignKey("State")]
        public int StateID { get; set; }
        [ForeignKey("City")]
        public int CityID { get; set; }
        public float? Balance { get; set; }
        public int UserState { get; set; }
        public string? UserLocation { get; set; }
        public byte? UserPicture { get; set; }
        public Cities? City { get; set; }
        public CountryStates? State { get; set; }
        public Countries? Country { get; set; }

    }
}
