using Foundation.ObjectHydrator;
using RoyNetCoreEmptyCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyNetCoreEmptyCommunity
{
  public class Repository
  {
    public static Repository Instance { get; } = new Repository();
    public IList<CustomersDTO> Customers { get; set; }

    public Repository()
    {
      //Escribe datos de ejemplo con este Nuget Instalado
      Hydrator<CustomersDTO> hydrator = new Hydrator<CustomersDTO>();
      Customers = hydrator.GetList(5);

      Random random = new Random();
      Hydrator<OrdersDTO> ordersHydrator = new Hydrator<OrdersDTO>();

      //Rellenar un conjunto de ordenes de orden aleatoria
      foreach (var customer in Customers)
      {
        customer.Orders = ordersHydrator.GetList(random.Next(1, 10));
      }

    }
  }
}

