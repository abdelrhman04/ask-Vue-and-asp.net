using AutoMapper;
using BLL.Helper;
using Core.DAL;
using MediatR;
namespace BLL.Services
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, APIResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        

        public GetByIdProductQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
           
        }
        public async Task<APIResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Data =
                    _mapper.Map<Product>(await _uow.Product.GetByIdAsync_AsNotracking(cancellationToken, x => x.Id == request.Id));
                return Data is not null
                    ? Data.GetRespons(false, "", 200)
                    : Data.GetRespons(false, "", 404);
            }
            catch (Exception ex)
            {
                return ex.GetRespons(true, ex.Message, 600);
            }
        }
    }
}
