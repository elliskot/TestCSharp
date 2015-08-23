using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
//using Moq;
using TestCSharp.Controllers;
using TestCSharp.Models;
using TestCSharp.Repositories;
using TestCSharp.Tests.Models;
using TestCSharp.WebSite.Base.ViewModels.Views;
//using TestCSharp.Tests.Models;

namespace TestCSharp.Tests.Controllers
{
    [TestClass]
    public class ExportControllerTest
    {
        [TestMethod]
        public void CausaliJson_CheckIfResultIsNotNullAndValid()
        {
            InizializeContext();

            Causale oCausale1 = GetCausale(1, "Carico");
            Causale oCausale2 = GetCausale(2, "Scarico");
            InMemoryCausaleRepository repository = new InMemoryCausaleRepository();
            repository.Add(oCausale1);
            repository.Add(oCausale2);

            var controller = new ExportController(repository);

            var result = controller.CausaliJson();

            //AssertCreate
            Assert.IsNotNull(result);

            bool testValue = isValidJSON(result);
            Assert.IsTrue(testValue);
        }
        [TestMethod]
        public void CausaliCSV_CheckIfResultIsNotNull()
        {
            InizializeContext();

            Causale oCausale1 = GetCausale(1, "Carico");
            Causale oCausale2 = GetCausale(2, "Scarico");
            InMemoryCausaleRepository repository = new InMemoryCausaleRepository();
            repository.Add(oCausale1);
            repository.Add(oCausale2);

            var controller = new ExportController(repository);

            var result = controller.CausaliCsv();

            //AssertCreate
            Assert.IsNotNull(result); 
            Assert.IsNotNull(result.FileStream);
        }

        private Causale GetCausale(int ID, string Descrizione)
        {
            return new Causale { ID = ID, Descrizione = Descrizione };
        }

        private void InizializeContext()
        {
            // Step 1: Setup the HTTP Request
            var httpRequest = new HttpRequest("", "http://localhost:11173/", "");
            // Step 2: Setup the HTTP Response
            var httpResponce = new HttpResponse(new StringWriter());
            // Step 3: Setup the Http Context
            var httpContext = new HttpContext(httpRequest, httpResponce);
            // Step 4: Assign the Context
            HttpContext.Current = httpContext;
        }

        public bool isValidJSON(JsonResult jsonResult)
        {
            try
            {
                var c = (List<CausaleExport>)jsonResult.Data;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
