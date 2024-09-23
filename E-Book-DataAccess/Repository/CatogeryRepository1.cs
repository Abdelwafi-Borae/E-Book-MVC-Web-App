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
    public class CatogeryRepository1 : Repository<Catogery>, ICatogeryRepository1
    {
        private readonly AppDbContext _Db;
        public CatogeryRepository1( AppDbContext db):base(db)
        {
                _Db = db;
        }
        

        public void Update(Catogery obj)
        {
            _Db.Catogeries.Update(obj);
        }
    }
}
