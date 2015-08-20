using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestCSharp.WebSite.Controllers
{
    public class HomeController : TestCSharp.WebSite.Base.Controllers.WebsiteContextController
    {
        //private Repositories.ArticoloRepository _oArticoloRepo;
        //private Repositories.MagazzinoRepository _oMagazzinoRepo;
        //private Repositories.MovimentoRepository _oMovimentoRepo;

        public HomeController() : base()
        {
            //_oArticoloRepo = new Repositories.ArticoloRepository(this.DatabaseFactory);
            //_oMagazzinoRepo = new Repositories.MagazzinoRepository(this.DatabaseFactory);
            //_oMovimentoRepo = new Repositories.MovimentoRepository(this.DatabaseFactory);
        }

        public ActionResult Index()
        {
            //using (TestCSharp.Models.Entities.TestCSharpContext db = new TestCSharp.Models.Entities.TestCSharpContext())
            //{
            //    db.Articoli.ToList();
            //}
            return View();
        }

    }
}
