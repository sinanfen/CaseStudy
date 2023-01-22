using CaseStudy.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseStudy.Models
{
    public class NoteDetail : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("NoteId")]
        public int? NoteId { get; set; }
        [Display(Name = "Note")]
        public Note? Notes { get; set; }
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        [Display(Name = "User")]
        public User? User { get; set; }
        [Display(Name = "Content")]
        public string Content { get; set; }
    }
}
