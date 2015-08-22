using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestCSharp.Controllers;
using TestCSharp.Models;

namespace TestCSharp.Tests.Controllers
{
    [TestClass]
    public class ModelStateTest : Controller
    {
        public ModelStateTest() 
        {
            ControllerContext = (new Mock<ControllerContext>()).Object; 
        }

        [TestMethod]
        public void CausaleModel_ModelState_Validation()
        {
            // Arrange 
            var controller = new ModelStateTest();
            var oCausale = new Causale
            {
               Descrizione = null //This is a required property and so this value is invalid 
            };

            // Act 
            var result = controller.TestTryValidateModel(oCausale);

            // Assert 
            Assert.IsFalse(result);

            var modelState = controller.ModelState;

            Assert.AreEqual(2, modelState.Keys.Count);

            Assert.IsTrue(modelState.Keys.Contains("Descrizione"));
            Assert.IsTrue(modelState["Descrizione"].Errors.Count == 1);
            Assert.AreEqual("Descrizione is required.", modelState["Descrizione"].Errors[0].ErrorMessage);

            //Assert.IsTrue(modelState.Keys.Contains("Colour"));
            //Assert.IsTrue(modelState["Colour"].Errors.Count == 1);
            //Assert.AreEqual("The Colour field is required.", modelState["Colour"].Errors[0].ErrorMessage);
        }

        public bool TestTryValidateModel(Causale model)
        {
            return TryValidateModel(model);
        } 
    }
}
