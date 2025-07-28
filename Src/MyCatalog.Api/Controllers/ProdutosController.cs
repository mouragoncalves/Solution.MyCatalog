using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCatalog.Api.Data;
using MyCatalog.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace MyCatalog.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController(ApiDbContext context) : ControllerBase
    {
        private readonly ApiDbContext _context = context;

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetProdutos()
        {
            if (_context.Produtos == null)
                return NotFound("A tabela de produtos não foi encontrada.");

            var request = await _context.Produtos.ToListAsync();

            if (request == null)
                return NotFound();

            return Ok(request);
        }

        [AllowAnonymous]
        [HttpGet("{id:int}", Name = "GetProduto???")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ProdutoModel>> GetProduto(int id)
        {
            if (_context.Produtos == null)
                return NotFound("A tabela de produtos não foi encontrada.");

            var request = await _context.Produtos.FindAsync(id);

            if (request == null)
                return NotFound();

            return Ok(request);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ProdutoModel>> PostProduto(ProdutoModel produto)
        {
            if (_context.Produtos == null)
                return Problem("Erro ao criar um produto, contate o suporte!");

            if (!ModelState.IsValid)
                //    return ValidationProblem(ModelState);
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = "Um ou mais erros de validação ocorreram!",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = "Verifique os dados enviados."
                });

            var request = await _context.Produtos
                .FirstOrDefaultAsync(c => c.Nome == produto.Nome && c.Descricao == produto.Descricao);

            if (request != null)
                return BadRequest("Já existe um produto com esse nome");

            _context.Produtos.Add(produto);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ProdutoModel>> PutById(int id, ProdutoModel produto)
        {
            if (_context.Produtos == null)
                return Problem("Erro ao criar um produto, contate o suporte!");

            if (id != produto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var request = await _context.Produtos.FindAsync(id);

            if (request == null)
                return NotFound();

            //_context.Produtos.Update(produto);

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException Ex)
            {
                var exists = (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();

                if (!exists)
                    return NotFound();

                throw new DbUpdateConcurrencyException(Ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (_context.Produtos == null)
                return Problem("Erro ao criar um produto, contate o suporte!");

            var request = await _context.Produtos.FindAsync(id);

            if (request == null)
                return NotFound();

            _context.Produtos.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
