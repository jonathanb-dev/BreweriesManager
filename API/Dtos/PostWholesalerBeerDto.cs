﻿using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PostWholesalerBeerDto
    {
        public int WholesalerId { get; set; }
        public int BeerId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be greater or equal to 0")]
        public int Stock { get; set; }
    }
}