using MediatR;
namespace BLL.Services
{
    public class GetByIdRolesQuery : IRequest<APIResponse>
    {
        public string Id { get; set; }
    }
}
