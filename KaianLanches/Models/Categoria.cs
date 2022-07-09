using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaianLanches.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "Informe o nome da categoria.")]
        [Display(Name = "Nome")]
        [StringLength(200, ErrorMessage = "O tamanho máximo da categoria é de 200 caracteres.")]
        public string CategoriaNome { get; set; }
        [Required(ErrorMessage = "Informe uma descrição.")]
        [Display(Name = "Descrição")]
        [StringLength(200, ErrorMessage = "O tamanho máximo da descrição é de 200 caracteres.")]
        public string Descricao { get; set; }
        public List<Lanche> Lanches { get; set; }
    }
}