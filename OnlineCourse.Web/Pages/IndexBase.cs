using Microsoft.AspNetCore.Components;
using OnlineCourse.Web.Service.Interfaces;
using OnlineCourse.Web.Service.Services;

namespace OnlineCourse.Web.Pages
{
    public class IndexBase : ComponentBase
    {
        private readonly IStudentService studentService;
        public IndexBase()
        {
            this.studentService = new StudentService();
        }

        [Inject]
        public OnlineCourse.Web.Models.Student Student { get; set; }
        protected OnlineCourse.Web.Models.Student[] Students{get;set;}
        protected override async Task OnInitializedAsync()
        {
            Students = (await studentService.RetrieveAllAsync()).ToArray();
        }

    }
}
