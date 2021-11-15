using FA.JustBlog.Core.Models.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    [Table("Comments")]
    public class Comment : BaseEntity
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(255)]
        public string Email { get; set; }

        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public Post post { get; set; }

        [Required(ErrorMessage = "Comment Header is required.")]
        [MaxLength(1024)]
        public string CommentHeader { get; set; }
    }
}