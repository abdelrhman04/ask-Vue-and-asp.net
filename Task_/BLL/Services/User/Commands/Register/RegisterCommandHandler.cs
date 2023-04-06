using AutoMapper;
using BLL.Helper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, APIResponse>
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public RegisterCommandHandler(UserManager<IdentityUser> userManager
           
            , IMapper _mapper,
IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            mapper = _mapper;
            this.unitOfWork = unitOfWork;   
        }

        public async Task<APIResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                
                var userExists = await userManager.FindByEmailAsync(request?.User?.Email);
                if (userExists != null)
                {
                    return userExists.GetRespons(true, "هذا المستخدم موجود بالفعل", StatusCodes.Status500InternalServerError);
                }
                   
                
                var token = Guid.NewGuid().ToString();
                IdentityUser user =new IdentityUser
                {
                    UserName=request?.User?.UserName,
                    Email= request?.User?.Email,
                };
                var result = await userManager.CreateAsync(user, request?.User?.PasswordHash);
                await userManager.AddToRoleAsync(user, request?.Role);
                if (!result.Succeeded)
                {
                    return userExists.GetRespons(true, "لم يتم إنشاء مستخدم الرجاء التحقق من البيانات و المحاولة مجدداً", 400);
                }
                return userExists.GetRespons(false, "تم إنشاء المستخدم الرجاء تسجيل الدخول", 200);
                
            }
            catch (Exception ex)
            {
                return ex.GetRespons(true, ex.Message, StatusCodes.Status500InternalServerError);
   
            }
        }
    }
}
