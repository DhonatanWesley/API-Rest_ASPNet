using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft. EntityFrameworkCore;
using testeef.Data;
using testeef.Models;

namespace testeef.Controllers
{

    [ApiController]
    [Route("v1/categorias")]

    public class CategoriaController : ControllerBase
    {

        /* Retorna todas as Categorias Cadastradas */
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Categoria>>> Get([FromServices] DataContext context )
        {   
            var categories = await context.Categorias.ToListAsync();
            return categories;
        }

        /* Retorna a Categoria Filtrada */
        [HttpGet]
        [Route("{codigo:int}")]
        public async Task<ActionResult<Categoria>> GetByID([FromServices] DataContext context, int codigo)
        {
            var category = await context.Categorias
                .AsNoTracking()
                .FirstOrDefaultAsync( x => x.codigo == codigo );
            return category;
        }

        /* Cadastra uma categoria */
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Categoria>> Post(
            [FromServices] DataContext context,
            [FromBody] Categoria model    )
        {
            if (ModelState.IsValid)
            {
                context.Categorias.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }

}