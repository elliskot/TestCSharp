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
    public class CausaleController : TestCSharp.WebSite.Base.Controllers.WebsiteContextController
    {
        //ICausaleRepository _repository;
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
            //return View();
        }

        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

    }
}