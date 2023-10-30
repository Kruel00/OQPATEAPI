using OQPATE.DB;
using OQPATE.DB.Models;

namespace OQPATE.API.Services
{
    public interface IAuthorizationServices
    {
        Task<AuthorizationResponse> GetAuthorizationResponseAsync( AuthorizationRequest request);
    }
}
