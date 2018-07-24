using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AppContext;
using BLL;
using Entities;
using System.Threading.Tasks;

namespace Exzamen.Controller
{
  [Route("api/products")]
  public class SalesController : ControllerBase
  {
    SalesService _salesService;

    public SalesController(MyAppDBContext context)
    {
      _salesService = new SalesService(context);
    }

    [HttpGet]
    public IEnumerable<Sales> GetProduct()
    {
      return _salesService.GetAllSales();
    }

    [HttpPost]
    public IActionResult AddSales([FromBody]Sales product)
    {
      if (ModelState.IsValid)
      {
        _salesService.CreateSales(product);
        return Ok(product);
      }
      return BadRequest(ModelState);
    }

    [HttpPut]
    public IActionResult Update([FromBody]Sales product)
    {
      if (ModelState.IsValid)
      {
        _salesService.UpdateSales(product);
        return Ok(product);
      }
      return BadRequest(ModelState);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteProductAsync(int? id)
    {
      if (id != null)
      {
        await _salesService.DeleteSalesAsync(id);
        return NoContent();
      }
      return NotFound();
    }

    [HttpGet]
    [Route("{id}")]
    public IEnumerable<Sales> GetSalesBySeller(int id)
    {
      return _salesService.GetSalesBySeller(id);
    }
  }
}
