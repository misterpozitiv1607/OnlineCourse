using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Domain.Entities.Students;
using OnlineCourse.Service.Dtos.Students;
using OnlineCourse.Service.Interfaces;

namespace OnlineCourse.Web.Controllers
{
	public class UsersController : Controller
	{
		private readonly IMapper mapper;
		private readonly  IStudentService userService;
		public UsersController(IStudentService userService, IMapper mapper)
		{
			this.userService = userService;
			this.mapper = mapper;
		}


		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(StudentCreationDto dto)
		{
			dto.DateOfBirth = dto.DateOfBirth.ToUniversalTime();
			var createdUser = await this.userService.AddAsync(dto);

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Edit(long id)
		{
			var user = await this.userService.RetrieveByIdAsync(id);
			var mappedUser = this.mapper.Map<Student>(user);
			return View(mappedUser);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(User model)
		{
			var mappedUser = this.mapper.Map<UserUpdateDto>(model);
			mappedUser.DateOfBirth = mappedUser.DateOfBirth.ToUniversalTime();
			var user = await this.userService.ModifyAsync(mappedUser);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Index()
		{
			var users = (await this.userService.RetrieveAllAsync()).OrderBy(t => t.Id);
			return View(users);
		}

		public async Task<IActionResult> Detail(long id)
		{
			var user = await this.userService.RetrieveByIdAsync(id);
			return View(user);
		}
	}
}
