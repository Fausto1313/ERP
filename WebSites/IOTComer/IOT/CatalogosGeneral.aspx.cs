using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class IOT_CatalogosGeneral : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int ide = -1;
        con.Open();
        SqlCommand cmd = new SqlCommand("select ID_Permiso from PermisoRol where ID_Rol = " +
            "(select ID_Rol from AspNetUsers where UserName = @usuario)", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ide = Convert.ToInt32(dr[0]);
           habilitarMenu(ide);
        }
        razon();
        ConsultarIcono();
    }
    protected void habilitarMenu(int id)
    {
           switch (id)
        {
            case 0:
                CatalogosUser.Visible = true;
                CatalogoDispos.Visible = true;
               CatalogoComan.Visible = true;
               CatalogoSeg.Visible = true;
                Restaurant.Visible = true;
                Paginas.Visible = true;
                Temperatura.Visible = true;
                AdminEmpleados.Visible = true;
                CatalogoTelegram.Visible = true;
                CatalogoAdminisUs.Visible = true;
                CatalogoDispos.Visible = true;
                CatDis.Visible = true;
                break;
            case 59:
                CatalogoTelegram.Visible = true;
                break;

            case 60:
                CatalogosUser.Visible = true;
                break;
            case 61:
                CatalogoDispos.Visible = true;
                break;
            case 62:
               CatalogoComan.Visible = true;
                break;
            case 63:
                CatalogoSeg.Visible = true;
                break;
            case 64:
                CatalogoAdminisUs.Visible = true;
                break;
            case 65:
                ConfigPlan.Visible = true;
                break;
            case 66:
               CatDis.Visible = true;
                break;
            case 55:
                Restaurant.Visible = true;
                break;
        }
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