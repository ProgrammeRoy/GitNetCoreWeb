using Foundation.ObjectHydrator;
using RoyNetCoreEmptyCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Paso 5: Create Repository para inicializar información del cliente

namespace RoyNetCoreEmptyCommunity
{
  public class Repository
  {
    //Paso 5.1: Establecer propiedades
    public static Repository Instance { get; } = new Repository();
    public IList<CustomersDTO> Customers { get; set; }

    public Repository()
    {
      //Paso 5.2: Crear datos de ejemplo con el Nuget Fundation.ObjectHydrator para clientes
      Hydrator<CustomersDTO> hydrator = new Hydrator<CustomersDTO>();
      Customers = hydrator.GetList(5);

      //Paso 7: Crear datos de ejemplo con el Nuget Fundation.ObjectHydrator para ordenes
      Random random = new Random();
      Hydrator<OrdersDTO> ordersHydrator = new Hydrator<OrdersDTO>();

      //Paso 8: Para Customers asignar ordenes aleatoria.
      foreach (var customer in Customers)
      {
        //Número de ordenes aleatoria de 1 al 10
        customer.Orders = ordersHydrator.GetList(random.Next(1, 10));
      }

    }
  }
}

