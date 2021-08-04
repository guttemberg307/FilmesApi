using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Models
{
    public class Filme
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required (ErrorMessage = "O Campo titulo é obrigatório")]//faz o requerimento necessario para o campo 
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres")]// delimita a quantidade maxima de caractere 
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ter no minimo 1 e no maximo 600 minutos")]// faz um range de 1 ate 600 na quantidade de minutos 
        public int Duracao { get; set; }

    }
}
