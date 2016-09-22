using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeGustaLaPelicula.Models
{
    public class Filme
    {

        [Required]
        public int FilmeID { get; set; }
        [Required]
        public string Titulo { get; set; }
        public int Ano { get; set; }
        [Required]
        public string Realizador { get; set; }
        public string Genero { get; set; }
    }

    //movida a class Userfilmes para este ficheiro
    //adicionadas referencias aos utilizadores e filmes para se poder utilizar em conjunto com o campo da classificação
    public class UserFilmes
    {
        [Required]
        [StringLength(128)]
        [Display(Name = "User")]
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [Required]
        [Key]
        [Column(Order = 2)]
        public int FilmeID { get; set; }
        [ForeignKey("FilmeID")]
        public Filme Filme { get; set; }
        public int Classificacao { get; set; }
    }
}