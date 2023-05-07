using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DLL_datos
{
    //Capa de clases que se comunican directamente con la base de datos
    public class BaseDatos
    {
        //PRODUCTOS--------------------------------------------------------------------------
        public static List<Productos> GetProducts()
        {
            //cargo los productos
            List<Productos> list = new List<Productos>();


            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()))
            {
                //Se abre la conexion a la base y se ejecuta el comando de tipo porceso almacenado
                conn.Open();
                string sql = @"GetProductos";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                //Por ultimo se carga a la lista lo que trae el reader a traves del metodo getEmpleado
                while (reader.Read()) { list.Add(GetProducto(reader)); }


            }

            return list;
        }
        private static Productos GetProducto(SqlDataReader reader)
        {
            //Este metodo crea un objeto empleado y asigna a todas las propiedades lo que trae la tabla
            Productos entitie = new Productos();

            entitie.IdProducto = Convert.ToInt32(reader["Codigo"]);
            entitie.Descripcion = Convert.ToString(reader["Descripcion"]);
            entitie.Costo = Convert.ToInt32(reader["Costo"]);
          

            return entitie;
        }

        //-----------------------------------------------------------------------------------

        //CLIENTES---------------------------------------------------------------------------------------
        public static List<Clientes> GetClientes()
        {
            List<Clientes> list = new List<Clientes>();
            //traigo de la db los clientes
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()))
            {
                //Se abre la conexion a la base y se ejecuta el comando de tipo porceso almacenado
                conn.Open();
                string sql = @"GetClientes";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                //Por ultimo se carga a la lista lo que trae el reader a traves del metodo getEmpleado
                while (reader.Read()) { list.Add(GetCliente(reader)); }


            }
            return list;
        }
        private static Clientes GetCliente(SqlDataReader reader)
        {
            Clientes cliente= new Clientes();

            cliente.IdCliente = Convert.ToInt32(reader["Codigo"]);
            cliente.Nombre = Convert.ToString(reader["Nombre"]);
            cliente.Apellido = Convert.ToString(reader["Apellido"]);

            return cliente;
        }

        //_------------------------------------------------------------------

        //CARGA CLIENTE----------------------------------------------------------------------------

        public static void NewClient(Clientes client)
        {
            //Añado un nuevo cliente ala tabla clientes
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()))
            {
                conn.Open();
                string sql = @"LoadCliente";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Agrega los parametros necesario para ejecutar la consulta sql
                cmd.Parameters.Add("@cNombre", SqlDbType.VarChar).Value = client.Nombre;
                cmd.Parameters.Add("@cApellido", SqlDbType.VarChar).Value = client.Apellido;


                cmd.ExecuteNonQuery();

            }
        }
        //-----------------------------------------------------------------------------------------

        //CARGA COMPRA-----------------------------------------------------------------------
        public static void AddCompra(int IdCLiente, int IdProducto)
        {
            DateTime dateTime= DateTime.Now;
            //aca agrega una nueva compra a la tabla ventas de mi db
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()))
            {
                conn.Open();
                string sql = @"LoadVenta";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Agrega los parametros necesario para ejecutar la consulta sql
                cmd.Parameters.Add("@cIdCliente", SqlDbType.VarChar).Value = IdCLiente;
                cmd.Parameters.Add("@pIdProducto", SqlDbType.VarChar).Value = IdProducto;
                cmd.Parameters.Add("@dFecha", SqlDbType.Date).Value = dateTime;


                cmd.ExecuteNonQuery();

            }

        }
         //-----------------------------------------------------------------------------------------

        //VENTAS-----------------------------------------------------------------------

        public static List<Compra> GetVentas(int IdCliente) 
        {
            List<Compra> compra = new List<Compra>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()))
            {
                //Se abre la conexion a la base y se ejecuta el comando de tipo porceso almacenado
                conn.Open();
                string sql = @"GetVentas";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cIdCliente",SqlDbType.Int).Value= IdCliente;

                SqlDataReader reader = cmd.ExecuteReader();

                //Por ultimo se carga a la lista lo que trae el reader a traves del metodo
                while (reader.Read()) { compra.Add(GetVenta(reader)); }


            }

            return compra;
        }

        private static Compra GetVenta(SqlDataReader reader)
        {
            Compra compra = new Compra();

            compra.Nombre = Convert.ToString(reader["Nombre"]);
            compra.Apellido = Convert.ToString(reader["Apellido"]);
            compra.Producto = Convert.ToString(reader["Descripcion"]);
            compra.Costo = Convert.ToInt32(reader["Costo"]);
            compra.FechaCompra = Convert.ToDateTime(reader["Fecha"]);

            return compra;
        }

    }
}
