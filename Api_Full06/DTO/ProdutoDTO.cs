using System.ComponentModel.DataAnnotations;

namespace Api_Full06.DTO
{
    public class ProdutoDTO
    {
        [Required(ErrorMessage = "É obrigatório inserir o Código do Produto!")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "É obrigatório inserir o Nome do Produto!")]
        public string Nome { get; set; }
    }
}
