using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MiracleTransportathon.EntityLayer.Concrete;
using System.Security.Claims;

namespace MiracleTransportathon.WebApi.Helper
{
    public class UserHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public UserHelper(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }

        public async Task<string> GetCurrentCompanyIdAsync()
        {
            var userId = GetCurrentUserId();
            var user = await _userManager.FindByIdAsync(userId);
            

            if (user != null)
            {
                if (user.Company!=null)
                {

                return user.Company.Id.ToString(); // Varsayılan olarak CompanyId özelliği olsun
                }
            }

            return null; // Kullanıcı bulunamazsa veya CompanyId yoksa null dönebilirsiniz
        }
    }
}
