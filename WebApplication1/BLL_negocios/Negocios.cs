using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_datos;


namespace BLL_negocios
{
    public class Negocios
    {

        public static List<Productos> GetProducts()
        {
            return BaseDatos.GetProducts();
        }
        public static List<Clientes> GetClientes()
        {
            return BaseDatos.GetClientes();
        }
        public static void NewClient(Clientes client)
        {
            BaseDatos.NewClient(client);
        }

        public static void AddCompra(int idcl, int idpr)
        {
            BaseDatos.AddCompra(idcl, idpr);
        }

        public static List<Compra> GetVentas(int IdCliente)
        {
            return BaseDatos.GetVentas(IdCliente);
        }
    }
}
