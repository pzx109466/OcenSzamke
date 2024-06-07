using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcenSzamke.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int RestaurantId { get; set; }
        public string UserId { get; set; } = string.Empty; // Zakładając, że UserId jest stringiem
        public int Rating { get; set; } // Typ wartościowy, domyślnie jest 0
        public string? Comment { get; set; } // Może być null, stąd znak zapytania
        public DateTime DatePosted { get; set; } = DateTime.Now; // Domyślna wartość to aktualna data
        [ForeignKey("RestaurantId")]
        public virtual Restaurant? Restaurant { get; set; } // Dopuszczenie wartości null
        public IdentityUser User { get; set; } = new IdentityUser(); // Zakładając, że używamy standardowego IdentityUser
    }

}
