using System;
using TaskScheduler;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;
using System.IO;

public partial class nuevoAuto : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected string us = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        Permisos permiso = new Permisos();
        int pantalla = 11;
        if (permiso.returnPermiso(usuario, pantalla) == "Programacion de Tareas")
        {
            if (!IsPostBack)
            {
                cargaDARS();   
            }
        }
        else
            Response.Redirect("~/IOT/Home");
        string done = Request["done"];
        if (done == "Hecho")
        {
            estatusOK.Visible = true;
        }
        else if (done == "Error")
            estatusF.Visible = true;
    }

    protected void crearTarea(object sender, EventArgs e)
    {
       
        string nombre = null, dispositivo=null, url=null, accion = string.Empty, nombreR = string.Empty, peticion = string.Empty, noip = string.Empty;
        int hora=0, minutos=0;
        
        dispositivo = DARS.Text;
        accion = Accion.Text;
        
        hora = Convert.ToInt32(horaD.Text);
        minutos = Convert.ToInt32(minD.Text);
        noip = returnNOIP(dispositivo);
        
        if (TareaR.Checked == false)
        {
            peticion = "http://" + noip + "/cronPhp/agregarTarea.php?min=" + minutos + "&hrs=" + hora + "&dias=*&meses=*&dSem=*&comando=localhost/rest.php?riscei=" + dispositivo + ",evento=" + accion;
            try
            {
                url = returnResponseValue(peticion);
                DateTime std = DateTime.Now;
                nombre = std + dispositivo;
                insertarD(nombre, dispositivo, accion, hora, minutos, std, url, "Repetitiva");
                
            }
            catch {
                Response.Redirect("/IOT/nuevoAuto?done=Error");
            }
            Response.Redirect("/IOT/nuevoAuto?done=Hecho");
        }
        else {
            DateTime std = Fecha.SelectedDate;
            std = std.AddHours(Convert.ToDouble(hora));
            std = std.AddMinutes(Convert.ToDouble(minutos));
            nombre = std + dispositivo;
            int dia = 0, mes = 0;
            dia = std.Day;
            mes = std.Month;
            peticion = "http://" + noip + "/cronPhp/agregarTarea.php?min=" + minutos + "&hrs=" + hora + "&dias="+dia+"&meses="+mes+"&dSem=*&comando=localhost/rest.php?riscei=" + dispositivo + ",evento=" + accion;
            try
            {
                url = returnResponseValue(peticion);
                DateTime stdw = DateTime.Now;
                nombre = std + dispositivo;
                insertarD(nombre, dispositivo, accion, hora, minutos, stdw, url, "Unica");
                
            }
            catch
            {
                Response.Redirect("/IOT/nuevoAuto?done=Error");
            }
            Response.Redirect("/IOT/nuevoAuto?done=Hecho");
        }  
    }

    protected string returnResponseValue(string url)
    {
        HttpWebRequest peticion = (HttpWebRequest)WebRequest.Create(url);
        //peticion.KeepAlive= false;
        string json2 = string.Empty;
        //peticion = WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)peticion.GetResponse();
        Stream stream = response.GetResponseStream();
        StreamReader reader = new StreamReader(stream);

        json2 = reader.ReadToEnd();
        reader.Close();
        stream.Close();
        response.Close();
        //peticion.Abort();
        return json2;
    }

    protected string returnNOIP(string riscei) {
        string noip = string.Empty;

        conn.Open();
        SqlCommand cmd = new SqlCommand("select s.NOIP from Sitios s, (select u.Cl_Sitio from DARS d inner join UbiDis u " +
            "on u.Id=d.UbiDis where d.RISCEI = @riscei) as a1 where s.ID = a1.Cl_Sitio ",conn);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
            noip = Convert.ToString(dr[0]);
        return noip;
    }

    protected void insertarD(String nombre, String dispositivo, string evento, int hora, int minutos, DateTime std, string url, string tipo)
    {
        String status = "Activo";
        SqlConnection sqlConnection1 = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text; 
        cmd.CommandText = "INSERT automatizado (Nombre, dispositivo, Evento, Hora, Minuto, Fecha, status, url, Tipo) VALUES (@nombre, @dispositivo,@Evento, @hora, @minutos, @std, @status,@url, @tipo)";
        cmd.Parameters.AddWithValue("@nombre", nombre);
        cmd.Parameters.AddWithValue("@dispositivo", dispositivo);
        cmd.Parameters.AddWithValue("@Evento", evento);
        cmd.Parameters.AddWithValue("@hora", hora);
        cmd.Parameters.AddWithValue("@minutos", minutos);
        cmd.Parameters.AddWithValue("@std", std);
        cmd.Parameters.AddWithValue("@status",status);
        cmd.Parameters.AddWithValue("@url", url);
        cmd.Parameters.AddWithValue("@tipo", tipo);
        cmd.Connection = sqlConnection1;
        sqlConnection1.Open();
        cmd.ExecuteNonQuery();
        sqlConnection1.Close();
    }

    protected void cargaDARS() {
        string usuario = User.Identity.Name;
        conn.Open();
        string query = "select d.Descripcion,  d.RISCEI from  DARS d inner join (select u.ID from UbiDis u where" +
            " u.Cl_Sitio=(select C_Sitio from AspNetUsers where UserName=@usuario)) as a1 on d.UbiDis=a1.Id where (d.Modelo='DAR-BIS-VA/LE/LU/LS' " +
            "or d.Modelo='DAR-BIS-HW')";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.CommandType = CommandType.Text;

        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        DARS.DataTextField = "Descripcion";
        DARS.DataValueField = "RISCEI";
        DARS.DataSource = dr;
        DARS.DataBind();
        if (DARS.Items.Count != 0)
        {
            us = Convert.ToString(DARS.SelectedValue);
            cargaEventos(us);
        }
        else
        {
            DARS.Items.Clear();
            Accion.Items.Clear();
        }
    }

    protected void cargaEventos(string riscei) {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("select Comando, Evento from Eventos where Modelo=(select Modelo from DARS where RISCEI=@riscei)", cn);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        Accion.DataSource = dr;
        Accion.DataTextField = "Evento";
        Accion.DataValueField = "Comando";
        Accion.DataBind();
        if (Accion.Items.Count != 0)
        {
            us = Convert.ToString(Accion.SelectedValue);
        }
        else
        {
            Accion.Items.Clear();
        }
    }

    protected void nomD_SelectedIndexChanged(object sender, EventArgs e)
    {
        us = Convert.ToString(DARS.SelectedValue);
        cargaEventos(us);
    }   

    protected void TareaR_CheckedChanged(object sender, EventArgs e)
    {
        if (TareaR.Checked == true)
        {
            DateTime date = DateTime.Today;
            Fecha.TodaysDate = date;
            Fecha.SelectedDate = Fecha.TodaysDate;
            Fecha.Visible = true;
        }
        else
            Fecha.Visible = false;
    }
}