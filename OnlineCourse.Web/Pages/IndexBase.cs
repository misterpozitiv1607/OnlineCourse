using Microsoft.AspNetCore.Components;
using OnlineCourse.Web.Service.Interfaces;
using OnlineCourse.Web.Service.Services;

namespace OnlineCourse.Web.Models
{
    public class IndexBase:ComponentBase
    {
        [Inject]
        public Student Student { get; set; }
        protected Models.Student[] Students { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Students = await StudentService.
        }
    }
}
