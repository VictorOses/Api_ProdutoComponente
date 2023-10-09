using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Api_Full06.Model
{
    public class Componente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É obrigatório inserir o Código do Componente!")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "É obrigatório inserir o índice do Componente!")]
        public int Indice { get; set; }
        [Required(ErrorMessage = "É obrigatório inserir o SKU do Componente!")]
        public int SKU { get; set; }
        [Required(ErrorMessage = "É obrigatório inserir a descrição do Componente!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "É obrigatório inserir o preço do Componente!")]
        public double Preco { get; set; }
        [Required(ErrorMessage = "É obrigatório inserir a quantidade do Componente!")]
        public int Quantidade { get; set; }
        public virtual Produto Produto { get; set; }
        public int ProdutoId { get; set; }
    }
}
