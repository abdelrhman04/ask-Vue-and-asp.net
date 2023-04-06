using BLL.Helper;

using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, APIResponse>
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly IConfiguration _configuration;

        public LoginQueryHandler(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            SignInManager = signInManager;
            _configuration = configuration;

        }

        public async Task<APIResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var userClaims = await userManager.GetClaimsAsync(user);

                var token = user.Create_Token(userRoles, userClaims, _configuration["JWT:Key"]);
                return new APIResponse
                {
                    IsError = false,
                    Message = "تم تسجيل الدخول بنجاح",
                    Data = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                        Role =userRoles
                    },
                    Code = 200
                };
            }
            return request.GetRespons(true, "الرجاء التأكد من البيانات", 401);
           
        }
    }
}
