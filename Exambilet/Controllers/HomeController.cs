using System.Diagnostics;
using Exambilet.DAL;
using Exambilet.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exambilet.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        

        public async Task< IActionResult> Index()
        {
            List<Game> games = await _context.Games.ToListAsync();
            return View(games);
        }

       
    }
}
