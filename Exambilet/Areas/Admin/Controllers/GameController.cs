using Exambilet.Areas.Admin.ViewModels.Games;
using Exambilet.DAL;
using Exambilet.Models;
using Exambilet.Utilities.Enums;
using Exambilet.Utilities.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exambilet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GameController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public GameController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task< IActionResult> Index()
        {
            List<Game> games=await _context.Games.ToListAsync();
            return View(games);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Create(CreateGameVM createGameVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!createGameVM.ImageFile.ValidateType("image/"))
            {
                ModelState.AddModelError("ImageFile", "Duzgun format yuklememisiz");
                return View(createGameVM);
            }
            if (createGameVM.ImageFile.ValidateSize(FileSize.MB, 20))
            {
                ModelState.AddModelError("ImageFile", "Duzgun format yuklememisiz");
                return View(createGameVM);
            }

            Game game = new Game()
            {
                Name=createGameVM.Name,
                Price=createGameVM.Price,
                Sale=createGameVM.Sale,
                Image=await createGameVM.ImageFile.CreateFile(_env.WebRootPath,"assets","images")
            };



            await _context.Games.AddRangeAsync(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if(id==null || id < 1)
            {
                return BadRequest();
            }

            Game game = await _context.Games.FirstOrDefaultAsync(g=>g.Id==id);
            if (game == null)
            {
                return NotFound();
            }

            UpdateGameVM updateGameVM = new UpdateGameVM()
            {
                  Name=game.Name,
                  Price=game.Price,
                  Sale=game.Sale,
           

            };

         return View(updateGameVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id,UpdateGameVM updateGameVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id == null || id < 1)
            {
                return BadRequest();
            }

            Game game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }

  

            if(updateGameVM.Image != null)
            {
                if (!updateGameVM.ImageFile.ValidateType("image/"))
                {
                    ModelState.AddModelError("ImageFile", "Duzgun format yuklememisiz");
                    return View(updateGameVM);
                }
                if (updateGameVM.ImageFile.ValidateSize(FileSize.MB, 20))
                {
                    ModelState.AddModelError("ImageFile", "Duzgun format yuklememisiz");
                    return View(updateGameVM);
                }
            game.Image = await updateGameVM.ImageFile.CreateFile(_env.WebRootPath, "assets", "images");
            }


            game.Name=updateGameVM.Name;
            game.Price = updateGameVM.Price;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null || id < 1)
            {
                return BadRequest();
            }

            Game game=await _context.Games.FirstOrDefaultAsync(g => g.Id==id);
            if (game == null)
            {
                return NotFound();
            }

           _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        
    }
}
