using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieWebApp.Data;
using MovieWebApp.Models;
using MovieWebApp.Models.Movies;

namespace MovieWebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MovieModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieDB.ToListAsync());
        }

        // GET: MovieModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieModel = await _context.MovieDB
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieModel == null)
            {
                return NotFound();
            }

            return View(movieModel);
        }

        // GET: MovieModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Title,Genre,DateTime,Actors,Directors")] MovieModel movieModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieModel);
                await _context.SaveChangesAsync();
                TempData["AddedMovie"] = movieModel.Title;
                
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Search(string option, string search)
        {                
            if (option == "Title")
            {
                
                var movieTitles = _context.MovieDB.Where(x => x.Title == search || search == null).ToList();
                return View(movieTitles);
            }
            else
            {
                var movieGenres = _context.MovieDB.Where(x => x.Title.StartsWith(search) || search == null).ToList();
                return View(movieGenres);
            }
            
        }

        public IActionResult SearchResultTitle(string movieTitle)
        {
            List<MovieModel> movies = _context.MovieDB.Where(m => m.Title.ToUpper().Contains(movieTitle.ToUpper())).ToList();

            return View(movies);
        }

        public IActionResult SearchResultGenre(string movieGenre)
        {
            List<MovieModel> movies = _context.MovieDB.Where(g => g.Genre == movieGenre).ToList();

            return View(movies);
        }

        

        // GET: MovieModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieModel = await _context.MovieDB.FindAsync(id);
            if (movieModel == null)
            {
                return NotFound();
            }
            return View(movieModel);
        }

        // POST: MovieModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Title,Genre,DateTime,Actors,Directors")] MovieModel movieModel)
        {
            if (id != movieModel.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieModelExists(movieModel.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movieModel);
        }

        // GET: MovieModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieModel = await _context.MovieDB
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieModel == null)
            {
                return NotFound();
            }

            return View(movieModel);
        }

        // POST: MovieModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieModel = await _context.MovieDB.FindAsync(id);
            _context.MovieDB.Remove(movieModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieModelExists(int id)
        {
            return _context.MovieDB.Any(e => e.MovieId == id);
        }
    }
}
