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

public partial class IOT_Bitacoras : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection con = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int ide = -1;
        con.Open();
        SqlCommand cmd = new SqlCommand("select ID_Permiso from PermisoRol where ID_Rol = " +
            "(select ID_Rol from AspNetUsers where UserName = @usuario) and (ID_Permiso between 27 and 60)", con);
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

    protected void habilitarMenu(int id) {
        switch (id) {
            case 27:
                Dispositivos.Visible = true;
                break;
            case 28:
                Ambiente.Visible = true;
                break;
            case 29:
                Sensores.Visible = true;
                break;
            case 30:
                HuellaDactilar.Visible = true;
                break;
            case 31:
                ConteoPersonas.Visible = true;
                break;
            case 32:
                Electrico.Visible = true;
                break;
            case 56:
                ReporteRISC.Visible = true;
                break;
            case 34:
                MapaRastreo.Visible = true;
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