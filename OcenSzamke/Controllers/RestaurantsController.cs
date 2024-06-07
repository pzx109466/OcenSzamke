using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcenSzamke.Data;
using OcenSzamke.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

public class RestaurantsController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public RestaurantsController(AppDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index(string searchString)
    {
        var restaurants = _context.Restaurants
                                  .Include(r => r.Reviews)
                                  .AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
        {
            restaurants = restaurants.Where(s => s.Name.Contains(searchString));
        }

        return View(await restaurants.ToListAsync());
    }

    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Create([Bind("Name,Address")] Restaurant restaurant)
    {
        if (ModelState.IsValid)
        {
            restaurant.UserId = _userManager.GetUserId(User); // Przypisz ID zalogowanego użytkownika
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(restaurant);
    }



    [HttpGet]
    [Authorize]
    public IActionResult CreateReview(int restaurantId)
    {
        var restaurant = _context.Restaurants.FirstOrDefault(r => r.RestaurantId == restaurantId);

        if (restaurant == null)
        {
            return NotFound();
        }

        var reviewViewModel = new ReviewViewModel
        {
            RestaurantId = restaurant.RestaurantId,
            RestaurantName = restaurant.Name
        };

        return View(reviewViewModel);
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> CreateReview(ReviewViewModel review)
    {
        if (!ModelState.IsValid)
        {
            return View(review);
        }

        // Pobierz użytkownika i sprawdź, czy istnieje
        var userId = _userManager.GetUserId(User);
        if (userId == null)
        {
            return NotFound("Nie znaleziono użytkownika.");
        }

        var newReview = new Review
        {
            RestaurantId = review.RestaurantId,
            Rating = review.Rating,
            Comment = review.Comment,
            UserId = userId
        };

        _context.Add(newReview);
        await _context.SaveChangesAsync();
        return RedirectToAction("Details", new { id = review.RestaurantId });
    }






    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var restaurant = await _context.Restaurants
                                       .Include(r => r.Reviews)
                                       .FirstOrDefaultAsync(m => m.RestaurantId == id);

        if (restaurant == null)
        {
            return NotFound();
        }

        return View(restaurant);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant == null || restaurant.UserId != _userManager.GetUserId(User))
        {
            return NotFound();  // Tylko właściciel może edytować restaurację
        }

        return View(restaurant);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Edit(int id, [Bind("RestaurantId,Name,Address")] Restaurant restaurant)
    {
        if (id != restaurant.RestaurantId || restaurant.UserId != _userManager.GetUserId(User))
        {
            return NotFound();  // Sprawdź czy użytkownik jest właścicielem
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(restaurant);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Restaurants.Any(e => e.RestaurantId == restaurant.RestaurantId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(restaurant);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var restaurant = await _context.Restaurants
                                       .Include(r => r.Reviews)
                                       .FirstOrDefaultAsync(m => m.RestaurantId == id);
        if (restaurant == null || restaurant.UserId != _userManager.GetUserId(User))
        {
            return NotFound();  // Tylko właściciel może usunąć restaurację
        }

        return View(restaurant);
    }

    [HttpPost, ActionName("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant == null || restaurant.UserId != _userManager.GetUserId(User))
        {
            return NotFound();  // Tylko właściciel może usunąć restaurację
        }

        _context.Restaurants.Remove(restaurant);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
