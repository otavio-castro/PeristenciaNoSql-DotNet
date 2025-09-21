using Microsoft.AspNetCore.Mvc;
using PeristenciaNoSql.Models;
using PeristenciaNoSql.Services.Interfaces;

namespace PeristenciaNoSql.Controllers
{
    [ApiController]
    [Route("api/alunos")]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunosServices _alunosServices;

        public AlunosController(IAlunosServices alunosServices)
        {
            _alunosServices = alunosServices;
        }

        // GET: api/alunos
        [HttpGet]
        public async Task<ActionResult<List<Aluno>>> Get()
        {
            var alunos = await _alunosServices.GetAsync();
            return Ok(alunos);
        }

        // GET: api/alunos/{id}
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Aluno>> Get(string id)
        {
            var aluno = await _alunosServices.GetByIdAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // GET: api/alunos/{email}
        [HttpGet("{email}")]
        public async Task<ActionResult<Aluno>> GetByEmail(string email)
        {
            var aluno = await _alunosServices.GetByEmailAsync(email);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // POST: api/Alunos
        [HttpPost]
        public async Task<ActionResult<Aluno>> Post(Aluno aluno)
        {
            await _alunosServices.CreateAsync(aluno);
            return CreatedAtAction(nameof(Get), new { id = aluno.Id }, aluno);
        }

        // PUT: api/alunos/{id}
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Aluno alunoAtualizado)
        {
            var aluno = await _alunosServices.GetByIdAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            alunoAtualizado.Id = id;

            await _alunosServices.UpdateAsync(id, alunoAtualizado);

            return NoContent();
        }

        // DELETE: api/Alunos/{id}
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var aluno = await _alunosServices.GetByIdAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            await _alunosServices.RemoveAsync(id);

            return NoContent();
        }

        // DELETE: api/alunos/{email}
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteByEmail(string email)
        {
            var aluno = await _alunosServices.GetByEmailAsync(email);

            if (aluno == null)
            {
                return NotFound();
            }

            await _alunosServices.RemoveByEmailAsync(email);

            return NoContent();
        }
    }
}