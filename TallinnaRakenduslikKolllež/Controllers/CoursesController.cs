using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolllež.Data;
using TallinnaRakenduslikKolllež.Models;

namespace TallinnaRakenduslikKolllež.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;

        public CoursesController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var courses = _context.Courses.Include(c => c.Department)
                .AsNoTracking();
            Console.WriteLine(courses);
            return View(courses);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["action"] = "Create";
            PopulateDepartmentsDropDownList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course courses)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(courses);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
                // PopulateDepartmentsDropDownList(course.DepartmentID);

            }
            return View(courses);
        }
 
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var courses = await _context.Courses.FirstOrDefaultAsync(m => m.CourseID == id);
            if (courses == null)
            {
                return NotFound();
            }
            ViewBag.action = "Delete";
            return View("Delete", courses);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courses == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var courses = await _context.Courses.FirstOrDefaultAsync(m => m.CourseID == id);
            if (courses == null)
            {
                return NotFound();
            }
            ViewBag.action = "Details";
            return View("Delete", courses);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["action"] = "Edit";

            if (id == null)
            {
                return NotFound();
            }
            var courses = await _context.Courses.FirstOrDefaultAsync(r => r.CourseID == id);
            if (courses == null)
            {
                return NotFound();
            }
                    {
            PopulateDepartmentsDropDownList();
            return View("Create", courses);

        }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(int id, [Bind("CourseID,Title,Credits,DepartmentID,Department,Enrollments,CourseAssignments")] Course courses)
        
        {
            ViewData["action"] = "EditConfirmed";
            if (ModelState.IsValid)
            {
                _context.Courses.Update(courses);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return View(courses);


        }
        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;
            ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
        }


    }
}
