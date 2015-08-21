using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        public void Index_Get_AsksForView()
        {
            InizializeContext();
            //Arrange
            var controller = new CausaleController();

            //Act
            var result = (ViewResult)controller.Index();

            //AssertCreate
            //result.AssertViewRendered();
            //Assert.AreEqual("Index", result.);
            //Assert.IsTrue(String.IsNullOrEmpty(result.ViewName));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index_Get_RetrievesAllCausaliFromRepository()
        {
            InizializeContext();
            // Arrange
            Causale oCausale1 = GetCausale(1, "Carico");
            Causale oCausale2 = GetCausale(2, "Scarico");
            InMemoryCausaleRepository repository = new InMemoryCausaleRepository();
            repository.Add(oCausale1);
            repository.Add(oCausale2);
            var controller = new CausaleController(repository);

            // Act
            var result = (ViewResult)controller.Index();

            // Assert
            var model = (IEnumerable<Causale>)result.ViewData.Model;
            CollectionAssert.Contains(model.ToList(), oCausale1);
            CollectionAssert.Contains(model.ToList(), oCausale1);
        }

        [TestMethod]
        public void Create_Get_AsksForView()
        {
            InizializeContext();
            // Arrange
            var controller = new CausaleController();
            Causale oCausale = GetCausale(1, "");

            // Act
            var result = (ViewResult)controller.Create(oCausale);

            // Assert
            Assert.IsTrue(String.IsNullOrEmpty(result.ViewName));
        }

        [TestMethod]
        public void Insert_Post_ReturnsViewIfModelStateIsNotValid()
        {
            // Arrange
            var controller = new CausaleController(new InMemoryCausaleRepository());

            //controller.ModelState.AddModelError("", "error message");
            controller.ModelState.Add("testError", new ModelState());
            controller.ModelState.AddModelError("testError", "test");

            Causale oCausale = GetCausale(1, "");

            // Act
            ActionResult result = controller.Insert(oCausale);
                        
            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult routeResult = result as RedirectToRouteResult;
            Assert.AreEqual(routeResult.RouteValues["action"], "Create");            
        }

        [TestMethod]
        public void Edit_Get_AsksForView()
        {
            InizializeContext();
            // Arrange
            var controller = new CausaleController();
            Causale oCausale = GetCausale(1, "");

            // Act
            var result = (ViewResult)controller.Edit(oCausale);

            // Assert
            Assert.IsTrue(String.IsNullOrEmpty(result.ViewName));
        }

        [TestMethod]
        public void Update_Post_ReturnsViewIfModelStateIsNotValid()
        {
            // Arrange
            var controller = new CausaleController(new InMemoryCausaleRepository());

            controller.ModelState.AddModelError("", "error message");
            Causale oCausale = GetCausale(1, "");

            // Act
            var result = controller.Update(oCausale);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult routeResult = result as RedirectToRouteResult;
            Assert.AreEqual(routeResult.RouteValues["action"], "Edit");
        }

        [TestMethod]
        public void Delete_Post_ReturnsViewIfModelStateIsNotValid()
        {
            // Arrange
            var controller = new CausaleController(new InMemoryCausaleRepository());

            controller.ModelState.AddModelError("", "error message");
            Causale oCausale = GetCausale(1, "");

            // Act
            var result = controller.Delete(oCausale);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult routeResult = result as RedirectToRouteResult;
            Assert.AreEqual(routeResult.RouteValues["action"], "Index"); 
        }

        //[TestMethod]
        //public void Insert_Post_ReturnsViewIfRepositoryThrowsException()
        //{
        //    InizializeContext();
        //    // Arrange
        //    InMemoryCausaleRepository repository = new InMemoryCausaleRepository();
        //    Exception exception = new Exception();
        //    repository.ExceptionToThrow = exception;
        //    var controller = new CausaleController(repository);
        //    Causale oCausale = GetCausale(1, "");

        //    // Act
        //    var result = controller.Insert(oCausale);

        //    // Assert
        //    Assert.AreEqual("Create", result.ViewName);
        //    //Assert.AreEqual("Insert", result.ViewName);
        //    ModelState modelState = result.ViewData.ModelState[""];
        //    Assert.IsNotNull(modelState);
        //    Assert.IsTrue(modelState.Errors.Any());
        //    Assert.AreEqual(exception, modelState.Errors[0].Exception);
        //} 

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

    }
}
