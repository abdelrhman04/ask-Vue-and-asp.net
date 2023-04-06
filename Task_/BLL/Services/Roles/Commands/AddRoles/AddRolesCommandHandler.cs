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
    public class AddRolesCommandHandler : IRequestHandler<AddRolesCommand, APIResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public AddRolesCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<APIResponse> Handle(AddRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                IdentityRole post=new IdentityRole();
                post.Name = request.Name;
                post.NormalizedName = request.Name.ToUpper();
                post = await unitOfWork.IdentityRole.AddAsync(post, cancellationToken);
                return new APIResponse
                {
                    IsError = false,
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
