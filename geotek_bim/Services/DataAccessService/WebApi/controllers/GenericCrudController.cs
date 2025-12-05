using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using DataAccessService.Domain.Interfaces.Repositories;

[ApiController]
[Route("api/[controller]")]
public class GenericCrudController<T> : ControllerBase where T : class
{
    private readonly ICrudRepository<T> _repository;

    public GenericCrudController(ICrudRepository<T> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _repository.GetAllAsync();
        return Ok(list);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] T model)
    {
        if (model == null) return BadRequest();
        await _repository.AddAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = GetEntityId(model) }, model);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] T model)
    {
        if (model == null || GetEntityId(model) != id) return BadRequest();

        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return NotFound();

        // Копируем свойства из model в existing
        CopyProperties(model, existing);

        await _repository.UpdateAsync(existing);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return NotFound();

        await _repository.DeleteAsync(id);
        return NoContent();
    }

    // -------------------
    // Вспомогательные методы
    // -------------------
    private long GetEntityId(T entity)
    {
        var prop = typeof(T).GetProperty("Id");
        if (prop == null) throw new System.Exception("Entity has no Id property");
        return (long)prop.GetValue(entity);
    }

    private void CopyProperties(T source, T target)
    {
        foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (!prop.CanWrite) continue;

            var value = prop.GetValue(source);
            prop.SetValue(target, value);
        }
    }
}
