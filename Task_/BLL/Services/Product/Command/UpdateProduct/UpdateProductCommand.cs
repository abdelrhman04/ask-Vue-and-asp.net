using CORE.DTO;
using MediatR;
namespace BLL.Services
{
    public class UpdateProductCommand : IRequest<APIResponse>
    {
        public ProductInputUpdate? ProductInput { get; set; }
    }
}
