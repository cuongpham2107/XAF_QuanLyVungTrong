using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security.Strategy;
using DXApplication.Module.BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevExpress.ExpressApp.Security;
using crypto;
using DXApplication.Module.BusinessObjects.QLVungTrong;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Xpo;

namespace MobileApps.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrentUser : ControllerBase
    {
        ISecurityProvider securityProvider;
        public CurrentUser(ISecurityProvider securityProvider)
        {
            this.securityProvider = securityProvider;
        }

        [HttpGet]
        public IActionResult GetCurrentUserInfo()
        {
            // Lấy thông tin người dùng hiện tại
            ISecurityStrategyBase security = securityProvider.GetSecurity();
            if (security != null)
            {
                // Tạo một object chứa thông tin người dùng
                var userInfo = new
                {
                    UserName = security.UserName,
                };
                // Trả về thông tin người dùng dưới dạng JSON
                return Ok(userInfo);
            }
            else
            {
                return NotFound(); // Hoặc trả về mã lỗi khác tùy theo yêu cầu của bạn
            }

        }
        //[HttpGet]
        //public IActionResult GetCurrentUserInfo(XPObjectSpace xPObjectSpace)
        //{
        //    // Lấy thông tin người dùng hiện tại
        //    var a= xPObjectSpace.FindObject<ApplicationUser>(CriteriaOperator.Parse("ID=CurrentUserId()"));

        //    if (a != null)
        //    {
        //        // Tạo một object chứa thông tin người dùng
        //        var userInfo = new
        //        {
        //            NongHo = a.NongHo.Ten,
        //        };
        //        // Trả về thông tin người dùng dưới dạng JSON
        //        return Ok(userInfo);
        //    }
        //    else
        //    {
        //        return NotFound(); // Hoặc trả về mã lỗi khác tùy theo yêu cầu của bạn
        //    }

        //}
    }
}
