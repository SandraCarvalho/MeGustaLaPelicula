namespace MeGustaLaPelicula.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MeGustaLaPelicula.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MeGustaLaPelicula.Models.ApplicationDbContext";
        }

        protected override void Seed(MeGustaLaPelicula.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Filmes.AddOrUpdate(x => x.FilmeID,
                new Filme()
                {
                    FilmeID = 1,
                    Titulo = "Pride and Prejudice",
                    Ano = 1953,
                    Realizador = "Bacalhau",
                    Genero = "CLASSICO"
                },
                new Filme()
                {
                    FilmeID = 2,
                    Titulo = "Balas e Bolinhos",
                    Ano = 2000,
                    Realizador = "Bino",
                    Genero = "LOL"
                },
                new Filme()
                {
                    FilmeID = 3,
                    Titulo = "Ataque Nocturno",
                    Ano = 1978,
                    Realizador = "Charles Bronson",
                    Genero = "PORRADA"
                },
                new Filme()
                {
                    FilmeID = 4,
                    Titulo = "Star Wars",
                    Ano = 1980,
                    Realizador = "Darth Vader",
                    Genero = "ACÇÃO"
                }
                );
        }
    }
}
