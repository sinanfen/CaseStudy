using CaseStudy.Data.Base;
using CaseStudy.Data.Services.Abstract;
using CaseStudy.Models;

namespace CaseStudy.Data.Services.Concrete
{
    public class NoteDetailManager : EntityBaseRepository<NoteDetail>, INoteDetailService
    {
        public NoteDetailManager(AppDbContext context) : base(context)
        {
        }
    }
}
