using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MeGustaLaPelicula.Models
{
    public class UserFilmes
    {
        [Required]
        [StringLength(128)]
        [Display(Name = "User")]
        public string UserId { get; set; }
        [Required]
        public int FilmeID { get; set; }
        public int Classificacao { get; set; }
    }
}