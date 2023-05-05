﻿using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProductsApp.Controllers
{
    [EnableCors(origins: "http://localhost:49345,http://csc123client.azurewebsites.net", headers: "*", methods: "*")]

    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        [HttpGet]
        [Route("api/v3/products/")]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        [HttpGet]
        [Route("api/v3/products/{id:int:min(1)}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}