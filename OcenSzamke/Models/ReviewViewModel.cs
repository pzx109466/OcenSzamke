using System;
using System.ComponentModel.DataAnnotations;

namespace OcenSzamke.Models
{
    public class ReviewViewModel
    {
        public int Id { get; set; }

        [Required]
        public int RestaurantId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Ocena musi być między 1 a 5")]
        public int Rating { get; set; }

        [StringLength(500, ErrorMessage = "Komentarz nie może przekraczać 500 znaków")]
        public string? Comment { get; set; }

        // Dodanie nazwy restauracji do modelu
        public string RestaurantName { get; set; } = string.Empty; // Ustawia pusty ciąg jako domyślną wartość

    }
}
