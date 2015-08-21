using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCSharp.Models;
using TestCSharp.Repositories;
using TestCSharp.WebSite.Base.ViewModels.Views;

namespace TestCSharp.Controllers
{
    [HandleError]
    public class CausaleController : TestCSharp.WebSite.Base.Controllers.WebsiteContextController
    {
        private ICausaleRepository _oCausaleRepo;

        public CausaleController() : base()
        {
            _oCausaleRepo = new Repositories.CausaleRepository(this.DatabaseFactory);
        }
        public CausaleController(ICausaleRepository repository) : base()
        {
            _oCausaleRepo = repository;
        }

        public ActionResult Index()
        {            
            IQueryable<Causale> oQuery = _oCausaleRepo.GetAll();
            List<Causale> oList = oQuery.OrderBy(x => x.Descrizione).ToList();
            return View(oList);
        }

        public ActionResult Create(Causale oCausale)
        {
            if (oCausale == null)
                oCausale = new Causale();

            return View(oCausale);
        }
        public ActionResult Insert(Causale oCausale)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _oCausaleRepo.Add(oCausale);
                    this.DatabaseFactory.GetContext().SaveChanges();
                    return RedirectToAction("Index");
                    //return View("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Create", oCausale);
                    //return View("Create", oCausale);
                }
            }
            //return View("Create", oCausale);
            return RedirectToAction("Create", oCausale);
        }

        public ActionResult Edit(Causale oCausale)
        {
            //if (oCausale == null)
            //    oCausale = new Causale();
            //else
            Causale model =_oCausaleRepo.GetEdit().SingleOrDefault(x => x.ID == oCausale.ID);

            return View(model);
        }
        public ActionResult Update(Causale oCausale)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _oCausaleRepo.Update(oCausale);
                    this.DatabaseFactory.GetContext().SaveChanges();
                    return RedirectToAction("Index");
                    //return View("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Edit", oCausale);
                    //return View("Edit", oCausale);
                }
            }
            return RedirectToAction("Edit", oCausale);
            //return View("Edit", oCausale);
        }

    }
}