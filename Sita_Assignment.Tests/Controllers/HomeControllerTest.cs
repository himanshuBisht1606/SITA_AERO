using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sita_Assignment;
using Sita_Assignment.Controllers;

namespace Sita_Assignment.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest 
    {
        HomeController _homeControllerTest;
        IParcel _IParcelTest;

        [TestInitialize]
        public void SetUp()
        {
            _IParcelTest = new ParcelBAL();
            _homeControllerTest = new HomeController(_IParcelTest);
        }
        [TestMethod]
        public void Index()
        {

            // Arrange
            //HomeController controller = new HomeController();

            // Act
            ViewResult result = _homeControllerTest.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
