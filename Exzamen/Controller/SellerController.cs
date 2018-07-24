using AppContext;
using BLL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exzamen.Controller
{
    public class SellerController
  {
    [Route("api/products")]
    public class ReceptsController : ControllerBase
    {
      SellerService _sellerService;

      public ReceptsController(MyAppDBContext context)
      {
        _sellerService = new SellerService(context);
      }

      [HttpGet]
      public IEnumerable<Seller> GetSeller()
      {
        return _sellerService.GetAllSeller();
      }

      [HttpPost]
      public IActionResult AddSellert([FromBody]Seller seller)
      {
        if (ModelState.IsValid)
        {
          _sellerService.CreateSeller(seller);
          return Ok(seller);
        }
        return BadRequest(ModelState);
      }

      [HttpPut]
      public IActionResult UpdateSeller([FromBody]Seller seller)
      {
        if (ModelState.IsValid)
        {
          _sellerService.UpdateSeller(seller);
          return Ok(seller);
        }
        return BadRequest(ModelState);
      }

      [HttpDelete]
      [Route("{id}")]
      public async Task<IActionResult> DeleteSellerAsync(int? id)
      {
        if (id != null)
        {
          await _sellerService.DeleteSellerAsync(id);
          return NoContent();
        }
        return NotFound();
      }

      [HttpGet]
      [Route("{id}")]
      public decimal? Premia(int id)
      {
        return _sellerService.Premia(id);
      }
    }
  }
}
