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
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarProdutosPorID(int id)
        {
            Produto produto = produtos.FirstOrDefault(produto => produto.Id == id);
            if(produto != null)
            {
                produtos.Sort(produto.Id);
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
                 return Ok();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AlterarProdutosPorId(int id)
        {
            Produto produto = produtos.FirstOrDefault(produto => produto.Id == id);
            if(produto != null)
            {
                 produtos.Remove(produto);
                 produtos.Insert(id, new Produto(){Nome = "Vela", Categoria = "Produtos Gerais", Preco = 12, Id = id});
                 return Ok();
            }
            return NotFound();
        }
    }
}