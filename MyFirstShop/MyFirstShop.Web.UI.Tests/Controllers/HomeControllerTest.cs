using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFirstShop.Core.Contracts;
using MyFirstShop.Core.Models;
using MyFirstShop.Core.ViewModels;
using MyFirstShop.Web.UI;
using MyFirstShop.Web.UI.Controllers;
using MyFirstShop.Web.UI.Tests.Mocks;

namespace MyFirstShop.Web.UI.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexPageDoesReturnProducts()
        {
            IRespository<Product> productContext = new MockContext<Product>();
            IRespository<ProductCategory> productCategoryContext = new MockContext<ProductCategory>();

            productContext.Insert(new Product());

            HomeController controller = new HomeController(productContext,  productCategoryContext);

            var result = controller.Index() as ViewResult;
            var viewModel = (ProductListViewModel) result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Products.Count());

        }
       
    }
}
