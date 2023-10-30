using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQPATE.DB.Models
{
    public class AuthorizationResponse
    {
        public string Token { get; set; }   
        public bool Result { get; set; }
        public string Msg { get; set; }
    }
}
