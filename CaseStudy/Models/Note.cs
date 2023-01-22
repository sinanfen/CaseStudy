using CaseStudy.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseStudy.Models
{
    public class Note : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Note Detail")]
        public List<NoteDetail>? NoteDetails { get; set; }
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        [Display(Name = "User")]
        public User? User { get; set; }
        [Display(Name = "Content")]
        public string Content { get; set; }
    }
}
