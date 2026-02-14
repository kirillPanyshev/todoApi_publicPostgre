using Microsoft.AspNetCore.Mvc;
using todoApi.DTOs;
using todoApi.Enums;
using todoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/todos")]
public class TodosController : ControllerBase
{
    private readonly TodoServiceInterface _service;

    public TodosController(TodoServiceInterface service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] bool? isCompleted,
        [FromQuery] Priority? priority)
    {
        var result = await _service.GetAllAsync(isCompleted, priority);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTodoDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTodoDto dto)
    {
        var ok = await _service.UpdateAsync(id, dto);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _service.DeleteAsync(id);
        return ok ? NoContent() : NotFound();
    }

    [HttpPatch("{id}/complete")]
    public async Task<IActionResult> Complete(int id)
    {
        var item = await _service.CompleteAsync(id);
        return item == null ? NotFound() : Ok(item);
    }
}
