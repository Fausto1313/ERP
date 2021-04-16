using IOTComer;
using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

public partial class appAndroidConVrj : System.Web.UI.Page
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    protected static string conString2 = ConfigurationManager.ConnectionStrings["ConnectionIOT"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    SqlConnection con2 = new SqlConnection(conString2);


    protected void Page_Load(object sender, EventArgs e)
    {
        string cu = null;
        cu = Request["cu"];
        switch (cu) {
            //Login
            case "1":
                Login();
                break;
            //Logout
            case "2":
               //****** Logout();
		 Comandos();
                break;
            //Dispositivos usuario
            case "3":
                Dispositivos();
                break;
            //Registrar comando de voz
            case "4":
               
                break;
            //Cambio de password
            case "5":
                break;
            //Comando de voz
            case "6":
                break;
            //Registrar tarea
            case "7":
                break;
            //Activar seguridad
            case "8":
                break;
            //Desactivar seguridad
            case "9":
                break;
            //Registrar evento
            case "10":
                break;
            //Activar sistema manual
            case "11":
                break;
            //Quitar tarea
            case "12":
                break;
            //Buscar eventos
            case "13":
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

        usuario = Request["v1"];
        password = Request["v2"];
        // Validate the user password
        var manager = new UserManager();
        ApplicationUser user = manager.Find(usuario, password);
        if (user != null)
        {
            Response.Write(ReturnCliente(usuario));
        }
        else
        {
            Response.Write("False");
        }
    }

    //Logout
    protected void Logout(){

    }

    //Obtener dispositivos 
    protected void Dispositivos(){
        int cliente = 0;
        string res = String.Empty;
        cliente = Convert.ToInt32(Request["v1"]);
        res = ReturnDispositivos(cliente);
        Response.Write(res);
    }

    protected void Comandos() {
        string comando = null;
        int cliente = 0;

        comando = Request["v1"];
        cliente = Convert.ToInt32(Request["v2"]);
        string[] datos = new string[2];
        if(cliente == 4)
            datos = ReturnComm(comando);
        if (datos[0] == null)
        {
            Response.Write("False");
        }
        else
        {
            if (datos[0] == "1710LE2005")
            {
                string ip = "risc-iot.ddns.net:4041";
                WebRequest Peticion = default(WebRequest);
                Peticion = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip + "&v2=" + datos[0] + "&v3=" + datos[1]);
                Response.Write(datos[0]+" "+datos[1]);
                Peticion.GetResponseAsync();
            }
            else if (datos[0] == "1710LU2002")
            {
                string ip = "risc-iot.ddns.net:4040";
                WebRequest Peticion = default(WebRequest);
                Peticion = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip + "&v2=" + datos[0] + "&v3=" + datos[1]);
                Peticion.GetResponseAsync();
            }
            else if (datos[0] == "1710VA2001")
            {
                string ip = "risc-iot.ddns.net:4042";
                WebRequest Peticion = default(WebRequest);
                Peticion = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip + "&v2=" + datos[0] + "&v3=" + datos[1]);
                Peticion.GetResponseAsync();
            }
            else if (datos[0] == "1710HW2006")
            {
                string ip = "risc-iot.ddns.net:4045";
                WebRequest Peticion = default(WebRequest);
                Peticion = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip + "&v2=" + datos[0] + "&v3=" + datos[1]);
                Peticion.GetResponseAsync();
            }
            Response.Write("True");
        }
    }

    /*--------------------------------------------------------------------------------------------------
   -----------------------------------------SECCION DE CONSULTAS---------------------------------------
   --------------------------------------------------------------------------------------------------*/
    //Consulta de clientes a partir del nombre de usuario
    protected int ReturnCliente(string user)
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

    protected string[] ReturnComm(string comando)
    {
        string[] com = new string[2];
        con2.Open();
        SqlCommand cmd = new SqlCommand("SELECT RISCEI, Accion FROM Comandos where Comando=@comando", con2);
        cmd.Parameters.AddWithValue("@comando", comando);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            com[0] = Convert.ToString(dr[0]);
            com[1] = Convert.ToString(dr[1]);
        }
        con2.Close();
        return com;
    }
    
    protected string ReturnDispositivos(int id){
        string json = String.Empty;
        List<Disp> dispositivo = new List<Disp>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select Descripcion from DARS where ID_Cliente=@cliente", con);
        cmd.Parameters.AddWithValue("@cliente", id);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Disp Object = new Disp();
            Object.nombre = Convert.ToString(dr[0]);
            dispositivo.Add(Object);
        }
        con.Close();
        json = JsonConvert.SerializeObject(dispositivo);
        return json;
    }
}

/*-----------------------------------------------------------------------------------------------------------
-----------------------------------------------FUNCIONES MISCELANEA------------------------------------------
-----------------------------------------------------------------------------------------------------------*/





/*-------------------------------------------Objetos--------------------*/

public class Disp
{
    public string nombre { get; set; }
}