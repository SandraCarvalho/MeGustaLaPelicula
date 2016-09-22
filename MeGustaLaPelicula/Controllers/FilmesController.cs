using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeGustaLaPelicula.Models;
using Microsoft.AspNet.Identity;

namespace MeGustaLaPelicula.Controllers
{
    public class FilmesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Filmes
        public ActionResult Index()
        {
            return View(new FilmesViewModel
            {
                Filmes = db.Filmes.ToList(),
                User = db.Users.Find(User.Identity.GetUserId()),
                UserFilmes = db.UserFilmes.ToList()
            });
        }
        // /website/filmes/meusfilmes mostra apenas os filmes que o utilizador tem associados a propria conta (nota que falha se nao tiver login)
        [Authorize]
        public ActionResult meusfilmes()
        {
            List<Filme> myfilmes = new List<Filme>();
            List<int> tempmovies = new List<int>();
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            foreach (var filme in db.UserFilmes)
            {
                if (user.Equals(filme.User))
                {
                    tempmovies.Add(filme.FilmeID);
                }
            }
            foreach (var item in tempmovies)
            {
                myfilmes.Add(db.Filmes.Find(item));
            }
            return View(new FilmesViewModel
            {
                Filmes = myfilmes,
                User = user,
                 UserFilmes = db.UserFilmes.ToList()
            });
        }
        
        // GET: Filmes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }
        
        // GET: Filmes/adicionarfilme/1 por exemplo adiciona o filme com ID = 1 ao user que estiver logged in
        [Authorize]
        public ActionResult adicionarfilme(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //o parametro passado vem do link. /filmes/adicionarfilme/1
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            //verificação se ja existe a relação entre user e filme
            foreach (var item in db.UserFilmes)
            {
                if (item.FilmeID.Equals(filme.FilmeID) && item.UserId.Equals(User.Identity.GetUserId()))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            //adicionar o filme ao utilizador logged in
            //db.Users.Find(User.Identity.GetUserId()).Filmes.Add(filme);
            UserFilmes newmovie = new UserFilmes();
            newmovie.Filme = filme;
            newmovie.User = db.Users.Find(User.Identity.GetUserId());
            db.UserFilmes.Add(newmovie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Filmes/removerfilme/1 por exemplo adiciona o filme com ID = 1 ao user que estiver logged in
        [Authorize]
        // o ? no parametro diz que pode ser null. neste caso tiramos porque nao pode ser
        public ActionResult removerfilme(int id)
        {
            //o parametro passado vem do link. /filmes/...lme/1
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            //verificação se ja existe a relação entre user e filme
            //neste caso ja podemos usar a verificação para garantir que tiramos o certo
            // nota: fazer return dentro do metodo senao partimos o foreach ao mudarmos a database :p
            UserFilmes removeme = null;
            foreach (var item in db.UserFilmes)
            {
                if (item.FilmeID.Equals(filme.FilmeID) && item.UserId.Equals(User.Identity.GetUserId()))
                {
                    //db.Users.Find(User.Identity.GetUserId()).Filmes.Remove(filme);
                    removeme = item;
                }
            }
            if (removeme != null)
            {
                db.UserFilmes.Remove(removeme);
                db.SaveChanges();
                return RedirectToAction("meusfilmes");
            }
            return RedirectToAction("Index");
        }

        // GET: Filmes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmeID,Titulo,Ano,Realizador,Genero")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Filmes.Add(filme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filme);
        }

        // GET: Filmes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmeID,Titulo,Ano,Realizador,Genero,Classificacao")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filme filme = db.Filmes.Find(id);
            db.Filmes.Remove(filme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
