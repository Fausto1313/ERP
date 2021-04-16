using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_Default : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection con = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 35;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) != "Planos")
        {
            mapas.Visible = false;
            mapas2.Visible = false;
        }
        razon();
        ConsultarIcono();
    }

     

    protected void razon()
    {
        
        string usuario = User.Identity.Name;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand("select RazonSocial from Clientes where ID = (select ID_cliente from AspNetUsers where UserName = @usuario)", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            cli.Text = Convert.ToString(dr[0]);
        }
        con.Close();
    }


    protected void ConsultarIcono()
    {
        string usuario = Context.User.Identity.GetUserName();
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT icono FROM Clientes Where ID=(select ID_Cliente from AspNetUsers where username = @usuario)";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Connection = con;
        con.Open();
        DataTable imagenesBD = new DataTable();

        imagenesBD.Load(cmd.ExecuteReader());
        Repeater1.DataSource = imagenesBD;
        Repeater1.DataBind();
        con.Close();
    }



}