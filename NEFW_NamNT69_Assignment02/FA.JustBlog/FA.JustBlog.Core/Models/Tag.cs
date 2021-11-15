using FA.JustBlog.Core.Models.EntityBase;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    [Table("Tags")]
    public class Tag : BaseEntity
    {
        [Required(ErrorMessage = "Tag name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string UrlSlug { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public int? Count { get; set; }

        public virtual ICollection<PostTagMap> PostTagMaps { get; set; }
    }
}