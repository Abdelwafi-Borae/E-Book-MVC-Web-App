using E_Book_DataAccess.Data;
using E_Book_DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Book_DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICatogeryRepository1 Catogery { get; private set; }

        public ICoverTypeRepository CoverType { get; private set; }

        public IProductRepository Product { get; private set; }

        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Catogery=new CatogeryRepository1(_dbContext);
            CoverType = new CoverTypeRepository(_dbContext);
            Product = new ProductRepository(_dbContext);

        }



        public void Save()
        {
          _dbContext.SaveChanges();
        }
    }
}
