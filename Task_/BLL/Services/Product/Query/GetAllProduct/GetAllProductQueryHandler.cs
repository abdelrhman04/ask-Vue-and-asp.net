using AutoMapper;
using BLL.Helper;
using Core.DAL;
using MediatR;
namespace BLL.Services
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, APIResponse>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            _mapper = mapper;
        }
        public async Task<APIResponse> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Data = _mapper.Map<List<Product>>
                    (await uow.Product.ListAllAsync(cancellationToken));
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
