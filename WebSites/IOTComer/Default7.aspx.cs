using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default7 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Go_Click(object sender, EventArgs e)
    {
        DateTime fechas = Calendar1.SelectedDate;
        fechas = fechas.AddHours(Convert.ToInt64(horas.Text));
        fechas = fechas.AddMinutes(Convert.ToInt64(minus.Text));
        DateTime fechas2 = Calendar2.SelectedDate;
        fechas2 = fechas2.AddHours(Convert.ToInt64(horas2.Text));
        fechas2 = fechas2.AddMinutes(Convert.ToInt64(minus2.Text));
        insertar(fechas, fechas2);
        Response.Write("<script language=\"javascript\">alert(\"Tu fecha inicial es"+fechas+" tu fecha" +
            "final es"+fechas2+"\");</script>");
    }

    public void insertar(DateTime inicial, DateTime final) {
        //Bloque de las variables que debes poner en los textbox
        string Activador = "pruebaaaaasss";
        string Nombre = "pruebaa";
        string Estatus = "Activo";
        //Fin de bloque
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);

        con.Open();

        string updatecmd = "insert into Activador (cveActivador,Nombre, FechaInicio, FechaFin, Estatus ) values (@cveActivador, @Nombre,@FechaInicio,@FechaFin,@Estatus)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@cveActivador", Activador);
        addCmd.Parameters.AddWithValue("@Nombre", Nombre);
        addCmd.Parameters.AddWithValue("@FechaInicio", inicial);
        addCmd.Parameters.AddWithValue("@FechaFin", final);
        addCmd.Parameters.AddWithValue("@Estatus", Estatus);
        addCmd.ExecuteNonQuery();
        con.Close();
    }
}