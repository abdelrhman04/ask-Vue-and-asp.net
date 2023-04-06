using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DeleteRolesCommandHandler : IRequestHandler<DeleteRolesCommand, APIResponse>
    {
        private readonly IUnitOfWork uow;
        public DeleteRolesCommandHandler(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public async Task<APIResponse> Handle(DeleteRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {
               
                var DeleteItem = await uow.IdentityRole.GetByIdAsync_AsNotracking(cancellationToken, x => x.Id == request.Id);
                if (DeleteItem == null)
                {
                    return new APIResponse
                    {
                        IsError = false,
                        Code = 404,
                        Message = "Element Not Found"
                    };
                }
                await uow.IdentityRole.DeleteAsync(DeleteItem, cancellationToken);
                return new APIResponse
                {
                    IsError = true,
                    Code = 200,
                    Message = "Element Deleted"
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    IsError = true,
                    Message = ex.Message,
                };
            }
        }
    }
}
