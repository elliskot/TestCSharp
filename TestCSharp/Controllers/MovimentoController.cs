using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCSharp.Models;

namespace TestCSharp.Controllers
{
    public class MovimentoController : TestCSharp.WebSite.Base.Controllers.WebsiteContextController
    {
        private Repositories.ArticoloRepository _oArticoloRepo;
        private Repositories.MagazzinoRepository _oMagazzinoRepo;
        private Repositories.MovimentoRepository _oMovimentoRepo;
        private Repositories.CausaleRepository _oCausaleRepo;

        public MovimentoController() : base()
        {
            _oArticoloRepo = new Repositories.ArticoloRepository(this.DatabaseFactory);
            _oMagazzinoRepo = new Repositories.MagazzinoRepository(this.DatabaseFactory);
            _oMovimentoRepo = new Repositories.MovimentoRepository(this.DatabaseFactory);
            _oCausaleRepo = new Repositories.CausaleRepository(this.DatabaseFactory);
        }

        public ActionResult Index()
        {
            IQueryable<Movimento> oQuery = _oMovimentoRepo.GetAll();
            List<Movimento> oList = oQuery.OrderByDescending(x => x.ID).ToList();
            return View(oList);
        }

        public ActionResult Create(Movimento model)
        {
            if (model == null)
                model = new Movimento();

            if (model.ArticoloID > 0)
            {
                var list = _oArticoloRepo.GetAllSimpleList().ToList();
                model.Articolo = _oArticoloRepo.GetAllSimpleList().SingleOrDefault(x => x.ID == model.ArticoloID);
            }
            else
            {
                ViewBag.Articoli = _oArticoloRepo.GetAllSimpleList();
            }
            ViewBag.Magazzini = _oMagazzinoRepo.GetAllSimpleList();
            ViewBag.Causali = _oCausaleRepo.GetAllSimpleList();

            return View(model);
        }
        public ActionResult Insert(Movimento model)
        {
            if (ModelState.IsValid)
            {
                _oMovimentoRepo.Add(model);
                this.DatabaseFactory.GetContext().SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Create", model);
        }
    }
}