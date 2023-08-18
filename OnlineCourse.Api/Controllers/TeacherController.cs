﻿using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Service.Dtos.CourseCategories;
using OnlineCourse.Service.Dtos.Orders;
using OnlineCourse.Service.Interfaces;

namespace OnlineCourse.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }

    [HttpPost("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostAsync(OrderCreationDto dto)
    {
        var result = await _service.AddAsync(dto);
        return Ok(result);
    }

    [HttpPut("Update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutAsync(OrderUpdateDto dto)
    {
        var result = await _service.ModifyAsync(dto);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var result = await _service.RemoveAsync(id);
        return Ok(result);
    }

    [HttpGet("GetById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _service.RetrieveByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.RetrieveAllAsync();
        return Ok(result);
    }
}