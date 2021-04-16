using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;

public partial class BotonPanico : System.Web.UI.Page
{
    protected static string conection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    public SqlConnection con = new SqlConnection(conection);

    protected void Page_Load(object sender, EventArgs e)
    {
        string cu = string.Empty;

        cu = Request["cu"];

        switch (cu) {
            case "1":
                prepareComboUsers();
                break;
            case "2":
                prepareInsertDevice();
                break;
            case "3":
                prepareInsertChannel();
                break;
            case "4":
                prepareInsertChannelSelected();
                break;
            case "5":
                doRequestPB();
                break;
            case "6":
                prepareLabelName();
                break;
            default:
                Response.Write("Undefined");
                break;
        }
    }

    /* ********************************************Seccion de Funciones CASE**********************************************************/

    /*------------------------------------------INSERT-------------------------------------------------*/

    protected void prepareInsertDevice()
    {
        string IMEI = string.Empty, nom = string.Empty;

        IMEI = Request["IMEI"];
        nom = Request["nom"];
        if (IMEI != "") {
            if (insertDevice(IMEI, nom))
                Response.Write("True");
            else
                Response.Write("False");
        }
        else
            Response.Write("False");
    }

    protected void prepareInsertChannel()
    {
        string usuario = string.Empty, canal = string.Empty, IMEI = string.Empty, resultado = string.Empty;
        usuario = Request["user"];
        canal = Request["canal"];
        canal = "@" + canal;
        IMEI = Request["IMEI"];
        resultado = insertChannel(canal, usuario, IMEI);
        Response.Write(resultado);
    }

    protected void prepareInsertChannelSelected() {
        string usuario = string.Empty, canal = string.Empty, IMEI = string.Empty;
        canal = Request["canal"];
        IMEI = Request["IMEI"];
        if (insertChannelSelected(canal, IMEI))
            Response.Write("True");
        else
            Response.Write("False");
    }

    /*------------------------------------------SELECT-------------------------------------------------*/

    protected void prepareComboUsers() {
        string json = string.Empty, usuario = string.Empty;
        usuario = Request["user"];
        json = selectUsers(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }

    protected void prepareLabelName() {
        string imei = string.Empty, json = string.Empty;

        imei = Request["IMEI"];
        json = selectNameButton(imei); ;
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }

    /*------------------------------------------ACCIONES-------------------------------------------------*/

    protected void doRequestPB() {
        string IMEI = string.Empty, lat = string.Empty, lon = string.Empty, tel = string.Empty;
        string[] pet = new string[2];
        IMEI = Request["IMEI"];
        tel = Request["telefono"];
        lat = Request["latitud"];
        lon = Request["longitud"];
        pet = selectInfoButton(IMEI);
        if(pet[0] != "" && pet[1] != ""){
            if(makeRequestTelegramChannel(pet, lat, lon, tel))
                Response.Write("True");
            else
                Response.Write("False 1");
        }
        else
            Response.Write("False 2");
    }

    /* ********************************************Seccion de SQL*************************************************************/

    /*------------------------------------------INSERT-------------------------------------------------*/

    protected bool insertDevice(string IMEI, string nom) {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "if(select NombreBoton from TelegramTelefono where IMEI = @imei) is null " +
                " insert into TelegramTelefono(IMEI, NombreBoton) values(@imei, @nombre) else" +
                " update TelegramTelefono set NombreBoton = @nombre where IMEI = @imei";
            cmd.Parameters.AddWithValue("@imei", IMEI);
            cmd.Parameters.AddWithValue("@nombre", nom);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch {
            return false;
        }
    }

    protected string insertChannel(string canal, string username, string IMEI) {
        string retorno = string.Empty;
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("if(select UserName from AspNetUsers where CanalTelegram = @canal) is null " +
                "BEGIN update AspNetUsers set CanalTelegram = @canal where UserName = @username; " +
                "update TelegramTelefono set Usuario = @username where IMEI = @imei; select 'True'; END " +
                "else select 'Warning'", con);
            cmd.Parameters.AddWithValue("@canal", canal);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@IMEI", IMEI);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
                retorno = Convert.ToString(dr[0]);
            con.Close();
            return retorno;
        }
        catch(Exception e)
        {
            Response.Write(e);
            return retorno = "False";
        }
    }

    protected bool insertChannelSelected(string canal, string IMEI) {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update TelegramTelefono set Usuario = (select UserName from AspNetUsers where " +
                "CanalTelegram = @canal ) where IMEI = @imei";
            cmd.Parameters.AddWithValue("@canal", canal);
            cmd.Parameters.AddWithValue("@IMEI", IMEI);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /*------------------------------------------SELECT-------------------------------------------------*/

    protected string selectUsers(string usuario) {
        string json = string.Empty;
        List<UsuariosBoton> up = new List<UsuariosBoton>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select CanalTelegram from AspNetUsers where ID_Cliente=" +
            "(select ID_Cliente from AspNetUsers where UserName = @usuario) and CanalTelegram is not null", con);
        cmd.Parameters.AddWithValue("@usuario",usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            UsuariosBoton ub = new UsuariosBoton();
            ub.usuarioTelegram = (Convert.ToString(dr[0]));
            up.Add(ub);
        }
        json = JsonConvert.SerializeObject(up);
        return json;
    }

    protected string[] selectInfoButton(string imei) {
        string[] boton = new string[2];
        con.Open();
        SqlCommand cmd = new SqlCommand("select tf.NombreBoton, u.CanalTelegram from TelegramTelefono tf inner join " +
            "AspNetUsers u on tf.Usuario=u.UserName where tf.IMEI = @imei", con);
        cmd.Parameters.AddWithValue("@imei", imei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            boton[0] = Convert.ToString(dr[0]);
            boton[1] = Convert.ToString(dr[1]);
        }
        else
        {
            boton[0] = "";
            boton[1] = "";
        }
        con.Close();
        
        return boton;
    }

    protected string selectNameButton(string imei)
    {
        string json = string.Empty;
        NombresBoton nb = new NombresBoton();
        con.Open();
        SqlCommand cmd = new SqlCommand("select NombreBoton from TelegramTelefono where IMEI = @imei", con);
        cmd.Parameters.AddWithValue("@imei", imei);
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        nb.NombreBoton = Convert.ToString(dr[0]);
        json = JsonConvert.SerializeObject(nb);
        return json;
    }

    /* ********************************************PETICIONES*********************************************************/

    protected bool makeRequestTelegramChannel(string[] parametros, string lat, string lon, string tel) {
        try
        {
            string token = "875170727:AAEmHTL8mzVBQhhDiFwlAJf3os6iWhG1fdw";
            string mensaje = "El botón de pánico " + parametros[0] + " ha sido accionado en la siguiente ubicación. " +
                "Favor de comunicarse al siguiente número: "+tel;
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + 
                parametros[1] + "&text=" + mensaje);
            Peticion.GetResponse();
            Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendLocation?chat_id=" +
                parametros[1] + "&latitude=" + lat + "&longitude=" + lon);
            Peticion.GetResponse();
            return true;
        }
        catch {
            return false;
        }
    }

    /* ********************************************Seccion de Objetos*********************************************************/

    public class UsuariosBoton {
        public string usuarioTelegram { get; set; }
    }

    public class NombresBoton {
        public string NombreBoton { get; set; }
    }

}