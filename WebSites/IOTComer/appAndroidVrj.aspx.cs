using Microsoft.AspNet.Identity;
using System;
using System.Data.SqlClient;
using IOTComer;
using System.Configuration;

public partial class appAndroidVrj : System.Web.UI.Page
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string cu = null;
        cu = Request["cu"];

        switch (cu) {
            case "1":
                Login();
                break;
            case "2":
                break;

        }

    }

    //Caso de uso 1
    protected void Login() {
        string usuario = null, password = null;

        usuario = Request["v1"];
        password = Request["v2"];
        // Validate the user password
        var manager = new UserManager();
        ApplicationUser user = manager.Find(usuario, password);
        if (user != null){
            Response.Write(returnCliente(usuario));
        }
        else{
            Response.Write("False");
        }
    }

    protected int returnCliente(string user) {
        int id = 0;
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID_Cliente FROM AspNetUsers where UserName=@user", con);
        cmd.Parameters.AddWithValue("@user", user);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            id = Convert.ToInt32(dr[0]);
        }
        con.Close();
        return id;
    }
}