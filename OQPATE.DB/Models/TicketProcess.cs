using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQPATE.DB.Models
{
    public class TicketProcess
    {
        public TicketProcess()
        {

        }

        public TicketProcess(string userName, string identifier, string version, int testResultId, int eraseId, TestResults testResult, EraseResults eraseResult)
        {
            UserName = userName;
            this.identifier = identifier;
            this.version = version;
            TestResultId = testResultId;
            EraseId = eraseId;
            this.testResult = testResult;
            this.eraseResult = eraseResult;
            UploadDate= DateTime.Now;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ticketID { get; set; }
        public string UserName { get; set; }
        public string identifier { get; set; }
        public string version { get; set; }
        [ForeignKey("testResult")]
        public int? TestResultId { get; set; }
        [ForeignKey("eraseResult")]
        public int EraseId { get; set; }
        public TestResults? testResult { get; set; }
        public EraseResults eraseResult { get; set; }
        public DateTime UploadDate { get ; set; } 

    }

}
