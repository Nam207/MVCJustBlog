using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Categories
{
    public class CreateCategoryViewModel
    {
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(255, ErrorMessage = "Category Name cann't exceed 255 characters")]
        public string Name { get; set; }

        [Display(Name = "UrlSlug")]
        [Required(ErrorMessage = "UrlSlug is required.")]
        [StringLength(255, ErrorMessage = "UrlSlug cann't exceed 255 characters")]
        public string UrlSlug { get; set; }

        [Display(Name = "Description")]
        [StringLength(1024, ErrorMessage = "Description cann't exceed 1024 characters")]
        public string Description { get; set; }
    }
}
