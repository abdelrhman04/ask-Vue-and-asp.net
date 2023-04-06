using AutoMapper;
using BLL.Helper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services 
{
    public class DeleteProductCommandHapler : IRequestHandler<DeleteProductCommand, APIResponse>
    {
        private readonly IUnitOfWork uow;

        public DeleteProductCommandHapler(IUnitOfWork _uow)
        {
            uow = _uow;
           
        }
        public async Task<APIResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var DeleteItm = await uow.Product.GetByIdAsync(cancellationToken, x => x.Id == request.Id);
                var image = request.upload("Image",null, DeleteItm.Image);
                return
                    DeleteItm
                   is null
                   ?
                   DeleteItm.GetRespons(false, "Element Not Found", 404)
                    : 
                    (await uow.Product.DeleteAsyncreturn(DeleteItm, cancellationToken)).GetRespons(true, "Element Deleted", 200) ;
            }
            catch (Exception ex)
            {
                return ex.GetRespons(true, ex.Message, 600);
            }
        }
    }
}
