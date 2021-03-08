using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyResume.Models;

namespace MyResume.Controllers
{
    public class HomeController : Controller
    {
        private readonly CardContext _context;

        public HomeController(CardContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ReadAllViewModel Model = new ReadAllViewModel(await _context.Articles.ToListAsync(), await _context.Skills.ToListAsync(),
               await _context.Experiences.ToListAsync(), await _context.Educations.ToListAsync());
            return View(Model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
