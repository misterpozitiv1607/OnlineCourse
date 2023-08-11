using OnlineCourse.Service.Services;
using OnlineCourse.Service.Dtos.Teachers;

namespace OnlineCourse.Views.Teachers
{
    public class TeacherServiceView
    {
        private TeacherService teacherService = new();
        public async void Create()
        {
            int count = 0;
            Console.WriteLine(@"1.Class va Struct Farqi nimada?
A.Biri Reference tip, biri value
B.Farqi yo'q
C.Struct optimalroq classga nisbatan");
            Console.WriteLine("Quyidagilardan birini tanlang(A,B,C): ");
            string choice = Console.ReadLine();
            if (choice == "A" || choice == "a")
                count += 1;

            Console.WriteLine(@"2.int a=8, int b=3 a/b=?
A.2,6
B.Xatolik
C.2");
            Console.WriteLine("Quyidagilardan birini tanlang(A,B,C): ");
            string choice1 = Console.ReadLine();
            if (choice1 == "C" || choice1 =="c")
                count += 1;

            Console.WriteLine(@"3Asynxron yoki syxron qaysi biri tezroq?
A.Syxron
B.Farqi yo'q
C.Asynxron");
            Console.WriteLine("Quyidagilardan birini tanlang(A,B,C): ");
            string choice2 = Console.ReadLine();
            if (choice2 == "C" || choice2=="c")
                count += 1;

            Console.WriteLine(@"4.Float o'ziga qanday qiymatlar oladi?
A.Butun
B.Xaqiqiy
C.Istalgan");
            Console.WriteLine("Quyidagilardan birini tanlang(A,B,C): ");
            string choice3 = Console.ReadLine();
            if (choice3 == "B" || choice3=="b")
                count += 1;

            Console.WriteLine(@"5.Generic tezroqmi yoki non-Generic?
A.Generic
B.Farqi yo'q
C.Nono-Generic");
            Console.WriteLine("Quyidagilardan birini tanlang(A,B,C): ");
            string choice4 = Console.ReadLine();
            if (choice4 == "A" || choice4 == "a")
                count += 1;





            if (count == 5)
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
            else
            {
                Console.WriteLine("Kechirasiz sizni ishga qabul qilolmaymiz!");
            }

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
