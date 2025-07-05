using Microsoft.AspNetCore.Mvc;
using GudangWebApp.Models;

namespace GudangWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarangApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BarangApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _context.Barang.ToList();
            return Ok(data); // return as JSON
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var barang = _context.Barang.Find(id);
            if (barang == null)
                return NotFound();

            return Ok(barang);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Barang barang)
        {
            _context.Barang.Add(barang);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = barang.Id }, barang);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Barang barang)
        {
            var existing = _context.Barang.Find(id);
            if (existing == null)
                return NotFound();

            existing.KodeBarang = barang.KodeBarang;
            existing.NamaBarang = barang.NamaBarang;
            existing.JumlahStok = barang.JumlahStok;
            existing.Kategori = barang.Kategori;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var barang = _context.Barang.Find(id);
            if (barang == null)
                return NotFound();

            _context.Barang.Remove(barang);
            _context.SaveChanges();
            return Ok();
        }
    }
}
