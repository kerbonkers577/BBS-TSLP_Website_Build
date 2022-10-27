using Microsoft.AspNetCore.Mvc;
using TSLP_Website_Merge.Models;
using TSLP_Website_Merge.Models.Domain;

namespace TSLP_Website_Merge.Controllers
{
    public class SellerController : Controller
    {
        private readonly DatabaseContext _db;

        public SellerController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Sellers> objSellerList = _db.sellers;
            return View(objSellerList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sellers obj)
        {
            if (ModelState.IsValid)
            {
                _db.sellers.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var sellerFromDb = _db.sellers.Find(id);

            if (sellerFromDb == null)
            {
                return NotFound();
            }

            return View(sellerFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Sellers obj)
        {
            if (ModelState.IsValid)
            {
                _db.sellers.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sellerFromDb = _db.sellers.Find(id);

            if (sellerFromDb == null)
            {
                return NotFound();
            }

            return View(sellerFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.sellers.Find(id);
            if(obj == null)
            { 
                return NotFound();
            }

                _db.sellers.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
