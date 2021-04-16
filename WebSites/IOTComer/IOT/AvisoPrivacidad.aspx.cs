using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_AvisoPrivacidad : Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        Permisos permiso = new Permisos();
        if (permiso.isCheckedAviso(Context.User.Identity.Name))
            Response.Redirect("~/IOT/Home");
    }

    protected void Acepto(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("update AspNetUsers set AvisoPrivacidad = 'Aceptado' where UserName = @usuario ",con);
        cmd.Parameters.AddWithValue("@usuario", User.Identity.Name);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("~/IOT/Home");
    }

    protected void NoAcepto(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("/Account/Login");
    }

}