using CaseStudy.Data;
using CaseStudy.Data.Services.Abstract;
using CaseStudy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Controllers
{
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;
        private readonly AppDbContext _context;

        public NotesController(AppDbContext context, INoteService noteService)
        {
            _context = context;
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allNotes = await _context.Notes.Include(n => n.User).OrderBy(n => n.Id).ToListAsync();
            return View(allNotes);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([Bind("Content,UserId")] Note note)
        {
            if (!ModelState.IsValid)
            {
                return View(note);
            }
            note.UserId = new Random().Next(1, 11);
            await _context.AddAsync(note);
            await _context.SaveChangesAsync(true);
            return RedirectToAction("Index");
        }

        //GET : Notes/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var note = await _noteService.GetByIdAsync(id);
            if (note == null) return View("NotFound");
            return View(note);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var note = await _noteService.GetByIdAsync(id);
            if (note == null) return View("NotFound");

            await _noteService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
