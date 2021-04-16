using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class appTestVrj : System.Web.UI.Page
{
    private SqlConnection con = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=appAndroid;User ID=sa;Password=sa+LANSA!;Pooling=False");
    protected void Page_Load(object sender, EventArgs e)
    {
        string user = null, pass = null;
        user = Request["v1"];
        pass = Request["v2"];
        log(user,pass);
        if (pass == "1")
        {
            //actualizaFin(user);
            Response.Write("End");
        }
        else
            Login(user, pass);
    }

    protected void Login(string user, string pass)
    {
        string aux = comprueba(user, pass);
        if (aux == "true")
        {
            Response.Write(aux);
            //actualizaInicio(user);
        }
        else if (aux == "warning")
            Response.Write(aux);
        else
            Response.Write("false");
    }

    private string comprueba(string user, string pass)
    {
        string stat = null;
        string ses = null;
        string com = null;
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT Password, Sesion FROM Login where UserName=@user", con);
        cmd.Parameters.AddWithValue("@user", user);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            stat = Convert.ToString(dr[0]);
            ses = Convert.ToString(dr[1]);
        }
        con.Close();
        if (stat != null)
        {
            if ((stat == pass) && (ses == "0"))
            {
                com = "true";
            }
            else if ((stat == pass) && (ses == "1"))
                com = "warning";
        }
        else
            com = "false";
        return com;
    }

    private void actualizaInicio(string user)
    {
        con.Open();
        string updateCmd = "UPDATE Login SET Sesion='1' WHERE UserName=@user";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@user", user);
        updatecmd.ExecuteNonQuery();
        con.Close();
    }

    private void actualizaFin(string user)
    {
        con.Open();
        string updateCmd = "UPDATE Login SET Sesion='0' WHERE UserName=@user";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@user", user);
        updatecmd.ExecuteNonQuery();
        con.Close();
    }

    protected void log(string a, string b){
        System.IO.StreamWriter sw = new System.IO.StreamWriter("C:/Pruebas/pruebaLogin.txt");
            sw.WriteLine(a);
            sw.WriteLine(b);
            sw.Close();
    }
}