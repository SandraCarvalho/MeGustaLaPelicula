using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeGustaLaPelicula.Models
{
    public class SearchLogic
    {
        private ApplicationDbContext Context;
        public SearchLogic(ApplicationDbContext context)
        {
            Context = context;
        }

        public IQueryable<Filme> GetProducts(SearchModel searchModel)
        {
            var result = Context.Filmes.AsQueryable();
            if (searchModel != null)
            {
                if (!string.IsNullOrEmpty(searchModel.titulo))
                    result = result.Where(x => x.Titulo.Contains(searchModel.titulo));
                if (searchModel.ano.HasValue)
                    result = result.Where(x => x.Ano == searchModel.ano);
                if (!string.IsNullOrEmpty(searchModel.realizador))
                    result = result.Where(x => x.Realizador.Contains(searchModel.realizador));
                if (!string.IsNullOrEmpty(searchModel.genero))
                    result = result.Where(x => x.Genero.Contains(searchModel.genero));
            }
            return result;
        }
    }
}