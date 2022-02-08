using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto6.Context;
using Projeto6.Models;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Projeto6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public MunicipioController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        // MÉTODOS GET
        [HttpGet]
        public async Task<IActionResult> GetMunicipios()
        {
            return Ok
            (new
            {
                success = true,
                data = await _appDbContext.TB_MUNICIPIO.AsNoTracking().ToListAsync()
            });
        }

        [HttpGet("CodigoUf/{CodigoUf}")]
        public async Task<ActionResult<TbUf>> GetUf(int CodigoUf)
        {
            var todoItem = await _appDbContext.TB_UF.FindAsync(CodigoUf);

            if (todoItem == null)
            {
                return NotFound();

            }

            return Ok(todoItem);
        }


        [HttpGet("{CodigoMunicipio}")]
        public async Task<ActionResult<TbMunicipio>> GetMunicipio(int CodigoMunicipio)
        {
            var todoItem = await _appDbContext.TB_MUNICIPIO.FindAsync(CodigoMunicipio);

            if (todoItem == null)
            {
                return NotFound();

            }

            return Ok(todoItem);
        }
        


        [HttpGet("Nome/{Nome}")]
        public async Task<IActionResult> Index(string Nome)  
        {
            var Nomes = from m in _appDbContext.TB_MUNICIPIO
                         select m;

            if (!String.IsNullOrEmpty(Nome))
            {
                Nomes = Nomes.Where(s => s.Nome!.Contains(Nome));

            }

            return Ok(Nomes);
        }



        // MÉTODO POST
        [HttpPost] 
        public async Task<ActionResult> CriarMunicipio(TbMunicipio TbMunicipio)
        {
            _appDbContext.TB_MUNICIPIO.Add(TbMunicipio);
            await _appDbContext.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                data = TbMunicipio,
            });
        }



        // MÉTODO PUT
        [HttpPut("{CodigoMunicipio}")]
        public async Task<IActionResult> PutTbMunicipio(int CodigoMunicipio, TbMunicipio TbMunicipio)
        {
            if (CodigoMunicipio != TbMunicipio.CodigoMunicipio)
            {
                return BadRequest();
            }

            _appDbContext.Entry(TbMunicipio).State = EntityState.Modified;

            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbMunicipioExists(CodigoMunicipio))
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

        private bool TbMunicipioExists(int CodigoMunicipio)
        {
            return _appDbContext.TB_MUNICIPIO.Any(e => e.CodigoMunicipio == CodigoMunicipio);
        }



        // MÉTODO DELETE
        [HttpDelete("{CodigoMunicipios}")]
        public async Task<IActionResult> Delete(int CodigoMunicipios)
        {
            var item = await _appDbContext.TB_MUNICIPIO.FindAsync(CodigoMunicipios);

            if (item == null)
            {
                return NotFound();
            }

            _appDbContext.TB_MUNICIPIO.Remove(item);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }


    }
}
