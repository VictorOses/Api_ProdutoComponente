using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api_Full06.Model
{
    public class Produto
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "É obrigatório inserir o Código do Produto!")]        
        public string Codigo { get; set; }
        [Required(ErrorMessage = "É obrigatório inserir o Nome do Produto!")]
        public string Nome { get; set; }
        [JsonIgnore]
        public virtual List<Componente> Componente { get; set; }
    }
}
