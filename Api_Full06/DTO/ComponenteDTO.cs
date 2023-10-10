using Api_Full06.Model;
using System.ComponentModel.DataAnnotations;

namespace Api_Full06.DTO
{
    public class ComponenteDTO
    {
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
        public int ProdutoId { get; set; }
    }
}
