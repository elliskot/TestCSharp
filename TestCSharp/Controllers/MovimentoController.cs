using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestCSharp.Controllers
{
    public class MovimentoController : TestCSharp.WebSite.Base.Controllers.WebsiteContextController
    {
        private Repositories.ArticoloRepository _oArticoloRepo;
        private Repositories.MagazzinoRepository _oMagazzinoRepo;
        private Repositories.MovimentoRepository _oMovimentoRepo;

        public MovimentoController() : base()
        {
            _oMovimentoRepo = new Repositories.MovimentoRepository(this.DatabaseFactory);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}