using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class peticionTemperatura : System.Web.UI.Page
{
    protected static string conection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    public SqlConnection cn = new SqlConnection(conection);
    protected void Page_Load(object sender, EventArgs e)
    {
        string tempe = null, riscei = null, humeda = null;
        double temp, humedad;
        DateTime std = DateTime.Now;
        riscei = Request["v1"];
        tempe = Request["v2"];
        humeda = Request["v3"];
        int umbramenor = 0, umbramayor = 0;
        umbramenor = umbralMenor1(riscei);
        umbramayor = umbralMayor1(riscei);
        humedad = Convert.ToDouble(humeda);
        temp = Convert.ToDouble(tempe);
        if ((temp < umbramenor) || (temp > umbramayor))
        {
            insertTemp(riscei, std, temp, humedad);
            telegramTemp(riscei, temp,std);
        }
        else
            insertTemp(riscei, std, temp, humedad);
    }

    protected void telegramTemp(string riscei, double temp, DateTime fecha) {
        string canal = string.Empty, descripcion = string.Empty;
        cn.Open();
        SqlCommand cmd = new SqlCommand("select d.Descripcion, u.CanalTelegram from DARS d, Umbrales u " +
            "where d.RISCEI = @riscei and u.RISCEI = @riscei", cn);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            descripcion = Convert.ToString(dr[0]);
            canal = Convert.ToString(dr[1]);
        }
        string token = "465931710:AAHAY4-x6ZozrHPWkLfy9t7UUrcJX6Q61bw";
        //string[] id = { "485219307", "401967737", "462385749" };
        string mensaje = "El dispositivo " + descripcion + " ha presentado una variación crítica" +
            " de temperatura de " + temp + "°C\n" +
            "Evento con fecha " + fecha;
        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + canal + "&text=" + mensaje);
        Peticion.GetResponse();
    }

    //protected void insertEstado(string riscei, string evento, string estado, DateTime fecha)
    //{
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.CommandType = System.Data.CommandType.Text;
    //    cmd.CommandText = "INSERT Dispositivos (RISCEI, Evento, Estado, Fecha) VALUES (@RISCEI, @Evento, @Estado, @Fecha)";
    //    cmd.Parameters.AddWithValue("@RISCEI", riscei);
    //    cmd.Parameters.AddWithValue("@Evento", evento);
    //    cmd.Parameters.AddWithValue("@Estado", estado);
    //    cmd.Parameters.AddWithValue("@Fecha", fecha);
    //    cmd.Connection = cn;
    //    cn.Open();
    //    cmd.ExecuteNonQuery();
    //    cn.Close();
    //}

    protected void insertTemp(string riscei, DateTime fecha, double temp, double hum)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "INSERT Sensado (RISCEI, Fecha, Temperatura, Humedad) VALUES (@RISCEI, @Fecha, @Temperatura, @Humedad)";
        cmd.Parameters.AddWithValue("@RISCEI", riscei);
        cmd.Parameters.AddWithValue("@Fecha", fecha);
        cmd.Parameters.AddWithValue("@Temperatura", temp);
        cmd.Parameters.AddWithValue("@Humedad", hum);
        cmd.Connection = cn;
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
    }

    protected int umbralMayor1(string rise)
    {
        int a = 0;
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT UmbralMayor FROM Umbrales where RISCEI=@riscei", cn);
        cmd.Parameters.AddWithValue("@riscei", rise);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            a = Convert.ToInt32(dr[0]);
        }
        cn.Close();
        return a;
    }

    protected int umbralMenor1(string rise)
    {
        int a = 0;
        cn.Open();
        DateTime s = DateTime.MinValue;
        SqlCommand cmd = new SqlCommand("SELECT UmbralMenor FROM Umbrales where RISCEI=@riscei", cn);
        cmd.Parameters.AddWithValue("@riscei", rise);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            a = Convert.ToInt32(dr[0]);
        }
        cn.Close();
        return a;
    }
}