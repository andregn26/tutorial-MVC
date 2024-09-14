using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tutorial_MVC.Data;
using tutorial_MVC.Models;

namespace tutorial_MVC.Controllers
{
    public class Menu : Controller
    {
        private readonly DataContext _context;

        public Menu(DataContext context) { 
        _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dishes.ToListAsync());
        }
    }
}
