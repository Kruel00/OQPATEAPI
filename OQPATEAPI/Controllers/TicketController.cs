using Microsoft.AspNetCore.Mvc;
using OQPATE.DB.Models;
using OQPATE.DB;
using Microsoft.AspNetCore.Authorization;

namespace OQPATE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly MySQLContext _context;

        public TicketController(MySQLContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost]
        public string Post(TicketProcess ticketProcess)
        {
            _context.TicketProcesses.Add(ticketProcess);
            _context.SaveChanges();
            return "OK";
        }
    }
}
