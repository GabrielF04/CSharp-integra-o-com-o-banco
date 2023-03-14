using FilmesApi.Data;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;


[ApiController]
[Route("Controller")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;

    public FilmeController(FilmeContext context)
    {
        _context = context;
    }

    [HttpPost]
    public CreatedAtActionResult AdicionaFilme([FromBody]Filme filme)   
    {
      _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }
    [HttpGet]
   
    public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50) 
    {
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]

    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = _context.Filmes.SingleOrDefault(filme
            => filme.Id == id);
        if(filme == null) return NotFound();
        return Ok(filme);
    }
}
