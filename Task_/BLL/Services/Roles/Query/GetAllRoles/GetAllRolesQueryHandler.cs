using AutoMapper;
using CORE.DTO;

using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, APIResponse>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;
        public GetAllRolesQueryHandler(IUnitOfWork _uow, IMapper mapper)
        {
            uow = _uow;
            _mapper = mapper;
        }
        public async Task<APIResponse> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Result = await uow.IdentityRole.ListAllAsync(cancellationToken);
                return new APIResponse
                {
                    IsError = true,
                    Code = 200,
                    Message = "",
                    Data = Result
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
