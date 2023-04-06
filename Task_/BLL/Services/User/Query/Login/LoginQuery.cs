using MediatR;

namespace BLL.Services
{
    public class LoginQuery : IRequest<APIResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
