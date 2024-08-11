using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BeltExam.Attributes;

public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? userId = context.HttpContext.Session.GetInt32("userId");
        if (userId == null)
        {
            context.Result = new RedirectToActionResult("Index", "Home", new { message = "not-authenticated" });
        }
    }
}
