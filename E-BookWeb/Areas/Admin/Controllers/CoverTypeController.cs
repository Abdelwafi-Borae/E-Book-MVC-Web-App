using E_Book_DataAccess.Data;
using E_Book_DataAccess.Repository.IRepository;
using E_Book_Model;
using Microsoft.AspNetCore.Mvc;

namespace E_BookWeb.Areas.Admin.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unit;
        public CoverTypeController(IUnitOfWork Db)
        {
            _unit = Db;
        }
        public IActionResult Index()
        {
            IEnumerable<Cover_type> cover_Types_List = _unit.CoverType.GetAll();
            return View(cover_Types_List);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cover_type Cover_type)
        {
            //if (catogery.Name == catogery.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "name and display can't match");
            //}
            if (ModelState.IsValid)
            {
                _unit.CoverType.Add(Cover_type);
                _unit.Save();
                TempData["success"] = "add data seccessfully";
                return RedirectToAction("Index");
            }
            return View(Cover_type);


        }
        [HttpGet]
        public IActionResult Edite(int? Id)
        {
            if (Id == null || Id == 0) return NotFound();
            var Cover_type = _unit.CoverType.GetFirstOrDefault(c => c.Id == Id);
            if (Cover_type == null) return NotFound();
            return View(Cover_type);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edite(Cover_type Cover_type)
        {
            //if (catogery.Name == catogery.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "name and display can't match");
            //}
            if (ModelState.IsValid)
            {
                _unit.CoverType.Update(Cover_type);
                _unit.Save();
                TempData["success"] = "update data seccessfully";
                return RedirectToAction("Index");
            }
            return View(Cover_type);


        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0) return NotFound();
            var Cover_type = _unit.CoverType.GetFirstOrDefault(c => c.Id == Id);
            if (Cover_type == null) return NotFound();
            return View(Cover_type);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {

            var Cover_type = _unit.CoverType.GetFirstOrDefault(c => c.Id == Id);
            if (Cover_type == null) return NotFound();
            _unit.CoverType.Remove(Cover_type);
            _unit.Save();
            TempData["success"] = "delete data seccessfully";
            return RedirectToAction("Index");




        }
    }
}
