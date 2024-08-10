#pragma warning disable CS8629 // Nullable value type may be null.
using WeddingPlanner.Attributes;
using WeddingPlanner.Context;
using WeddingPlanner.Models;
using WeddingPlanner.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WeddingPlanner.Controllers;

public class WeddingController : Controller
{
    private readonly ApplicationContext _context;

    public WeddingController(ApplicationContext context)
    {
        _context = context;
    }

    [SessionCheck]
    [HttpGet("weddings")]
    public IActionResult Weddings(string? property)
    {
        int? userId = HttpContext.Session.GetInt32("userId");
        if (userId is null)
        {
            return RedirectToAction("Index");
        }

        var user = _context.Users.FirstOrDefault((user) => user.UserId == userId);

        if (user is null)
        {
            return RedirectToAction("Index");
        }

        var viewModel = new WeddingsPageViewModel()
        {
            User = user,
            Weddings = GetSortedWeddings(property ?? "CreatedAt"),
        };
        Console.WriteLine("````````````````T1````````````````");
        return View("Weddings", viewModel);
    }

    [HttpPost("weddings/sort")]
    public RedirectToActionResult SortWeddings(string property)
    {
        return RedirectToAction("Weddings", new { property });
    }

    public List<Wedding> GetSortedWeddings(string property)
    {
        Console.WriteLine("````````````````T2````````````````");
        return property switch

        {
            "Date" => _context.Weddings
                            .Include((w) => w.Rsvp)
                            .ThenInclude((r) => r.User)
                            .OrderBy((w) => w.Date)
                            .ToList(),
            _ => _context.Weddings
                            .Include((w) => w.Rsvp)
                            .ThenInclude((r) => r.User)
                            .OrderBy((w) => w.CreatedAt)
                            .ToList(),
        };

    }


    [SessionCheck]
    [HttpGet("weddings/new")]
    public ViewResult NewWedding()
    {
        Console.WriteLine("````````````````T3````````````````");
        var wedding = new Wedding()
        {
            UserId = (int)HttpContext.Session.GetInt32("userId"),
        };

        return View("NewWedding", wedding);
    }

    [SessionCheck]
    [HttpPost("weddings/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (!ModelState.IsValid)
        {
            var wedding = new Wedding()
            {
                UserId = (int)HttpContext.Session.GetInt32("userId"),
            };

            return View("NewWedding", wedding);
        }
        Console.WriteLine("````````````````T4````````````````");
        _context.Weddings.Add(newWedding);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
    }

    [SessionCheck]
    [HttpGet("weddings/{weddingId:int}")]
    public IActionResult WeddingDetails(int weddingId)
    {
        var wedding = _context.Weddings
            .Include((w) => w.Rsvp)
            .ThenInclude((r) => r.User)
            .FirstOrDefault((w) => w.WeddingId == weddingId);
        if (wedding is null)
        {
            return NotFound();
        }

        var viewModel = new WeddingDetailsViewModel()
        {
            UserId = (int)HttpContext.Session.GetInt32("userId"),
            Wedding = wedding,
            Rsvp = new Rsvp()
            {
                UserId = (int)HttpContext.Session.GetInt32("userId"),
                WeddingId = weddingId,
            }
        };

        return View("WeddingDetails", viewModel);
    }

    // [SessionCheck]
    // [HttpPost("weddings/{weddingId:int}/rsvp/create")]
    // public IActionResult CreateRsvp(int weddingId, Rsvp newRsvp)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         var message = string.Join(" | ", ModelState.Values
    //             .SelectMany(v => v.Errors)
    //             .Select(e => e.ErrorMessage));
    //         Console.WriteLine(message);

    //         var wedding = _context.Weddings.FirstOrDefault((w) => w.WeddingId == weddingId);
    //         if (wedding is null)
    //         {
    //             return NotFound();
    //         }

    //         var viewModel = new WeddingDetailsViewModel()
    //         {
    //             UserId = (int)HttpContext.Session.GetInt32("userId"),
    //             Wedding = wedding,
    //             Rsvp = new Rsvp()
    //             {
    //                 UserId = (int)HttpContext.Session.GetInt32("userId"),
    //             }
    //         };
    //         return View("WeddingDetails", viewModel);
    //     }

    //     _context.Rsvps.Add(newRsvp);
    //     _context.SaveChanges();
    //     return RedirectToAction("WeddingDetails", new { weddingId });
    // }

    [SessionCheck]
    [HttpPost("weddings/{weddingId:int}/rsvp")]
    public IActionResult RSVP(int weddingId)
    {
        int? userId = HttpContext.Session.GetInt32("userId");
        if (userId is null)
        {
            return RedirectToAction("Index");
        }

        // var existingRsvp = _context.Rsvps.FirstOrDefault(r => r.WeddingId == weddingId && r.UserId == userId);

        // if (existingRsvp == null)
        // {
        var rsvp = new Rsvp
        {
            WeddingId = weddingId,
            UserId = (int)userId
        };

        _context.Rsvps.Add(rsvp);
        _context.SaveChanges();
        // }

        return RedirectToAction("Weddings");
    }

    [SessionCheck]
    [HttpPost("weddings/{weddingId:int}/unrsvp")]
    public IActionResult UnRSVP(int weddingId)
    {
        int? userId = HttpContext.Session.GetInt32("userId");
        if (userId is null)
        {
            return RedirectToAction("Index");
        }

        var existingRsvp = _context.Rsvps.FirstOrDefault(r => r.WeddingId == weddingId && r.UserId == userId);

        if (existingRsvp != null)
        {
            _context.Rsvps.Remove(existingRsvp);
            _context.SaveChanges();
        }

        return RedirectToAction("Weddings");
    }

    [SessionCheck]
    [HttpGet("weddings/{weddingId:int}/edit")]
    public IActionResult EditWedding(int weddingId)
    {
        var wedding = _context.Weddings.FirstOrDefault((w) => w.WeddingId == weddingId);

        if (wedding is null)
        {
            return NotFound();
        }

        return View("EditWedding", wedding);
    }

    [SessionCheck]
    [HttpPost("weddings/{weddingId:int}/update")]
    public IActionResult UpdateWedding(int weddingId, Wedding updatedWedding)
    {
        var existingWedding = _context.Weddings.FirstOrDefault((w) => w.WeddingId == weddingId);
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
            var wedding = _context.Weddings.FirstOrDefault((w) => w.WeddingId == weddingId);

            if (wedding is null)
            {
                return NotFound();
            }

            return View("EditWedding", wedding);
        }

        existingWedding.WedderOne = updatedWedding.WedderOne;
        existingWedding.WedderTwo = updatedWedding.WedderTwo;
        existingWedding.Date = updatedWedding.Date;
        existingWedding.Address = updatedWedding.Address;
        existingWedding.UpdatedAt = updatedWedding.UpdatedAt;

        _context.SaveChanges();
        return RedirectToAction("WeddingDetails", new { weddingId });
    }

    [SessionCheck]
    [HttpPost("weddinga/{weddingId:int}/delete")]
    public IActionResult DeleteWedding(int weddingId)
    {
        Console.WriteLine("DELETEWEDDING METHOD INVOKED!!!");
        Console.WriteLine($"Wedding ID: {weddingId}");
        var existingWedding = _context.Weddings.FirstOrDefault((w) => w.WeddingId == weddingId);

        if (existingWedding is null)
        {
            return NotFound();
        }

        _context.Weddings.Remove(existingWedding);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
    }
}
