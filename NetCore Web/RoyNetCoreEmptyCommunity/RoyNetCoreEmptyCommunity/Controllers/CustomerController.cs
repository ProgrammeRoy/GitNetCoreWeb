using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyNetCoreEmptyCommunity.Controllers
{
  [Route("api/customers")]
  public class CustomerController : Controller
  {
    //[HttpGet("PRUEBA")] Es una manera de enrutar por el método para recibir un getCustomers
    //[HttpGet("1")] Lo uso cuando no hay Rout encima de la clase
    [HttpGet()]

    //Cambio método JssonResult por IActionResult ya que este si contiene a NotFound()
    public IActionResult GetCustomers()
    {
      return new JsonResult(Repository.Instance.Customers);

      //Envía datos personalizados
      //return new JsonResult(new List<object>()
      //{
      //  new{CustomerId = 1, CustomerName = "Anderson" },
      //  new{CustomerId = 2, CustomerName = "Solaris"},
      //  new{nuevo = "Cliente"},
      //  new{probando = 123456}
      //}
      //  );
    }

    //Cambio método JssonResult por IActionResult ya que este si contiene a NotFound()

    [HttpGet("{id}")]
    public IActionResult GetCustomer(int id)
    {
      var result = Repository.Instance.Customers.FirstOrDefault(c => c.Id == id);
      if (result == null)
      {
        return NotFound();
      }
      return new JsonResult(result);
    }





    //Ejemplo para agregar una segunda direccion
    //[HttpGet("2")]
    //public JsonResult GetClients()
    //{
    //  return new JsonResult(new List<object>()
    //  {
    //    new{CustomerId = 3, CustomerName = "Jessica" },
    //    new{CustomerId = 4, CustomerName = "Elian"},
    //    new{nuevo = "Andrea"},
    //    new{probando = 28}
    //  }
    //    );
    //}
  }
}
