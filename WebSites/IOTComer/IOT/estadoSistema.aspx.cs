using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_estadoSistema : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button_Click(object sender, EventArgs e)
    {
        //Bloque de las variables que debes poner en los textbox
        string Estatus = "Activo";
        //Fin de bloque
        DateTime fechas = inicio.SelectedDate;
        fechas = fechas.AddHours(Convert.ToInt64(horas.Text));
        fechas = fechas.AddMinutes(Convert.ToInt64(minus.Text));
        DateTime fechas2 = fin.SelectedDate;
        fechas2 = fechas2.AddHours(Convert.ToInt64(horas2.Text));
        fechas2 = fechas2.AddMinutes(Convert.ToInt64(minus2.Text));
        añadir(fechas, fechas2, Estatus);
    }

    public void añadir(DateTime inicial, DateTime final, String Estatus) {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);

        con.Open();

        string updatecmd = "insert into Activador (FechaInicio, FechaFin, Estatus ) values (@FechaInicio,@FechaFin,@Estatus)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@FechaInicio", inicial);
        addCmd.Parameters.AddWithValue("@FechaFin", final);
        addCmd.Parameters.AddWithValue("@Estatus", Estatus);
        addCmd.ExecuteNonQuery();
        con.Close();
        Response.Write("<script language=\"javascript\">alert(\"Registro realizado de forma correcta\");</script>");
        Response.Redirect("~/IOT/Activado");

    }
}