using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data.SqlClient;

public partial class pruebaArduino : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        String macID = null, evento = null, estado = null;
        DateTime std = DateTime.Now;
        macID = Request.QueryString["v1"];
        evento = Request.QueryString["v2"];
        estado = Request.QueryString["v3"];
        String es = comprobarD(evento, estado);
        insertarE(macID, es);
        if (estado == "critico")
        {
            enviaCorreo(macID, evento, estado, std);
            insertarD(macID, evento, estado, std);
        }
        else
        {
            insertarD(macID, evento, estado, std);
        }
    }

    protected void insertarD(String macID, String evento, String estado, DateTime std)
    {
        //System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection("Data Source=localhost;Initial Catalog=IOT;User ID=sa;Password=user06");
        SqlConnection sqlConnection1 = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=multicliente;User ID=sa;Password=sa+LANSA!;Pooling=False");

        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "INSERT dispositivos (macID, evento, estado, fecha) VALUES (@macID, @evento, @estado, @std)";
        cmd.Parameters.AddWithValue("@macID", macID);
        cmd.Parameters.AddWithValue("@evento", evento);
        cmd.Parameters.AddWithValue("@estado", estado);
        cmd.Parameters.AddWithValue("@std", std);
        cmd.Connection = sqlConnection1;
        sqlConnection1.Open();
        cmd.ExecuteNonQuery();
        sqlConnection1.Close();
    }

    public void enviaCorreo(String macID, String evento, String estado, DateTime std)
    {
        SmtpClient client = new SmtpClient("smtp.live.com", 587);
        client.Credentials = new System.Net.NetworkCredential("gerard9310@hotmail.com", "assasin_val_9310");
        client.EnableSsl = true;
        MailAddress from = new MailAddress("gerard9310@hotmail.com");
        MailAddress to = new MailAddress("lgverdiguel@risc.com.mx, mmtzros@risc.com.mx, b10n1c09310@gmail.com");
        MailMessage message = new MailMessage(from, to);
        message.Body = "El dispositivo " + macID + " ha presentado una intrusion de nivel " + estado + " \n" +
            "Descripcion del evento: " + " Dispositivo " + evento + " vulnerado\nCon fecha: " + std;
        message.Subject = "Intrusion en: " + evento;
        client.Send(message);
    }

    public Boolean eliminaBasura(DateTime std, String macID, String evento)
    {
        DateTime old = leeA();
        String s = leeD();
        String ev = leeEvt();
        TimeSpan ts = std - old;
        if ((ts.TotalMinutes < 1) && (macID == s) && (evento == ev))
        {
            return false;
        }
        else
            return true;
    }

    public DateTime leeA()
    {
        SqlConnection cn = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=multicliente;User ID=sa;Password=sa+LANSA!;Pooling=False");
        cn.Open();
        DateTime s = DateTime.MinValue;
        SqlCommand cmd = new SqlCommand("SELECT * FROM fechaC", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            s = Convert.ToDateTime(dr[0]);
        }
        cn.Close();
        return s;
    }

    public String leeD()
    {
        SqlConnection cn = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=multicliente;User ID=sa;Password=sa+LANSA!;Pooling=False");
        cn.Open();
        String s = null;
        SqlCommand cmd = new SqlCommand("SELECT * FROM fechaC", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            s = Convert.ToString(dr[2]);
        }
        cn.Close();
        return s;
    }

    public void escribeA(DateTime std, String macID, String evento)
    {
        SqlConnection sqlConnection1 = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=multicliente;User ID=sa;Password=sa+LANSA!;Pooling=False");
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "Update fechaC set fechaAntigua=@std , macID=@macID , evento=@evento WHERE id = 1";
        cmd.Parameters.AddWithValue("@std", std);
        cmd.Parameters.AddWithValue("@macID", macID);
        cmd.Parameters.AddWithValue("@evento", evento);
        cmd.Connection = sqlConnection1;
        sqlConnection1.Open();
        cmd.ExecuteNonQuery();
        sqlConnection1.Close();
    }

    public String leeEvt()
    {
        SqlConnection cn = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=multicliente;User ID=sa;Password=sa+LANSA!;Pooling=False");
        cn.Open();
        String s = null;
        SqlCommand cmd = new SqlCommand("SELECT * FROM fechaC", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            s = Convert.ToString(dr[3]);
        }
        cn.Close();
        return s;
    }

    protected void insertarE(String macID, String evento)
    {
        //System.Data.SqlClient.SqlConnection sqlConnection2 = new System.Data.SqlClient.SqlConnection("Data Source=localhost;Initial Catalog=IOT;User ID=sa;Password=user06");
        SqlConnection sqlConnection2 = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=multicliente;User ID=sa;Password=sa+LANSA!;Pooling=False");

        System.Data.SqlClient.SqlCommand cmd2 = new System.Data.SqlClient.SqlCommand();
        cmd2.CommandType = System.Data.CommandType.Text;
        cmd2.CommandText = "UPDATE estadoD SET evento=@evento where macID=@macID";
        cmd2.Parameters.AddWithValue("@macID", macID);
        cmd2.Parameters.AddWithValue("@evento", evento);
        cmd2.Connection = sqlConnection2;
        sqlConnection2.Open();
        cmd2.ExecuteNonQuery();
        sqlConnection2.Close();
    }

    public String comprobarD(String evento, String estado)
    {
        String dis = null;
        if ((evento == "Leds_Encendidos") || (evento == "Luz_Encendida") || (evento == "Encendido"))
            dis = "ON";
        else if ((evento == "Leds_Apagados") || (evento == "Luz_Apagada") || (evento == "Apagado"))
            dis = "OFF";
        else if ((evento == "Puerta") && (estado == "no_critico"))
            dis = "Cerrada";
        else if ((evento == "Puerta") && (estado == "critico"))
            dis = "Abierta";
        else if ((evento == "Entrada") && (estado == "no_critico"))
            dis = "Desactivado";
        else if ((evento == "Entrada") && (estado == "critico"))
            dis = "Activado";
        else
            dis = "Error de dispositivo";
        return dis;
    }
}