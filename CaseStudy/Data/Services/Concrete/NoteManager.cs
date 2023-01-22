using CaseStudy.Data.Base;
using CaseStudy.Data.Services.Abstract;
using CaseStudy.Models;

namespace CaseStudy.Data.Services.Concrete
{
    public class NoteManager : EntityBaseRepository<Note>, INoteService
    {
        public NoteManager(AppDbContext context) : base(context)
        {
        }
    }
}
