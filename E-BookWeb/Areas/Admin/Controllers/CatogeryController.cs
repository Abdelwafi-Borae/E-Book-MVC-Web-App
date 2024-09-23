using E_Book_DataAccess.Data;
using E_Book_DataAccess.Repository.IRepository;
using E_Book_Model;
using Microsoft.AspNetCore.Mvc;

namespace E_BookWeb.Areas.Admin.Controllers
{
    public class CatogeryController : Controller
    {
        private readonly IUnitOfWork _unit;
        public CatogeryController(IUnitOfWork Db)
        {
            _unit = Db;
        }
        public IActionResult Index()
        {
            IEnumerable<Catogery> CatogryList = _unit.Catogery.GetAll();
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
                ModelState.AddModelError("Name", "name and display can't match");
            }
            if (ModelState.IsValid)
            {
                _unit.Catogery.Add(catogery);
                _unit.Save();
                TempData["success"] = "add data seccessfully";
                return RedirectToAction("Index");
            }
            return View(catogery);


        }
        [HttpGet]
        public IActionResult Edite(int? Id)
        {
            if (Id == null || Id == 0) return NotFound();
            var catogery = _unit.Catogery.GetFirstOrDefault(c => c.Id == Id);
            if (catogery == null) return NotFound();
            return View(catogery);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edite(Catogery catogery)
        {
            if (catogery.Name == catogery.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "name and display can't match");
            }
            if (ModelState.IsValid)
            {
                _unit.Catogery.Update(catogery);
                _unit.Save();
                TempData["success"] = "update data seccessfully";
                return RedirectToAction("Index");
            }
            return View(catogery);


        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0) return NotFound();
            var catogery = _unit.Catogery.GetFirstOrDefault(c => c.Id == Id);
            if (catogery == null) return NotFound();
            return View(catogery);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {

            var catogery = _unit.Catogery.GetFirstOrDefault(c => c.Id == Id);
            if (catogery == null) return NotFound();
            _unit.Catogery.Remove(catogery);
            _unit.Save();
            TempData["success"] = "delete data seccessfully";
            return RedirectToAction("Index");




        }
    }
}
