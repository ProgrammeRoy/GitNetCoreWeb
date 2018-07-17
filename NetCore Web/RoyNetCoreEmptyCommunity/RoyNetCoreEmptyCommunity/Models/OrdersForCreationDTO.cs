using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Crea esta clase para que el cliente no tenga acceso a la principal

namespace RoyNetCoreEmptyCommunity.Models
{
  public class OrdersForCreationDTO
  {
    //Copiamos las propiedades 
    public int OrderId { get; set; }
    public string CustomerId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime RequiredDate { get; set; }
    public DateTime ShippedDate { get; set; }
    public int ShipVia { get; set; }
    public decimal Freight { get; set; }
    public string ShipName { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipRegion { get; set; }
    public string ShipPostalCode { get; set; }
    public string ShipCountry { get; set; }
  }
}
