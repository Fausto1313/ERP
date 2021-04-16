using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class peticionDemo : System.Web.UI.Page
{

    protected static string conection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    public SqlConnection con = new SqlConnection(conection);
    protected void Page_Load(object sender, EventArgs e)
    {
        string tipo = string.Empty, riscei = string.Empty, segundo = string.Empty, tercero = string.Empty;
        DateTime sd = DateTime.Now;
        tipo = Request["tipo"];
        riscei = Request["v1"];
        segundo = Request["v2"];
        tercero = Request["v3"];
        switch (tipo) {
            case "corriente":
                insertCorriente(riscei, Convert.ToDouble(segundo), Convert.ToDouble(tercero), sd);
                break;
            case "temperatura":
                insertTemperatura(riscei, Convert.ToDouble(segundo), Convert.ToDouble(tercero), sd);
                break;
            case null:
                Response.Write("False");
                break;
        }
    }

    protected void insertTemperatura(string riscei, double temp, double hum, DateTime fecha) {
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into Sensado(RISCEI, Temperatura, Humedad, Fecha) values (@riscei, @temp," +
            "@hum, @fecha)",con);
        cmd.Parameters.AddWithValue("@riscei",riscei);
        cmd.Parameters.AddWithValue("@temp", temp);
        cmd.Parameters.AddWithValue("@hum", hum);
        cmd.Parameters.AddWithValue("@fecha",fecha);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected void insertCorriente(string riscei, double watts, double amp, DateTime fecha) {
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into Electrico(RISCEI, Watts, Amperaje, Fecha) values (@riscei, @watts," +
            "@amp, @fecha)", con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        cmd.Parameters.AddWithValue("@watts", watts);
        cmd.Parameters.AddWithValue("@amp", amp);
        cmd.Parameters.AddWithValue("@fecha", fecha);
        cmd.ExecuteNonQuery();
        con.Close();
    }
}