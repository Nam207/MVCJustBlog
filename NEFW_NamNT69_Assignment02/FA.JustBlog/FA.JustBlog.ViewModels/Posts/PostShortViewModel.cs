using FA.JustBlog.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Posts
{
    public class PostShortViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Published { get; set; }

        public DateTime PostedOn { get; set; }

        public Status Status { get; set; } 
    }
}
