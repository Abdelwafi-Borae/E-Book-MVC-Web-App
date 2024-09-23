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
    public class CoverTypeRepository : Repository<Cover_type>, ICoverTypeRepository
    {
        private readonly AppDbContext _appDbContext;

        public CoverTypeRepository(AppDbContext context)  :base(context)
        {
            _appDbContext   = context;
        }


        public void Update(Cover_type obj)
        {
            _appDbContext.Cover_Types.Update(obj);
        }
    }
}
