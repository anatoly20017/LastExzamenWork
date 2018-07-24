using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AppContext;
using BLL;
using Entities;
using System.Threading.Tasks;

namespace Exzamen.Controller
{
  public class ProductController
  {
    [Route("api/products")]
    public class ReceptsController : ControllerBase
    {
      ProductService _productService;

      public ReceptsController(MyAppDBContext context)
      {
        _productService = new ProductService(context);
      }

      [HttpGet]
      public IEnumerable<Product> GetProduct()
      {
        return _productService.GetAllProduct();
      }

      [HttpPost]
      public IActionResult AddProduct([FromBody]Product product)
      {
        if (ModelState.IsValid)
        {
          _productService.CreateProduct(product);
          return Ok(product);
        }
        return BadRequest(ModelState);
      }

      [HttpPut]
      public IActionResult Update([FromBody]Product product)
      {
        if (ModelState.IsValid)
        {
          _productService.UpdateProduct(product);
          return Ok(product);
        }
        return BadRequest(ModelState);
      }

      [HttpDelete]
      [Route("{id}")]
      public async Task<IActionResult> DeleteProduct(int? id)
      {
        if (id != null)
        {
          await _productService.DeleteProductAsync(id);
          return NoContent();
        }
        return NotFound();
      }
    }
  }
}
