using CaseStudy.Data;
using CaseStudy.Data.Services.Abstract;
using CaseStudy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Controllers
{
    public class NoteDetailsController : Controller
    {

        //private readonly INoteService _noteService;
        private readonly AppDbContext _context;
        private readonly INoteService _noteService;
        private readonly INoteDetailService _noteDetailService;

        public NoteDetailsController(AppDbContext context, INoteDetailService noteDetailService, INoteService noteService)
        {
            _context = context;
            _noteDetailService = noteDetailService;
            _noteService = noteService;
        }

        public async Task<IActionResult> Index()
        {
            var allNoteDetails = await _context.NoteDetails.Include(n => n.Notes).Include(n => n.User).OrderBy(n => n.Notes.Id).ToListAsync();
            return View(allNoteDetails);
        }

        [HttpGet]
        public IActionResult AddDetail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDetail([Bind("Content,NoteId,UserId")] NoteDetail noteDetail, int noteId)
        {
            if (!ModelState.IsValid)
            {
                return View(noteDetail);
            }
            var selectedNote = await _noteService.GetByIdAsync(noteId);
            //noteDetail.NoteId = new Random().Next(1, 12);
            noteDetail.UserId = new Random().Next(1, 11);
            await _context.AddAsync(noteDetail);
            await _context.SaveChangesAsync(true);
            return RedirectToAction("Index");
        }

        //GET : NoteDetails/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var noteDetails = await _noteDetailService.GetByIdAsync(id);
            if (noteDetails == null) return View("NotFound");
            return View(noteDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var noteDetails = await _noteDetailService.GetByIdAsync(id);
            if (noteDetails == null) return View("NotFound");

            await _noteDetailService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
