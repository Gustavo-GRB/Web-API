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
    public class EnderecoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public EnderecoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }





        // MÉTODO GET
        [HttpGet]
        public async Task<IActionResult> GetEnderecos()
        {
            return Ok
            (new
            {
                success = true,
                data = await _appDbContext.TB_ENDERECO.AsNoTracking().ToListAsync()
            });
        }

        
        // MÉTODO POST
        [HttpPost]
        public async Task<IActionResult> CriarEndereco(TbEndereco tbEndereco)
        {
            _appDbContext.TB_ENDERECO.Add(tbEndereco);
            await _appDbContext.SaveChangesAsync();

            return Ok(new
            {
                Success = true,
                data = tbEndereco,
            });
        }

        // MÉTODO PUT
        [HttpPut("{CodigoEndereco}")]
        public async Task<IActionResult> PutTbEndereco(int CodigoEndereco, TbEndereco TbEndereco)
        {
            if (CodigoEndereco != TbEndereco.CodigoEndereco)
            {
                return BadRequest();
            }

            _appDbContext.Entry(TbEndereco).State = EntityState.Modified;

            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbEnderecoExists(CodigoEndereco))
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

        private bool TbEnderecoExists(int CodigoEndereco)
        {
            return _appDbContext.TB_ENDERECO.Any(e => e.CodigoEndereco == CodigoEndereco);
        }



        // MÉTODO DELETE
        [HttpDelete("{CodigoEndereco}")]
        public async Task<IActionResult> Delete(int CodigoEndereco)
        {
            var item = await _appDbContext.TB_ENDERECO.FindAsync(CodigoEndereco);

            if (item == null)
            {
                return NotFound();
            }

            _appDbContext.TB_ENDERECO.Remove(item);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

    }

}
