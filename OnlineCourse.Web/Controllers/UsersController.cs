using Microsoft.AspNetCore.Mvc;

namespace OnlineCourse.Web.Controllers
{
	public class UsersController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
