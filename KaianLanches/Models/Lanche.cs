using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaianLanches.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }
        [Required]
        [Display(Name = "Nome do lanche")]
        [StringLength(200, ErrorMessage = "O nome do lanche deve ter no máximo 200 caracteres.")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Descrição curta do lanche")]
        [MinLength(20, ErrorMessage = "A descrição curta do lanche precisa ter no mínimo 20 caracteres.")]
        [MaxLength(200, ErrorMessage = "A descrição curta do lanche pode ter no máximo 200 caracteres.")]
        public string DescricaoCurta { get; set; }
        [Required]
        [Display(Name = "Descrição detalhada do lanche")]
        [MinLength(20, ErrorMessage = "A descrição detalhada do lanche precisa ter no mínimo 20 caracteres.")]
        [MaxLength(200, ErrorMessage = "A descrição detalhada do lanche pode ter no máximo 200 caracteres.")]
        public string DescricaoDetalhada { get; set; }
        [Required]
        [Display(Name = "Preço do lanche")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }
        [Display(Name = "Caminho da imagem normal")]
        [StringLength(200, ErrorMessage = "O caminho só pode ter até 200 caracteres")]
        public string ImagemUrl { get; set; }
        [Display(Name = "Caminho da imagem miniatura")]
        [StringLength(200, ErrorMessage = "O caminho só pode ter até 200 caracteres")]
        public string ImagemThumbnailUrl { get; set; }
        [Display(Name = "Preferido?")]
        public bool EhLanchePreferido { get; set; }
        [Display(Name = "Estoque?")]
        public bool EmEstoque { get; set; }
        [Display(Name = "Categorias")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
