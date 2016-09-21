using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeGustaLaPelicula.Models
{
    public class FilmesViewModel
    {
        public List<Filme> Filmes { get; set; }
        public ApplicationUser User { get; set; }
    }
}