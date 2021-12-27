using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using ProductMicroservice.Model;
using ProductMicroservice.Functions;
using ProductMicroservice.Controllers;
using ProductMicroservice;
using Microsoft.AspNetCore.Mvc;
using Assert = NUnit.Framework.Assert;

namespace ProductTests
{
    [TestClass]
    public class Tests
    {
        List<Product> prod;
        
        int success = 1;
        int failure = 0;

        [SetUp]
        public void setup()
        {
            prod = new List<Product>()
            {
                    new Product() { Id = 1, Price = 80000.00, Name = "Iphone", Description = "Some example text.", Image_Name = "1.jfif", Rating = 2 },
                    new Product() { Id = 2, Price = 2000.00, Name = "Bracelet", Description = "Some example text.", Image_Name = "1.jfif", Rating = 3 },
                    new Product() { Id = 3, Price = 40000.00, Name = "Oneplus8", Description = "Some example text.", Image_Name = "1.jfif", Rating = 3 },
                    new Product() { Id = 4, Price = 15000.00, Name = "Apple Watch", Description = "Some example text.", Image_Name = "1.jfif", Rating = 3 }
            };
        }


        [Test]
        public void GetAllProducts_ReturnsOkRequest()
        {
            var mock = new Mock<IFunctionRepository>();
            mock.Setup(m => m.GetAllProduct()).Returns(prod);
            ProductController obj = new ProductController(mock.Object);
            OkObjectResult objectResult = (OkObjectResult)obj.GetAll();
            NUnit.Framework.Assert.AreEqual(200, objectResult.StatusCode);
        }
        [Test]
        public void GetAllProducts_ReturnsNotNullList()
        {
            var mock = new Mock<IFunctionRepository>();
            ProductController obj = new ProductController(mock.Object);
            var data = obj.GetAll();
            NUnit.Framework.Assert.IsNotNull(data);
        }

        [Test]
        public void SearchProductById_ValidInput_ReturnsOkRequest()
        {
            int id = 2;
            var mock = new Mock<IFunctionRepository>();
           

            mock.Setup(x => x.SearchProductByID(id)).Returns(prod.Where(x => x.Id == id));
            ProductController obj = new ProductController(mock.Object);

            var data = obj.Get(id);

            var res = data as ObjectResult;

            NUnit.Framework.Assert.AreEqual(200, res.StatusCode);
        }

        [Test]
        public void SearchProductById_InvalidInput_ReturnsNotFoundResult()
        {
            int id = 9;

            var mock = new Mock<IFunctionRepository>();

            mock.Setup(x => x.SearchProductByID(id)).Returns((IEnumerable<Product>)(prod.Where(x => x.Id == id)).FirstOrDefault());
            try
            {
                ProductController obj = new ProductController(mock.Object);

                var data = obj.Get(id);

            }
            catch (Exception e)
            {
                Assert.AreEqual("Product not found for the given productID", e.Message);
            }

        }
        [Test]
        public void SearchProductByName_ValidInput_ReturnsOkRequest()
        {
            string name = "Iphone";

            var mock = new Mock<IFunctionRepository>();

            mock.Setup(x => x.SearchProductByName(name)).Returns((prod.Where(x => x.Name == name)));

            ProductController obj = new ProductController(mock.Object);

            var data = obj.GetbyName(name);

            var res = data as ObjectResult;

            Assert.AreEqual(200, res.StatusCode);
        }

        [Test]
        public void SearchProductByName_InvalidInput_ReturnsNotFoundResult()
        {
            string name = "ProductName";

            var mock = new Mock<IFunctionRepository>();
            try
            {
                Product test = (prod.Where(x => x.Name == name)).FirstOrDefault();
                mock.Setup(x => x.SearchProductByName(name)).Returns((IEnumerable<Product>)test);

                ProductController obj = new ProductController(mock.Object);

                var data = obj.GetbyName(name);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Product not found for the given productName", e.Message);
            }
        }

    }
}
