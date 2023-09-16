namespace MiracleTransportathon.WebUI.Helper
{
    using Microsoft.AspNetCore.Http;
    using System.Security.Claims;

    public class UserHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string GetCurrentRole()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }
    }

}
