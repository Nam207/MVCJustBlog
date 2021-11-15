﻿using FA.JustBlog.Core.Models.Enums;
using System;

namespace FA.JustBlog.ViewModels.Posts
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string PostContent { get; set; }

        public string UrlSlug { get; set; }

        public string Published { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime Modified { get; set; }

        public int CategoryId { get; set; }

        public int ViewCount { get; set; }

        public int RateCount { get; set; }

        public int TotalRate { get; set; }

        public decimal Rate { get; set; }

        public Status Status { get; set; }

    }
}