using IOTComer;
using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using TaskScheduler;
using System.Data;
using System.Collections;

public partial class ControlService : System.Web.UI.Page
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string cu = null;
        cu = Request["cu"];
        switch (cu)
        {
            //Login
            case "1":
                LoginTemp();
                break;
            //Logout
            case "2":
                //****** Logout();
                //Comandos();
                break;
            //Dispositivos usuario
            case "3":
                returnDispositivos();
                break;
            case "3b":
                returnCommand();
                break;
            //Registrar comando de voz
            case "4":
                insertCommand();
                break;
            //Cambio de password
            case "5":
                break;
            //Comando de voz
            case "6":
                doCommand();
                break;
            //Registrar tarea
            case "7":
                Tasks();
                break;
            //Activar seguridad
            case "8":
                updateSecurity();
                break;
            //Desactivar seguridad
            case "9":
                updateSecurity();
                break;
            //Registrar evento
            case "10":
                break;
            //Activar sistema manual
            case "11":
                doCommandManual();
                break;
            //Quitar tarea
            case "12":
                break;
            //Buscar comandos por dispositivo
            case "13":
                returnCommandsList();
                break;
            case "14":
                Login();
                break;
            /*--------------------------------------------------------------------------------------------------
           -----------------------------------SECCION DE FUNCIONES ADMINISTRADOR--------------------------------
           --------------------------------------------------------------------------------------------------*/
           //LOGIN Administrador
            case "ad1":
                break;
            case "ad2":
                break;
            case "ad3":
                break;

        }
    }

    /*--------------------------------------------------------------------------------------------------
   -----------------------------------SECCION DE FUNCIONES PRINCIPALES----------------------------------
   --------------------------------------------------------------------------------------------------*/

    //Login de la app
    protected void Login()
    {
        string usuario = null, password = null;
        string seg = string.Empty;
        usuario = Request["usuario"];
        password = Request["pwd"];
        // Validate the user password
        var manager = new UserManager();
        ApplicationUser user = manager.Find(usuario, password);
        if (user != null)
        {
            seg = ReturnCliente(usuario);
            if (seg == "")
                Response.Write("Desactivado");
            else
                Response.Write(seg);
        }
        else
        {
            Response.Write("False");
        }
    }

    protected void LoginTemp()
    {
        string usuario = null, password = null;

        usuario = Request["usuario"];
        password = Request["pwd"];
        // Validate the user password
        var manager = new UserManager();
        ApplicationUser user = manager.Find(usuario, password);
        if (user != null)
        {
            Response.Write(ReturnClientes(usuario));
        }
        else
        {
            Response.Write("False");
        }
    }

    //Logout
    protected void Logout()
    {

    }

    //Obtener dispositivos 
    protected void returnDispositivos()
    {
        string usuario = string.Empty;
        string res = String.Empty;
        usuario = Request["usuario"];
        res = ReturnDispositivos(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(res);
    }

    protected void returnCommand()
    {
        string usuario = string.Empty, dis = string.Empty;
        string res = String.Empty;
        usuario = Request["usuario"];
        dis = Request["dis"];
        res = ReturnComandos(usuario, dis);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(res);
    }

    protected void insertCommand()
    {
        string usuario = string.Empty, dis = string.Empty, accion = string.Empty, comando = string.Empty;
        usuario = Request["user"];
        dis = Request["dispositivo"];
        accion = Request["accion"];
        comando = Request["texto"];
        if (insertCommandSQL(usuario, dis, accion, comando))
            Response.Write("True");
        else
            Response.Write("False");
    }

    protected void doCommand()
    {
        string usuario = string.Empty, comando = string.Empty;
        usuario = Request["user"];
        comando = Request["comando"];
        string[] peticion = ReturnComm(usuario, comando);
        try
        {
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("http://addar.mx:8082/peticion.php?v1=" + peticion[0] + "&v2=" + peticion[1] + "&v3=" + peticion[2]);
            Peticion.GetResponseAsync();
            Response.Write("True");
        }
        catch
        {
            Response.Write("False");
        }
    }

    protected void doCommandManual()
    {
        string usuario = string.Empty, dispositivo = string.Empty, accion = string.Empty;
        usuario = Request["user"];
        dispositivo = Request["dispositivo"];
        accion = Request["accion"];
        string[] peticion = ReturnComm2(usuario, dispositivo);
        try
        {
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("http://addar.mx:8082/peticion.php?v1=" + peticion[0] + "&v2=" + peticion[1] + "&v3=" + accion);
            Peticion.GetResponseAsync();
            Response.Write("True");

        }
        catch
        {
            Response.Write("False");
        }
    }

    protected void Tasks() {
        string nombre = string.Empty, dispositivo = string.Empty, url = string.Empty, accion = string.Empty, nombreR = string.Empty, usuario = string.Empty;
        string i = string.Empty, m = string.Empty;
        int hora = 0, minutos = 0;
        short hora2, min2;
        DateTime std = DateTime.Now;
        usuario = Request["user"];
        dispositivo = Request["dispositivo"];
        dispositivo = returnRiscei(dispositivo, usuario);
        accion = Request["accion"];
        nombre = std + dispositivo;
        i = Request["hora"];
        m = Request["minuto"];
        hora2 = short.Parse(i);
        min2 = short.Parse(m);

        url = direccion(dispositivo, accion);
        if (url == "Error")
        {
            Response.Write("False");
        }
        else
        {
            insertarD(nombre, dispositivo, accion, hora2, min2, std, url);
            nombreR = hora + minutos + dispositivo + accion;
            crearTarea(nombreR, hora2, min2, url);
            Response.Write("True");
        }

    }

    protected string direccion(string dispositivo, string accion)
    {
        string aux = null;
        con.Open();
        SqlCommand cmd = new SqlCommand("select URL from BAT where RISCEI=@dis and Comando =@accion", con);
        cmd.Parameters.AddWithValue("@dis", dispositivo);
        cmd.Parameters.AddWithValue("@accion", accion);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            aux = Convert.ToString(dr[0]);
        }
        else
            aux = "Error";
        con.Close();
        return aux;
    }

    protected void returnCommandsList()
    {
        string dispositivo = string.Empty, usuario = string.Empty;
        string res = string.Empty;
        usuario = Request["usuario"];
        dispositivo = Request["dispositivo"];
        res = searchCommands(usuario, dispositivo);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(res);
    }

    protected void updateSecurity()
    {
        string usuario = string.Empty, estatus = string.Empty;

        usuario = Request["usuario"];
        estatus = Request["seguridad"];
        if (changeSecurity(usuario, estatus)) {
            Response.Write("True");
            sendTelegramSec(usuario, estatus);
        }
            
        else
            Response.Write("False");

    }

    protected void sendTelegramSec(string usuario, string seguridad)
    {
        ArrayList lista = new ArrayList();
        con.Open();
        SqlCommand cmd = new SqlCommand("select ID from Telegram where ID_Cliente = (select ID_Cliente from AspNetUsers where UserName = @user)", con);
        cmd.Parameters.AddWithValue("@user", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            lista.Add(Convert.ToString(dr[0]));
        }
        con.Close();

        string token = "465931710:AAHAY4-x6ZozrHPWkLfy9t7UUrcJX6Q61bw";
        //string[] id = { "485219307", "401967737", "462385749" };
        string mensaje = "El usuario " + usuario + " ha colocado el sistema en estado " + seguridad;

        for (int i = 0; i < lista.Count; i++)
        {
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + lista[i] + "&text=" + mensaje);
            Peticion.GetResponse();
        }
    }

    /*--------------------------------------------------------------------------------------------------
   -----------------------------------------SECCION DE CONSULTAS---------------------------------------
   --------------------------------------------------------------------------------------------------*/
    //Consulta de clientes a partir del nombre de usuarios
    protected string ReturnCliente(string user)
    {
        string id = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select Seguridad from Sitios where ID=(select C_Sitio from AspNetUsers where UserName=@user)", con);
        cmd.Parameters.AddWithValue("@user", user);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            id = Convert.ToString(dr[0]);
        }
        con.Close();
        return id;
    }

    protected int ReturnClientes(string user)
    {
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

    protected string returnRiscei2(string usuario, string desc)
    {
        string riscei = string.Empty;

        con.Open();
        SqlCommand cmd = new SqlCommand("select d.RISCEI from dars d, Sitios s where s.ID=(select C_Sitio from AspNetUsers where UserName=@user)" +
            " and d.Descripcion=@desc", con);
        cmd.Parameters.AddWithValue("@user", usuario);
        cmd.Parameters.AddWithValue("@desc", desc);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            riscei = Convert.ToString(dr[0]);
        }
        con.Close();
        return riscei;

    }

    protected bool insertCommandSQL(string usuario, string desc, string accion, string comando)
    {
        bool done = false;

        string riscei = returnRiscei(desc, usuario);
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT Comandos (Comando, Accion, RISCEI) VALUES (@comando, @Accion, @RISCEI)";
            cmd.Parameters.AddWithValue("@comando", comando);
            cmd.Parameters.AddWithValue("@Accion", accion);
            cmd.Parameters.AddWithValue("RISCEI", riscei);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            done = true;
        }
        catch
        {
        }
        return done;
    }

    protected string returnRiscei(string desc, string user)
    {
        string riscei = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select d.RISCEI from DARS d inner join (select ID from UbiDis where Cl_Sitio=(select Cl_Sitio from AspNetUsers" +
            " where UserName=@user)) as a1 on a1.Id=d.UbiDis where d.Descripcion = @desc", con);
        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@desc", desc);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            riscei = Convert.ToString(dr[0]);
        }
        con.Close();
        return riscei;
    }

    protected string[] ReturnComm(string user, string comando)
    {
        string[] com = new string[3];
        con.Open();
        SqlCommand cmd = new SqlCommand("select s.NOIP, c.RISCEI, c.Accion from Comandos c, Sitios s where Comando = " +
            "@comando and s.ID = (select C_Sitio from AspNetUsers where UserName=@user)", con);
        cmd.Parameters.AddWithValue("@comando", comando);
        cmd.Parameters.AddWithValue("@user", user);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            com[0] = Convert.ToString(dr[0]);
            com[1] = Convert.ToString(dr[1]);
            com[2] = Convert.ToString(dr[2]);
        }
        con.Close();
        return com;
    }

    protected string[] ReturnComm2(string user, string desc)
    {
        string[] com = new string[2];
        con.Open();
        SqlCommand cmd = new SqlCommand("select s.NOIP, d.RISCEI from dars d, Sitios s where s.ID=(select C_Sitio from " +
            "AspNetUsers where UserName=@user) and d.Descripcion=@desc", con);
        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@desc", desc);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            com[0] = Convert.ToString(dr[0]);
            com[1] = Convert.ToString(dr[1]);
        }
        con.Close();
        return com;
    }

    //FUncion que regresa los dispositivos por cliente y por sitio de usuario logueado
    protected string ReturnDispositivos(string user)
    {
        string json = String.Empty;
        List<Disposi> dispositivo = new List<Disposi>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select d.Descripcion from DARS d inner join UbiDis UD on d.UbiDis=UD.Id where UD.Cl_Sitio=(select C_Sitio " +
            "from AspNetUsers where UserName=@user) and (d.Modelo='DAR-BIS-LU/VA/LE' or d.Modelo='DAR-BIS-HW')", con);
        cmd.Parameters.AddWithValue("@user", user);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Disposi Object = new Disposi();
            Object.nombre = Convert.ToString(dr[0]);
            dispositivo.Add(Object);
        }
        con.Close();
        json = JsonConvert.SerializeObject(dispositivo);
        return json;
    }

    //Funcion que regresa JSON con Comandos del dispositivo seleccionado
    protected string ReturnComandos(string user, string des)
    {
        string json = string.Empty;
        List<comando> coma = new List<comando>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select Comando from Eventos where Modelo=(select d.modelo from dars d inner join " +
            "(select ID from UbiDis where Cl_Sitio=(select Cl_Sitio from AspNetUsers where UserName=@user)) as a1 on d.UbiDis=a1.ID " +
            "where d.Descripcion=@desc)", con);
        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@desc", des);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            comando Object = new comando();
            Object.accion = Convert.ToString(dr[0]);
            coma.Add(Object);
        }
        con.Close();
        json = JsonConvert.SerializeObject(coma);
        return json;
    }

    protected string searchCommands(string user, string des)
    {
        string json = string.Empty;
        List<acciones> ac = new List<acciones>();
        con.Open();
        SqlCommand cmd = new SqlCommand(" select com.Comando, com.Accion from Comandos com inner join (select d.RISCEI from dars d," +
            " Sitios s where s.ID=(select C_Sitio from AspNetUsers where UserName=@user) and d.Descripcion=@desc) " +
            "as a1 on a1.RISCEI= com.RISCEI", con);
        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@desc", des);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            acciones Object = new acciones();
            Object.comando = Convert.ToString(dr[0]);
            Object.accion = Convert.ToString(dr[1]);
            ac.Add(Object);
        }
        con.Close();
        json = JsonConvert.SerializeObject(ac);
        return json;
    }

    protected bool changeSecurity(string user, string estatus)
    {
        bool done = false;
        DateTime fecha = DateTime.Now;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update Sitios set Seguridad=@estatus where ID=(select C_Sitio from AspNetUsers where UserName=@user)";
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@estatus", estatus);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "insert into Activador (Fecha, Sitio, Estatus, Usuario) values(@Fecha,(select C_Sitio from AspNetUsers where" +
                " UserName=@user), @estatus, @user)";
            cmd2.Parameters.AddWithValue("@user", user);
            cmd2.Parameters.AddWithValue("@estatus", estatus);
            cmd2.Parameters.AddWithValue("@Fecha", fecha);
            cmd2.Connection = con;
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
            done = true;
        }
        catch
        {
        }

        return done;
    }

    protected void insertarD(String nombre, String dispositivo, string evento, int hora, int minutos, DateTime std, string url)
    {
        String status = "Activo";
        SqlConnection sqlConnection1 = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "INSERT automatizado (Nombre, dispositivo, Evento, Hora, Minuto, Fecha, status, url) VALUES (@nombre, @dispositivo,@Evento, @hora, @minutos, @std, @status,@url)";
        cmd.Parameters.AddWithValue("@nombre", nombre);
        cmd.Parameters.AddWithValue("@dispositivo", dispositivo);
        cmd.Parameters.AddWithValue("@Evento", evento);
        cmd.Parameters.AddWithValue("@hora", hora);
        cmd.Parameters.AddWithValue("@minutos", minutos);
        cmd.Parameters.AddWithValue("@std", std);
        cmd.Parameters.AddWithValue("@status", status);
        cmd.Parameters.AddWithValue("@url", url);
        cmd.Connection = sqlConnection1;
        sqlConnection1.Open();
        cmd.ExecuteNonQuery();
        sqlConnection1.Close();
    }

    protected void crearTarea(String nombre, short hora, short minutos, string url)
    {
        ScheduledTasks Tareas = new ScheduledTasks();
        Task tarea = Tareas.CreateTask(nombre);
        // archivo que vamos a ejecutar, escribimos la ruta completa
        tarea.ApplicationName = @"" + url + "";
        tarea.Comment = "Tarea de prueba";
        // configurar la cuenta con la que se ejecutara la tarea
        tarea.SetAccountInformation("Administrator", "addar-18");
        tarea.Creator = "RISC-IOT";
        // prioridad de la tarea
        tarea.Priority = System.Diagnostics.ProcessPriorityClass.Normal;
        // agregamos el disparador, la tarea se ejecutara diariamente a las 6 y 15 pm
        tarea.Triggers.Add(new DailyTrigger(hora, minutos));
        tarea.Save();
    }
}

/*-----------------------------------------------------------------------------------------------------------
-----------------------------------------------FUNCIONES MISCELANEA------------------------------------------
-----------------------------------------------------------------------------------------------------------*/





/*-------------------------------------------Objetos--------------------*/

public class Disposi
{
    public string nombre { get; set; }
}

public class comando
{
    public string accion { get; set; }
}

public class acciones
{
    public string accion { get; set; }
    public string comando { get; set; }
}