﻿using System.ComponentModel.DataAnnotations;

namespace MenuPlanerApp.API.Model
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string ReferenceUnit { get; set; }

        [Required]
        public bool CompatibleForFructose { get; set; }

        [Required]
        public bool CompatibleForHistamin { get; set; }

        [Required]
        public bool CompatibleForLactose { get; set; }

        [Required]
        public bool CompatibleForCeliac { get; set; }


    }
}