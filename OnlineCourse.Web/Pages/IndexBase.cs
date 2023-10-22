using Microsoft.AspNetCore.Components;
using OnlineCourse.Web.Service.Services;

namespace OnlineCourse.Web.Pages
{
    public class IndexBase : ComponentBase
    {
        private readonly StudentService studentService;
        
        [Inject]
        public OnlineCourse.Web.Models.Student Student { get; set; }
        protected OnlineCourse.Web.Models.Student[] Students{get;set;}
        protected override async Task OnInitializedAsync()
        {
            Students = (await studentService.RetrieveAllAsync()).ToArray();
        }

    }
}
