using AutoMapper;
using BLL.Helper;
using Core.DAL;
using CORE.DTO;
using MediatR;
namespace BLL.Services
{
    public class UpdateProductCommandHapler : IRequestHandler<UpdateProductCommand, APIResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateProductCommandHapler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<APIResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var return_value =
                     await unitOfWork.Product.GetByIdAsync_AsNotracking(cancellationToken, x => x.Id == request.ProductInput.Id);
                if (request.ProductInput.file!=null)
                {
                    var image = request.upload("Image", request.ProductInput.file, return_value.Image);
                    request.ProductInput.Image = image;
                }
             
                
                return return_value is null ?
                    return_value.GetRespons(false, 
                        "Element Not Found", 404)
                     : 
                        mapper.Map<ProductOutput>(await unitOfWork.Product.UpdateAsync_Return(
                         mapper.Map<Product>(request.ProductInput), cancellationToken)).GetRespons(true,
                        "", 200);
            }
            catch (Exception ex)
            {
                return ex.GetRespons(true, ex.Message, 600);
            }
        }
    }
}
