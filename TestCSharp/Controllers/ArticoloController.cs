using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCSharp.Models;
using TestCSharp.WebSite.Base.ViewModels.Views;

namespace TestCSharp.Controllers
{
    public class ArticoloController : TestCSharp.WebSite.Base.Controllers.WebsiteContextController
    {        
        private Repositories.ArticoloRepository _oArticoloRepo;

        public ArticoloController() : base()
        {
            _oArticoloRepo = new Repositories.ArticoloRepository(this.DatabaseFactory);
        }

        public ActionResult Index()
        {
            IQueryable<Articolo> oQuery = _oArticoloRepo.GetAll();
            List<Articolo> oList = oQuery.OrderBy(x => x.Codice).ToList();
            return View(oList);
        }

        public ActionResult Create()
        {
            Articolo oArticolo = new Articolo();

            return View(oArticolo);
        }
        public ActionResult Insert(Articolo model)
        {
            if (ModelState.IsValid)
            {

                _oArticoloRepo.Add(model);
                this.DatabaseFactory.GetContext().SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            Articolo oArticolo = _oArticoloRepo.GetEdit().SingleOrDefault(x => x.ID == ID);

            return View(oArticolo);
        }
        public ActionResult Update(Articolo model)
        {
            if (ModelState.IsValid)
            {
                _oArticoloRepo.Update(model);
                this.DatabaseFactory.GetContext().SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Articolo model)
        {
            if (model != null && ModelState.IsValid)
            {
                // Aggiorno l'operazione
                Articolo oArticolo = _oArticoloRepo.GetEdit().SingleOrDefault(x => x.ID == model.ID);
                if (oArticolo != null)
                    _oArticoloRepo.Delete(oArticolo);
            }

            this.DatabaseFactory.GetContext().SaveChanges();
            return RedirectToAction("Index");
        }

    }
}