using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OQPATE.DB;
using OQPATE.DB.Models;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace OQPATE.API.Controllers
{
    public class CatalogsController : ControllerBase
    {

        private readonly MySQLContext _context;
        public CatalogsController(MySQLContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(_context.Users.ToList());
        }

        [HttpGet]
        [Route("api/GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            return Ok(_context.Country.ToList());
        }

        [HttpGet]
        [Route("api/GetStates")]
        public async Task<IActionResult> GetStates(int countryId)
        {
            return Ok(_context.CountryStates.ToList());
        }

        [HttpPost]
        [Route("api/RegisterCountry")]
        public async Task<IActionResult> RegisterCountry(string CountryName, string areaCode)
        {
            try
            {
                _context.Country.Add(new Countries(CountryName, areaCode));
            }
            catch (Exception ex)
            {
                return BadRequest("Bad data received");
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest("Can't save country");
            }

            return Ok("OK");
        }

        [HttpPost]
        [Route("api/RegisterState")]
        public async Task<IActionResult> RegisterState(string stateName, int countryCode)
        {
            try
            {
                _context.CountryStates.Add(new CountryStates(stateName, countryCode));
            }
            catch(Exception ex) 
            {
                return BadRequest("Bad data received");
            }

            try { 
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest("Can't save state");
            }

            return Ok("OK");
        }

        [HttpPost]
        [Route("api/RegisterCity")]
        public async Task<IActionResult> RegisterCity(string cityName, int stateCode)
        {
            try
            {
                _context.Cities.Add(new Cities(cityName, stateCode));
            }
            catch (Exception ex)
            {
                return BadRequest("Bad data received");
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest("Can't save city");
            }

            return Ok("OK");
        }

    }
}
