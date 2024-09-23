using E_Book_DataAccess.Data;
using E_Book_DataAccess.Repository.IRepository;
using E_Book_Model;
using E_Book_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.X509Certificates;

namespace E_BookWeb.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IWebHostEnvironment _environment;
        public ProductController(IUnitOfWork Db, IWebHostEnvironment environment)
        {
            _unit = Db;
            _environment = environment;
        }
        public IActionResult Index()
        {
            //IEnumerable<Cover_type> cover_Types_List = _unit.CoverType.GetAll();
            return View();
        }


        [HttpGet]
        public IActionResult Upsert(int? Id)
        {
            ProductVM productVM = new()
            {
                product = new (),
                CatogeryList = _unit.Catogery.GetAll().Select(
                c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                CoverTypeList= _unit.CoverType.GetAll().Select(
                c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };

           
            if (Id == null || Id == 0)
            {
                ////create
                
                 
                return View(productVM);
            }
            else
            {
                productVM.product=_unit.Product.GetFirstOrDefault(p=>p.Id == Id);

            }
            return View(productVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM  obj,IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwrootpath = _environment.WebRootPath;
                if (file != null)
                {
                    string filename=Guid.NewGuid().ToString();
                    var uploads=Path.Combine(wwwrootpath,@"Images\Products");
                    var extention = Path.GetExtension(file.FileName);
                    if (obj.product.ImageUrl != null)
                    {
                        var oldimagepath = Path.Combine(wwwrootpath, obj.product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldimagepath))
                        {
                           
                            System.IO.File.Delete(oldimagepath);
                        }
                    }
                    using(var filestream=new FileStream(Path.Combine(uploads,filename+extention), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    obj.product.ImageUrl= @"Images\Products\"+filename+extention;

                }
                if (obj.product.Id == 0)
                {
                    _unit.Product.Add(obj.product);
                    _unit.Save();
                    TempData["success"] = "product  created seccessfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    _unit.Product.Update(obj.product);
                    _unit.Save();
                    TempData["success"] = "product  updated seccessfully";
                    return RedirectToAction("Index");
                }
            }
            return View(obj);


        }
       
        
        



        #region

        [HttpGet]
        public IActionResult GetAll()
        { string[] include =new string[] { "Catogery" , "Cover_Type" };
            var productlist = _unit.Product.GetAll(include);
            return Json(new {data =productlist});
        }

        [HttpDelete(Name = "Delete")]
        public IActionResult Delete(int? Id)
        {

            var product = _unit.Product.GetFirstOrDefault(c => c.Id == Id);
            if (product == null) return Json(new { success = false,message="error while deleting" }) ;
            var oldimagepath = Path.Combine(_environment.WebRootPath,  product.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldimagepath))
            {

                System.IO.File.Delete(oldimagepath);
            }
            _unit.Product.Remove(product);
            _unit.Save();
            //TempData["success"] = "delete data seccessfully";
            return Json(new { success = true, message = "delete successfull @ " });




        }


        #endregion
    }
}
