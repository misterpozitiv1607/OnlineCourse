﻿using OnlineCourse.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCourse.Web.Service.Interfaces;

namespace OnlineCourse.Web.Service.Services;

public class StudentService : IStudentService
{
    private readonly HttpClient httpClient;
    public StudentService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    internal static Task<Student[]> RetrieveAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Student> AddAsync(Student dto)
    {
        throw new NotImplementedException();
    }

    public Task<Student> ModifyAsync(Student dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Student>> RetrieveAllAsync()
    {
       return await this.httpClient.GetFromJsonAsync<Student[]>("api/Student/GetAll");
    }
    
    public Task<Student> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
