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
    public class BairroController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public BairroController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // MÉTODOS GET
        [HttpGet]
        public async Task<IActionResult> GetBairros()
        {
            return Ok
            (new
            {
                success = true,
                data = await _appDbContext.TB_BAIRRO.AsNoTracking().ToListAsync()
            });
        }

        [HttpGet("CodigoMunicipio/{CodigoMunicipio}")]
        public async Task<ActionResult<TbMunicipio>> GetMunicipio(int CodigoMunicipio)
        {
            var todoItem = await _appDbContext.TB_MUNICIPIO.FindAsync(CodigoMunicipio);

            if (todoItem == null)
            {
                return NotFound();

            }

            return Ok(todoItem);
        }

        [HttpGet("{CodigoBairro}")]
        public async Task<ActionResult<TbBairro>> GetBairro(int CodigoBairro)
        {
            var todoItem = await _appDbContext.TB_BAIRRO.FindAsync(CodigoBairro);

            if (todoItem == null)
            {
                return NotFound();

            }

            return Ok(todoItem);
        }



        // MÉTODO POST
        [HttpPost]
        public async Task<ActionResult> CriarBairros(TbBairro TbBairro)
        {
            _appDbContext.TB_BAIRRO.Add(TbBairro);
            await _appDbContext.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                data = TbBairro,
            });
        }


        // MÉTODO PUT
        [HttpPut("{CodigoBairro}")]
        public async Task<IActionResult> PutTbBairro(int CodigoBairro, TbBairro TbBairro)
        {
            if (CodigoBairro != TbBairro.CodigoBairro)
            {
                return BadRequest();
            }

            _appDbContext.Entry(TbBairro).State = EntityState.Modified;

            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbBairroExists(CodigoBairro))
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

        private bool TbBairroExists(int CodigoBairro)
        {
            return _appDbContext.TB_BAIRRO.Any(e => e.CodigoBairro == CodigoBairro);
        }


        // MÉTODO DELETE
        [HttpDelete("{CodigoBairro}")]
        public async Task<IActionResult> Delete(int CodigoBairro)
        {
            var item = await _appDbContext.TB_BAIRRO.FindAsync(CodigoBairro);

            if (item == null)
            {
                return NotFound();
            }

            _appDbContext.TB_BAIRRO.Remove(item);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

    }

}
