using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GetAllProductQuery : IRequest<APIResponse>
    {
        public decimal page { get; set; } = 1;
    }
}
