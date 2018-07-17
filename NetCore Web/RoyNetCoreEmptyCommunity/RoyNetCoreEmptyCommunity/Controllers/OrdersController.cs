using Microsoft.AspNetCore.Mvc;
using RoyNetCoreEmptyCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyNetCoreEmptyCommunity.Controllers
{
  //api/customers/23/orders/1

  [Route("api/customers")]
  public class OrdersController : Controller
  {
    [HttpGet("{customerId}/orders")]
    public IActionResult GetOrders(int customerId)
    {
      //busca a cliente
      var customer = Repository.Instance.Customers.FirstOrDefault(c => c.Id == customerId);
      if(customer == null)
      {
        return NotFound();
      }
      return Ok(customer.Orders);
    }

    [HttpGet("{customerId}/orders/{id}", Name = "GetOrder")]
    public IActionResult GetOrder(int customerId, int id)
    {
      var customer = Repository.Instance.Customers.FirstOrDefault(c => c.Id == customerId);
      if (customer == null)
      {
        return NotFound();
      }

      //Busca el order id
      var order = customer.Orders.FirstOrDefault(o => o.OrderId == id);
      if (order == null)
      {
        return NotFound();
      }
      return Ok(order);
    }
    //Colocar HttpPost cuando va a ser una nueva creación
    [HttpPost("{CustomerId}/orders")]
    //Creación de un nuevo registro con OrdersController
    public IActionResult CreateOrder(int customerId, [FromBody] OrdersForCreationDTO order)
    {
      if (order == null)
      {
        return BadRequest();
      }

      //Busca ClienteId
      var customer = Repository.Instance.Customers.FirstOrDefault(c => c.Id == customerId);
      if (customer == null)
      {
        return NotFound();
      }

      //Retorna Id más alto
      var maxOrderId = Repository.Instance.Customers.SelectMany(c => c.Orders).Max(o => o.OrderId);

      //Asignar propiedades
      var finalOrder = new OrdersDTO()
      {
        OrderId = maxOrderId++,
        CustomerId = order.CustomerId,
        EmployeeId = order.EmployeeId,
        OrderDate = order.OrderDate,
        RequiredDate = order.RequiredDate,
        ShippedDate = order.ShippedDate,
        ShipVia = order.ShipVia,
        Freight = order.Freight,
        ShipName = order.ShipName,
        ShipAddress = order.ShipAddress,
        ShipCity = order.ShipCity,
        ShipRegion = order.ShipRegion,
        ShipPostalCode = order.ShipPostalCode,
        ShipCountry = order.ShipCountry
      };
      customer.Orders.Add(finalOrder);

      //retornamos el nuevo recurso creado
      return CreatedAtRoute("GetOrder", new { customerId = customerId, id = finalOrder.OrderId },finalOrder );


    }
  }
}
