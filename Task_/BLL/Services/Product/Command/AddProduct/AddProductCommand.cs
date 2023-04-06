
using CORE.DTO;
using MediatR;
namespace BLL.Services
{
    public class AddProductCommand : IRequest<APIResponse>
    {
       public ProductInput? ProductInput { get; set; }
    }
}
