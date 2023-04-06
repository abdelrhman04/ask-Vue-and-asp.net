using AutoMapper;
using BLL.Helper;
using Core.DAL;

using CORE.DTO;
using MediatR;


namespace BLL.Services
{
    public class AddProductCommandHapler : IRequestHandler<AddProductCommand, APIResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public AddProductCommandHapler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<APIResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
               var image =  request.upload("Image",request.ProductInput.file);
                request.ProductInput.Image= image;
                var Data = mapper.Map<ProductOutput>(await unitOfWork.Product.AddAsync(mapper.Map<Product>(request.ProductInput), cancellationToken));
                return Data is not  null
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
