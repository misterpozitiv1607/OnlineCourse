using OnlineCourse.Views.CourseCategories;
using OnlineCourse.Views.Courses;
using OnlineCourse.Views.Orders;
using OnlineCourse.Views.Students;
using OnlineCourse.Views.Teachers;

namespace OnlineCourse.Views;

public class MainView
{
    public async void MainPage()
    {
        TeacherServiceView teacherServiceView = new TeacherServiceView();
        CourseCategoryServiceView courseCategoryServiceView = new CourseCategoryServiceView();
        CourseServiceView courseServiceView = new CourseServiceView();
        StudentServiceView studentServiceView = new StudentServiceView();
        OrderServiceView orderServiceView = new OrderServiceView();
        Console.WriteLine(@"---------------- Main Page -----------------
1.Teacher
2.Student
3.Courses
4.CourseCategories
5.Orders
6.I'm a Admin
0.Exit");
        Console.WriteLine(">>>>>>>>>>>>>>>>>");

        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                TeacherPage();
                break;
            case 2:
                StudentPage();
                break;
            case 3:
                CoursePage();
                break;
            case 4:
                CourseCategoryPage();
                break;
            case 5:
                OrderPage();
                break;
            case 6:
                AdminPage();
                break;
            case 0:
                MainPage();
                break;
            default:
                break;
        }

    }

    public async void TeacherPage()
    {
        TeacherServiceView teacherServiceView = new TeacherServiceView();
        StudentServiceView studentServiceView = new StudentServiceView();



        Console.WriteLine(@"------------------ Teacher Page ----------------------
1.Register
2.LogIn

0.Exit");
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        int select = int.Parse(Console.ReadLine());
        switch (select)
        {
            case 1:
                teacherServiceView.Create();
                break;
            case 2:
                teacherServiceView.GetById();
                Console.WriteLine(@"-------------------------- Teacher Rights --------------------
1.Student Delete
2.Update Student Information
0.Exit");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        studentServiceView.Delete();
                        break;
                    case 2:
                        studentServiceView.Update();
                        break;
                    case 0:
                        TeacherPage();
                        break;
                    default:
                        break;
                }
                break;
            case 0:
                MainPage();
                break;
            default:
                break;
        }
    }

    public async void AdminPage()
    {
        TeacherServiceView teacherServiceView = new TeacherServiceView();
        CourseServiceView courseServiceView = new CourseServiceView();
        StudentServiceView studentServiceView = new StudentServiceView();


        Console.WriteLine("Email: ");
        string email = Console.ReadLine();

        Console.WriteLine("Password: ");
        string password = Console.ReadLine();

        if (email == "admin@gmail.com" && password == "admin")
            Console.WriteLine(@"---------------- Admin Page --------------------

1.View All Teacher
2.Delete Teacher
3.Update Teacher Information
4.View All Student
5.View All CourseInformation
0.Exit");
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                teacherServiceView.GetAll();
                break;
            case 2:
                teacherServiceView.Delete();
                break;
            case 3:
                teacherServiceView.Update();
                break;
            case 4:
                studentServiceView.GetAll();
                break;
            case 5:
                courseServiceView.GetAll();
                break;
            case 0:
                TeacherPage();
                break;
            default:
                break;
        }
    }

    public async void StudentPage()
    {
        StudentServiceView studentServiceView = new StudentServiceView();

        Console.WriteLine(@"-------------------------- Student Page ------------------------
1.LogIn
2.Registration
0.Exit");
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                studentServiceView.GetById();
                break;
            case 2:
                studentServiceView.Create();
                break;
            case 0:
                StudentPage();
                break;
            default:
                break;
        }
    }

    public async void CoursePage()
    {
        CourseServiceView courseServiceView = new CourseServiceView();

        Console.WriteLine(@"--------------------- Course Page -----------------------
1.Courses
2.Add Course
3.Exit");
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                courseServiceView.GetAll();
                break;
            case 2:
                courseServiceView.Create();
                break;
            case 0:
                CoursePage();
                break;
            default:
                break;
        }
    }

    public async void CourseCategoryPage()
    {
        CourseCategoryServiceView coursecategoryServiceView = new CourseCategoryServiceView();

        Console.WriteLine(@"--------------------- CourseCategory Page -----------------------
1.CourseCategories
2.Add CourseCategory
3.Exit");
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                coursecategoryServiceView.GetAll();
                break;
            case 2:
                coursecategoryServiceView.Create();
                break;
            case 0:
                CourseCategoryPage();
                break;
            default:
                break;
        }
    }

    static async void OrderPage() 
    {
        OrderServiceView orderServiceView = new OrderServiceView();

        Console.WriteLine(@"--------------------- Order Page -----------------------
1.Orders View
2.Add Orders
3.Exit");
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                orderServiceView.GetAll();
                break;
            case 2:
                orderServiceView.Create();
                break;
            case 0:
                OrderPage();
                break;
            default:
                break;
        }
    }

}
