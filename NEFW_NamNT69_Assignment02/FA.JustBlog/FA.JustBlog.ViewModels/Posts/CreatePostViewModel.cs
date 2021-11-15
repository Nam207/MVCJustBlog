using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Posts
{
    public class CreatePostViewModel
    {

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(255, ErrorMessage = "Title cann't exceed 255 characters")]
        public string Title { get; set; }

        [Display(Name = "Short Description")]
        [MaxLength(1024, ErrorMessage = "Short Description cann't exceed 1024 characters")]
        public string ShortDescription { get; set; }

        [Display(Name = "Content")]
        [Required(ErrorMessage = "Post Content is required.")]
        public string PostContent { get; set; }

        [Display(Name = "UrlSlug")]
        [Required(ErrorMessage = "UrlSlug Post is required")]
        [MaxLength(255, ErrorMessage = "UrlSlug cann't exceed 255 characters")]
        public string UrlSlug { get; set; }

        [Display(Name = "Published")]
        [Required(ErrorMessage = "Published is required")]
        [MaxLength(255, ErrorMessage = "Published cann't exceed 255 characters")]
        public string Published { get; set; }

        [Display(Name = "Category of Post")]
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        [Display(Name = "Tag of Post (separated by ';')")]
        public string Tags { get; set; }
    }
}
