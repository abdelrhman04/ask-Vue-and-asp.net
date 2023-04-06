
using Core.DAL;
using CORE;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MyContext context;
        public UnitOfWork(MyContext _context)
        {
            context = _context;
        }

        private IRepository<IdentityRole> identityRole;
        public IRepository<IdentityRole> IdentityRole
        {
            get { return identityRole ?? (identityRole = new Repository<IdentityRole>(context)); }
        }
        

        private IRepository<Product> product;
        public IRepository<Product> Product
        {
            get { return product ?? (product = new Repository<Product>(context)); }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
            System.GC.SuppressFinalize(this);
        }
    }
}
