using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OQPATE.DB;
using OQPATE.DB.Models;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace OQPATE.API.Controllers
{
    public class ReportsController : ControllerBase
    {

        private readonly MySQLContext _context;
        public ReportsController(MySQLContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        [Route("api/GetEraseResultAll")]
        public async Task<IActionResult> GetEraseResultAll()
        {
            return Ok(_context.EraseResults.ToList());
        }

        [Authorize]
        [HttpGet]
        [Route("api/GetEraseResulByID")]
        public async Task<IActionResult> GetEraseResulByID(int id)
        {
            return Ok(_context.EraseResults.FirstOrDefault(q => q.EraseId == id));
        }

        [Authorize]
        [HttpGet]
        [Route("api/GetTicketsAll")]
        public async Task<IActionResult> GetTicketsAll()
        {
            return Ok(_context.TicketProcesses.ToList());
        }


    }
}
