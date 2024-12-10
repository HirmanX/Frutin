﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Display(Name = "دسته بندی پدر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ParentCategoryID { get; set; }
        [Display(Name = "غنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Tittle { get; set; }
        [Display(Name = "نوع موجودیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string EntityType { get; set; }

        // Navigation Property :
        public virtual List<Product> Products { get; set; }
        public virtual List<Blog> Blogs { get; set; }

        public Category()
        {

        }
    }
}