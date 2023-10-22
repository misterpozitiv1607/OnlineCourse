using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Components;
using OnlineCourse.Web.Service.Services;

namespace OnlineCourse.Web.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        private  StudentService studentService { get; set; }
        public OnlineCourse.Web.Models.Student Student { get; set; }
        protected OnlineCourse.Web.Models.Student[] Students{get;set;}
        protected override async Task OnInitializedAsync()
        {
            Students = (await studentService.RetrieveAllAsync()).ToArray();
        }

    }
}
