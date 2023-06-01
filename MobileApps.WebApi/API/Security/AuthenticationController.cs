using crypto;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Authentication;
using DevExpress.ExpressApp.Security.Authentication.ClientServer;
using DXApplication.Module.BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Cryptography;

namespace MobileApps.WebApi.JWT;

[ApiController]
[Route("api/[controller]")]
// This is a JWT authentication service sample.
public class AuthenticationController : ControllerBase {
    readonly IAuthenticationTokenProvider tokenProvider;
    internal ISecurityProvider securityProvider;
    public AuthenticationController(IAuthenticationTokenProvider tokenProvider, ISecurityProvider securityProvider) {
        this.tokenProvider = tokenProvider;
        this.securityProvider = securityProvider;
    }
    [HttpPost("Authenticate")]
    [SwaggerOperation("Checks if the user with the specified logon parameters exists in the database. If it does, authenticates this user.", "Refer to the following help topic for more information on authentication methods in the XAF Security System: <a href='https://docs.devexpress.com/eXpressAppFramework/119064/data-security-and-safety/security-system/authentication'>Authentication</a>.")]
    public IActionResult Authenticate(
        [FromBody]
        [SwaggerRequestBody(@"For example: <br /> { ""userName"": ""Admin"", ""password"": """" }")]
        AuthenticationStandardLogonParameters logonParameters
    ) {
       
        try {
            var _token = tokenProvider.Authenticate(logonParameters);
            if( _token != null )
            {
                ISecurityStrategyBase security = securityProvider.GetSecurity();
                ApplicationUser user = (ApplicationUser)security.User;
                string mattruoc = user.MatTruoc != null ? Convert.ToBase64String(user.MatTruoc) : null;
                string matsau = user.MatSau != null ? Convert.ToBase64String(user.MatSau) : null;
                string avatar = user.Avatar != null ? Convert.ToBase64String(user.Avatar) : null;
                return Ok(new { 
                    token = _token, 
                    user =  new
                    {
                        Oid = security.UserId,
                        Ten = user.Ten,
                        DiaChi = user.DiaChi,
                        SDT = user.SDT,
                        Email = user.DiaChiEmail,
                        CCCD = user.CCCD,
                        MatTruoc = mattruoc,
                        MatSau = matsau,
                        Avatar = avatar,
                    }
                });
            }
            return Ok( _token);


        }
        catch(AuthenticationException) {
            return Unauthorized("User name or password is incorrect.");
        }
    }
}
