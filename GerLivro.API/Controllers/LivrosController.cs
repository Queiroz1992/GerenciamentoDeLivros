using GerLivro.Application.DTOs;
using GerLivro.Application.Services;
using GerLivro.Domain.Intities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerLivro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly LivroService _livroservice;

        public LivrosController(LivroService livroservice)
        {
            _livroservice = livroservice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroDTO>>> GetLivros()
        {
          var livros = await _livroservice.GetAllAsync();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroDTO>> GetLivro(int id)
        {
            var livros = await _livroservice.GetByIdAsync(id);
            return Ok(livros);
        }

        [HttpPost]
        public async Task<ActionResult<LivroDTO>> PostLivro(CreateLivroDTO createLivroDTO)
        {
            var livroId = await _livroservice.AddAsync(createLivroDTO);

            return CreatedAtAction(nameof(GetLivro), new { id = livroId }, createLivroDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutLivro(int id, LivroDTO livroDTO)
        {
            if (id != livroDTO.Id) return BadRequest();            

            await _livroservice.UpdateAsync(livroDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLivro(int id)
        {
            await _livroservice.DeleteAsync(id);
            return NoContent();
        }
    }
}
