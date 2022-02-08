using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto6.Context;
using Projeto6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto6.Controllers
{
    [Route("[controller]")] //[Route("Api/[controller]")]
    [ApiController]
    public class UfController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UfController(AppDbContext appDbContext)//public CadastroController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        // MÉTODOS GET
        [HttpGet]
        public async Task<IActionResult> GetUf() //GetUf
        {
            return Ok
            (new
            {
                success = true,
                data = await _appDbContext.TB_UF.AsNoTracking().OrderBy(x => x.Sigla).ToListAsync()
            });//TB_UF apontando para o DbSet | AsNoTracking melhora o desempenho
        }

        
       [HttpGet("{CodigoUf}")] //[HttpGet("{CodigoUf:int}")]
       public async Task<ActionResult<TbUf>> GetUf(int CodigoUf)
       {
           var todoItem = await _appDbContext.TB_UF.FindAsync(CodigoUf);

           if (todoItem == null)
           {
               return NotFound();

           }

           return Ok(todoItem);
       }
        
        
        [HttpGet("Sigla/{Sigla}")]
        public async Task<IActionResult> Index(string Sigla) 
        {
            var Siglas = from m in _appDbContext.TB_UF
                         select m;


            if (!String.IsNullOrEmpty(Sigla))
            {
                Siglas = Siglas.Where(s => s.Sigla!.Contains(Sigla));

            }


            //return View(await Siglas.ToListAsync());
            return Ok(Siglas);
        }


        // MÉTODO POST
        [HttpPost]
        public async Task<IActionResult> CriarUf(TbUf tbUf)
        {
            _appDbContext.TB_UF.Add(tbUf);
            await _appDbContext.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                data = tbUf,
                lista = _appDbContext.TB_UF.AsNoTracking().OrderBy(x => x.Sigla).ToListAsync() //Exibindo a lista ordenada
            });

        }




        // MÉTODO PUT
        [HttpPut("{CodigoUf}")]
        public async Task<IActionResult> PutTbUf(int CodigoUf, TbUf TbUf)
        {
            if (CodigoUf != TbUf.CodigoUf)
            {
                return BadRequest();
            }

            _appDbContext.Entry(TbUf).State = EntityState.Modified;

            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbUfExists(CodigoUf))
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

        private bool TbUfExists(int CodigoUf)
        {
            return _appDbContext.TB_UF.Any(e => e.CodigoUf == CodigoUf);
        }




        // MÉTODO DELETE
        [HttpDelete("{CodigoUf}")]
        public async Task<IActionResult> Delete(int CodigoUf)
        {
            var item = await _appDbContext.TB_UF.FindAsync(CodigoUf);
            
            if (item == null)
            {
                return NotFound();
            }

            _appDbContext.TB_UF.Remove(item);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }



    }

}
