using OnlineCourse.Service.Services;
using OnlineCourse.Service.Dtos.Teachers;

namespace OnlineCourse.Views.Teachers
{
    public class TeacherServiceView
    {
        private TeacherService teacherService = new();
        public async void Create()
        {
            Console.WriteLine("FirstName: ");
            string first_name = Console.ReadLine();

            Console.WriteLine("LastName: ");
            string last_name = Console.ReadLine();

            Console.WriteLine("Date Of Birth(example:yyyy-mm-dd)");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Phone(example:+998xxxxxxxxx)");
            string phone = Console.ReadLine();

            Console.WriteLine("Email(example:example@gmail.com): ");
            string email = Console.ReadLine();

            Console.WriteLine("Experience:(number enter): ");
            int experience = int.Parse(Console.ReadLine());

            Console.WriteLine("Specialty(example:.Net): ");
            string specialty = Console.ReadLine();

            var result = await teacherService.CreateAsync(new TeacherCreationDto
            {
                FirstName = first_name,
                LastName = last_name,
                DateOfBirth = date,
                Phone = phone,
                Email = email,
                Experince = experience,
                Speciality = specialty
            });
            
            if (result.StatusCode == 200)
                Console.WriteLine(result.Data.FirstName);
        }

        public async void Update()
        {
            Console.WriteLine("Id: ");
            long id = long.Parse(Console.ReadLine());

            Console.WriteLine("FirstName: ");
            string first_name = Console.ReadLine();

            Console.WriteLine("LastName: ");
            string last_name = Console.ReadLine();

            Console.WriteLine("Date Of Birth(example:yyyy-mm-dd)");
            DateTime date = DateTimeOffset.Parse(DateTime.Parse(Console.ReadLine()).ToString()).UtcDateTime;


            Console.WriteLine("Phone(example:+998xxxxxxxxx)");
            string phone = Console.ReadLine();

            Console.WriteLine("Email(example:example@gmail.com): ");
            string email = Console.ReadLine();

            Console.WriteLine("Experience:(number enter): ");
            int experience = int.Parse(Console.ReadLine());

            Console.WriteLine("Specialty(example:.Net): ");
            string specialty = Console.ReadLine();


            TeacherUpdateDto teacherUpdateDto = new TeacherUpdateDto()
            {
                Id = id,
                FirstName = first_name,
                LastName = last_name,
                DateOfBirth = date,
                Phone = phone,
                Email = email,
                Experince = experience,
                Speciality = specialty
            };

           await teacherService.UpdateAsync(teacherUpdateDto);

        }

        public async void Delete()
        {
            Console.WriteLine("Id: ");
            long id = long.Parse(Console.ReadLine());

            var result = await teacherService.DeleteAsync(id);
            Console.WriteLine(result.StatusCode);
            
        }

        public async void GetById()
        {
            Console.WriteLine("Id: ");
            long id = long.Parse(Console.ReadLine());

            var result = await teacherService.GetByIdAsync(id);
            Console.WriteLine(result.Message);

        }

        public async Task GetAll()
        {
            var result =await teacherService.GetAllAsync();

            foreach(var item in result.Data)
                Console.WriteLine(item.FirstName);
        }
    }
}
