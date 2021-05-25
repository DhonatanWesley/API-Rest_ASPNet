using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testeef.Data;
using testeef.Models;

namespace testeef.Controllers
{
    [ApiController]
    [Route("v1/produtos")]
    public class ProdutoController : ControllerBase 
    {
        /* Retorna todas os produtos */
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Produto>>> Get([FromServices] DataContext context)
        {
            var products = await context.Produtos
                //.Include( x => x.Categoria )
                .ToListAsync();
            return products;
        }

        /* Retorna o produto filtrado */
        [HttpGet]
        [Route("{codigo:int}")]
        public async Task<ActionResult<Produto>> GetByID([FromServices] DataContext context, int codigo)
        {
            var product = await context.Produtos
                //.Include(x => x.Categoria)
                .AsNoTracking()
                .FirstOrDefaultAsync( x => x.codigo == codigo );
            return product;
        }

        /* Retorna os produtos vinculados a categoria filtrada */
        [HttpGet]
        [Route("categorias/{codigo:int}")]
        public async Task<ActionResult<List<Produto>>> GetByCategory( [FromServices] DataContext context, int codigo )
        {
            var products = await context.Produtos
                //.Include(x => x.Categoria)
                .AsNoTracking()
                .Where(x => x.CategoriaCodigo == codigo)
                .ToListAsync();
            return products;
        }

        /* Cadastra um Produto */
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produto>> Post(
            [FromServices] DataContext context,
            [FromBody] Produto model )
        {

            /* Teste Validação Campo */
            if ( model.codigo == 2 ) 
            {
                return BadRequest("Deu Pau Brow");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    context.Produtos.Add(model);
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
}