using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolllež.Data;

namespace TallinnaRakenduslikKolllež.Controllers
{
    public class StudentsController : Controller
    {
       
            private readonly SchoolContext _context;
            public StudentsController(SchoolContext context)
            {
                _context = context;
            }
        
        
            public async Task<IActionResult> Index()
            {
                return View(await _context.Students.ToListAsync());
                        }
        public async Task<IActionResult> Delete(int? id)
            {
                if(id == null)
                {
                    return NotFound();
                }
                var student = await _context.Students.SingleOrDefaultAsync(m => m.Id == id);
                if(student == null)
                {
                    return NotFound();
                }
                   return View(student);
            }
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var student = await _context.Students.FindAsync(id);
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
    }
}
