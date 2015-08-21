using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
using TestCSharp.Controllers;
using TestCSharp.Models;
using TestCSharp.Repositories;
using TestCSharp.Tests.Models;
//using TestCSharp.Tests.Models;

namespace TestCSharp.Tests.Controllers
{
    [TestClass]
    public class CausaleControllerTest
    {
        [TestMethod]
        public void Index_Get_AsksForIndexView()
        {
            InizializaContext();
            //Arrange
            var controller = new CausaleController();

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.IsTrue(String.IsNullOrEmpty(result.ViewName));
        }

        [TestMethod]
        public void Index_Get_RetrievesAllCausaliFromRepository()
        {
            InizializaContext();
            // Arrange
            Causale oCausale1 = GetCausale(1, "Carico");
            Causale oCausale2 = GetCausale(2, "Scarico");
            InMemoryCausaleRepository repository = new InMemoryCausaleRepository();
            repository.Add(oCausale1);
            repository.Add(oCausale2);
            var controller = new CausaleController(repository);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            var model = (IEnumerable<Causale>)result.ViewData.Model;
            CollectionAssert.Contains(model.ToList(), oCausale1);
            CollectionAssert.Contains(model.ToList(), oCausale1);
        }

        [TestMethod]
        public void Create_Post_ReturnsViewIfModelStateIsNotValid()
        {
            // Arrange
            var controller = new CausaleController(new InMemoryCausaleRepository());

            controller.ModelState.AddModelError("", "mock error message");
            //Causale model = GetCausale(1, "");

            // Act
            var result = (ViewResult)controller.Create();

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        } 

        private Causale GetCausale(int ID, string Descrizione)
        {
            return new Causale { ID = ID, Descrizione = Descrizione };
        }

        private void InizializaContext()
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

    }
}
