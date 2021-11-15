using FA.JustBlog.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models.EntityBase
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}