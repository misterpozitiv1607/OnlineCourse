using Microsoft.AspNetCore.Components;
namespace OnlineCourse.Web.Pages
{
    public partial class Student
    {
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public DateOnly? Date { get; set; }
    }
}
