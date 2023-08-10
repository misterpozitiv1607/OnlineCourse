namespace OnlineCourse.Service.Helpers;

public class Response<T>
{
    public  int StatusCode { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}
