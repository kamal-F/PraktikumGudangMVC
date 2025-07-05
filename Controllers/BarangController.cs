using GudangWebApp.Models;
using GudangWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GudangWebApp.Controllers
{
    public class BarangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BarangController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Barang.ToList();
            return View(data);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(BarangViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var barang = new Barang
                {
                    KodeBarang = vm.KodeBarang,
                    NamaBarang = vm.NamaBarang,
                    JumlahStok = vm.JumlahStok,
                    Kategori = vm.Kategori
                };

                _context.Barang.Add(barang);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        public IActionResult Edit(int id)
        {
            var barang = _context.Barang.Find(id);
            if (barang == null) return NotFound();
            return View(barang);
        }

        [HttpPost]
        public IActionResult Edit(Barang barang)
        {
            if (ModelState.IsValid)
            {
                _context.Barang.Update(barang);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barang);
        }

        public IActionResult Delete(int id)
        {
            var barang = _context.Barang.Find(id);
            if (barang == null) return NotFound();
            return View(barang);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var barang = _context.Barang.Find(id);
            if (barang == null) return NotFound();

            _context.Barang.Remove(barang);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
