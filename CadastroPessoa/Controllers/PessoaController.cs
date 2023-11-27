using AutoMapper;
using CadastroPessoa.DTOs;
using CadastroPessoa.Models;
using CadastroPessoa.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly ClienteContext _context;
        private readonly IMapper _mapper;
        public PessoaController(ClienteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
        {
            if (_context.Pessoas == null)
            {
                return NotFound();
            }
            var pessoas = await _context.Pessoas.ToListAsync();
            var pessoasDTO = _mapper.Map<IEnumerable<PessoaDTO>>(pessoas);
            return Ok(pessoasDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaDTO>> GetPessoa(long id)
        {
            if (_context.Pessoas == null)
            {
                return NotFound();
            }
            var pessoa = await _context.Pessoas.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            var pessoaDTO = _mapper.Map<PessoaDTO>(pessoa);
            return Ok(pessoaDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(long id, PessoaDTO pessoaDTO)
        {
            if (id != pessoaDTO.Id)
            {
                return BadRequest("A Alteração não foi possivel. Informe o ID!");
            }
            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);
            _context.Entry(pessoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
                {
                    return NotFound("Pessoa não encontrada!");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(PessoaDTO pessoaDTO)
        {
            if (_context.Pessoas == null)
            {
                return Problem("Entity set 'CoreContext.Pessoas'  is null.");
            }
            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoa", new { id = pessoa.Id }, pessoa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(long id)
        {
            if (_context.Pessoas == null)
            {
                return NotFound();
            }
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaExists(long id)
        {
            return (_context.Pessoas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
