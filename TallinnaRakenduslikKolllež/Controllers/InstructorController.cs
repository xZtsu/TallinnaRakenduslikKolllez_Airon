﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolllež.Data;
using TallinnaRakenduslikKolllež.Models;

namespace TallinnaRakenduslikKolllež.Controllers
{
    public class InstructorsController : Controller
    {
        
        private readonly SchoolContext _context;
        public InstructorsController(SchoolContext context)
        {
            
            _context = context;
        }
        public async Task<IActionResult> Index(int? Id, int? courseId)
        {
            var vm = new InstructorIndexData();
            vm.Instructors = await _context.Instructors
                .Include(i => i.OfficeAssignments)
                .Include(i => i.CourseAssignments)
                .ToListAsync();
            return View(vm);
        }
    }
}
