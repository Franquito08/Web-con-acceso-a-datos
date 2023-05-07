using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using BLL_negocios;

namespace WebApplication1
{
    public partial class Sistema_de_ventas : System.Web.UI.Page
    {
        List<Productos> listaproductos;
        List<Clientes> listaclientes;
        List<Compra> listaventas;

        //Cada vez que se carga la pagina se cargan los clientes y productos actuales
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetProducts();           
                GetClientes();

            }
        }
     
        //Las siguientes dos funciones son para cargar la lista de clientes y productos desde la bbdd
        private void GetProducts()
        {
            listaproductos = Negocios.GetProducts();
            ddlProducts.DataSource = listaproductos;
            ddlProducts.DataBind();
        }
        private void GetClientes()
        {
            listaclientes = Negocios.GetClientes();
            ddlClientes.DataSource = listaclientes;
            ddlClientes.DataBind();
        }


        //boton que añade al carrito
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (ddlProducts.SelectedIndex >= 0)
            {
                string itemText = ddlClientes.SelectedItem.Text+ "   ----   " + ddlProducts.SelectedItem.Text + "----";
                ListItem item = new ListItem(itemText, ddlProducts.SelectedValue);
                lstCart.Items.Add(item);
                AddCompra();
            }
        }
        private void AddCompra()
        {
            //Primero obtenemos el cliente y el producto seleccionado para cargar la compra
            int clienteId = int.Parse(ddlClientes.SelectedValue);

            int productoId = int.Parse(ddlProducts.SelectedValue);

            //LLama a la funcion para añadir una nueva compra a la bd
            Negocios.AddCompra(clienteId, productoId);
        }
       

        //añadir cliente
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Clientes client = new Clientes();
            client.Nombre = txtUsername.Text;
            client.Apellido = txtUserapellido.Text;
            NewClient(client);
            GetClientes();
            txtUsername.Text = "";
            txtUserapellido.Text = txtUsername.Text;
        }
        private void NewClient(Clientes client)
        {
            Negocios.NewClient(client);
        }

        //finalizar compra
        //Muestra la lista de productos comprados por el cliente seleccionado
        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            listaventas = Negocios.GetVentas(int.Parse(ddlClientes.SelectedValue));
            datagridCompras.DataSource = listaventas;
            datagridCompras.DataBind();

            lstCart.Items.Clear();
            txtUsername.Text = "";
            txtUserapellido.Text = txtUsername.Text;
        }
    }
}