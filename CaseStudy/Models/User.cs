using CaseStudy.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Models
{
    public class User : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Notes")]
        public List<Note>? Notes { get; set; }
        [Display(Name = "Note Detali")]
        public List<NoteDetail>? NoteDetails { get; set; }
    }
}
