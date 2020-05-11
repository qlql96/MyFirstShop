using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFirstShop.Core.Contracts;
using MyFirstShop.Core.Models;
using MyFirstShop.Core.ViewModels;
using MyFirstShop.Services;
using MyFirstShop.Web.UI.Controllers;
using MyFirstShop.Web.UI.Tests.Mocks;

namespace MyFirstShop.Web.UI.Tests.Controllers
{
    [TestClass]
    public class BasketControllerTest
    {
        [TestMethod]
        public void CanAddBasketItem()
        {
            //Setup
            IRespository<Basket> baskets = new MockContext<Basket>();
            IRespository<Product> products = new MockContext<Product>();


            var httpContext = new MockHttpContext();


            IBasketService basketService = new BasketService(products, baskets);
           // var controller = new BasketController(basketService);
          //  controller.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext, new System.Web.Routing.RouteData(), controller);
             basketService.AddToBasket(httpContext, "1");
            //Act
            //controller.AddToBasket("1");


            Basket basket = baskets.Collection().FirstOrDefault();


            //Assert
            Assert.IsNotNull(basket);
            Assert.AreEqual(1, basket.BasketItems.Count);
            //Assert.AreEqual("1", basket.BasketItems.ToList().FirstOrDefault().ProductId);


        }

        [TestMethod]
        public void CanGetSummaryViewMode()
        {

            //Setup
            IRespository<Basket> baskets = new MockContext<Basket>();
            IRespository<Product> products = new MockContext<Product>();


            products.Insert(new Product() { Id = "1", Price = 10.00m });
            products.Insert(new Product() { Id = "2", Price = 5.00m });

            Basket basket = new Basket();
            basket.BasketItems.Add(new BasketItem() { ProductId = "1", Quantity = 2 });
            basket.BasketItems.Add(new BasketItem() { ProductId = "2", Quantity = 1 });
            baskets.Insert(basket);

            IBasketService basketService = new BasketService(products, baskets);

            var controller = new BasketController(basketService);
            var httpContext = new MockHttpContext();
            httpContext.Request.Cookies.Add(new System.Web.HttpCookie("eCommerceBasket") { Value = basket.Id });
            controller.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext, new System.Web.Routing.RouteData(), controller);


            var result = controller.BasketSummary() as PartialViewResult;
            var basketSummary = (BasketSummaryViewModel)result.ViewData.Model;

            Assert.AreEqual(3, basketSummary.BasketCount);
            Assert.AreEqual(25.00m, basketSummary.BasketTotal);


        }
    }
}
