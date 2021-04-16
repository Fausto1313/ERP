/********************************************************************************************
Desarrollado por: Luis Gerardo Verdiguel
Version: 1.0
Descripción: Pagina que recibe peticiones correspondientes a los eventos realizados por
            los sensores de temperatura situados en los refrigeradores, así como la apertura
            de puertas y la falta de corriente eléctrica.
Optimizado para: Bioskinco
Fecha: 04/01/2018 
 ********************************************************************************************/
using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;

public partial class congeladorSensado : System.Web.UI.Page
{
    //Conector de BD
    protected static string conection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    public SqlConnection cn = new SqlConnection(conection);

    //Clase que al cargarse procesa las peticiones 
    protected void Page_Load(object sender, EventArgs e)
    {
        String tempe = null, estado = null, riscei = null, horas = null, fecha2 = null, humeda=null;
        double temp, humedad;
        DateTime std = DateTime.Now;
        DateTime fecha;
        riscei = Request.QueryString["v1"];
        tempe = Request.QueryString["v2"];
        humeda = Request.QueryString["v4"];
        estado = Request.QueryString["v3"];
        fecha = std.Date;
        fecha2 = std.ToShortDateString();
        int cli = cliente(riscei);
        horas = Convert.ToString(std.Hour) + ":" + Convert.ToString(std.Minute);
        //ArrayList umb = umbrales(riscei);
        int umbramenor=0, umbramayor=0;
        umbramenor= umbralMenor1(riscei);
        umbramayor= umbralMayor1(riscei);
        humedad = Convert.ToDouble(humeda);
        if (estado == "Sensado")
        {
            
            temp = Convert.ToDouble(tempe);
            if ((temp < umbramenor) || (temp > umbramayor))
            {
                insertTemp(riscei, fecha, horas, temp, humedad, cli);
                telegramTemp(riscei, fecha2, horas, temp, cli);
            }
            else
                insertTemp(riscei, fecha, horas, temp, humedad, cli);
        }
        else if ((estado == "Critico")||(estado == "No_Critico")){
            if(estado=="Critico"){
                insertEstado(riscei, tempe, estado, std, cli);
                telegramElec(riscei, tempe, estado, std, cli);
            }
            else
                insertEstado(riscei, tempe, estado, std, cli);
        }

    }
    //Insercion en la BD de los registros de temperatura
    protected void insertTemp(string id, DateTime fecha, string hora, double temp, double hum, int cliente)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "INSERT Sensado (RISCEI, Fecha, Hora, Temperatura, Humedad, ID_Cliente) VALUES (@RISCEI, @Fecha, @Hora, @Temperatura, @Humedad, @Cliente)";
        cmd.Parameters.AddWithValue("@RISCEI", id);
        cmd.Parameters.AddWithValue("@Fecha", fecha);
        cmd.Parameters.AddWithValue("@Hora", hora);
        cmd.Parameters.AddWithValue("@Temperatura", temp);
        cmd.Parameters.AddWithValue("@Humedad", hum);
        cmd.Parameters.AddWithValue("@cliente", cliente);
        cmd.Connection = cn;
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
    }
    //Insercion en la BD de los registros de apertura y corte de energía
    protected void insertEstado(string riscei, string evento, string estado, DateTime fecha, int cliente)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "INSERT ControlSensado (RISCEI, Evento, Estado, Fecha, ID_Cliente) VALUES (@RISCEI, @Evento, @Estado, @Fecha, @Cliente)";
        cmd.Parameters.AddWithValue("@RISCEI", riscei);
        cmd.Parameters.AddWithValue("@Evento", evento);
        cmd.Parameters.AddWithValue("@Estado", estado);
        cmd.Parameters.AddWithValue("@Fecha", fecha);
        cmd.Parameters.AddWithValue("@Cliente", cliente);
        cmd.Connection = cn;
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
    }
    //Envio de mensajes de Telegram cuando hay cambios de termperatura de acuerdo a los umbrales
    protected void telegramTemp(String macID, string fecha, string hora, double temp, int cliente)
    {
        ArrayList c = new ArrayList();
        int q = 0;
        SqlConnection cn = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=multicliente;User ID=sa;Password=sa+LANSA!;Pooling=False");
        cn.Open();
        DateTime s = DateTime.MinValue;
        SqlCommand cmd = new SqlCommand("SELECT ID FROM Telegram where ID_Cliente=@cliente", cn);
        cmd.Parameters.AddWithValue("@cliente", cliente);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            c.Add(Convert.ToString(dr[0]));
            q++;
        }
        cn.Close();
        string token = "465931710:AAHAY4-x6ZozrHPWkLfy9t7UUrcJX6Q61bw";
        //string[] id = { "485219307", "401967737", "462385749" };
        string mensaje = "El dispositivo " + macID + " ha presentado una variación crítica" +
            " de temperatura de " + temp + "°C\n" +
            "El día " + fecha + " a las " + hora;
        for (int i = 0; i < q; i++)
        {
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + c[i] + "&text=" + mensaje);
            Peticion.GetResponse();
        }
    }
    //Consulta del ID del cliente
    public int cliente(string riscei)
    {
        cn.Open();
        int s = 0;
        SqlCommand cmd = new SqlCommand("SELECT ID_Cliente FROM DARS where RISCEI=@riscei", cn);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            s = Convert.ToInt32(dr[0]);
        }
        cn.Close();
        return s;
    }
    //Envio de mensajes de Telegram cuando se presenta un corte de energia o una apertura
    public void telegramElec(String macID, String evento, String estado, DateTime std, int cliente)
    {
        ArrayList c = new ArrayList();
        int q = 0;
        cn.Open();
        DateTime s = DateTime.MinValue;
        SqlCommand cmd = new SqlCommand("SELECT ID FROM Telegram where ID_Cliente=@cliente", cn);
        cmd.Parameters.AddWithValue("@cliente", cliente);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            c.Add(Convert.ToString(dr[0]));
            q++;
        }
        cn.Close();
        string token = "465931710:AAHAY4-x6ZozrHPWkLfy9t7UUrcJX6Q61bw";
        //string[] id = { "485219307", "401967737", "462385749" };
        string mensaje = "El dispositivo " + macID + " ha presentado una apertura y/o interrupcion de energia \n" +
            "Descripcion del evento: " + evento + " \nCon fecha: " + std;
        for (int i = 0; i < q; i++)
        {
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + c[i] + "&text=" + mensaje);
            Peticion.GetResponse();
        }
    }

    protected int umbralMayor1(string rise){
        int a=0;
        cn.Open();
        DateTime s = DateTime.MinValue;
        SqlCommand cmd = new SqlCommand("SELECT TOP 1 UmbralMayor FROM Umbrales where RISCEI=@riscei ORDER BY Id DESC", cn);
        cmd.Parameters.AddWithValue("@riscei", rise);
        SqlDataReader dr = cmd.ExecuteReader();
        if(dr.Read())
        {
           a=Convert.ToInt32(dr[0]);
        }
        cn.Close();
        return a;
    }

     protected int umbralMenor1(string rise){
        int a=0;
        cn.Open();
        DateTime s = DateTime.MinValue;
        SqlCommand cmd = new SqlCommand("SELECT TOP 1 UmbralMenor FROM Umbrales where RISCEI=@riscei ORDER BY Id DESC", cn);
        cmd.Parameters.AddWithValue("@riscei", rise);
        SqlDataReader dr = cmd.ExecuteReader();
        if(dr.Read())
        {
           a=Convert.ToInt32(dr[0]);
        }
        cn.Close();
        return a;
    }
}