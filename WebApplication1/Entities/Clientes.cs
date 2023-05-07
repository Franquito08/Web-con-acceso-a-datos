using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Clientes
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdCliente { get; set; }
        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }
        }
    }

    public class Productos
    {
        public string Descripcion { get; set; }
        public int Costo { get; set; }
        public int IdProducto { get; set; }
    }

    public class Compra
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Producto { get; set; }
        public int Costo { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
