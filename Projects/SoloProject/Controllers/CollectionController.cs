#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8629 // Nullable value type may be null.
using SoloProject.Attributes;
using SoloProject.Context;
using SoloProject.Models;
using SoloProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using SoloProject.Services;


namespace SoloProject.Controllers;

public class CollectionController : Controller
{
    private readonly ApplicationContext _context;
    private readonly IImagekitAPIService _imagekit;

    public CollectionController(ApplicationContext context, IImagekitAPIService imagekit)
    {
        _context = context;
        _imagekit = imagekit;
    }

    [SessionCheck]
    [HttpGet("collections")]
    public IActionResult Collections()
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
        var userCollections = _context.Collections
                                   .Where(c => c.UserId == userId)
                                   .ToList();
        var viewModel = new CollectionsPageViewModel()
        {
            User = user,
            Collections = userCollections
        };

        Console.WriteLine("````````````````T1````````````````");
        return View("Collections", viewModel);
    }
    [SessionCheck]
    [HttpGet("collections/explore")]
    public IActionResult Explore()
    {
        int? userId = HttpContext.Session.GetInt32("userId");
        if (userId == null)
        {
            return RedirectToAction("Index");
        }

        var allUsers = _context.Users.ToList();
        var allCollections = _context.Collections
                                       .Include(c => c.User)
                                       .ToList();

        var viewModel = new ExplorePageViewModel
        {
            User = allUsers.FirstOrDefault(u => u.UserId == userId),
            Collections = allCollections,
            Users = allUsers
        };

        return View("Explore", viewModel);
    }

    [SessionCheck]
    [HttpGet("collections/new")]
    public ViewResult NewCollection()
    {
        Console.WriteLine("````````````````T3````````````````");
        var collection = new CollectionForm()

        {
            UserId = (int)HttpContext.Session.GetInt32("userId"),
        };

        return View("NewCollection", collection);
    }

    [SessionCheck]
    [HttpPost("collections/create")]
    public async Task<IActionResult> CreateCollection(CollectionForm collectionForm)
    {
        if (ModelState.IsValid)
        {
            var imageUrls = new List<string>();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (var image in collectionForm.Images)
            {
                var imageUrl = await _imagekit.UploadImageAsync((IFormFile)image!);
                imageUrls.Add(imageUrl);
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            var coverImage = await _imagekit.UploadImageAsync((IFormFile)collectionForm.CoverImage!);

#pragma warning disable CS8601 // Possible null reference assignment.
            var collection = new Collection()
            {
                UserId = (int)HttpContext.Session.GetInt32("userId"),
                CollectionName = collectionForm.CollectionName,
                JournalEntry = collectionForm.JournalEntry,
                CoverImage = coverImage,
                Date = collectionForm.Date,
                ImagePaths = imageUrls,
            };
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8601 // Possible null reference assignment.

            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();
            return RedirectToAction("Collections");
        }

        return View("CollectionDetails", collectionForm);
    }

    [SessionCheck]
    [HttpGet("collections/{collectionId:int}")]
    public IActionResult CollectionDetails(int collectionId)
    {
        var collection = _context.Collections
            .Include(c => c.Engagements)
            .ThenInclude(e => e.User)
            .FirstOrDefault(c => c.CollectionId == collectionId);

        if (collection is null)
        {
            return NotFound();
        }

        int userId = (int)HttpContext.Session.GetInt32("userId");

        var engagements = collection.Engagements
            .Where(e => e.Comment != null)
            .ToList();

        var likeCount = collection.Engagements.Count(e => e.Like);
        var isLiked = collection.Engagements.Any(e => e.UserId == userId && e.Like);

        var viewModel = new CollectionDetailsViewModel
        {
            UserId = userId,
            User = _context.Users.FirstOrDefault(u => u.UserId == collection.UserId),
            Collection = collection,
            Engagements = engagements,
            LikeCount = likeCount,
            IsLiked = isLiked,
            CommentCount = engagements.Count
        };

        return View("CollectionDetails", viewModel);
    }

    [SessionCheck]
    [HttpPost("collections/{collectionId:int}/engagement")]
    public IActionResult Engagement(int collectionId)
    {
        int? userId = HttpContext.Session.GetInt32("userId");
        if (userId is null)
        {
            return RedirectToAction("Index");
        }

        var engagement = new Engagement
        {
            CollectionId = collectionId,
            UserId = (int)userId
        };

        _context.Engagements.Add(engagement);
        _context.SaveChanges();


        return RedirectToAction("CollectionDetails");
    }
    [SessionCheck]
    [HttpPost("collections/{collectionId:int}/togglelike")]
    public IActionResult ToggleLike(int collectionId)
    {
        int? userId = HttpContext.Session.GetInt32("userId");
        if (userId is null)
        {
            return RedirectToAction("Index");
        }

        var engagement = _context.Engagements
            .FirstOrDefault(e => e.CollectionId == collectionId && e.UserId == userId);

        if (engagement is null)
        {
            engagement = new Engagement
            {
                CollectionId = collectionId,
                UserId = (int)userId,
                Like = true,
            };
            _context.Engagements.Add(engagement);
        }
        else
        {
            engagement.Like = !engagement.Like;
        }

        _context.SaveChanges();
        return RedirectToAction("CollectionDetails", new { collectionId });
    }

    [SessionCheck]
    [HttpPost("collections/{collectionId:int}/addcomment")]
    public IActionResult AddComment(int collectionId, string comment)
    {
        int? userId = HttpContext.Session.GetInt32("userId");
        if (userId is null)
        {
            return RedirectToAction("Index");
        }

        if (string.IsNullOrWhiteSpace(comment))
        {
            TempData["Error"] = "Comment cannot be empty.";
            return RedirectToAction("CollectionDetails", new { collectionId });
        }

        var engagement = _context.Engagements
            .FirstOrDefault(e => e.CollectionId == collectionId && e.UserId == userId);

        if (engagement is null)
        {
            engagement = new Engagement
            {
                CollectionId = collectionId,
                UserId = (int)userId,
                Comment = comment,
            };
            _context.Engagements.Add(engagement);
        }
        else
        {
            engagement.Comment = comment;
        }

        _context.SaveChanges();
        return RedirectToAction("CollectionDetails", new { collectionId });
    }

    [SessionCheck]
    [HttpGet("collections/{collectionId:int}/edit")]
    public IActionResult EditCollection(int collectionId)
    {
        var collection = _context.Collections.FirstOrDefault((c) => c.CollectionId == collectionId);

        if (collection is null)
        {
            return NotFound();
        }
        var collectionForm = new CollectionForm
        {
            CollectionId = collection.CollectionId,
            CollectionName = collection.CollectionName,
            JournalEntry = collection.JournalEntry,
            Date = collection.Date,

        };
        return View("EditCollection", collectionForm);
    }

    [SessionCheck]
    [HttpPost("collections/{collectionId:int}/update")]
    public async Task<IActionResult> UpdateCollection(int collectionId, CollectionForm collectionForm)
    {
        var existingCollection = _context.Collections.FirstOrDefault(c => c.CollectionId == collectionId);

        if (existingCollection == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            Console.WriteLine(message);


            collectionForm.CollectionId = collectionId;
            return View("EditCollection", collectionForm);
        }

        if (collectionForm.CoverImage != null)
        {
            var newCoverImageUrl = await _imagekit.UploadImageAsync((IFormFile)collectionForm.CoverImage!);
            existingCollection.CoverImage = newCoverImageUrl;
        }

        if (collectionForm.Images != null)
        {
            var newImages = new List<string>();
            foreach (var image in collectionForm.Images)
            {
                if (image != null)
                {
                    var imageUrl = await _imagekit.UploadImageAsync((IFormFile)image!);
                    newImages.Add(imageUrl);
                }
            }
            existingCollection.ImagePaths = newImages;
        }

#pragma warning disable CS8601 // Possible null reference assignment.
        existingCollection.CollectionName = collectionForm.CollectionName;
        existingCollection.JournalEntry = collectionForm.JournalEntry;
#pragma warning restore CS8601 // Possible null reference assignment.
        existingCollection.Date = collectionForm.Date;
        existingCollection.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();
        return RedirectToAction("CollectionDetails", new { collectionId });
    }

    [SessionCheck]
    [HttpGet("collections/profile/{userId:int}/edit")]
    public IActionResult EditProfile(int userId)
    {
        var profile = _context.Users.FirstOrDefault((c) => c.UserId == userId);

        if (profile is null)
        {
            return NotFound();
        }
        var profileForm = new ProfileForm
        {
            UserId = profile.UserId,
            Username = profile.Username,
            Bio = profile.Bio,
            // ProfileImage = profileImage,
        };

        return View("EditProfile", profileForm);
    }
    [SessionCheck]
    [HttpPost("collections/profile/{userId:int}/update")]
    public async Task<IActionResult> UpdateProfile(int userId, ProfileForm updatedProfile)
    {
        var existingProfile = _context.Users.FirstOrDefault(c => c.UserId == userId);

        if (existingProfile is null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            Console.WriteLine(message);

            return View("EditProfile", updatedProfile);
        }

        if (updatedProfile.ProfileImage != null)
        {
            var newProfileImageUrl = await _imagekit.UploadImageAsync((IFormFile)updatedProfile.ProfileImage!);
            existingProfile.ProfileImage = newProfileImageUrl;
        }

        existingProfile.Bio = updatedProfile.Bio;
        existingProfile.Username = updatedProfile.Username;
        existingProfile.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();
        return RedirectToAction("Collections", new { userId });
    }

    [SessionCheck]
    [HttpPost("collections/{collectionId:int}/delete")]
    public IActionResult DeleteCollection(int collectionId)
    {
        Console.WriteLine("DELETECOLLECTION METHOD INVOKED!!!");
        Console.WriteLine($"Collection ID: {collectionId}");
        var existingCollection = _context.Collections.FirstOrDefault((c) => c.CollectionId == collectionId);

        if (existingCollection is null)
        {
            return NotFound();
        }

        _context.Collections.Remove(existingCollection);
        _context.SaveChanges();
        return RedirectToAction("Collections");
    }

}
