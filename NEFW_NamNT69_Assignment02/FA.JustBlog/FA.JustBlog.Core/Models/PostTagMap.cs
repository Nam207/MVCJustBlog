using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    [Table("PostTagMaps")]
    public class PostTagMap
    {
        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public Post post { get; set; }

        public int TagId { get; set; }

        [ForeignKey("TagId")]
        public Tag tag { get; set; }
    }
}