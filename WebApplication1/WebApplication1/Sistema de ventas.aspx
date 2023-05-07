<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sistema de ventas.aspx.cs" Inherits="WebApplication1.Sistema_de_ventas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
            
<body>
    <form id="form1" runat="server">
        <div dir="ltr">
            <h1>Sistema de Ventas</h1>
            <h3>Agregar cliente</h3>
            <label for="txtUsername">Nombre:</label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br /><br />
            <label for="txtUserapellido">Apellido:</label>
            <asp:TextBox ID="txtUserapellido" runat="server"></asp:TextBox>
            <br /> <br />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            <br />
            <h3>Clientes</h3>
            <asp:DropDownList ID="ddlClientes" runat="server" DataTextField="NombreCompleto" DataValueField="IdCliente" ></asp:DropDownList>

            <br /><br />
            <h3>Su compra</h3>
            <label for="ddlProducts">Productos disponibles:</label>
            <asp:DropDownList ID="ddlProducts" runat="server" DataTextField="Descripcion" DataValueField="IdProducto"></asp:DropDownList>
            <br /><br />
            <asp:Button ID="btnAddToCart" runat="server" Text="Agregar al carrito" OnClick="btnAddToCart_Click" />
            <br /><br />
            <asp:Label for="lblCart" runat="server" Text="Carrito de compras:"></asp:Label>
            <br /><br />
            <asp:ListBox ID="lstCart" runat="server" Height="100px" Width="400px"></asp:ListBox>
            <br /><br />
            <asp:Button ID="btnCheckout" runat="server" Text="Finalizar compra" OnClick="btnCheckout_Click" />
            <br /><br />
            <h3>Lista de compras por cliente</h3>
            <br /><br />
            <asp:DataGrid ID="datagridCompras" runat="server" AutoGenerateColumns="False" CellPadding="7" GridLines="Horizontal" HorizontalAlign="Center">
                <Columns>
                    <asp:BoundColumn DataField="Nombre" HeaderText="Nombre" ReadOnly="True" />
                    <asp:BoundColumn DataField="Apellido" HeaderText="Apellido" ReadOnly="True" />
                    <asp:BoundColumn DataField="Producto" HeaderText="Producto" ReadOnly="True" />
                    <asp:BoundColumn DataField="Costo" HeaderText="Costo" ReadOnly="True" />
                    <asp:BoundColumn DataField="FechaCompra" HeaderText="Fecha de compra" ReadOnly="True" />
                </Columns>
            </asp:DataGrid>

        </div>
        <div><br /><br /></div>
    </form>
</body>
</html>
