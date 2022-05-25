using System.ComponentModel.DataAnnotations;

namespace LojaApi.Models
{
    public class Produto
    {
        public int Id{get;internal set;}

        [Required(ErrorMessage ="O campo é obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O campo é obrigatorio")]
        public string Categoria { get; set; }

        [Required(ErrorMessage ="O campo é obrigatorio")]
        public double Preco { get; set; }
    }
}