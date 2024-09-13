using E_Book_Model;
using E_BookWeb.Data;
 
using Microsoft.AspNetCore.Mvc;

namespace E_BookWeb.Controllers
{
    public class CatogeryController : Controller
    {
        private readonly AppDbContext _AppDbContext;
        public CatogeryController(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Catogery> CatogryList = _AppDbContext.Catogeries;
            return View(CatogryList);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Catogery catogery)
        {
            if (catogery.Name == catogery.DisplayOrder.ToString())
            {
                ModelState.AddModelError("ss", "name and display can't match");
            }
            if (ModelState.IsValid)
            {
                _AppDbContext.Catogeries.Add(catogery);
                _AppDbContext.SaveChanges();
                TempData["success"] = "add data seccessfully";
                return RedirectToAction("Index");
            }
            return View(catogery);


        }
        [HttpGet]
        public IActionResult Edite(int? Id)
        {
            if (Id == null || Id == 0) return NotFound();
            var catogery= _AppDbContext.Catogeries.Find(Id);
            if(catogery == null) return NotFound();
            return View(catogery);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edite(Catogery catogery )
        {
            if (catogery.Name == catogery.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "name and display can't match");
            }
            if (ModelState.IsValid)
            {
                _AppDbContext.Catogeries.Update(catogery);
                _AppDbContext.SaveChanges();
                TempData["success"] = "update data seccessfully";
                return RedirectToAction("Index");
            }
            return View(catogery);


        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0) return NotFound();
            var catogery = _AppDbContext.Catogeries.Find(Id);
            if (catogery == null) return NotFound();
            return View(catogery);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {

            var catogery = _AppDbContext.Catogeries.Find(Id);
            if(catogery == null) return NotFound();
            _AppDbContext.Catogeries.Remove(catogery);
                _AppDbContext.SaveChanges();
            TempData["success"] = "delete data seccessfully";
                return RedirectToAction("Index");
            
           


        }
    }
}
