using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCSharp.Models;

namespace TestCSharp.Controllers
{
    public class MagazzinoController : TestCSharp.WebSite.Base.Controllers.WebsiteContextController
    {
        //private Repositories.ArticoloRepository _oArticoloRepo;
        private Repositories.MagazzinoRepository _oMagazzinoRepo;
        //private Repositories.MovimentoRepository _oMovimentoRepo;

        public MagazzinoController() : base()
        {
            _oMagazzinoRepo = new Repositories.MagazzinoRepository(this.DatabaseFactory);
        }

        public ActionResult Index()
        {
            IQueryable<Magazzino> oQuery = _oMagazzinoRepo.GetAll();
            List<Magazzino> oList = oQuery.OrderBy(x => x.Codice).ToList();
            return View(oList);
        }

        public ActionResult Create()
        {
            Magazzino oMagazzino = new Magazzino();

            return View(oMagazzino);
        }
        public ActionResult Insert(Magazzino model)
        {
            if (ModelState.IsValid)
            {
                _oMagazzinoRepo.Add(model);
                this.DatabaseFactory.GetContext().SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            Magazzino oMagazzino = _oMagazzinoRepo.GetEdit().SingleOrDefault(x => x.ID == ID);

            return View(oMagazzino);
        }
        public ActionResult Update(Magazzino model)
        {
            if (ModelState.IsValid)
            {
                _oMagazzinoRepo.Update(model);
                this.DatabaseFactory.GetContext().SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Magazzino model)
        {
            if (model != null && ModelState.IsValid)
            {
                // Aggiorno l'operazione
                Magazzino oMagazzino = _oMagazzinoRepo.GetEdit().SingleOrDefault(x => x.ID == model.ID);
                if (oMagazzino != null)
                    _oMagazzinoRepo.Delete(oMagazzino);
            }

            this.DatabaseFactory.GetContext().SaveChanges();
            return RedirectToAction("Index");
        }
    }
}