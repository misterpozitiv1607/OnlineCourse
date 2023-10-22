using Microsoft.AspNetCore.Components;

namespace OnlineCourse.Web.Models
{
    public class StudentBase:ComponentBase
    {
        [Parameter]
        public Student Student { get; set; }
    }
    
}
