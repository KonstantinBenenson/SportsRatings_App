﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SportsRatings.Models.Interfaces;

namespace SportsRatings.Models.DTO
{
    public class CreateSportDTO 
    {
        public SportModel Sport { get; set; } = null!;       
        public IEnumerable<SelectListItem> Categories { get; set; } = null!;
    }
}
