using Microsoft.AspNetCore.Components;

namespace OnlineCourse.Web.Pages
{
    public class StudentBase:ComponentBase
    {

		[Parameter]
		public string FirstName { get; set; }

		[Parameter]
		public string LastName { get; set; }

		[Parameter]
		public string DateOfBirth { get; set; }

		[Parameter]
		public string Phone { get; set; }

		[Parameter]
		public string Email { get; set; }
	}
    
}
