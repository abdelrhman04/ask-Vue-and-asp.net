


using Core.DAL;
using Microsoft.AspNetCore.Identity;

namespace BLL
{
    public interface IUnitOfWork
    {

        
       IRepository<Product> Product { get; }
        IRepository<IdentityRole> IdentityRole { get; }
        
        void Save();
    }
}
