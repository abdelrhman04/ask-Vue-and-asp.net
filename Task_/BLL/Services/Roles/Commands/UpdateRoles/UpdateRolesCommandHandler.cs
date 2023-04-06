using AutoMapper;
using CORE.DTO;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UpdateRolesCommandHandler : IRequestHandler<UpdateRolesCommand, APIResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public UpdateRolesCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<APIResponse> Handle(UpdateRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                IdentityRole post = await unitOfWork.IdentityRole.GetByIdAsync_AsNotracking(cancellationToken, x=>x.Id== request.Id);
                post.Name = request.Name;
                post.NormalizedName = request.Name.ToUpper();
                post = await unitOfWork.IdentityRole.UpdateAsync_Return(post, cancellationToken);
                return new APIResponse
                {
                    IsError = true,
                    Code = 200,
                    Message = "",
                    Data = mapper.Map<RolesOutput>(post),
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
