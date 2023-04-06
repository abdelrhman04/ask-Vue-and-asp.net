using AutoMapper;
using CORE.DTO;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace BLL.Services
{
    public class GetByIdRolesQueryHandler : IRequestHandler<GetByIdRolesQuery, APIResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetByIdRolesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<APIResponse> Handle(GetByIdRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Result = await _uow.IdentityRole.GetByIdAsync_AsNotracking(cancellationToken,x=>x.Id==request.Id);
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
