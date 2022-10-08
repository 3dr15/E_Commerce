using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;
using AutoMapper;
using DAL.Entity;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusiness _productBusiness;
        private readonly IMapper _mapper;

        public ProductController(
            IProductBusiness productBusiness,
            IMapper mapper
            )
        {
            _productBusiness = productBusiness;
            _mapper = mapper;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HOST.Modals.Response.Product>>> GetProducts([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            return Ok(_mapper.Map<List<HOST.Modals.Response.Product>>(await _productBusiness.GetProducts(pageSize, pageNumber)));
        }

        // GET: api/Product/C945FFE8-A012-415B-B11E-3CDB9FFC8626
        [HttpGet("{id}")]
        public async Task<ActionResult<HOST.Modals.Response.Product>> GetProduct(Guid id)
        {
            var product = await _productBusiness.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<HOST.Modals.Response.Product>(product));
            }
        }

        // PUT: api/Product/C945FFE8-A012-415B-B11E-3CDB9FFC8626
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid id, HOST.Modals.Request.UpdateProduct product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            try
            {
                await _productBusiness.UpdateProduct(_mapper.Map<Product>(product));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_productBusiness.DoesProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<HOST.Modals.Response.Product>> PostProduct(HOST.Modals.Request.AddProduct product)
        {
            return Ok(
                _mapper.Map<HOST.Modals.Response.Product>(
                    await _productBusiness.AddProduct(_mapper.Map<DAL.Entity.Product>(product))
                )
            );
        }

        // DELETE: api/Product/C945FFE8-A012-415B-B11E-3CDB9FFC8626
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productBusiness.DeleteProduct(id);
            return NoContent();
        }
    }
}
