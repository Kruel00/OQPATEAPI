using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQPATE.DB.Models
{
    public class TestResults
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestResultId { get; set; }
        public DateTime TestDate { get; set; }
        public TestResults(DateTime testDate)
        {
            TestDate = DateTime.Now;
        }
    }
}
