using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCSharp.Models;
using TestCSharp.WebSite.Base.ViewModels.Views;

namespace TestCSharp.Controllers
{
    public class ExportController : TestCSharp.WebSite.Base.Controllers.WebsiteContextController
    {
        private Repositories.ArticoloRepository _oArticoloRepo;
        private Repositories.MagazzinoRepository _oMagazzinoRepo;
        private Repositories.MovimentoRepository _oMovimentoRepo;

        public ExportController() : base()
        {
            _oArticoloRepo = new Repositories.ArticoloRepository(this.DatabaseFactory);
            _oMagazzinoRepo = new Repositories.MagazzinoRepository(this.DatabaseFactory);
            _oMovimentoRepo = new Repositories.MovimentoRepository(this.DatabaseFactory);
        }

        public JsonResult ArticoliJson()
        {
            IQueryable<Articolo> oQuery = _oArticoloRepo.GetAllSimpleList();
            List<ArticoloExport> oList = oQuery.Select(x => new ArticoloExport
            {
                id = x.ID,
                cod = x.Codice,
                des = x.Descrizione,
            }).OrderBy(x => x.cod).ToList();
            return Json(oList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MagazziniJson()
        {
            IQueryable<Magazzino> oQuery = _oMagazzinoRepo.GetAllSimpleList();
            List<MagazzinoExport> oList = oQuery.Select(x => new MagazzinoExport
            {
                id = x.ID,
                cod = x.Codice,
                des = x.Descrizione,
            }).OrderBy(x => x.cod).ToList();
            return Json(oList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MovimentiJson(int ArticoloID)
        {
            IQueryable<Movimento> oQuery = _oMovimentoRepo.GetAll().Where(x => x.ArticoloID == ArticoloID);
            List<MovimentoExport> oList = oQuery.Select(x => new MovimentoExport
            {
                id = x.ID,
                artc = x.Articolo.Codice,
                artd = x.Articolo.Descrizione,
                parc = x.Partenza.Codice,
                pard = x.Partenza.Descrizione,
                desc = x.Destinazione.Codice,
                desd = x.Destinazione.Descrizione,
                cau = x.Causale,
            }).OrderBy(x => x.id).ToList();
            return Json(oList, JsonRequestBehavior.AllowGet);
        }

        public FileStreamResult ArticoliCsv()
        {
            IQueryable<Articolo> oQuery = _oArticoloRepo.GetAllSimpleList();
            List<ArticoloExport> oList = oQuery.Select(x => new ArticoloExport
            {
                id = x.ID,
                cod = x.Codice,
                des = x.Descrizione,
            }).OrderBy(x => x.cod).ToList();

            return Reporting.CsvHelper.ResponseCsv<ArticoloExport>(oList, "articoli.csv", ";", true);

            //List<ArticoloExport> oPartecipanti = new List<ArticoloExport>();
            //Articolo oCorso = _oArticoloRepo.GetAll();
            //if (oCorso != null)
            //{
            //    string sCategorieCorso = "";
            //    foreach (CategoriaCorso oCategoria in oCorso.CategorieCorso)
            //    {
            //        sCategorieCorso += oCategoria.Descrizione + " (" + oCategoria.Codice + ")";
            //    }
            //    GiornoCorso oTeoria = oCorso.GiorniCorso.Where(m => m.Tipo == "Teoria").OrderByDescending(m => m.Data).FirstOrDefault();

            //    string sDataEsame = String.Format("{0:d}", oTeoria.Data);
            //    string sDataInizio = String.Format("{0:d}", oCorso.GiorniCorso.Min(m => m.Data)); ;
            //    string sDataFine = String.Format("{0:d}", oCorso.GiorniCorso.Max(m => m.Data)); ;

            //    oPartecipanti = (from model in _oPartecipanteRepo.GetAll()
            //                         .Where(m => (m.CorsoFormazione_ID == oCorso.ID)
            //                             && (m.Idoneo == "Idoneo"))
            //                     select new Models.ViewModels.PartecipanteCsv()
            //                     {
            //                         Attrezzature = sCategorieCorso,
            //                         CodiceFiscale = model.CodiceFiscale,
            //                         Cognome = model.Cognome,
            //                         CorsoSedeCap = oTeoria.IndirizzoCap,
            //                         CorsoSedeComune = oTeoria.IndirizzoCitta,
            //                         CorsoSedeIndirizzo = oTeoria.IndirizzoCivico,
            //                         CorsoSedeProvincia = oTeoria.IndirizzoProvincia,
            //                         CorsoSedeRagioneSociale = oTeoria.IndirizzoSocieta,
            //                         CorsoTipologia = oCorso.Grado.Descrizione,
            //                         CorsoTitolo = oCorso.Nome,
            //                         DataEsame = SqlFunctions.DatePart("yyyy", model.GiorniCorso.Where(m => m.Tipo == "Teoria").Max(m => m.Data)) + "/" + SqlFunctions.DatePart("mm", model.GiorniCorso.Where(m => m.Tipo == "Teoria").Max(m => m.Data)) + "/" + SqlFunctions.DatePart("dd", model.GiorniCorso.Where(m => m.Tipo == "Teoria").Max(m => m.Data)),
            //                         DataInizio = SqlFunctions.DatePart("yyyy", model.GiorniCorso.Min(m => m.Data)) + "/" + SqlFunctions.DatePart("mm", model.GiorniCorso.Min(m => m.Data)) + "/" + SqlFunctions.DatePart("dd", model.GiorniCorso.Min(m => m.Data)),
            //                         DataFine = SqlFunctions.DatePart("yyyy", model.GiorniCorso.Max(m => m.Data)) + "/" + SqlFunctions.DatePart("mm", model.GiorniCorso.Max(m => m.Data)) + "/" + SqlFunctions.DatePart("dd", model.GiorniCorso.Max(m => m.Data)),
            //                         DataNascita = SqlFunctions.DatePart("yyyy", model.DataNascita) + "/" + SqlFunctions.DatePart("mm", model.DataNascita) + "/" + SqlFunctions.DatePart("dd", model.DataNascita),
            //                         LuogoNascita = model.LuogoNascita,
            //                         Nome = model.Nome,
            //                         NumeroLicenzaIpaf = model.NumeroLicenzaIpaf,
            //                         ProvinciaNascita = model.ProvinciaNascita,
            //                         Sesso = model.Sesso,
            //                         CategorieConStabilizzatori = model.CategorieCorso.Any(m => m.ConStabilizzatore),
            //                         CategorieSenzaStabilizzatori = model.CategorieCorso.Any(m => m.SenzaStabilizzatore)
            //                     }).ToList();
            //}
            //return Reporting.CsvHelper.ResponseCsv<Models.ViewModels.PartecipanteCsv>(oPartecipanti, "partecipanti_" + oCorso.Codice + ".csv", ";", true);
        }

        public FileStreamResult MagazziniCsv()
        {
            IQueryable<Magazzino> oQuery = _oMagazzinoRepo.GetAllSimpleList();
            List<MagazzinoExport> oList = oQuery.Select(x => new MagazzinoExport
            {
                id = x.ID,
                cod = x.Codice,
                des = x.Descrizione,
            }).OrderBy(x => x.cod).ToList();

            return Reporting.CsvHelper.ResponseCsv<MagazzinoExport>(oList, "magazzini.csv", ";", true);
        }

        public FileStreamResult MovimentiCsv(int ArticoloID, string CodiceArticolo)
        {
            IQueryable<Movimento> oQuery = _oMovimentoRepo.GetAll().Where(x => x.ArticoloID == ArticoloID);
            List<MovimentoExport> oList = oQuery.Select(x => new MovimentoExport
            {
                id = x.ID,
                artc = x.Articolo.Codice,
                artd = x.Articolo.Descrizione,
                parc = x.Partenza.Codice,
                pard = x.Partenza.Descrizione,
                desc = x.Destinazione.Codice,
                desd = x.Destinazione.Descrizione,
                cau = x.Causale,
            }).OrderBy(x => x.id).ToList();

            return Reporting.CsvHelper.ResponseCsv<MovimentoExport>(oList, "movimenti_articolo_" + CodiceArticolo + ".csv", ";", true);
        }
    }
}
