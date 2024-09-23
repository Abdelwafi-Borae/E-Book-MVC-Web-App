using E_Book_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Book_DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository: IRepository<Cover_type>
    {
        void Update(Cover_type obj);
       
    }
}


 
