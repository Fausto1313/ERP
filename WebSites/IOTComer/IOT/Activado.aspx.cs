using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.UI;

public partial class IOT_Activado : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 12;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Activacion de Sistema")
        {
            showStatus();
        }
        else
            Response.Redirect("~/IOT/Home");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string user = User.Identity.Name;
        
        if (activarDAR1(user, "Activado")){
            insertStatus("Activado", user);
            sendTelegramSec(user, "Activado");
            
            con.Open();
            string updateCmd = "update Sitios set Seguridad='Activado' where ID=(select C_Sitio from AspNetUsers where UserName=@user)";
            SqlCommand updatecmd = new SqlCommand(updateCmd, con);
            updatecmd.Parameters.AddWithValue("@user", user);
            updatecmd.ExecuteNonQuery();
            con.Close();
        }
        else
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Problema de comunicación con el DAR, intente más tarde');");
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "errorSystem", sb.ToString(), false);
        }

        showStatus();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string user = User.Identity.Name;
        if (activarDAR1(user, "Desactivado"))
        {
            insertStatus("Desactivado", user);
            sendTelegramSec(user, "Desactivado");
            
            con.Open();
            string updateCmd = "update Sitios set Seguridad='Desactivado' where ID=(select C_Sitio from AspNetUsers where UserName=@user)";
            SqlCommand updatecmd = new SqlCommand(updateCmd, con);
            updatecmd.Parameters.AddWithValue("@user", user);
            updatecmd.ExecuteNonQuery();
            con.Close();
        }
        else {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Problema de comunicación con el DAR, intente más tarde');");
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "errorSystem", sb.ToString(), false);
        }
        showStatus();

    }

    protected string selectStatus(string nombre) {
        string estatus = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select Seguridad from Sitios where ID=(select C_Sitio from AspNetUsers where UserName=@user)", con);
        cmd.Parameters.AddWithValue("@user", nombre);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            estatus = Convert.ToString(dr[0]);
        }
        con.Close();

        return estatus;
    }

    protected void showStatus() {
        string user = User.Identity.Name, status = string.Empty;
        status = selectStatus(user);
        if (status == "")
            seguridad.Text = "Sin Configurar";
        else
            seguridad.Text = status;
    }

    protected void insertStatus(string status, string nombre) {
        DateTime fecha = DateTime.Now;

        con.Open();
        string updateCmd = "insert into Activador (Fecha, Sitio, Estatus, Usuario) values(@fecha,(select C_Sitio from AspNetUsers where UserName=@user), @status, @user)";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@fecha",fecha);
        updatecmd.Parameters.AddWithValue("@user", nombre);
        updatecmd.Parameters.AddWithValue("@status", status);
        updatecmd.ExecuteNonQuery();
        con.Close();
    }

    protected void sendTelegramSec(string usuario, string seguridad)
    {
        ArrayList lista = new ArrayList();
        con.Open();
        SqlCommand cmd = new SqlCommand("select c.CanalTelegram from CanalTelegram c inner join AspNetUsers us on c.Usuario = " +
            "us.UserName inner join AspNetRoles r on r.Id = us.Id_Rol inner join PermisoRol pr on pr.ID_Rol = r.Id " +
            "where pr.ID_Permiso = 36 and us.UserName = @usuario", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            lista.Add(Convert.ToString(dr[0]));
        }
        con.Close();

        string token = "465931710:AAHAY4-x6ZozrHPWkLfy9t7UUrcJX6Q61bw";
        //string[] id = { "485219307", "401967737", "462385749" };
        string mensaje = "El usuario " + usuario + " ha colocado el sistema en estado " + seguridad;

        for (int i = 0; i < lista.Count; i++)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + lista[i] + "&text=" + mensaje);
            Peticion.GetResponseAsync();
        }
    }

    protected bool activarDAR1(string usuario, string estatus)
    {
        bool acciones = false;
        con.Open();
        ArrayList noips = new ArrayList();
        string pas = string.Empty, url = string.Empty;
        SqlCommand cmd = new SqlCommand("if(select s.MultipleNOIP from Sitios s inner join AspNetUsers us on us.C_Sitio = " +
            "s.ID where us.UserName = @usuario) = 0 begin select NOIP from Sitios where ID = " +
            "(select C_Sitio from AspNetUsers where UserName = @usuario) end else select n1.NOIP from Nivel1 n1 " +
            "inner join AspNetUsers u on u.C_Sitio = n1.UbiDispo where u.UserName = @usuario", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
             noips.Add(Convert.ToString(dr[0]));
        }
        con.Close();
        for (int a = 0; a < noips.Count; a++) {
            url = "https://addar.mx/Especiales/alarmaPeticion.php?v1=" + noips[a] + "&v2=" + estatus;
            
            string uri = returnResponseValue(url);
            if (uri == "True")
                acciones = true;
            else
                acciones = false;
        }
        return acciones;
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

}