using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeGustaLaPelicula.Models
{
    public class SearchModel
    {
        public string titulo { get; set; }
        public int? ano { get; set; }
        public string realizador { get; set; }
        public string genero { get; set; }
    }
}