using IOTComer;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;
public partial class ControlService2 : System.Web.UI.Page
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    SqlConnection con2 = new SqlConnection(conString);

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
            case "7b":
                TaskUnique();
                break;
            //Activar seguridad
            case "8":
                updateSecurity();
                break;
            //Desactivar seguridad
            case "9":
                updateSecurity();
                break;
            //Estatus de Seguridad
            case "10":
                returnSecurityUser();
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
            case "15":
                returnStatusDevices();
                break;
            //Favoritos
            case "16":
                insertFavoritos();
                break;
            case "17":
                deleteFavoritos();
                break;
            case "18":
                returnDispo();
                break;
            case "19":
                returnFavoritos();
                break;
            case "20":
                doCommandFavoritosUserAd();
                break;
            case "21":
                deleteFavoritosUser();
                break;
            case "22":
                returnDispoUser();
                break;
            case "23":
                programmTasKUser();
                break;
            case "24":
                returnRulesTempUser();
                break;
            case "25":
                registerRulesTempeUser();
                break;
            case "26":
                returnRulesGridUser();
                break;
            case "27":
                updateAviso();
                break;
            case "28":
                returnCentinelaUser();
                break;
            /*--------------------------------------------------------------------------------------------------
           -----------------------------------SECCION DE FUNCIONES ADMINISTRADOR--------------------------------
           --------------------------------------------------------------------------------------------------*/
            //LOGIN Administrador
            case "ad1":
                LoginAdmin();
                break;
            case "ad2":
                returnNiveles();
                break;
            case "ad3":
                returnDevices();
                break;
            case "ad4":
                CommandsAdmin();
                break;
            case "ad5":
                returnCommandsSite();
                break;
            case "ad6":
                doCommandSite();
                break;
            case "ad7":
                doCommandManualSite();
                break;
            case "ad8":
                programmTaskAdm1();
                break;
            case "ad9":
                returnActions();
                break;
            case "ad10":
                TasksAdmin();
                break;
            case "ad11":
                updateSecurityAdm();
                break;
            case "ad12":
                updateSecurityAdm();
                break;
            case "ad13":
                returnSecurityAdm();
                break;
            case "ad14":
                returnStatusDeviceAdm();
                break;
            case "ad15":
                programmTasKPredeAdmi();
                break;
            case "ad16":
                returnRulesTempAdm();
                break;
            case "ad17":
                insertRulesTempAdm();
                break;
            case "ad18":
                returnRulesGridAdm();
                break;
            case "ad19":
                returnCentinelaAdm();   
                break;
        }
    }

    /*--------------------------------------------------------------------------------------------------
  -----------------------------------SECCION DE FUNCIONES ADMINISTRADOR--------------------------------
  --------------------------------------------------------------------------------------------------*/


    protected void LoginAdmin()
    {
        string usuario = string.Empty, password = string.Empty;
        string seg = string.Empty;
        usuario = Request["usuario"];
        password = Request["pwd"];
        // Validate the user password
        var manager = new UserManager();
        UsuarioExterno ue = new UsuarioExterno();
        ApplicationUser user = manager.Find(usuario, password);
        if (user != null)
        {
            logFile(usuario + password, "Success Login");
            string res = string.Empty;
            res = ReturnLogin(usuario);
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(res);
        }
        else if (ue.Login(usuario, password) == "True") {
            logFile(usuario + password, "Success Login");
            string res = string.Empty;
            res = ReturnLoginRestaurant(usuario);
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(res);
        }
        else
        {
            logFile(usuario + password, "Failed Login");
            usuario users = new usuario();
            users.estado = "False";
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(JsonConvert.SerializeObject(users));
        }
    }

    protected void updateAviso() {
        string usuario = string.Empty;
        usuario = Request["usuario"];
        updateAviso(usuario);
        Response.Write("True");
    }

    protected void logFile(string error, string descripcion) {
        string rutaCompleta = @"C:\DataIOT\addarLOG.txt";
        using (StreamWriter sw = File.AppendText(rutaCompleta))         //se crea el archivo
        {
            sw.WriteLine("----------------------------------------");
            DateTime std = DateTime.Now;
            sw.WriteLine(std);
            sw.WriteLine(error);
            sw.WriteLine(descripcion);
            sw.WriteLine("status OK");
            sw.Close();
        }
    }

    protected void commandLog(string comando, string usuario)
    {
        string rutaCompleta = @"C:\DataIOT\addarLOGCommands.txt";
        using (StreamWriter sw = File.AppendText(rutaCompleta))         //se crea el archivo
        {
            sw.WriteLine("----------------------------------------");
            DateTime std = DateTime.Now;
            sw.WriteLine(std);
            sw.WriteLine(usuario);
            sw.WriteLine(comando);
            sw.WriteLine("status OK");
            sw.Close();
        }
    }

    protected void returnNiveles()
    {
        string sitio = string.Empty, res = string.Empty;

        sitio = Request["sitio"];
        res = returnLevels(sitio);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(res);
    }

    protected void returnDevices()
    {
        string sitio = string.Empty, nivel = string.Empty, res = string.Empty;

        sitio = Request["sitio"];
        nivel = Request["nivel"];
        res = returnDevsAd(sitio, nivel);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(res);

    }

    protected void CommandsAdmin()
    {
        string sitio = string.Empty, nivel = string.Empty, dispositivo = string.Empty, accion = string.Empty, comando = string.Empty;

        sitio = Request["sitio"];
        nivel = Request["nivel"];
        dispositivo = Request["dispo"];
        accion = Request["accion"];
        comando = Request["comando"];
        if (insertCommandSQL2(sitio, nivel, dispositivo, accion, comando))
            Response.Write("True");
        else
            Response.Write("False");

    }

    protected void returnCommandsSite()
    {
        string sitio = string.Empty, nivel = string.Empty, dispo = string.Empty, res = string.Empty;

        sitio = Request["sitio"];
        nivel = Request["nivel"];
        dispo = Request["dispositivo"];

        res = searchCommandsAdmin(sitio, nivel, dispo);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(res);
    }

    protected void doCommandSite()
    {
        string sitio = string.Empty, comando = string.Empty, tempe = string.Empty, usuario = string.Empty, req = string.Empty, noip = string.Empty, comando2 = string.Empty;
        string[] peticion;
        sitio = Request["sitio"];
        comando = Request["comando"];
        usuario = Request["user"];
        tempe = comando.ToLower();
        tempe = returnCadena(tempe);
        comando2 = comando.ToUpper();
        if (comando.Contains("Reproducir") && comando.Contains("pista"))
        {
            int i = comando.LastIndexOf(' ') + 1;
            int j = comando.Length;
            int k = j - i;
            string nuevo = comando.Substring(i, k);
            noip = returnNOIP(usuario, sitio, 2);
            req = "https://addar.mx/Especiales/peticion3.php?v1=" + noip + "&v2=" + nuevo + "&v3=Pista";
        }
        else if(comando2.Contains("NEMI")){
            asistenteDeVidaAdministrador(sitio, usuario,comando2, tempe);
        }
        //else if (comando2.Contains("NOTIFICACION") || comando2.Contains("NOTIFICACIÓN"))
        //    avisoLLegada(usuario, comando2, 2, sitio);
        //else if (tempe.Contains("regla"))
        //    programmRuleTempAdm(usuario, sitio, tempe);
        else
        {
            peticion = ReturnCommAdm(sitio, comando, usuario);
            if (peticion[2] == "PLAY" || peticion[2] == "PAUSE")
            {
                req = "https://addar.mx/Especiales/peticion3.php?v1=" + peticion[0] + "&v2=" + peticion[2] + "&v3=Accion";
            }
            else
                req = "https://addar.mx/Especiales/peticion2.php?v1=" + peticion[0] + "&v2=" + peticion[1] + "&v3=" + peticion[2];
            try
            {
                WebRequest Peticion = default(WebRequest);
                //string pet = "https://addar.mx/Especiales/peticion2.php?v1=" + peticion[0] + "&v2=" + peticion[1] + "&v3=" + peticion[2];
                Peticion = WebRequest.Create(req);
                Peticion.GetResponseAsync();
                // Response.Write(pet);
                Response.Write("True");
            }
            catch
            {
                Response.Write("False");
            }
        }

    }

    protected void doCommandManualSite()
    {
        string sitio = string.Empty, dispositivo = string.Empty, comando = string.Empty, req = string.Empty, nivel = string.Empty, estatus = string.Empty;

        sitio = Request["sitio"];
        nivel = Request["nivel"];
        dispositivo = Request["dispositivo"];
        comando = Request["accion"];

        string[] peticion = ReturnComm2(sitio, nivel, dispositivo);
        if (comando == "PLAY" || comando == "PAUSE")
        {
            req = "https://addar.mx/Especiales/peticion3.php?v1=" + peticion[0] + "&v2=" + comando + "&v3=Accion";
        }
        else
            req = "https://addar.mx/Especiales/peticion2.php?v1=" + peticion[0] + "&v2=" + peticion[1] + "&v3=" + comando;
        try
        {
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create(req);
            /*using (HttpWebResponse response = (HttpWebResponse)Peticion.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json2 = reader.ReadToEnd();
                if (json2.Contains("Encendido"))
                {
                    estatus = "Encendido";
                }
                else if (json2.Contains("Apagado"))
                {
                    estatus = "Apagado";
                }
            }*/
            Peticion.GetResponseAsync();
            Response.Write("True");

        }
        catch
        {
            estatus = "False";
        }

        Response.Write(estatus);
    }

    protected void programmTaskAdm1()
    {
        string sitio = string.Empty, peticion = string.Empty, nivel = string.Empty, dispositivo = string.Empty, accion = string.Empty, nombre = string.Empty, url = string.Empty, nombreR = string.Empty;
        string[] dis = new string[2];
        int dia = 0, mes = 0, hora = 0, min = 0;
        DateTime std = DateTime.Now;
        sitio = Request["sitio"];
        nivel = Request["nivel"];
        dispositivo = Request["dispositivo"];
        dis = returnRiscei2(sitio, nivel, dispositivo);
        accion = Request["accion"];
        dia = Convert.ToInt32(Request["dia"]);
        nombre = std + dis[0];
        mes = returnMes(Request["mes"]);
        hora = Convert.ToInt32(Request["hora"]);
        min = Convert.ToInt32(Request["minuto"]);
        peticion = "http://" + dis[1] + "/cronPhp/agregarTarea.php?min=" + min + "&hrs=" + hora + "&dias=" + dia + "&meses=" + mes + "&dSem=*&comando=localhost/rest.php?riscei=" + dis[0] + ",evento=" + accion;
        try
        {
            url = returnResponseValue(peticion);
            insertarD(nombre, dis[0], accion, hora, min, std, url, "Unica");
            Response.Write("True");
        }
        catch
        {
            Response.Write("False");
        }
        //Response.Write(peticion + " <br/> " + url);
    }

    protected void returnActions()
    {
        string sitio = string.Empty, nivel = string.Empty, dispositivo = string.Empty, res = string.Empty;

        sitio = Request["sitio"];
        nivel = Request["nivel"];
        dispositivo = Request["dispositivo"];
        res = returnActionsAdm(sitio, nivel, dispositivo);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(res);
    }

    protected void TasksAdmin()
    {
        string nombre = string.Empty, dispositivo = string.Empty, url = string.Empty, accion = string.Empty, nombreR = string.Empty, sitio = string.Empty, nivel = string.Empty;
        string i = string.Empty, m = string.Empty, peticion = string.Empty;
        int hora = 0, minutos = 0;
        string[] dis = new string[2];
        DateTime std = DateTime.Now;
        sitio = Request["sitio"];
        nivel = Request["nivel"];
        dispositivo = Request["dispositivo"];
        dis = returnRiscei2(sitio, nivel, dispositivo);
        accion = Request["accion"];
        nombre = std + dis[0];
        hora = Convert.ToInt32(Request["hora"]);
        minutos = Convert.ToInt32(Request["minuto"]);
        peticion = "http://" + dis[1] + "/cronPhp/agregarTarea.php?min=" + minutos + "&hrs=" + hora + "&dias=*&meses=*&dSem=*&comando=localhost/rest.php?riscei=" + dis[0] + ",evento=" + accion;
        try
        {
            url = returnResponseValue(peticion);
            insertarD(nombre, dis[0], accion, hora, minutos, std, url, "Repetitiva");
            Response.Write("True");
        }
        catch {
            Response.Write("False");
        }
        //Response.Write(peticion+" <br/> "+url);
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

    protected void updateSecurityAdm()
    {
        string sitio = string.Empty, usuario = string.Empty, estatus = string.Empty;

        usuario = Request["usuario"];
        sitio = Request["sitio"];
        estatus = Request["seguridad"];
        if (activarDAR1Adm(sitio, estatus))
        {
            Response.Write("True");
            changeSecurityAdm(sitio, usuario, estatus);
            sendTelegramSecAdm(usuario, estatus, sitio);
        }
        else
            Response.Write("False");
    }

    protected void returnSecurityAdm()
    {
        string sitio = string.Empty, usuario = string.Empty, res = string.Empty;

        usuario = Request["usuario"];
        sitio = Request["sitio"];
        res = returnStatusSecurity(sitio, usuario);
        if (res == "")
            Response.Write("Desactivado");
        else
            Response.Write(res);
    }

    protected void returnSecurityUser() {
        string usuario = string.Empty, res = string.Empty;
        usuario = Request["usuario"];
        res = returnStatusSecurityUser(usuario);
        if (res == "")
            Response.Write("Desactivado");
        else
            Response.Write(res);
    }

    protected void returnStatusDeviceAdm()
    {
        string sitio = string.Empty, nivel = string.Empty, dispositivo = string.Empty, res = string.Empty;

        sitio = Request["sitio"];
        nivel = Request["nivel"];
        dispositivo = Request["dispositivo"];
        res = searchCommandsStatusAdmin(sitio, nivel, dispositivo);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(res);
    }
    protected void returnCentinelaUser() {
        string usuario = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        json = returnCentinelaUserSQL(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }

    protected void returnCentinelaAdm() {
        string usuario = string.Empty, sitio = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        sitio = Request["sitio"];
        json = returnCentinelaAdmSQL(usuario,sitio);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
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

    //Obtener dispositivos 
    protected void returnDispositivos()
    {
        string usuario = string.Empty, nivel = string.Empty;
        string res = String.Empty;
        usuario = Request["usuario"];
        nivel = Request["nivel"];
        res = ReturnDispositivos(usuario, nivel);
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
        string usuario = string.Empty, dis = string.Empty, accion = string.Empty, comando = string.Empty, nivel = string.Empty;
        usuario = Request["user"];
        nivel = Request["nivel"];
        dis = Request["dispositivo"];
        accion = Request["accion"];
        comando = Request["texto"];
        if (insertCommandSQL(usuario, dis, accion, comando, nivel))
            Response.Write("True");
        else
            Response.Write("False");
    }

    protected void doCommand()
    {
        string usuario = string.Empty, comando = string.Empty, tempe = string.Empty, comando2 = string.Empty, req = string.Empty, noip = string.Empty, valor = string.Empty;
        usuario = Request["user"];
        comando = Request["comando"];
        tempe = comando.ToLower();
        tempe = returnCadena(tempe);
        comando2 = comando.ToUpper();
        commandLog(tempe,usuario);
        if (comando2.Contains("REPRODUCIR") && comando2.Contains("PISTA"))
        {
            int i = comando.LastIndexOf(' ') + 1;
            int j = comando.Length;
            int k = j - i;
            string nuevo = comando.Substring(i, k);
            noip = returnNOIP(usuario, "", 1);
            req = "https://addar.mx/Especiales/peticion3.php?v1=" + noip + "&v2=" + nuevo + "&v3=Pista";
            valor = makeRequest(req);
        }
        else if (comando2.Contains("TINI")) {
            asistenteDeVidaUsuario(usuario, comando2, tempe);
        }
        //else if (comando2.Contains("NOTIFICACION") || comando2.Contains("NOTIFICACIÓN"))
        //    avisoLLegada(usuario, comando2, 1, "");
        //else if (tempe.Contains("regla"))
        //    programmRuleTempUser(usuario, tempe);
        else
        {
            try
            {
                List<eventosAgrupados> peticion = ReturnComm(usuario, comando);
                if (peticion[0].accion == "PLAY" || peticion[0].accion == "PAUSE")
                {
                    req = "https://addar.mx/Especiales/peticion3.php?v1=" + peticion[0] + "&v2=" + peticion[2] + "&v3=Accion";
                    valor = makeRequest(req);
                }
                else
                {
                    int a = peticion.Count;
                    //Response.Write(a+" ");
                    for (int i = 0; i < a; i++)
                    {
                        req = "https://addar.mx/Especiales/peticion2.php?v1=" + peticion[i].noip + "&v2=" + peticion[i].dispositivo + "&v3=" + peticion[i].accion;
                        valor = makeRequest(req);
                    }

                }
            }
            catch
            {
                valor = "False";
            }

        }
        Response.Write(valor);

    }

    protected string makeRequest(string req) {
        string valor = string.Empty;
        try
        {
            //Response.Write(peticion[0]+peticion[1]+peticion[2]);
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create(req);
            Peticion.GetResponseAsync();
            valor = "True";

        }
        catch
        {
            valor = "False";

        }
        return valor;
    }
    protected void doCommandManual()
    {
        string usuario = string.Empty, dispositivo = string.Empty, accion = string.Empty, estatus = string.Empty, req = string.Empty;
        usuario = Request["user"];
        dispositivo = Request["dispositivo"];
        accion = Request["accion"];
        string[] peticion = ReturnComm2Adm(usuario, dispositivo);
        if (accion == "PLAY" || accion == "PAUSE")
        {
            req = "https://addar.mx/Especiales/peticion3.php?v1=" + peticion[0] + "&v2=" + accion + "&v3=Accion";
        }
        else
            req = "https://addar.mx/Especiales/peticion2.php?v1=" + peticion[0] + "&v2=" + peticion[1] + "&v3=" + accion;
        try
        {
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create(req);
            /*using (HttpWebResponse response = (HttpWebResponse)Peticion.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json2 = reader.ReadToEnd();
                if (json2.Contains("Encendido"))
                {
                    estatus = "Encendido";
                }
                else if (json2.Contains("Apagado"))
                {
                    estatus = "Apagado";
                }
            }*/
            Peticion.GetResponseAsync();
            estatus = "True";

        }
        catch
        {
            estatus = "False";
        }

        Response.Write(estatus);
    }

    protected void Tasks()
    {
        string nombre = string.Empty, nivel = string.Empty, url = string.Empty, accion = string.Empty, nombreR = string.Empty, usuario = string.Empty;
        string i = string.Empty, m = string.Empty, peticion = string.Empty;
        string[] dispositivo = new string[2];
        int hora = 0, minutos = 0;
        DateTime std = DateTime.Now;
        usuario = Request["user"];
        nivel = Request["nivel"];
        i = Request["dispositivo"];
        dispositivo = returnRisceiTareas(i, usuario, nivel);
        accion = Request["accion"];
        nombre = std + dispositivo[0];
        hora = Convert.ToInt32(Request["hora"]);
        minutos = Convert.ToInt32(Request["minuto"]);
        peticion = "http://" + dispositivo[1] + "/cronPhp/agregarTarea.php?min=" + minutos + "&hrs=" + hora + "&dias=*&meses=*&dSem=*&comando=localhost/rest.php?riscei=" + dispositivo[0] + ",evento=" + accion;
        try
        {
            url = returnResponseValue(peticion);
            insertarD(nombre, dispositivo[0], accion, hora, minutos, std, url, "Repetitiva");
            Response.Write("True");
        }
        catch
        {
            Response.Write("False");
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

    protected void updateAviso(string usuario) {
        con.Open();
        SqlCommand cmd = new SqlCommand("update AspNetUsers set AvisoPrivacidad = 'Aceptado' where UserName = @user" ,con);
        cmd.Parameters.AddWithValue("@user",usuario);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected void returnCommandsList()
    {
        string dispositivo = string.Empty, usuario = string.Empty, nivel = string.Empty;
        string res = string.Empty;
        usuario = Request["usuario"];
        dispositivo = Request["dispositivo"];
        nivel = Request["nivel"];
        res = searchCommands(usuario, dispositivo, nivel);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(res);
    }

    protected void updateSecurity()
    {
        string usuario = string.Empty, estatus = string.Empty;
        usuario = Request["usuario"];
        estatus = Request["seguridad"];
        if (activarDAR1(usuario, estatus))
        {
            Response.Write("True");
            changeSecurity(usuario, estatus);
            sendTelegramSec(usuario, estatus);
        }
        else
            Response.Write("False");

    }
    
    protected void TaskUnique()
    {
        string usuario = string.Empty, nivel = string.Empty, dispositivo = string.Empty, accion = string.Empty, nombre = string.Empty, url = string.Empty, nombreR = string.Empty, peticion = string.Empty;
        string[] dis = new string[2];
        int dia = 0, mes = 0, hora = 0, min = 0;
        DateTime std = DateTime.Now;
        usuario = Request["user"];
        nivel = Request["nivel"];
        dispositivo = Request["dispositivo"];
        dis = returnRisceiTareas(dispositivo, usuario, nivel);
        accion = Request["accion"];
        hora = Convert.ToInt32(Request["hora"]);
        min = Convert.ToInt32(Request["minuto"]);
        dia = Convert.ToInt32(Request["dia"]);
        mes = returnMes(Request["mes"]);
        nombre = std + dis[0];
        peticion = "http://" + dis[1] + "/cronPhp/agregarTarea.php?min=" + min + "&hrs=" + hora + "&dias=" + dia + "&meses=" + mes + "&dSem=*&comando=localhost/rest.php?riscei=" + dis[0] + ",evento=" + accion;
        try
        {
            url = returnResponseValue(peticion);
            insertarD(nombre, dis[0], accion, hora, min, std, url, "Unica");
            Response.Write("True");
        }
        catch {
            Response.Write("False");
        }

    }

    protected void returnStatusDevices()
    {
        string usuario = string.Empty, dis = string.Empty;
        string res = String.Empty;
        usuario = Request["usuario"];
        dis = Request["dis"];
        res = searchCommandsStatus(usuario, dis);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(res);
    }

    /*--------------------------------------------------------------------------------------------------
   ---------------------------------SECCION DE CONSULTAS ADMINISTRADOR---------------------------------
   --------------------------------------------------------------------------------------------------*/
    protected string ReturnLoginRestaurant(string usuario) {
        string json = string.Empty;
        usuario user = new usuario();
        user.estado = "True";
        user.rol = "Restaurante";
        user.nombreCliente = returnNameCliente(usuario,"Restaurant");
        user.icono = ConsultarIcono(usuario,"Restaurant");
        //user.listaCategorias = consultarCategorias(usuario);
        json = JsonConvert.SerializeObject(user);
        return json;
    }
    protected string ReturnLogin(string usuario)
    {
        string json = string.Empty;
        usuario user = new usuario();
        user.estado = "True";
        con.Open();
        SqlCommand cmd = new SqlCommand("select p.Modulo from Permisos p inner join PermisoRol pr on p.ID=pr.ID_Permiso and " +
            "pr.ID_Rol=(select ID_Rol from AspNetUsers where UserName=@user) and pr.ID_Permiso=36", con);
        cmd.Parameters.AddWithValue("@user", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string consulta = string.Empty;
            consulta = Convert.ToString(dr[0]);
            if (consulta == "Administrador App")
            {
                user.rol = "Administrador";
                List<sitio> sitio = new List<sitio>();
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("select Descripcion from Sitios where ID_Cliente = " +
                    "(select ID_Cliente from AspNetUsers where UserName=@user)", con2);
                cmd2.Parameters.AddWithValue("@user", usuario);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    sitio site2 = new sitio();
                    site2.sitios = Convert.ToString(dr2[0]);
                    sitio.Add(site2);
                }
                con2.Close();
                user.site = sitio;
            }
        }
        else
        {
            con2.Open();
            user.rol = "Usuario";
            SqlCommand cmd2 = new SqlCommand("select Seguridad from Sitios where ID = (select C_Sitio from AspNetUsers where UserName = @user)", con2);
            cmd2.Parameters.AddWithValue("@user", usuario);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                user.estatus = Convert.ToString(dr2[0]);
            }
            con2.Close();
            con2.Open();
            List<nivel> lev = new List<nivel>();
            SqlCommand cmd3 = new SqlCommand("select distinct n.Nombre from Nivel1 n inner join (select nivel1 from UbiDis " +
                "where Cl_Sitio=(Select C_Sitio from AspNetUsers where UserName = @user)) as a1 on n.ID=a1.nivel1", con2);
            cmd3.Parameters.AddWithValue("@user", usuario);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                nivel levi = new nivel();
                levi.nombreNivel = Convert.ToString(dr3[0]);
                lev.Add(levi);
            }
            con2.Close();
            user.nivels = lev;
        }
        con.Close();
        user.nombreCliente = returnNameCliente(usuario, "Normal");
        user.avisoPrivacidad = returnAvisoPrivacidad(usuario);
        user.icono = ConsultarIcono(usuario,"Normal");
        if (returnPermisoSeguridadUsuario(usuario) == "Activacion de Sistema")
            user.Activado = "True";
        else
            user.Activado = "False";
        if (returnPermisoRestaurant(usuario) == "Restaurant")
        {
            user.AdmRestaurant = "True";
        }
        else
            user.AdmRestaurant = "False";
        json = JsonConvert.SerializeObject(user);
        return json;
    }

    protected string returnPermisoSeguridadUsuario(string usuario) {
        string resultado = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select p.Modulo from Permisos p inner join PermisoRol pr on " +
            "p.ID=pr.ID_Permiso and pr.ID_Rol = (select ID_Rol from AspNetUsers where UserName = @user) " +
            "and pr.ID_Permiso = 12",con);
        cmd.Parameters.AddWithValue("@user",usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            resultado = Convert.ToString(dr[0]);
        }
        con.Close();
        return resultado;
    }

    protected string returnPermisoRestaurant(string usuario) {
        string resultado = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select p.Modulo from Permisos p inner join PermisoRol pr on " +
            "p.ID=pr.ID_Permiso and pr.ID_Rol = (select ID_Rol from AspNetUsers where UserName = @user) " +
            "and pr.ID_Permiso = 55", con);
        cmd.Parameters.AddWithValue("@user", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            resultado = Convert.ToString(dr[0]);
        }
        con.Close();
        return resultado;
    }

    protected string returnLevels(string nivel)
    {
        string json = string.Empty;
        List<nivel> level = new List<nivel>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select distinct n.Nombre from Nivel1 n inner join (select nivel1 from UbiDis where " +
            "Cl_Sitio=(Select ID from Sitios where Descripcion = @nivel)) as a1 on n.ID=a1.nivel1", con);
        cmd.Parameters.AddWithValue("@nivel", nivel);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            nivel objects = new nivel();
            objects.nombreNivel = Convert.ToString(dr[0]);
            level.Add(objects);
        }
        json = JsonConvert.SerializeObject(level);
        con.Close();
        return json;
        
    }

    protected string returnDevsAd(string sitio, string nivel)
    {
        string json = string.Empty;

        List<Disposis> dispositivo = new List<Disposis>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select d.Descripcion from dars d inner join (select ID from UbiDis where nivel1=(select ID " +
            "from Nivel1 where Nombre=@nivel and UbiDispo=(select ID from Sitios where Descripcion=@sitio))) as a1 on a1.Id=d.UbiDis and (d.Modelo='DAR-BIS-VA/LE/LU/LS' or d.Modelo = 'DAR-BIS-HW' or d.Modelo = 'DAR-BIS-MP')", con);
        cmd.Parameters.AddWithValue("@nivel", nivel);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Disposis Object = new Disposis();
            Object.nombre = Convert.ToString(dr[0]);
            dispositivo.Add(Object);
        }
        con.Close();
        json = JsonConvert.SerializeObject(dispositivo);
        return json;

    }

    protected string returnAvisoPrivacidad(string usuario) {
        con.Open();
        string regreso = string.Empty;
        SqlCommand cmd = new SqlCommand("select AvisoPrivacidad from AspnetUsers where UserName = @user",con);
        cmd.Parameters.AddWithValue("@user", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
            regreso = Convert.ToString(dr[0]);
        con.Close();
        return regreso;
    }
    protected bool insertCommandSQL2(string sitio, string nivel, string desc, string accion, string comando)
    {
        bool done = false;

        string riscei = returnRisceiSitio(sitio, nivel, desc);
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
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

    protected string returnRisceiSitio(string sitio, string nivel, string desc)
    {
        string riscei = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select d.RISCEI from dars d inner join (select ID from UbiDis where nivel1=(select ID " +
            "from Nivel1 where Nombre=@nivel and UbiDispo=(select ID from Sitios where Descripcion=@sitio))) as a1 on " +
            "a1.Id=d.UbiDis where d.Descripcion = @desc", con);
        cmd.Parameters.AddWithValue("@nivel", nivel);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        cmd.Parameters.AddWithValue("@desc", desc);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            riscei = Convert.ToString(dr[0]);
        }
        con.Close();
        return riscei;
    }

    protected string searchCommandsAdmin(string sitio, string nivel, string des)
    {
        string json = string.Empty;
        List<accioness> ac = new List<accioness>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select com.Comando, com.Accion from Comandos com inner join (select d.RISCEI from dars " +
            "d inner join (select ID from UbiDis where nivel1=(select ID from Nivel1 where Nombre=@nivel and " +
            "UbiDispo=(select ID from Sitios where Descripcion=@sitio))) as a1 on a1.Id=d.UbiDis where d.Descripcion = " +
            "@dis) as a1 on a1.RISCEI= com.RISCEI", con);
        cmd.Parameters.AddWithValue("@nivel", nivel);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        cmd.Parameters.AddWithValue("@dis", des);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            accioness Object = new accioness();
            Object.comando = Convert.ToString(dr[0]);
            Object.accion = Convert.ToString(dr[1]);
            ac.Add(Object);
        }
        con.Close();
        json = JsonConvert.SerializeObject(ac);
        return json;
    }

    protected string[] ReturnCommAdm(string sitio, string comando, string usuario)
    {
        string[] com = new string[3];
        con.Open();
        SqlCommand cmd = new SqlCommand("select s.NOIP, c.RISCEI, c.Accion from (select ID_cliente from Sitios where " +
            "Descripcion = @sitio and ID_cliente = (select ID_Cliente from AspNetUsers where UserName = @user)) as a1, " +
            "Comandos c, dars d, Sitios s where Comando = @comando and s.ID = (select ID from Sitios where " +
            "Descripcion = @sitio) and d.ID_Cliente = a1.ID_cliente and d.RISCEI = c.RISCEI", con);
        cmd.Parameters.AddWithValue("@comando", comando);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        cmd.Parameters.AddWithValue("@user", usuario);
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

    protected string[] ReturnComm2Adm(string usuario, string desc)
    {
        string[] com = new string[2];
        con.Open();
        SqlCommand cmd = new SqlCommand("select s.NOIP, d.RISCEI from dars d, Sitios s, UbiDis u, " +
            "(select C_Sitio from AspNetUsers where UserName = @usuario) as a1 where s.ID = a1.C_Sitio " +
            "and d.Descripcion = @desc and (d.UbiDis = u.Id and u.Cl_Sitio = a1.C_Sitio)", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
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

    protected string returnStatusDAR(string sitio, string nivel, string dispositivo)
    {
        string json = string.Empty;
        estatusDAR stat = new estatusDAR();
        con.Open();
        SqlCommand cmd = new SqlCommand("select e.Comando from Eventos e where Modelo = (select d.Modelo from dars d inner join" +
            " (select ID from UbiDis where nivel1=(select ID from Nivel1 where Nombre=@nivel and UbiDispo=(select ID from Sitios " +
            "where Descripcion=@sitio))) as a1 on a1.Id=d.UbiDis where d.Descripcion = @dis)", con);
        cmd.Parameters.AddWithValue("@nivel", nivel);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        cmd.Parameters.AddWithValue("@dis", dispositivo);
        SqlDataReader dr = cmd.ExecuteReader();
        //while (dr.Read())
        //{
        //    accioness Object = new accioness();
        //    Object.comando = Convert.ToString(dr[0]);
        //    Object.accion = Convert.ToString(dr[1]);
        //    ac.Add(Object);
        //}
        con.Close();
        return json;
    }

    protected string[] returnRiscei2(string site, string nivel, string desc)
    {
        string[] riscei = new string[2];

        con.Open();
        SqlCommand cmd = new SqlCommand("select aa1.riscei, aa2.NOIP from (select d.RISCEI from dars d, Sitios s, UbiDis u, " +
            "(select ID from Sitios where Descripcion=@sitio ) as a1 where s.ID = a1.ID and d.Descripcion = @desc " +
            "and u.nivel1 = (select ID from Nivel1 where Nombre = @nivel and UbiDispo = a1.ID) and u.Id = d.UbiDis) as aa1, (select NOIP from Sitios where Descripcion = @sitio) as aa2", con);
        cmd.Parameters.AddWithValue("@sitio", site);
        cmd.Parameters.AddWithValue("@desc", desc);
        cmd.Parameters.AddWithValue("@nivel", nivel);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            riscei[0] = Convert.ToString(dr[0]);
            riscei[1] = Convert.ToString(dr[1]);
        }
        con.Close();
        return riscei;
    }

    protected string returnActionsAdm(string sitio, string nivel, string desc)
    {
        string json = string.Empty;

        List<comandos> comi = new List<comandos>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select Comando from Eventos, (select ID from Sitios where Descripcion=@sitio) as a1 " +
            "where Modelo = (select d.modelo from dars d inner join (select ID from UbiDis where Cl_Sitio = a1.ID and " +
            "Nivel1 = (select ID from Nivel1 where Nombre = @nivel and UbiDispo = a1.ID)) as a1 on d.UbiDis = " +
            "a1.ID where d.Descripcion = @desc)", con);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        cmd.Parameters.AddWithValue("@nivel", nivel);
        cmd.Parameters.AddWithValue("@desc", desc);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            comandos Object = new comandos();
            Object.accion = Convert.ToString(dr[0]);
            comi.Add(Object);
        }
        con.Close();
        json = JsonConvert.SerializeObject(comi);

        return json;
    }

    protected bool changeSecurityAdm(string sitio, string user, string estatus)
    {
        bool done = false;
        DateTime fecha = DateTime.Now;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Sitios set Seguridad=@estatus where Descripcion = @sitio ";
            cmd.Parameters.AddWithValue("@sitio", sitio);
            cmd.Parameters.AddWithValue("@estatus", estatus);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandType = CommandType.Text;
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

    protected string returnStatusSecurity(string sitio, string usuario)
    {
        string res = string.Empty;

        con.Open();
        SqlCommand cmd = new SqlCommand("select Seguridad from Sitios where Descripcion=@sitio and " +
            "ID_cliente = (select ID_Cliente from AspNetUsers where UserName = @user)", con);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        cmd.Parameters.AddWithValue("@user", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            res = Convert.ToString(dr[0]);
        }
        con.Close();

        return res;
    }

    protected string returnStatusSecurityUser(string usuario) {
        string res = string.Empty;

        con.Open();
        SqlCommand cmd = new SqlCommand("select Seguridad from Sitios where ID=(select C_Sitio from AspNetUsers where " +
            "UserName = @user)", con);
        cmd.Parameters.AddWithValue("@user", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            res = Convert.ToString(dr[0]);
        }
        con.Close();

        return res;
    }

    protected string searchCommandsStatusAdmin(string sitio, string nivel, string des)
    {
        string json = string.Empty;
        //accionesPintado ap = new accionesPintado();
        List<comandos> ac = new List<comandos>();
        //comandos ac = new comandos();
        con.Open();
        SqlCommand cmd = new SqlCommand("select Comando from Eventos, (select ID from Sitios where Descripcion=@sitio) as a1 " +
            "where Modelo = (select d.modelo from dars d inner join (select ID from UbiDis where Cl_Sitio = a1.ID and " +
            "Nivel1 = (select ID from Nivel1 where Nombre = @nivel and UbiDispo = a1.ID)) as a1 on d.UbiDis = " +
            "a1.ID where d.Descripcion = @desc)", con);
        cmd.Parameters.AddWithValue("@nivel", nivel);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        cmd.Parameters.AddWithValue("@desc", des);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            comandos Object = new comandos();
            Object.accion = Convert.ToString(dr[0]);
            ac.Add(Object);
        }
        con.Close();

        /*ap.acciones = ac;
        string[] peticion = ReturnComm2(sitio, nivel, des);
        try
        {
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("http://"+peticion[0] + "/" + peticion[1] + "/test/");
            using (HttpWebResponse response = (HttpWebResponse)Peticion.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json2 = reader.ReadToEnd();
                if (json2.Contains("Encendido"))
                {
                    ap.pintado = "Encendido";
                }
                else if (json2.Contains("Apagado")) {
                    ap.pintado = "Apagado";
                }
            }

        }
        catch(Exception e)
        {
            //Response.Write(e);
        }*/
        json = JsonConvert.SerializeObject(ac);
        return json;
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

    protected bool insertCommandSQL(string usuario, string desc, string accion, string comando, string nivel)
    {
        bool done = false;

        string riscei = returnRiscei(desc, usuario, nivel);
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
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

    protected string returnRiscei(string desc, string user, string nivel)
    {
        string riscei = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select d.RISCEI from (select C_Sitio from AspNetUsers where UserName=@user) as a1, " +
            "DARS d inner join UbiDis UD on d.UbiDis = UD.Id where UD.Cl_Sitio = a1.C_Sitio and UD.nivel1 = (select ID from Nivel1 " +
            "where Nombre = @nivel and UbiDispo = a1.C_Sitio) and d.Descripcion = @desc", con);
        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@desc", desc);
        cmd.Parameters.AddWithValue("@nivel", nivel);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            riscei = Convert.ToString(dr[0]);
        }
        con.Close();
        return riscei;
    }

    protected string[] returnRisceiTareas(string desc, string user, string nivel)
    {
        string[] riscei = new string[2];
        con.Open();
        SqlCommand cmd = new SqlCommand("select aa1.RISCEI, aa2.NOIP from (select d.RISCEI from (select C_Sitio from AspNetUsers " +
            "where UserName=@user) as a1, DARS d inner join UbiDis UD on d.UbiDis = UD.Id where UD.Cl_Sitio = " +
            "a1.C_Sitio and UD.nivel1 = (select ID from Nivel1 where Nombre = @nivel and UbiDispo = a1.C_Sitio) and " +
            "d.Descripcion = @desc) as aa1, (select NOIP from Sitios where ID = (select C_Sitio from AspNetUsers where " +
            "UserName = @user)) as aa2", con);
        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@desc", desc);
        cmd.Parameters.AddWithValue("@nivel", nivel);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            riscei[0] = Convert.ToString(dr[0]);
            riscei[1] = Convert.ToString(dr[1]);
        }
        con.Close();
        return riscei;
    }

    protected List<eventosAgrupados> ReturnComm(string user, string comando)
    {
        List<eventosAgrupados> ea = new List<eventosAgrupados>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select s.NOIP, c.RISCEI, c.Accion from (select C_Sitio from AspNetUsers where UserName=@user) as aa2, " +
 "Comandos c, (select D.RISCEI from DARS D inner join Ubidis u on u.Id=D.UbiDis where u.Cl_Sitio=(select C_Sitio from AspNetUsers where " +
 "UserName=@user)) as a3, Sitios s where Comando =@comando and s.ID = aa2.C_Sitio and c.RISCEI=a3.RISCEI", con);
        cmd.Parameters.AddWithValue("@comando", comando);
        cmd.Parameters.AddWithValue("@user", user);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            eventosAgrupados ea2 = new eventosAgrupados();
            ea2.noip = Convert.ToString(dr[0]);
            ea2.dispositivo = Convert.ToString(dr[1]);
            ea2.accion = Convert.ToString(dr[2]);
            ea.Add(ea2);
        }
        con.Close();
        return ea;
    }

    protected string[] ReturnComm2(string sitio, string nivel, string desc)
    {
        string[] com = new string[2];
        con.Open();
        SqlCommand cmd = new SqlCommand("select s.NOIP, d.RISCEI from dars d, Sitios s, UbiDis u, (select ID from Sitios " +
            "where Descripcion =@sitio) as a1 where s.ID = a1.ID and d.Descripcion = @desc and " +
            "(d.UbiDis = u.Id and u.Cl_Sitio = a1.ID and u.Nivel1 = (select ID from Nivel1 where Nombre = @nivel and UbiDispo = a1.ID))", con);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        cmd.Parameters.AddWithValue("@nivel", nivel);
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
    protected string ReturnDispositivos(string user, string nivel)
    {
        string json = String.Empty;
        List<Disposis> dispositivo = new List<Disposis>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select d.Descripcion from (select C_Sitio from AspNetUsers where UserName=@user) as a1, " +
            "DARS d inner join UbiDis UD on d.UbiDis = UD.Id where UD.Cl_Sitio = a1.C_Sitio and UD.nivel1 = (select ID from Nivel1 where " +
            "Nombre = @nivel and UbiDispo = a1.C_Sitio) and(d.Modelo = 'DAR-BIS-VA/LE/LU/LS' or d.Modelo = 'DAR-BIS-HW' or d.Modelo ='DAR-BIS-MP')", con);
        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@nivel", nivel);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Disposis Object = new Disposis();
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
        List<comandos> coma = new List<comandos>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select Comando from Eventos where Modelo=(select d.modelo from dars d inner join " +
            "(select ID from UbiDis where Cl_Sitio=(select C_Sitio from AspNetUsers where UserName=@user)) as a1 on d.UbiDis=a1.ID " +
            "where d.Descripcion=@desc)", con);
        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@desc", des);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            comandos Object = new comandos();
            Object.accion = Convert.ToString(dr[0]);
            coma.Add(Object);
        }
        con.Close();
        json = JsonConvert.SerializeObject(coma);
        return json;
    }

    protected string searchCommands(string user, string des, string nivel)
    {
        string json = string.Empty;
        List<accioness> ac = new List<accioness>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select com.Comando, com.Accion from Comandos com inner join (select d.RISCEI from " +
            "(select C_Sitio from AspNetUsers where UserName=@user) as a1, DARS d inner join UbiDis UD on d.UbiDis = UD.Id where " +
            "UD.Cl_Sitio = a1.C_Sitio and UD.nivel1 = (select ID from Nivel1 where Nombre = @nivel and UbiDispo = a1.C_Sitio) and " +
            "d.Descripcion = @desc) as a1 on a1.RISCEI = com.RISCEI", con);
        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@desc", des);
        cmd.Parameters.AddWithValue("@nivel", nivel);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            accioness Object = new accioness();
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

    protected void insertarD(String nombre, String dispositivo, string evento, int hora, int minutos, DateTime std, string url, string tipo)
    {
        String status = "Activo";
        SqlConnection sqlConnection1 = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "INSERT automatizado (Nombre, dispositivo, Evento, Hora, Minuto, Fecha, status, url, Tipo) VALUES (@nombre, @dispositivo,@Evento, @hora, @minutos, @std, @status,@url,@tipo)";
        cmd.Parameters.AddWithValue("@nombre", nombre);
        cmd.Parameters.AddWithValue("@dispositivo", dispositivo);
        cmd.Parameters.AddWithValue("@Evento", evento);
        cmd.Parameters.AddWithValue("@hora", hora);
        cmd.Parameters.AddWithValue("@minutos", minutos);
        cmd.Parameters.AddWithValue("@std", std);
        cmd.Parameters.AddWithValue("@status", status);
        cmd.Parameters.AddWithValue("@url", url);
        cmd.Parameters.AddWithValue("@tipo", tipo);
        cmd.Connection = sqlConnection1;
        sqlConnection1.Open();
        cmd.ExecuteNonQuery();
        sqlConnection1.Close();
    }

    protected void insertarDi(String nombre, String dispositivo, string evento, int hora, int minutos, DateTime std, string url, string tipo)
    {
        String status = "Activo";
        SqlConnection sqlConnection1 = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "INSERT automatizado (Nombre, dispositivo, Evento, Hora, Minuto,Fecha, status, url, Tipo) VALUES (@nombre, @dispositivo,@Evento, @hora, @minutos, @std, @status, @url, @tipo)";
        cmd.Parameters.AddWithValue("@nombre", nombre);
        cmd.Parameters.AddWithValue("@dispositivo", dispositivo);
        cmd.Parameters.AddWithValue("@Evento", evento);
        cmd.Parameters.AddWithValue("@hora", hora);
        cmd.Parameters.AddWithValue("@minutos", minutos);
        cmd.Parameters.AddWithValue("@std", std);
        cmd.Parameters.AddWithValue("@status", status);
        cmd.Parameters.AddWithValue("@url", url);
        cmd.Parameters.AddWithValue("@tipo", tipo);
        cmd.Connection = sqlConnection1;
        sqlConnection1.Open();
        cmd.ExecuteNonQuery();
        sqlConnection1.Close();
    }

    protected void sendTelegramSec(string usuario, string seguridad)
    {
        ArrayList lista = new ArrayList();
        con.Open();
        string sitio = string.Empty;
        SqlCommand cmd = new SqlCommand("select c.CanalTelegram, S.Descripcion from Sitios S, CanalTelegram c inner join " +
            "AspNetUsers us on c.Usuario = us.UserName inner join AspNetRoles r on r.Id = us.Id_Rol inner join PermisoRol pr " +
            "on pr.ID_Rol = r.Id where pr.ID_Permiso = 36 and c.ID_Sitio = (select C_Sitio from AspNetUsers where " +
            "UserName = @user) and c.Primario = 'Primario'and S.ID = c.ID_Sitio", con);
        cmd.Parameters.AddWithValue("@user", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            lista.Add(Convert.ToString(dr[0]));
            sitio = Convert.ToString(dr[1]);
        }
        con.Close();

        string token = "465931710:AAHAY4-x6ZozrHPWkLfy9t7UUrcJX6Q61bw";
        //string[] id = { "485219307", "401967737", "462385749" };
        string mensaje = "El usuario " + usuario + " ha colocado el sistema en estado " + seguridad + " de la ubicacion " + sitio;

        for (int i = 0; i < lista.Count; i++)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + lista[i] + "&text=" + mensaje);
            Peticion.GetResponse();
        }


    }

    protected void sendTelegramSecAdm(string usuario, string seguridad, string sitio)
    {
        ArrayList lista = new ArrayList();
        con.Open();
        SqlCommand cmd = new SqlCommand("select c.CanalTelegram from CanalTelegram c inner join AspNetUsers us on c.Usuario " +
            "= us.UserName inner join AspNetRoles r on r.Id = us.Id_Rol inner join PermisoRol pr on pr.ID_Rol = r.Id " +
            "where pr.ID_Permiso = 36 and us.UserName = @usuario and c.ID_Sitio = (select ID from Sitios where " +
            "Descripcion = @sitio and ID_cliente = (select ID_Cliente from AspNetUsers where UserName = @usuario)) " +
            "and c.Primario = 'Primario'", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            lista.Add(Convert.ToString(dr[0]));
        }
        con.Close();

        string token = "465931710:AAHAY4-x6ZozrHPWkLfy9t7UUrcJX6Q61bw";
        //string[] id = { "485219307", "401967737", "462385749" };
        string mensaje = "El usuario " + usuario + " ha colocado el sistema en estado " + seguridad + " de la ubicacion " + sitio;

        for (int i = 0; i < lista.Count; i++)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + lista[i] + "&text=" + mensaje);
            Peticion.GetResponse();
        }


    }

    protected string searchCommandsStatus(string user, string des)
    {
        string json = string.Empty;
        //accionesPintado ap = new accionesPintado();
        List<comandos> coma = new List<comandos>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select Comando from Eventos where Modelo=(select d.modelo from dars d inner join " +
            "(select ID from UbiDis where Cl_Sitio=(select C_Sitio from AspNetUsers where UserName=@user)) as a1 on d.UbiDis=a1.ID " +
            "where d.Descripcion=@desc)", con);
        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@desc", des);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            comandos Object = new comandos();
            Object.accion = Convert.ToString(dr[0]);
            coma.Add(Object);
        }
        con.Close();
        /*ap.acciones = coma;
        string[] peticion = ReturnComm2Adm(user, des);
        try
        {
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("http://" + peticion[0] + "/" + peticion[1] + "/test/");
            using (HttpWebResponse response = (HttpWebResponse)Peticion.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json2 = reader.ReadToEnd();
                if (json2.Contains("Encendido"))
                {
                    ap.pintado = "Encendido";
                }
                else if (json2.Contains("Apagado"))
                {
                    ap.pintado = "Apagado";
                }
            }
        }
        catch
        {
            
        }*/
        json = JsonConvert.SerializeObject(coma);
        return json;
    }

    /*-----------------------------------------------------------------------------------------------------------
-----------------------------------------------FUNCIONES MISCELANEA------------------------------------------
-----------------------------------------------------------------------------------------------------------*/

    protected int returnMes(string mes)
    {
        int mess = 0;

        switch (mes)
        {
            case "Enero":
                mess = 1;
                break;
            case "Febrero":
                mess = 2;
                break;
            case "Marzo":
                mess = 3;
                break;
            case "Abril":
                mess = 4;
                break;
            case "Mayo":
                mess = 5;
                break;
            case "Junio":
                mess = 6;
                break;
            case "Julio":
                mess = 7;
                break;
            case "Agosto":
                mess = 8;
                break;
            case "Septiembre":
                mess = 9;
                break;
            case "Octubre":
                mess = 10;
                break;
            case "Noviembre":
                mess = 11;
                break;
            case "Diciembre":
                mess = 12;
                break;
        }
        return mess;
    }

    protected void asistenteDeVidaUsuario(string usuario, string comandoCentinela, string chelas) {
        string resultado = string.Empty;

        resultado = programmRuleTempUser(usuario, chelas);
        if (resultado == "True")
            Response.Write(resultado);
        else
            avisoLLegada(usuario, comandoCentinela, 1, "");
    }

    protected void asistenteDeVidaAdministrador(string sitio, string usuario, string comandoCentinela, string chelas) {
        string resultado = string.Empty;
        resultado = programmRuleTempAdm(usuario, sitio, chelas);
        if (resultado == "True")
            Response.Write(resultado);
        else
            avisoLLegada(usuario, comandoCentinela, 2, sitio);
    }

    protected void avisoLLegada(string usuario, string comando, int tipo, string sitio)
    {
        comando = returnCadena(comando);
        int contador = 0;
        List<Empleado> resultado = returnEmpleados(usuario, tipo, sitio);
        List<int> numeros = returnNames(resultado, comando), segundos;
        contador = numeros.Count;
        //Response.Write(contador+ " "+comando);
        if (contador == 1)
        {
            //Response.Write(resultado[numeros[0]].IDEmpleado + " " + resultado[numeros[0]].nombreEmpleado + " " + resultado[numeros[0]].apellidoEmpleado);
            if (programRule(resultado[numeros[0]].IDEmpleado, usuario))
                Response.Write("True");
            else
                Response.Write("False");
        }
        else if (contador > 1)
        {
            segundos = returnSurnames(resultado, comando, numeros);
            if (segundos.Count == 1)
            {
                //Response.Write(resultado[segundos[0]].IDEmpleado + " " + resultado[segundos[0]].nombreEmpleado + " " + resultado[segundos[0]].apellidoEmpleado);
                if (programRule(resultado[segundos[0]].IDEmpleado, usuario))
                    Response.Write("True");
                else
                    Response.Write("False");
            }
            else if (segundos.Count > 1)
                Response.Write("False");
            else
                Response.Write("False");
        }

        else
            Response.Write("False");
    }

    protected bool programRule(int id, string usuario)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("if(select COUNT(ID) from CanalEmpleados where ID_Empleado = " +
                "@id and ID_Telegram in (select CanalTelegram from CanalTelegram where Usuario = @usuario)) >= 1 " +
                "begin update CanalEmpleados set Estatus = 'Habilitado' where ID_Empleado = @id and Tipo = " +
                "'Unico' and ID_Telegram in (select CanalTelegram from CanalTelegram where Usuario = " +
                "@usuario and Primario = 'Primario') end " +
                "else begin insert into CanalEmpleados(ID_Sitio, ID_empleado, ID_Telegram, Tipo, Estatus) values " +
                "((select Sitio from Empleado where ID = @id ), @id, (select CanalTelegram from CanalTelegram where " +
                "Usuario = @usuario and Primario = 'Primario' and ID_Sitio = (select Sitio from Empleado where " +
                "ID = @id)), 'Unico', 'Habilitado') end", con);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch (Exception e)
        {
            Response.Write(e);
            return false;
        }
    }

    protected List<int> returnNames(List<Empleado> resultado, string comando)
    {
        List<int> num = new List<int>();
        int contador = 0;
        string auxiliar = string.Empty, auxiliar2 = string.Empty;
        contador = resultado.Count;
        if (contador > 0)
        {
            for (int i = 0; i < contador; i++)
            {
                auxiliar = resultado[i].nombreEmpleado.ToUpper();
                if (comando.Contains(auxiliar))
                {
                    num.Add(i);

                }
            }
        }
        return num;
    }

    protected List<int> returnSurnames(List<Empleado> resultado, string comando, List<int> ides)
    {
        List<int> num = new List<int>();
        int contador = 0;
        string auxiliar = string.Empty, auxiliar2 = string.Empty;
        contador = ides.Count;
        if (contador > 0)
        {
            for (int i = 0; i < contador; i++)
            {
                auxiliar = resultado[ides[i]].apellidoEmpleado.ToUpper();
                if (comando.Contains(auxiliar))
                {
                    num.Add(ides[i]);
                }
            }
        }
        return num;
    }

    protected List<Empleado> returnEmpleados(string usuario, int tipo, string sitio)
    {
        List<Empleado> e = new List<Empleado>();
        con.Open();
        SqlCommand cmd;
        string query = string.Empty;
        if (tipo == 1)
        {
            query = "select ID, Nombre, Apellidos from Empleado where Sitio = " +
            "(select C_Sitio from AspNetUsers where UserName = @usuario)";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@usuario", usuario);
        }

        else
        {
            query = "select ID, Nombre, Apellidos from Empleado where Sitio in " +
                "(select ID from Sitios where Descripcion = @sitio and ID_Cliente = " +
                "(select ID_Cliente from AspNetUsers where UserName = @usuario))";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@sitio", sitio);
        }
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Empleado ob = new Empleado();
            ob.IDEmpleado = Convert.ToInt32(dr[0]);
            ob.nombreEmpleado = Convert.ToString(dr[1]);
            ob.apellidoEmpleado = Convert.ToString(dr[2]);
            e.Add(ob);
        }
        con.Close();
        return e;
    }
    public class Empleado
    {

        public int IDEmpleado { get; set; }
        public string nombreEmpleado { get; set; }
        public string apellidoEmpleado { get; set; }
    }
    protected string returnCadena(string comando)
    {
        comando = comando.Replace("á", "a");
        comando = comando.Replace("Á", "A");
        comando = comando.Replace("é", "e");
        comando = comando.Replace("É", "e");
        comando = comando.Replace("í", "i");
        comando = comando.Replace("Í", "i");
        comando = comando.Replace("ó", "o");
        comando = comando.Replace("Ó", "o");
        comando = comando.Replace("ú", "u");
        comando = comando.Replace("Ú", "u");
        return comando;
    }
    protected bool activarDAR1(string usuario, string estatus)
    {
        bool acciones = false;
        ArrayList noips = new ArrayList();
        con.Open();
        string pas = string.Empty, url = string.Empty;
        SqlCommand cmd = new SqlCommand("if(select MultipleNOIP from Sitios where ID=(select C_Sitio from AspNetUsers where UserName = " +
            "@user)) = 0 begin select NOIP from Sitios where ID = (select C_Sitio from AspNetUsers where UserName = " +
            "@user) end else select n1.NOIP from Nivel1 n1 inner join Sitios s on s.ID = n1.UbiDispo where s.ID = " +
            "(select C_Sitio from AspNetUsers where UserName = @user)", con);
        cmd.Parameters.AddWithValue("@user", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            noips.Add(Convert.ToString(dr[0]));
        }
        con.Close();
        for (int a = 0; a < noips.Count; a++)
        {
            url = "https://addar.mx/Especiales/alarmaPeticion.php?v1=" + noips[a] + "&v2=" + estatus;

            string uri = returnResponseValue(url);
            if (uri == "True")
                acciones = true;
            else {
                acciones = false;
                a = noips.Count + 1;
            }
        }
        return acciones;
    }

    protected bool activarDAR1Adm(string sitio, string estatus)
    {
        bool acciones = false;
        ArrayList noips = new ArrayList();
        con.Open();
        string pas = string.Empty, url = string.Empty;
        SqlCommand cmd = new SqlCommand("if(select MultipleNOIP from Sitios where Descripcion = @user) = 0 begin " +
            "select NOIP from Sitios where Descripcion = @user end else select n1.NOIP from Nivel1 n1 inner " +
            "join Sitios s on s.ID = n1.UbiDispo where s.Descripcion = @user", con);
        cmd.Parameters.AddWithValue("@user", sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            noips.Add(Convert.ToString(dr[0]));
        }
        con.Close();
        for (int a = 0; a < noips.Count; a++)
        {
            url = "https://addar.mx/Especiales/alarmaPeticion.php?v1=" + noips[a] + "&v2=" + estatus;

            string uri = returnResponseValue(url);
            if (uri == "True")
                acciones = true;
            else {
                acciones = false;
                a = noips.Count + 1;
            }
        }
        return acciones;
    }

    /*-----------------------------------------------------------------------------------------------------------
 -----------------------------------------------------Favoritos------------------------------------------------
 -----------------------------------------------------------------------------------------------------------*/
    /*-----------------ADMINISTRADOR--------------------*/
    protected void insertFavoritos()
    {
        string usuario = string.Empty, dis = string.Empty, sitio = string.Empty;
        usuario = Request["user"];
        dis = Request["dispositivo"];
        sitio = Request["site"];

        if (sitio != null)
        {
            if (insertFavoritosSQL(usuario, dis, sitio))
                Response.Write("True");
            else
                Response.Write("False");
        }
        else
        {
            if (insertFavoritosUserSQL(usuario, dis))
                Response.Write("True");
            else
                Response.Write("False");
        }
    }

    /*-----------------QUITAR LISTA ---------------------*/
    protected void deleteFavoritos()
    {
        string dispositivo = string.Empty, user = string.Empty, sitio = string.Empty;
        user = Request["user"];
        dispositivo = Request["dispo"];
        sitio = Request["site"];
        if (EliminarFavSQL(user, dispositivo, sitio))
            Response.Write("True");
        else
            Response.Write("False");
    }
    /*----------------NOMBRE DE DISPOSITIVOS ADMINI-------------*/
    protected void returnDispo()
    {
        string nom = string.Empty, res = string.Empty;

        nom = Request["user"];
        res = returndispo(nom);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(res);
    }

    /*--------------------------------------------------------------------------------------------------
   -------------------SECCION DE CONSULTAS ADMIN--------------------------------------
   --------------------------------------------------------------------------------------------------*/

    /*----------------INSERCCION DE DISPOSITIVO ADMINISTRADOR---------- */
    protected bool insertFavoritosSQL(string usuario, string desc, string sitio)
    {
        bool done = false;

        string riscei = returnRisceiFav(desc, usuario, sitio);
        //Response.Write(riscei+sitio+usuario);
        try
        {
            SqlCommand cmd = new SqlCommand("if (select count(RISCEI) from Favoritos where usuario = @usuario) >= 4" +
          " select 'False' else insert Favoritos(RISCEI, Sitio, Usuario) values(@RISCEI, @sitio, @usuario)", con); ;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "INSERT Favoritos (RISCEI,Sitio,Usuario) VALUES (@RISCEI, @sitio, @usuario)";
            cmd.Parameters.AddWithValue("@RISCEI", riscei);
            cmd.Parameters.AddWithValue("@sitio", sitio);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            done = true;
        }
        catch (SqlException e)
        {
            Response.Write(e);
        }
        return done;
    }
    /*----------------RETORNA EL RISCEI DE DISPOSITIVO---------- */
    protected string returnRisceiFav(string desc, string user, string sitio)
    {
        string riscei = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select d.RISCEI from DARS d inner join (select ID from UbiDis where Cl_Sitio = (select ID from Sitios where Descripcion = @sitio and ID_Cliente = (select ID_Cliente from AspNetUsers where UserName = @user)) and Cl_Cliente = (select ID_Cliente from AspNetUsers where UserName = @user)) as a1 on a1.Id = d.UbiDis where d.Descripcion = @desc", con);
        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@desc", desc);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            riscei = Convert.ToString(dr[0]);
        }
        con.Close();
        return riscei;
    }

    /*----------------ELIMINA LISTA DE FAVORITOS ADMIN---------- */
    protected bool EliminarFavSQL(string user, string desc, string sitio)
    {
        bool done = false;

        string riscei = returnRisceiFavDos(desc, user, sitio);
        try
        {
            SqlCommand cmd = new SqlCommand("delete Favoritos where Usuario = @user and sitio = @sitio and RISCEI= @riscei", con);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@riscei", riscei);
            cmd.Parameters.AddWithValue("@sitio", sitio);
            //SqlDataReader dr = cmd.ExecuteReader();
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
    /*----------------RETORNA LA DESCRIPCION  DE DISPOSITIVO---------- */
    protected string returnRisceiFavDos(string desc, string user, string sitio)
    {
        string risce = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select f.RISCEI from Favoritos f inner join dars d on f.RISCEI = d.RISCEI where f.Usuario = @user  and d.Descripcion = @desc and f.Sitio = @sitio", con);
        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@desc", desc);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            risce = Convert.ToString(dr[0]);
        }
        con.Close();
        return risce;
    }
    /*----------------JSON PARA NOMBRE DE DISPO ADMIN------- */
    protected string returndispo(string usuario)
    {
        string json = string.Empty;
        List<Disposi> diss = new List<Disposi>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select d.Descripcion, f.Sitio from dars d inner join Favoritos f on d.RISCEI= f.RISCEI where usuario = @usuario", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Disposi objects = new Disposi();
            objects.nombre = Convert.ToString(dr[0]);
            objects.sitio = Convert.ToString(dr[1]);
            diss.Add(objects);
        }
        json = JsonConvert.SerializeObject(diss);
        con.Close();
        return json;
    }
    /*---------------Generalizacion de botones Usuario y Admin-----------*/
    protected void returnFavoritos()
    {
        string usuario = Request["usuario"];
        string resultado = null;
        List<dispositivo2> dis = new List<dispositivo2>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select f.RISCEI, d.Descripcion,f.Sitio from favoritos f inner join dars d on d.RISCEI=f.RISCEI where f.Usuario = @user", con);
        cmd.Parameters.AddWithValue("@user", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            string dar = Convert.ToString(dr[0]);
            List<comandosFav> comando = new List<comandosFav>();
            dispositivo2 dis2 = new dispositivo2();
            con2.Open();
            SqlCommand cmd1 = new SqlCommand("select comando from Eventos where Modelo=(select Modelo from DARS where RISCEI = @riscei)", con2);
            cmd1.Parameters.AddWithValue("@riscei", dar);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comandosFav com = new comandosFav();
                com.comando = Convert.ToString(dr1[0]);
                comando.Add(com);
            }
            dis2.descripcion = Convert.ToString(dr[1]);
            dis2.site = Convert.ToString(dr[2]);
            dis2.Listacomandos = comando;
            dis.Add(dis2);
            con2.Close();
        }
        con.Close();
        resultado = JsonConvert.SerializeObject(dis);
        Response.ContentType = "application/JSON; charset=UTF-8;";
        Response.Write(resultado);
    }

    /*--------------------------------------------------------------------------------------------------
    -------------------SECCION DE CONSULTAS USUARIO-------------------------------------
   -------------------------------------------------------------------------------------------------*/

    protected void deleteFavoritosUser()
    {
        string dispositivo = string.Empty, user = string.Empty, sitio = string.Empty;
        user = Request["user"];
        dispositivo = Request["dispo"];
        sitio = Request["site"];
        if (EliminarFavUsersSQL(user, dispositivo, sitio))
            Response.Write("True");
        else
            Response.Write("False");
    }
    protected void returnDispoUser()
    {
        string nom = string.Empty, res = string.Empty;

        nom = Request["user"];
        res = returndispoUser(nom);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(res);
    }
    protected void doCommandFavoritosUserAd()
    {
        string usuario = string.Empty, dispositivo = string.Empty, accion = string.Empty, estatus = string.Empty, sitio = string.Empty;
        usuario = Request["user"];
        sitio = Request["sitio"];
        dispositivo = Request["dispositivo"];
        accion = Request["accion"];
        string[] peticion = ReturnCommUserAd(usuario, sitio, dispositivo);
        try
        {
            WebRequest Peticion = default(WebRequest);
            string url = "https://addar.mx/Especiales/peticion2.php?v1=" + peticion[0] + "&v2=" + peticion[1] + "&v3=" + accion;
            Peticion = WebRequest.Create(url);

            /*using (HttpWebResponse response = (HttpWebResponse)Peticion.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json2 = reader.ReadToEnd();
                if (json2.Contains("Encendido"))
                {
                    estatus = "Encendido";
                }
                else if (json2.Contains("Apagado"))
                {
                    estatus = "Apagado";
                }
            }*/
            Peticion.GetResponseAsync();
            estatus = "True";

        }
        catch
        {
            estatus = "False";
        }

        Response.Write(estatus);
    }

    /*----------------INSERCCION DE DISPOSITIVO DE USUARIO---------- */
    protected bool insertFavoritosUserSQL(string usuario, string dispositivo)
    {
        bool done = false;

        string riscei = returnRisceiFavUsers(dispositivo, usuario);
        try
        {
            SqlCommand cmd = new SqlCommand("if(select count(RISCEI) from Favoritos where usuario = @usuario) >= 4 select 'False' else insert Favoritos(RISCEI, Sitio, Usuario) values(@dis, (select descripcion from Sitios where ID=(select C_Sitio from AspNetUsers where userName = @usuario)), @usuario)", con); ;
            cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "INSERT Favoritos (RISCEI,Sitio,Usuario) VALUES (@RISCEI, @sitio, @usuario)";
            cmd.Parameters.AddWithValue("@dis", riscei);
            cmd.Parameters.AddWithValue("@usuario", usuario);
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
    /*----------------RETORNA EL RICEI DE DISPOSITIVO USUARIO---------- */
    protected string returnRisceiFavUsers(string desc, string user)
    {
        string riscei = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select d.RISCEI from DARS d inner join (select ID from UbiDis where Cl_Sitio=(select C_Sitio from AspNetUsers" +
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
    /*----------------ELIMINA LISTA  DE FAVORITOS USUARIO--------- */
    protected bool EliminarFavUsersSQL(string user, string desc, string sitio)
    {

        bool done = false;

        string riscei = returnRisceiFavDosUser(desc, user, sitio);
        try
        {
            SqlCommand cmd = new SqlCommand("delete Favoritos where Usuario = @user and sitio = @sitio and RISCEI= @riscei", con);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@riscei", riscei);
            cmd.Parameters.AddWithValue("@sitio", sitio);
            //SqlDataReader dr = cmd.ExecuteReader();
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
    /*----------------RETORNA LA DESCRIPCION  DE DISPOSITIVO USUARIO---------- */
    protected string returnRisceiFavDosUser(string desc, string user, string sitio)
    {
        string risce = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select f.RISCEI from Favoritos f inner join dars d on f.RISCEI = d.RISCEI where f.Usuario = @user  and d.Descripcion = @desc and f.Sitio = @sitio", con);
        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@desc", desc);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            risce = Convert.ToString(dr[0]);
        }
        con.Close();
        return risce;
    }
    /*---------------JSON PARA NOMBRE DE DISPO USUARIO------- */
    protected string returndispoUser(string usuario)
    {

        string json = string.Empty;
        List<Disposi> diss = new List<Disposi>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select d.Descripcion, f.Sitio from dars d inner join Favoritos f on d.RISCEI= f.RISCEI where usuario = @usuario", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Disposi objects = new Disposi();
            objects.nombre = Convert.ToString(dr[0]);
            objects.sitio = Convert.ToString(dr[1]);
            diss.Add(objects);
        }
        
        json = JsonConvert.SerializeObject(diss);
        con.Close();
        return json;
    }

    /*------------------------------------------CONSULTAS DE CHELAS ADM Y USUARIO :v-------------------------------------*/
    protected string returnRulesUser(string usuario) {
        List<reglaUmbral> reglaumbral = new List<reglaUmbral>();
        string json = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select Nombre from ReglaUmbral where CanalTelegram in " +
            "(select CanalTelegram from CanalTelegram where Usuario = @usuario)", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            reglaUmbral ru = new reglaUmbral();
            ru.nombreRegla = Convert.ToString(dr[0]);
            reglaumbral.Add(ru);
        }
        json = JsonConvert.SerializeObject(reglaumbral);
        con.Close();
        return json;
    }
    protected bool insertCommandRulesUser(string usuario, string regla, string comando) {
        con.Open();
        SqlCommand cmd = new SqlCommand("update ReglaUmbral set ComandoVoz = @comando where Nombre = " +
            "@nombre and CanalTelegram in (select CanalTelegram from CanalTelegram where Usuario = @usuario)", con);
        cmd.Parameters.AddWithValue("@comando", comando);
        cmd.Parameters.AddWithValue("@nombre", regla);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        try
        {
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch {
            return false;
        }

    }
    protected string returnRulesGridUserQuery(string usuario)
    {
        string json = string.Empty;
        con.Open();
        List<reglaUmbralGrid> ru = new List<reglaUmbralGrid>();
        SqlCommand cmd = new SqlCommand("select Nombre, ComandoVoz from ReglaUmbral where CanalTelegram in " +
            "(select CanalTelegram from CanalTelegram where Usuario = @usuario and ID_Sitio = " +
            "(select C_Sitio from AspNetUsers where UserName = @usuario))", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            reglaUmbralGrid rug = new reglaUmbralGrid();
            rug.Regla = Convert.ToString(dr[0]);
            rug.Comando = Convert.ToString(dr[1]);
            ru.Add(rug);
        }
        con.Close();
        json = JsonConvert.SerializeObject(ru);

        return json;
    }
    protected bool  programmRuleTempUserQuery(string comando, string usuario) {
        bool flag = false;
        int i = 0;
        con.Open();
        SqlCommand cmd = new SqlCommand("update ReglaUmbral set Estatus = 'Habilitado' where ComandoVoz = " +
            "@comando and CanalTelegram in (select CanalTelegram from CanalTelegram where Usuario = " +
            "@usuario and ID_Sitio = (select C_Sitio from AspNetUsers where UserName = @usuario))", con);
        cmd.Parameters.AddWithValue("@comando", comando);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        try
        {
            i = cmd.ExecuteNonQuery();
            if(i >= 1)
            flag = true;
            con.Close();
        }
        catch
        {
            return false;
        }
        return flag;
    }
    protected bool insertCommandRulesAdm(string usuario, string sitio, string regla, string comando) {
        con.Open();
        SqlCommand cmd = new SqlCommand("update ReglaUmbral set ComandoVoz = @comando where Nombre = " +
            "@nombre and CanalTelegram in (select CanalTelegram from CanalTelegram where Usuario = @usuario " +
            "and ID_Sitio = (select ID from Sitios where Descripcion = @sitio and " +
            "ID_cliente = (select ID_cliente from AspNetUsers where UserName = @usuario)))", con);
        cmd.Parameters.AddWithValue("@comando", comando);
        cmd.Parameters.AddWithValue("@nombre", regla);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        try
        {
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected string returnRulesGridAdmQuery(string usuario, string sitio)
    {
        string json = string.Empty;
        con.Open();
        List<reglaUmbralGrid> ru = new List<reglaUmbralGrid>();
        SqlCommand cmd = new SqlCommand("select Nombre, ComandoVoz from ReglaUmbral where CanalTelegram in " +
            "(select CanalTelegram from CanalTelegram where Usuario = @usuario and ID_Sitio = " +
            "(select ID from Sitios where Descripcion = @sitio and " +
            "ID_cliente = (select ID_Cliente from AspNetUsers where UserName = @usuario)))", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            reglaUmbralGrid rug = new reglaUmbralGrid();
            rug.Regla = Convert.ToString(dr[0]);
            rug.Comando = Convert.ToString(dr[1]);
            ru.Add(rug);
        }
        con.Close();
        json = JsonConvert.SerializeObject(ru);

        return json;
    }
    protected string returnRulesAdm(string usuario, string sitio) {
        List<reglaUmbral> reglaumbral = new List<reglaUmbral>();
        string json = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select Nombre from ReglaUmbral where CanalTelegram in " +
            "(select CanalTelegram from CanalTelegram where Usuario = @usuario and ID_Sitio = " +
            "(select ID from Sitios where Descripcion = @sitio and ID_cliente = " +
            "(select ID_cliente from AspNetUsers where UserName = @usuario)))", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            reglaUmbral ru = new reglaUmbral();
            ru.nombreRegla = Convert.ToString(dr[0]);
            reglaumbral.Add(ru);
        }
        json = JsonConvert.SerializeObject(reglaumbral);
        con.Close();
        return json;
    }
    protected bool programmRuleTempAdmQuery(string usuario, string comando, string sitio) {
        bool flag = false;
        int i = 0;
        con.Open();
        SqlCommand cmd = new SqlCommand("update ReglaUmbral set Estatus = 'Habilitado' where ComandoVoz = " +
            "@comando and CanalTelegram in (select CanalTelegram from CanalTelegram where Usuario = @usuario and ID_Sitio = " +
            "(select ID from Sitios where Descripcion = @sitio and ID_Cliente = (select ID_Cliente from " +
            "AspNetUsers where UserName = @usuario)))", con);
        cmd.Parameters.AddWithValue("@comando", comando);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        try
        {
            i = cmd.ExecuteNonQuery();
            if (i >= 1)
                flag = true;
            con.Close();
        }
        catch
        {
            return false;
        }
        return flag;
    }

    /*------------------------------------------TERMINAN CHELAS CONSULTAS-------------------------------------------------*/

    /*----------------RETORNA ACCIONES DE USUARIO y ADMINISTRADOR -------------*/
    protected string[] ReturnCommUserAd(string usuario, string sitio, string desc)
    {
        string[] com = new string[2];
        con.Open();
        SqlCommand cmd = new SqlCommand("select a1.NOIP, d.RISCEI from (select NOIP from Sitios where Descripcion = @sitio and ID_cliente=(select ID_Cliente from AspNetUsers where userName = @user)) as a1, DARS d inner join Favoritos f on f.RISCEI = d.RISCEI where f.Usuario = @user and d.Descripcion = @desc and f.Sitio = @sitio", con);
        cmd.Parameters.AddWithValue("@user", usuario);
        cmd.Parameters.AddWithValue("@sitio", sitio);
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

    protected string returnNOIP(string usuario, string descripcion, int tipo) {
        string noip = string.Empty, query = string.Empty;
        con.Open();
        SqlCommand cmd;
        if (tipo == 1) {
            query = "select NOIP from sitios where ID=(select C_Sitio from AspnetUsers where UserName = @usuario)";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@usuario", usuario);
        }
        else
        {
            query = "select NOIP from sitios where ID_cliente=(select ID_Cliente from AspnetUsers where UserName = @usuario)" +
                " and Descripcion = @descripcion";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
        }

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            noip = Convert.ToString(dr[0]);
        }
        con.Close();
        return noip;
    }

    /*---------------------------Tareas predeterminadas Usuario/Admin*-----------------------------*/

    /*----------------TARERAS PREDETERMINADAS ADMIN-------------*/
    protected void programmTasKPredeAdmi()
    {
        string sitio = string.Empty, nivel = string.Empty, dispositivo = string.Empty, accion = string.Empty, nombre = string.Empty, url = string.Empty, nombreR = string.Empty;
        string i = string.Empty, m = string.Empty, pet = string.Empty;
        string[] dis = new string[2];
        int hora = 0, min = 0, mes = 0, dia = 0, min2 = 0;
        sitio = Request["sitio"];
        nivel = Request["nivel"];
        dispositivo = Request["dispositivo"];
        dis = returnRisceiAd2(sitio, nivel, dispositivo);
        accion = Request["accion"];
        min = Convert.ToInt32(Request["minuto"]);
        DateTime fechita = DateTime.Now;
        nombre = fechita + dis[0];
        //url = direccion(dis, accion);
        // Response.Write(dis);
        switch (min)
        {
            case 0:
                string[] peticion = ReturnComm2(sitio, nivel, dispositivo);
                //Response.Write(peticion[0] + peticion[1]);
                try
                {
                    WebRequest Peticion = default(WebRequest);
                    Peticion = WebRequest.Create("https://addar.mx/Especiales/peticion2.php?v1=" + peticion[0] + "&v2=" + peticion[1] + "&v3=" + accion);
                    Peticion.GetResponseAsync();
                    Response.Write("True");
                }
                catch
                {
                    Response.Write("False");
                }
                break;
            case 1:
                fechita = fechita.AddMinutes(1);
                break;
            case 5:
                fechita = fechita.AddMinutes(5);
                break;
            case 10:
                fechita = fechita.AddMinutes(10);
                break;
            case 30:
                fechita = fechita.AddMinutes(30);
                break;
            case 60:
                fechita = fechita.AddHours(1);
                break;
            case 120:
                fechita = fechita.AddHours(2);
                break;
            case 240:
                fechita = fechita.AddHours(4);
                break;
            case 600:
                fechita = fechita.AddHours(10);
                break;
        }
        if (min > 0)
        {
            hora = fechita.Hour;
            min2 = fechita.Minute;
            mes = fechita.Month;
            dia = fechita.Day;
            pet = "http://" + dis[1] + "/cronPhp/agregarTarea.php?min=" + min2 + "&hrs=" + hora + "&dias=" + dia + "&meses=" + mes + "&dSem=*&comando=localhost/rest.php?riscei=" + dis[0] + ",evento=" + accion;
            try
            {
                url = returnResponseValue(pet);
                insertarD(nombre, dis[0], accion, hora, min2, fechita, url, "Predeterminada");
                //Response.Write(pet);
                Response.Write("True");
            }
            catch {
                Response.Write("False");
            }
        }
    }

    protected string[] returnRisceiAd2(string site, string nivel, string desc)
    {
        string[] riscei = new string[2];

        con.Open();
        SqlCommand cmd = new SqlCommand("select aa1.RISCEI, aa2.NOIP from (select d.RISCEI from dars d, Sitios s, UbiDis u, " +
            "(select ID from Sitios where Descripcion=@sitio ) as a1 where s.ID = a1.ID and d.Descripcion = @desc and " +
            "u.nivel1 = (select ID from Nivel1 where Nombre = @nivel and a1.ID = UbiDispo)and u.Id = d.UbiDis) as aa1," +
            "(select NOIP from Sitios where Descripcion = @sitio) as aa2", con);
        cmd.Parameters.AddWithValue("@sitio", site);
        cmd.Parameters.AddWithValue("@desc", desc);
        cmd.Parameters.AddWithValue("@nivel", nivel);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            riscei[0] = Convert.ToString(dr[0]);
            riscei[1] = Convert.ToString(dr[1]);
        }
        con.Close();
        return riscei;
    }

    /*----------------TARERAS PREDETERMINADAS USER------------*/
    protected void programmTasKUser()
    {
        string nivel = string.Empty, dispositivo = string.Empty, accion = string.Empty, nombre = string.Empty, url = string.Empty, nombreR = string.Empty, usuario = string.Empty;
        string i = string.Empty, m = string.Empty, pet = string.Empty;
        string[] dis = new string[2];
        int horasu = 0, min = 0, minu2 = 0, dia = 0, mes = 0;

        usuario = Request["user"];
        nivel = Request["nivel"];
        dispositivo = Request["dispositivo"];
        dis = returnRisceiTareas(dispositivo, usuario, nivel);
        accion = Request["accion"];
        min = Convert.ToInt32(Request["minuto"]);
        DateTime fechitas = DateTime.Now;

        nombre = fechitas + dis[0];
        // Response.Write(dis);
        switch (min)
        {
            case 0:
                string[] peticion = ReturnComm2Adm(usuario, dispositivo);
                //Response.Write(peticion[0] + peticion[1]);
                try
                {
                    WebRequest Peticion = default(WebRequest);
                    Peticion = WebRequest.Create("https://addar.mx/Especiales/peticion2.php?v1=" + peticion[0] + "&v2=" + peticion[1] + "&v3=" + accion);

                    Peticion.GetResponseAsync();
                    Response.Write("True");
                }
                catch
                {
                    Response.Write("True");
                }
                break;

            case 1:
                fechitas = fechitas.AddMinutes(1);
                break;
            case 5:
                fechitas = fechitas.AddMinutes(5);
                break;
            case 10:

                fechitas = fechitas.AddMinutes(10);
                break;
            case 30:
                fechitas = fechitas.AddMinutes(30);
                break;
            case 60:
                fechitas = fechitas.AddHours(1);
                break;
            case 120:
                fechitas = fechitas.AddHours(2);
                break;
            case 240:
                fechitas = fechitas.AddHours(4);
                break;
            case 600:
                fechitas = fechitas.AddHours(10);
                break;
        }
        if (min > 0)
        {
            horasu = fechitas.Hour;
            minu2 = fechitas.Minute;
            dia = fechitas.Day;
            mes = fechitas.Month;
            pet = "http://" + dis[1] + "/cronPhp/agregarTarea.php?min=" + minu2 + "&hrs=" + horasu + "&dias=" + dia + "&meses=" + mes + "&dSem=*&comando=localhost/rest.php?riscei=" + dis[0] + ",evento=" + accion;
            try
            {
                url = returnResponseValue(pet);
                insertarD(nombre, dis[0], accion, horasu, minu2, fechitas, url, "Repetitiva");
                Response.Write("True");
            }
            catch
            {
                Response.Write("False");
            }

        }
    }

    /*---------------------------------------------------------------------------------------------------------------------------
     *------------------------------------ FUNCIONES DE CHELAS LISTAS ADM Y USUARIO---------------------------------------------
     ---------------------------------------------------------------------------------------------------------------------------*/

    //--------------------------------------------------------SECCION DE USUARIO-------------------------------------------------
    protected void returnRulesTempUser() {
        string usuario = string.Empty, json = string.Empty;

        usuario = Request["user"];
        Response.ContentType = "application/json; charset=utf-8";
        json = returnRulesUser(usuario);
        Response.Write(json);
    }
    protected void returnRulesGridUser() {
        string usuario = string.Empty, json = string.Empty;
        usuario = Request["user"];
        json = returnRulesGridUserQuery(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void registerRulesTempeUser() {
        string usuario = string.Empty, regla = string.Empty, comando = string.Empty;

        usuario = Request["user"];
        regla = Request["regla"];
        comando = Request["texto"];
        comando = returnCadena(comando);
        comando = comando.ToLower();
        if (insertCommandRulesUser(usuario, regla, comando))
        {
            Response.Write("True");
        }
        else
            Response.Write("False");

    }
    protected string programmRuleTempUser(string usuario, string comando) {
        string resultado = string.Empty;
        comando = returnCadena(comando);
        comando = comando.ToLower();
        if (programmRuleTempUserQuery(comando, usuario))
        {
            resultado = "True";
        }
        else
            resultado = "False";
        return resultado;
    }
    //--------------------------------------------------------SECCION DE ADMINISTRADOR--------------------------------------------
    protected void returnRulesTempAdm() {
        string usuario = string.Empty, sitio = string.Empty, json = string.Empty;

        usuario = Request["user"];
        sitio = Request["sitio"];
        json = returnRulesAdm(usuario, sitio);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void insertRulesTempAdm() {
        string usuario = string.Empty, regla = string.Empty, comando = string.Empty, sitio = string.Empty;

        usuario = Request["user"];
        sitio = Request["sitio"];
        regla = Request["regla"];
        comando = Request["texto"];
        comando = returnCadena(comando);
        comando = comando.ToLower();
        if (insertCommandRulesAdm(usuario, sitio, regla, comando))
        {
            Response.Write("True");
        }
        else
            Response.Write("False");
    }
    protected void returnRulesGridAdm() {
        string usuario = string.Empty, sitio = string.Empty, json = string.Empty;
        usuario = Request["user"];
        sitio = Request["sitio"];
        json = returnRulesGridAdmQuery(usuario, sitio);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected string programmRuleTempAdm(string usuario, string sitio, string comando) {
        string resultado = string.Empty;
        comando = returnCadena(comando);
        comando = comando.ToLower();
        if (programmRuleTempAdmQuery(usuario, comando, sitio))
        {
            resultado = "True";
        }
        else
            resultado = "False";

        return resultado;
    }

    protected string returnNameCliente(string usuario, string tipo) {
        string nombre = string.Empty;
        con.Open();
        SqlCommand cmd;
        if (tipo == "Normal")
        {
            cmd = new SqlCommand("select RazonSocial from Clientes where ID = (select ID_Cliente from AspNetUsers where UserName=@usuario)", con);
            cmd.Parameters.AddWithValue("@usuario", usuario);
        }
        else {
            cmd = new SqlCommand("select RazonSocial from Clientes where ID = (select ID_cliente from Sitios where ID=(select " +
                "Sitio from UsuarioRestaurant where Usuario = @usuario ))", con);
            cmd.Parameters.AddWithValue("@usuario", usuario);
        }
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            nombre = Convert.ToString(dr[0]);
        }
        con.Close();
        return nombre;
    }

    protected string ConsultarIcono(string usuario, string tipo)
    {
        string icono = string.Empty;
        byte[] icon;
        con.Open();
        SqlCommand cmd;
        if (tipo == "Normal")
        {
            cmd = new SqlCommand("SELECT icono FROM Clientes Where ID=(select ID_Cliente from AspNetUsers where username = @usuario)", con);
            cmd.Parameters.AddWithValue("@usuario", usuario);
        }
        else {
            cmd = new SqlCommand("SELECT icono FROM Clientes Where ID=(select ID_Cliente from Sitios where ID=(select Sitio from usuariorestaurant" +
                " where Usuario = @usuario))", con);
            cmd.Parameters.AddWithValue("@usuario", usuario);
        }
        
        //objCmd.CommandType = CommandType.Text;
        object result = cmd.ExecuteScalar();
        con.Close();
        icon = (byte[])result;
        icono = Convert.ToBase64String(icon);
        //return (byte[])result;
        return icono;
    }

    

    protected string returnCentinelaUserSQL(string usuario) {
        string json = string.Empty;
        List<personas> persona = new List<personas>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select a1.Nombre, a1.Apellidos, a1.Estatus from CanalTelegram ct inner " +
            "join(select ce.ID, e.Nombre, e.Apellidos, ce.ID_Telegram, ce.Tipo, " +
            "ce.Estatus from Empleado e inner join CanalEmpleados ce on e.ID = ce.ID_Empleado where e.Sitio = " +
            "(select C_Sitio from AspNetUsers where UserName = @usuario)) as a1 on ct.CanalTelegram = a1.ID_Telegram " +
            "where ct.Usuario = @usuario",con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            personas person = new personas();
            person.nombrePersona = Convert.ToString(dr[0]) + " " + Convert.ToString(dr[1]);
            person.estatus = Convert.ToString(dr[2]);
            persona.Add(person);
        }
        con.Close();
        json = JsonConvert.SerializeObject(persona);
        return json;
    }
    protected string returnCentinelaAdmSQL(string usuario,string sitio) {
        string json = string.Empty;
        List<personas> persona = new List<personas>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select a1.Nombre, a1.Apellidos, a1.Estatus from CanalTelegram ct inner" +
            " join (select ce.ID, e.Nombre, e.Apellidos, ce.ID_Telegram, ce.Tipo, ce.Estatus from Empleado e " +
            "inner join CanalEmpleados ce on e.ID = ce.ID_Empleado where e.Sitio in (select ID from Sitios where " +
            "ID_Cliente = (select ID_Cliente from AspNetUsers where UserName = @usuario) and Descripcion = @sitio)) " +
            "as a1 on ct.CanalTelegram = a1.ID_Telegram where ct.Usuario = @usuario",con);
        cmd.Parameters.AddWithValue("@usuario",usuario);
        cmd.Parameters.AddWithValue("@sitio",sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            personas person = new personas();
            person.nombrePersona = Convert.ToString(dr[0]) + " " + Convert.ToString(dr[1]) ;
            person.estatus = Convert.ToString(dr[2]);
            persona.Add(person);
        }
        json = JsonConvert.SerializeObject(persona);
        con.Close();
        return json;
    }

    /*---------------------------------------------------------------------------------------------------------------------------
    /*--------------------------------------------------------FIN CHELAS--------------------------------------------------------*/
    /*---------------------------------------------------------------------------------------------------------------------------
    /*---------------OBJETOS DE LISTA--------------------*/

    public class Disposi
    {
        public string nombre { get; set; }
        public string sitio { get; set; }

    }

    public class dispositivo2
    {
        public string descripcion { get; set; }
        public List<comandosFav> Listacomandos { get; set; }
        public string site { get; set; }
    }

    public class comandosFav
    {
        public string comando { get; set; }
    }
    public class accion
    {
        public string acciones { get; set; }
        public string comando { get; set; }
    }

}


/*-----------------------------------------------------------------------------------------------------------
 -----------------------------------------------------OBJETOS------------------------------------------------
 -----------------------------------------------------------------------------------------------------------*/
public class Disposis
{
    public string nombre { get; set; }
}
public class personas { 
    public string nombrePersona { get; set; }
    public string estatus { get; set; }
}

public class comandos
{
    public string accion { get; set; }
}

public class accioness
{
    public string accion { get; set; }
    public string comando { get; set; }
}

public class usuario
{
    public string estado { get; set; }
    public string rol { get; set; }
    public List<sitio> site { get; set; }
    public string AdmRestaurant { get; set; }
    public List<nivel> nivels { get; set; }
    public string estatus { get; set; }
    public string avisoPrivacidad { get; set; }
    public string nombreCliente { get; set; }
    public string icono { get; set; }
    public string Activado { get; set; }
}

public class sitio
{
    public string sitios { get; set; }
}

public class nivel
{
    public string nombreNivel { get; set; }

}

public class estatusDAR
{
    public string estatus { get; set; }
    public string accionDAR { get; set; }
}

public class accionesPintado
{
    public List<comandos> acciones { get; set; }
    public string pintado { get; set; }
}

public class eventosAgrupados {
    public string noip { get; set; }
    public string dispositivo { get; set; }
    public string accion { get; set; }
}

public class reglaUmbral {
    public string nombreRegla { get; set; }
}

public class reglaUmbralGrid {
    public string Regla { get; set; }
    public string Comando { get; set; }
}