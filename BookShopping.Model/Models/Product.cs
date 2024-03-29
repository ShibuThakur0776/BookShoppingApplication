﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopping.Model.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        public string Author { get; set; }
        [Required]
        [Range(1,10000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }
        [Required]
        [Range(1,10000)]
        public double Price50 { get; set; }
        [Required]
        [Range(1,10000)]
        public double Price100 { get; set; }
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }
        [Display(Name ="Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get;set;}
        [Display(Name ="Cover Type ")]
        public int CoverTypeId { get; set; }
        [ForeignKey("CoverTypeId")]
        public CoverType CoverType { get; set; }
        public bool IsDeleted { get; set; }
    }
}