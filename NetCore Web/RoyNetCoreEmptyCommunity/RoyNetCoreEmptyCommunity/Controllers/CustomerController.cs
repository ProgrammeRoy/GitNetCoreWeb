using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Paso 3: Add Clase Controlador
//Un controlador realiza operaciones hacia una base u origen de datos que va a solicitar datos y va a recibirlos del conjunto de datos

namespace RoyNetCoreEmptyCommunity.Controllers
{
  //Establece un ruteo general(a nivel de controlador) para no tener que asignar un ruteo a cada método
  [Route("api/customers")]
  //Paso 3.1: Heredar de Controller
  public class CustomerController : Controller
  {
    //Paso 3.3: Establecer Ruteo por Atributo [HttpGet()]
    //[HttpGet("PRUEBA")] Es una manera de enrutar por el método para recibir un getCustomers() general
    //[HttpGet()] Es una manera de enrutar cuando se quiere seleccionar alguna opción específica y se añade un [HttpGet("{valorBuscado}")] en la cabecera del método que busca
    [HttpGet()]

    //Paso 3.2: Create método que retorne lista de clientes 
    //Cambio método JssonResult por IActionResult ya que este es general y contiene a NotFound()
    public IActionResult GetCustomers()
    {
      //Retorna una lista de Clientes, para esto se agregó el método Repository
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

    //Establece Ruteo por Atributo específico [HttpGet("{  }")]
    [HttpGet("{id}")]
    //Cambio método JssonResult por IActionResult ya que este es general y contiene a NotFound()
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
