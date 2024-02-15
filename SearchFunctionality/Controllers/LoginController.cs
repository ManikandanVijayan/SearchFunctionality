using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SearchFunctionality.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SearchFunctionality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Property  
        /// <summary>  
        /// IConfiguration
        /// </summary>  
        /// <returns></returns>  
        private IConfiguration _config;

        #endregion

        #region Contructor Injector  
        /// <summary>  
        /// Constructor Injection to access all methods or simply DI(Dependency Injection)  
        /// </summary>  
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        #endregion

        #region GenerateJWT  
        /// <summary>  
        /// Generate Json Web Token Method  
        /// </summary>  
        /// <param name="userInfo"></param>  
        /// <returns></returns>  
        private string GenerateJSONWebToken(LoginModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion

        #region AuthenticateUser  
        /// <summary>  
        /// User authentication  
        /// </summary>  
        /// <param name="login"></param>  
        /// <returns></returns>  
        private async Task<LoginModel> AuthenticateUser(LoginModel login)
        {
            LoginModel user = null;
            var pwdEncryption = new Encryption();
            var userName = pwdEncryption.Decrypt(_config.GetSection("adminpwd").Value);
            //Validate the User Credentials        
            if (login.UserName == userName)
            {
                user = new LoginModel { UserName = userName, Password = userName };
            }
            return user;
        }
        #endregion

        #region Login Validation  
        /// <summary>  
        /// Login Authenticaton
        /// </summary>  
        /// <param name="data"></param>  
        /// <returns></returns>  
        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginModel data)
        {
            IActionResult response = Unauthorized();
            var user = await AuthenticateUser(data);
            if (data != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { Token = tokenString, Message = "Success" });
            }
            return response;
        }
        #endregion

    }
}
