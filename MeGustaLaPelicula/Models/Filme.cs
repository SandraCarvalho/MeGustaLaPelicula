using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

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
        public int Classificacao { get; set; }
    }

    public class FilmeDBContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
    }
}