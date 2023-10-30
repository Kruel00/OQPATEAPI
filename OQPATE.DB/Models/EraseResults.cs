using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQPATE.DB.Models
{
    public class EraseResults
    {
        public EraseResults(string devicePath, string vendor, string capacity, string busTypeName, string deviceTypeName, string serialNumber, string sanitizationMethod, string eraseResult, DateTime eraseDate)
        {
            DevicePath = devicePath;
            Vendor = vendor;
            Capacity = capacity;
            BusTypeName = busTypeName;
            DeviceTypeName = deviceTypeName;
            SerialNumber = serialNumber;
            SanitizationMethod = sanitizationMethod;
            EraseResult = eraseResult;
            EraseDate = eraseDate;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EraseId { get; set; }    
        public string DevicePath { get; set; }
        public string Vendor { get; set; }
        public string Capacity { get; set; }
        public string BusTypeName { get; set; }
        public string DeviceTypeName { get; set; }
        public string SerialNumber { get; set; }
        public string SanitizationMethod { get; set; }
        public string EraseResult { get; set; }
        public DateTime EraseDate { get; set; }

    }
}
