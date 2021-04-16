using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

public partial class IOT_Drools : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected int cliente = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
       
        string usuario = User.Identity.Name;
        int pantalla = 25;
        Permisos permiso = new Permisos();

        if (permiso.returnPermiso(usuario, 0) == "RISC")
        {

        }
        else if (permiso.returnPermiso(usuario, pantalla) == "Reglas de Negocio")
        {

        }
        else
            Response.Redirect("~/IOT/Home");
    }


    protected int consultaide()
    {
        int cliente = 0;
        string id = User.Identity.GetUserId();
        string usuario = User.Identity.Name;
        conn.Open();
        string algo = null;
        string clientes = ("Select u.ID_Cliente from Clientes c, dbo.AspNetUsers u  where c.ID=u.ID_Cliente and u.UserName=@usuario");
        SqlCommand cmd = new SqlCommand(clientes, conn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            algo = Convert.ToString(dr[0]);
        }
        conn.Close();
        cliente = Convert.ToInt32(algo);
        return cliente;
    }

}