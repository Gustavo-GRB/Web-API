using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto6.Context;
using Projeto6.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PessoaController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        // MÉTODOS GET
        [HttpGet]
        public async Task<IActionResult> GetPessoas()
        {
            return Ok
            (new
            {
                success = true,
                data = await _appDbContext.TB_PESSOA.AsNoTracking().ToListAsync()
            });
        }

        [HttpGet("{CodigoPessoa}")]
        public async Task<ActionResult<TbPessoa>> GetPessoa(int CodigoPessoa)
        {
            var todoItem = await _appDbContext.TB_PESSOA.FindAsync(CodigoPessoa);

            if (todoItem == null)
            {
                return NotFound();

            }

            return Ok(todoItem);
        }


        // MÉTODO POST
        [HttpPost]
        public async Task<ActionResult> CriarPessoa(TbPessoa TbPessoa)
        {
            _appDbContext.TB_PESSOA.Add(TbPessoa);
            await _appDbContext.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                data = TbPessoa,
            });
        }


        // MÉTODO PUT
        [HttpPut("{CodigoPessoa}")]
        public async Task<IActionResult> PutTbPessoa(int CodigoPessoa, TbPessoa TbPessoa)
        {
            if (CodigoPessoa != TbPessoa.CodigoPessoa)
            {
                return BadRequest();
            }

            _appDbContext.Entry(TbPessoa).State = EntityState.Modified;

            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPessoaExists(CodigoPessoa))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool TbPessoaExists(int CodigoPessoa)
        {
            return _appDbContext.TB_PESSOA.Any(e => e.CodigoPessoa == CodigoPessoa);
        }



        // MÉTODO DELETE
        [HttpDelete("{CodigoPessoa}")]
        public async Task<IActionResult> Delete(int CodigoPessoa)
        {
            var item = await _appDbContext.TB_PESSOA.FindAsync(CodigoPessoa);

            if (item == null)
            {
                return NotFound();
            }

            _appDbContext.TB_PESSOA.Remove(item);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }





    }

}
