using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMessageLogger.DataAccess;

namespace MvcMessageLogger.Controllers
{
	public class MessagesController : Controller
	{
		private readonly MvcMessageLoggerContext _context;

		public MessagesController(MvcMessageLoggerContext context)
		{
			_context = context;
		}

        [Route("users/{userId:int}/messages")]
        public IActionResult Index(int userId)
		{
            var user = _context.Users
				.Where(u => u.Id == userId)
				.Include(u => u.Messages)
				.First();

            return View(user);
        }

        [Route("users/{userId:int}/messages/new")]
        public IActionResult New(int userId)
		{
            var user = _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.Messages)
                .First();

            return View(user);
        }
    }
}
