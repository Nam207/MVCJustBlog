using FA.JustBlog.Core.Models.EntityBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    [Table("Posts")]
    public class Post : BaseEntity
    {
        [NotMapped]
        private decimal rate;

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(1024)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Post Content is required.")]
        public string PostContent { get; set; }

        [Required(ErrorMessage = "UrlSlug Post is required")]
        [MaxLength(255)]
        public string UrlSlug { get; set; }

        [Required(ErrorMessage = "Published is required")]
        [MaxLength(255)]
        public string Published { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime PostedOn { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category category { get; set; }

        public int ViewCount { get; set; }

        public int RateCount { get; set; }

        public int TotalRate { get; set; }

        public decimal Rate
        {
            get => rate;
            set
            {
                if(RateCount == 0)
                {
                    rate = 0;
                }
                else
                {
                    rate = TotalRate / RateCount;
                }             
            }
        }

        public virtual ICollection<PostTagMap> PostTagMaps { get; set; }
    }
}