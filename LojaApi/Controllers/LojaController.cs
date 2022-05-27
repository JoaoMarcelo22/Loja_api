using LojaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LojaController : ControllerBase
    {
        private static List<Produto>produtos = new List<Produto>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionarProduto([FromBody]Produto produto)
        {
            produto.Id = id++;
            produtos.Add(produto);
            return CreatedAtAction(nameof(RecuperarProdutosPorID), new{ Id = produto.Id},produto);
        }

        [HttpGet]
        public IActionResult RecuperarProduto()
        {
            produtos = produtos.OrderBy(x => x.Id).ToList();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarProdutosPorID(int id)
        {
            Produto produto = produtos.FirstOrDefault(produto => produto.Id == id);
            if(produto != null)
            {
                return Ok(produto);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarProdutosPorId(int id)
        {
            Produto produto = produtos.FirstOrDefault(produto => produto.Id == id);
            if(produto != null)
            {
                 produtos.Remove(produto);
                 return Ok(produto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AlterarProdutosPorId(int id,[FromBody]Produto produtoNovo)
        {
            Produto produto = produtos.FirstOrDefault(produto => produto.Id == id);
            if(produto != null)
            {
                 produtos.Remove(produto);
                 produto.Nome = produtoNovo.Nome;
                 produto.Categoria = produtoNovo.Categoria;
                 produto.Preco = produtoNovo.Preco;
                 produtos.Insert(id,produto);
                 return Ok(produto);
            }
            return NotFound();
        }
    }
}