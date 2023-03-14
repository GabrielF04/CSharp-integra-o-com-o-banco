using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Filme
    {
        [Key]
        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [MaxLength(50)]
        public string Genero { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [Range(70, 600, ErrorMessage = "A duração deve ter de 70 a 600 min")]
        public int Duracao { get; set; }
        public int Id { get; set; }
    }
}
