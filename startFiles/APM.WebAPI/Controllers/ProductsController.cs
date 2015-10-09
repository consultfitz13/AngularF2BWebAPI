using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.OData;

namespace APM.WebAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:49716","*","*")]
    public class ProductsController : ApiController
    {
        // GET: api/Products
        [EnableQuery()]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get()
        {
            try
            {
                var productRepo = new ProductRepository();
                return Ok(productRepo.Retrieve().AsQueryable());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Products/5
        [Authorize]
        public IHttpActionResult Get(int id)
        {
            try
            {

                Product product;
                var productRepo = new ProductRepository();
                if (id > 0)
                {
                    var products = productRepo.Retrieve();
                    product = products.FirstOrDefault(p => p.ProductId == id);
                    if (product == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    product = new Product();
                }

                return Ok(product);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody]Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var productRepo = new ProductRepository();
                Product newProduct = productRepo.Save(product);
                if (newProduct == null)
                {
                    return Conflict();
                }

                return Created<Product>(Request.RequestUri + newProduct.ProductId.ToString(), newProduct);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var productRepo = new ProductRepository();
                Product updatedProduct = productRepo.Save(id, product);
                if (updatedProduct == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }


        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
