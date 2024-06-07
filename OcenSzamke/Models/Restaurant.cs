using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace OcenSzamke.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; } = string.Empty;  // Domyślna wartość, aby zapobiec null
        public string Address { get; set; } = string.Empty;  // Domyślna wartość, aby zapobiec null
        public string? UserId { get; set; }  // Dopuści wartości null

        public virtual IdentityUser? User { get; set; }  // Dopuści wartości null
        public virtual List<Review> Reviews { get; set; } = new List<Review>();

        [NotMapped]
        public string AverageRating
        {
            get
            {
                if (!Reviews.Any())
                    return "brak ocen";
                else
                    return Reviews.Average(r => r.Rating).ToString("0.0");
            }
        }
    }
}
