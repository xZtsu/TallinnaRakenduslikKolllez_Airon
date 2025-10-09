using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolllež.Data;
using TallinnaRakenduslikKolllež.Models;


namespace TallinnaRakenduslikKolllež.Controllers
{
    public class DelinquentsController : Controller
    {
        private readonly SchoolContext _context;

        public DelinquentsController(SchoolContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Delinquents.ToListAsync());

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CurrentViolation = new SelectList(Enum.GetValues(typeof(Violation))
                .Cast<Violation>()
                .Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = v.ToString()
                }), "Value", "Text");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DelinquentID,FirstName,LastName,Violation,CurrentViolation,OnOpetaja,Description,Olukord")] Delinquent delinquent)
        {
            if (ModelState.IsValid)
            {
                _context.Delinquents.Add(delinquent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
          
            ViewBag.CurrentViolation = new SelectList(Enum.GetValues(typeof(Violation))
                            .Cast<Violation>()
                            .Select(v => new SelectListItem
                            {
                                Text = v.ToString(),
                                Value = v.ToString()
                            }), "Value", "Text");

            return View(delinquent);
        }
                [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(m => m.DelinquentID == id);
            if (delinquent == null)
            {
                return NotFound();
            }
            return View(delinquent);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(a => a.DelinquentID == id);
            if (delinquent == null)
            {
                return NotFound();
            }
           
            return View(delinquent);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delinqueent = await _context.Delinquents.FindAsync(id);
            _context.Delinquents.Remove(delinqueent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}