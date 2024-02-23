using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductosDB.Entities
{
    public class Productos
    {
      public string Id {get; set;}
      public string Nombre {get; set;}
      public string TipoProductoId {get; set;}
      public string Proveedor {get; set;}
      public string CreadoEl {get; set;}
      public string CreadoPor {get; set;}
      public string ModificadoEn {get; set;}
      public string ModificadoPor {get; set;}
    }
}