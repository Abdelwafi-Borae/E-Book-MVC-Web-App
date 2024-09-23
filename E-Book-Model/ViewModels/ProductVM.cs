using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E_Book_Model.ViewModels
{
	public class ProductVM
	{
        [ValidateNever]
        public IEnumerable<SelectListItem> CatogeryList { set; get; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CoverTypeList { set; get; }
        public Product product  { set; get; }
}
}
