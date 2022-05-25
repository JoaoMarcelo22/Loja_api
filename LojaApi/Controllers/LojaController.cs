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
            Console.WriteLine(produto.Nome,produto.Categoria,produto.Preco);
            return CreatedAtAction(nameof(RecuperarProdutosPorID), new{ Id = produto.Id},produto);
        }

        [HttpGet]
        public IActionResult RecuperarProduto()
        {
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarProdutosPorID(double id)
        {
            Produto produto = produtos.FirstOrDefault(produto => produto.Id == id);
            if(produto != null)
            {
                return Ok(produto);
            }
            return NotFound();
        }
    }
}