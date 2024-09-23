using E_Book_DataAccess.Data;
using E_Book_DataAccess.Repository.IRepository;
using E_Book_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Book_DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext context)  :base(context)
        {
            _appDbContext   = context;
        }


        public void Update(Product obj)
        {
            var objfromdb=_appDbContext.Products.FirstOrDefault(p=>p.Id==obj.Id);
            if (objfromdb != null)
            {
                objfromdb.ISBN = obj.ISBN;
                objfromdb.ListPrice = obj.ListPrice;
                objfromdb.Price = obj.Price;
                objfromdb.Price1000 = obj.Price1000;
                objfromdb.Price50 = obj.Price50;
                objfromdb.Author = obj.Author;
                objfromdb.CatogeryId = obj.CatogeryId;
                objfromdb.Cover_TypeId = obj.Cover_TypeId;
                objfromdb.Description = obj.Description;
                objfromdb.Tital = obj.Tital;
                if(obj.ImageUrl != null) {
                    objfromdb.ImageUrl = obj.ImageUrl;
                }
                
                 
            }
        }
    }
}
