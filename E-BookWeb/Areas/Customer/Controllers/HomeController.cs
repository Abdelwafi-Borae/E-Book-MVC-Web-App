using E_Book_DataAccess.Repository.IRepository;
using E_Book_Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace E_BookWeb.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
           _unitOfWork=unitOfWork;
        }

        public IActionResult Index()
        {
             
            IEnumerable<Product> ProductList = _unitOfWork.Product.GetAll(new string[] { "Catogery", "Cover_Type" });
            return View(ProductList);
        }


        public IActionResult Details(int id)
        {
            ShopingCart shopingCart = new ()
            {
                Count = 1,
                Product = _unitOfWork.Product.GetFirstOrDefault(p => p.Id == id, new string[] { "Catogery", "Cover_Type" })

            }; 
            return View(shopingCart);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}