using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OQPATE.API.common;
using OQPATE.API.Services;
using OQPATE.DB;
using OQPATE.DB.Models;
using OQPATEAPI;

namespace OQPATE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public readonly MySQLContext _context;

        public UsersController(MySQLContext context)
        {
            _context = context; 
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<Users> Get(MySQLContext context)
        {
            return context.Users.ToList();
        }

        [HttpPost]
        public string Post(string username, string password,string email, string firstName, string lastName,string phone, string addressLine1,string addressLine2, int country, int state, int city, string zipcode) 
        {
           
            var salt = Utility.GetSalt();
            var user = new Users(
                    username, 
                    firstName,
                    lastName, 
                    phone,
                    email,
                    Utility.HashString(password, salt),
                    salt,
                    addressLine1,
                    addressLine2,
                    zipcode,
                    country,
                    state,
                    city,
                    0, //saldo
                    0, //state
                    string.Empty, //location
                    null //picture
                );
            _context.Users.Add(user);

            _context.SaveChanges();

            return "OK";
        }
        
        [Authorize]
        [HttpPut]
        public string Put(MySQLContext context,Users User) 
        {
            var user = context.Users.Update(User);

            try
            {
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                return "Error saving changes";
            }
            return "OK";
        }

        [Authorize]
        [HttpDelete]
        public string Delete(MySQLContext context, int? UserID) 
        {
            try
            {
                if(UserID != null)
                {
                    context.Users.Remove(context.Users.FirstOrDefault(q => q.UserID == UserID));
                    context.SaveChanges();
                }
                return "User ID cannot by null";
                    
            }
            catch(Exception ex) 
            {
                return "Can not delete user";
            }
            return "OK";
        }




    }
}


/*
 {
  "userID": 0,
  "userName": "jcastorena-admin",
  "firstName": "Javier",
  "lastName": "Castorena",
  "email": "javiercastorena@hotmail.com",
  "userPassword": "Pa$$w0rd!@#",
  "salt": "string",
  "adreesLine1": "gaucho #130",
  "adressLine2": "Buenos Aires 2",
  "zipCode": 21355,
  "country": 1,
  "countryState": 2,
  "saldo": 0,
  "userState": 0,
  "userLocation": "string",
  "userPicture": 0
}
 */