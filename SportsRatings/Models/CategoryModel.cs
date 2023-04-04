﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportsRatings.Models.Interfaces;

namespace SportsRatings.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("CATEGORY NAME")]
        public string Name { get; set; } = null!;
        [DisplayName("CATEGORY DESCRIPTION")]
        public string Description { get; set; }

        public IEnumerable<SportModel> Sports { get; set; } = null!;
    }

    //public class CategoryBase
    //{       
        
    //}
}