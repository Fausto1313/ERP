using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler;

public partial class appTaskAndroidVrj : System.Web.UI.Page
{
    protected static string conection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    public SqlConnection cn = new SqlConnection(conection);

    protected void Page_Load(object sender, EventArgs e)
    {
        string disp = null, evt = null, hr = null, min = null, dir = null, nombre = null;
        short h, m;
        int nom = 0;
        disp = Request["v1"];
        evt = Request["v2"];
        hr = Request["v3"];
        min = Request["v4"];
        dir = direccion(disp, evt);
        DateTime std = DateTime.Now;
        nom = nombreID();
        nombre = nom + disp + hr + min;
        h = short.Parse(hr);
        m = short.Parse(min);
       
        if((insertarD(nombre, disp, evt, h, m, std,dir))&&( crearTarea(nombre, h,m,dir)))
            Response.Write("True");
        else
            Response.Write("False");

    }

    protected string direccion(string dispositivo, string evt)
    {
        string aux = null;
        if ((dispositivo == "LED") && (evt == "ON"))
            aux = "C:/WebSite/tareas/ledsON.vbs";
        else if ((dispositivo == "LED") && (evt == "OFF"))
            aux = "C:/WebSite/tareas/ledsOFF.vbs";
        else if ((dispositivo == "LUZ") && (evt == "ON"))
            aux = "C:/WebSite/tareas/luzON.vbs";
        else if ((dispositivo == "LUZ") && (evt == "OFF"))
            aux = "C:/WebSite/tareas/luzOFF.vbs";
        else if ((dispositivo == "VENTILADOR") && (evt == "ON"))
            aux = "C:/WebSite/tareas/ventiON.vbs";
        else if ((dispositivo == "VENTILADOR") && (evt == "OFF"))
            aux = "C:/WebSite/tareas/ventiOFF.vbs";
        else
            aux = "Error";
        return aux;
    }

    protected bool insertarD(String nombre, String dispositivo, string evt, int hora, int minutos, DateTime std, string url)
    {
        String status = "Activo";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "INSERT automatizado (Nombre, Dispositivo, Evento, Hora, Minuto, Fecha, Status, Url) VALUES (@nombre, @dispositivo, @evento, @hora, @minutos, @std, @status, @url)";
        cmd.Parameters.AddWithValue("@nombre", nombre);
        cmd.Parameters.AddWithValue("@dispositivo", dispositivo);
        cmd.Parameters.AddWithValue("evento", evt);
        cmd.Parameters.AddWithValue("@hora", hora);
        cmd.Parameters.AddWithValue("@minutos", minutos);
        cmd.Parameters.AddWithValue("@std", std);
        cmd.Parameters.AddWithValue("@status", status);
        cmd.Parameters.AddWithValue("@url", url);
        cmd.Connection = cn;
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
        return true;
    }

    protected bool crearTarea(String nombre, short hora, short minutos, string url)
    {
        ScheduledTasks Tareas = new ScheduledTasks();
        Task tarea = Tareas.CreateTask(nombre);
        // archivo que vamos a ejecutar, escribimos la ruta completa
        tarea.ApplicationName = @"" + url + "";
        tarea.Comment = "Tarea de prueba";
        // configurar la cuenta con la que se ejecutara la tarea
        tarea.SetAccountInformation("Administrador", "Risc2018Server?!");
        tarea.Creator = "RISC-IOT";
        // prioridad de la tarea
        tarea.Priority = System.Diagnostics.ProcessPriorityClass.Normal;
        // agregamos el disparador, la tarea se ejecutara diariamente a las 6 y 15 pm
        tarea.Triggers.Add(new DailyTrigger(hora, minutos));
        tarea.Save();
        return true;
    }

    protected int nombreID() {
        int id = 0;
        cn.Open();
        SqlCommand cmd = new SqlCommand("select TOP 1 Id from automatizado order by Id DESC", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            id = Convert.ToInt32(dr[0]);
        }
        cn.Close();
        return id;
    }
}