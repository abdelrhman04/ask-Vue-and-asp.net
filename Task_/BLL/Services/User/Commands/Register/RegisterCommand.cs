
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RegisterCommand : IRequest<APIResponse>
    {
       public  IdentityUser? User { get; set; }
       public string Role { get; set; }
    }
}
