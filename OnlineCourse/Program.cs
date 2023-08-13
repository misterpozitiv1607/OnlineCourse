//using OnlineCourse.Views;

//MainView mainView = new MainView();
//mainView.MainPage();

using OnlineCourse.Service.Services;

TeacherService teacherService = new TeacherService();
teacherService.GetByIdAsync(2);