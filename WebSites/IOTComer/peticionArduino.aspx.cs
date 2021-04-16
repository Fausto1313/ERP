using Newtonsoft.Json;
using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;

public partial class peticionArduino : System.Web.UI.Page
{
    protected static string conection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    public SqlConnection con = new SqlConnection(conection);

    protected void Page_Load(object sender, EventArgs e)
    {
       for(int i = 0; i<5;i++)
            checkRules();
        respuestaDrools respuesta;
        string riscei = null, estado = null, evento = null, query = null, tipo = null;
        ArrayList canales = new ArrayList();
        string[] modeloCliente, sec;
        DateTime std = DateTime.Now;
        riscei = Request["v1"];
        evento = Request["v2"];
        estado = Request["v3"];
        modeloCliente = returnModelo(riscei);
        sec = returnSecurityID(riscei);
        WebRequest Peticion = default(WebRequest);
        //Response.Write(riscei);
        //&& riscei != "1808BP2205"
        if ((modeloCliente[0] != null && checkBIS(riscei)) || (modeloCliente[0] == "DAR-BIS-BP/MG") || (modeloCliente[0]!="DAR-BIS-AL"))
        {
            Peticion = WebRequest.Create("http://addar.mx:9999/iotrules?riscei=" + riscei + "&identificador=" +
                modeloCliente[0] + "&cliente=" + modeloCliente[1] + "&sitio=" + sec[0] + "&sistema=" + sec[1] + "&estado=" + estado);
            using (HttpWebResponse response = (HttpWebResponse)Peticion.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                Response.Write(json);
                respuesta = JsonConvert.DeserializeObject<respuestaDrools>(json);
            }
            //Response.Write(respuesta.destinatario);

            Response.Write(respuesta.comando);
            switch (respuesta.identificador)
            {
                case "Telegram":
                    if (respuesta.destinatario.Contains("@"))
                    {
                        tipo = "canales";
                        query = respuesta.destinatario;
                    }
                    else {
                        query = returnUsersTelegram(respuesta.destinatario);
                        tipo = "usuarios";
                    }
                        
                    if (modeloCliente[0] == "DAR")
                    {
                        sendTelegramInitial(riscei, query, evento, std, estado);
                    }
                    else if (evento == "GPRS_Activo") {
                        sendTelegramGPRS(riscei, query, evento, std, estado);
                    }
                    else
                    {
                        sendTelegram(riscei, query, evento, std, estado, tipo);
                    }
                    break;
                case "Dispositivo":
                    sendRequest(respuesta.destinatario, respuesta.comando);
                    break;
                case "Correo":
                    sendEmail(respuesta.destinatario, respuesta.riscei, evento, std);
                    break;
                case "Telegram|Alarma":
                    query = returnUsersTelegram(respuesta.destinatario);
                    sendTelegram(riscei, query, evento, std, estado, tipo);
                    sendRequest(respuesta.riscei, respuesta.comando);
                    break;
                case "Correo|Alarma":
                    sendEmail(respuesta.destinatario, riscei, evento, std);
                    sendRequest(respuesta.riscei, respuesta.comando);
                    break;
            }
            
            if (modeloCliente[0] == "DAR-BIS-VA/LE/LU/LS") {
                saveRegisterStatus(riscei, evento, std);
                saveRegisterActive(riscei, evento, estado, std);
            }
            else
                saveRegister(riscei, evento, estado, std);
            Response.Write("Done");
            //returnSecurity(riscei, estado, std, evento, modeloCliente[0]);
        }
        else
            Response.Write("Error");
    }

    protected bool checkBIS(string riscei) {
        con.Open();
        bool ok = false;
        string res = string.Empty;
        SqlCommand cmd = new SqlCommand("select Estatus from DARS where RISCEI =@riscei",con);
        cmd.Parameters.AddWithValue("@riscei",riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            res = Convert.ToString(dr[0]);
            if (res == "Habilitado" || res == "")
            
                ok = true;
            else
                ok = false;
        }
        else {
            ok = false;
        }
        con.Close();
        return ok;
    }

    protected ArrayList returnCanales(string canales) {
        int i, j, k;
        ArrayList users = new ArrayList();

        for (i = 0, j = 0, k = 0; k < canales.Length; k++, j++)
        {
            if (canales[k] == '|')
            {
                users.Add(canales.Substring(i, j));
                i = k + 1;
                j = -1;
            }
        }
        return users;
    }
    protected void sendTelegramGPRS(string riscei, string query, string evento, DateTime tiempo, string estado) {

        ArrayList c = new ArrayList();
        int q = 0;
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            c.Add(Convert.ToString(dr[0]));
            q++;
            //Response.Write(c[q]);
        }
        con.Close();
        string dis = null, nivel3 = null, nivel2 = null, nivel1 = null;
        dis = obtenerDescripcion(riscei);
        nivel3 = obtenerNivel3(riscei);
        nivel2 = obtenerNivel2(riscei);
        nivel1 = obtenerNivel1(riscei);
        string token = "465931710:AAHAY4-x6ZozrHPWkLfy9t7UUrcJX6Q61bw";
        //string[] id = { "485219307", "401967737", "462385749" };
        string mensaje = "El dispositivo " + riscei + " \n Nombre: " + dis + " ha tenido un evento del tipo " + estado +
                         " \n" + " Descripcion del evento: " + evento + " \nCon fecha: " + tiempo;

        for (int i = 0; i < c.Count; i++)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + c[i] + "&text=" + mensaje);
            Peticion.GetResponse();
        }

    }

    protected void saveRegisterStatus(string riscei, string evento, DateTime fecha) {
        SqlCommand cmd = new SqlCommand();
        string query = string.Empty;
        if (evento == "Encendido")
            query = "if(select RISCEI from eventoDispositivo where riscei = @riscei) is not null update eventoDispositivo " +
            "set UltimoEvento = @evento, FechaEncendido = @fecha where RISCEI = @riscei; else insert into " +
            "eventoDispositivo(RISCEI, UltimoEvento, FechaEncendido) values(@riscei, @evento, @fecha)";
        else
            query = "if(select RISCEI from eventoDispositivo where riscei = @riscei) is not null update eventoDispositivo " +
            "set UltimoEvento = @evento, FechaApagado = @fecha where RISCEI = @riscei; else insert into " +
            "eventoDispositivo(RISCEI, UltimoEvento, FechaApagado) values(@riscei, @evento, @fecha)";
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@riscei", riscei);
        cmd.Parameters.AddWithValue("@evento", evento);
        cmd.Parameters.AddWithValue("@fecha", fecha);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected string[] returnSecurityID(string riscei){
        string[] seguridad = new string[2];
        con.Open();
        SqlCommand cmd = new SqlCommand("select ID, Seguridad from Sitios where ID=(Select Cl_Sitio from UbiDis where "+
            "ID=(select UbiDis from DARS where RISCEI=@riscei))", con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            seguridad[0] = Convert.ToString(dr[0]);
            seguridad[1] = Convert.ToString(dr[1]);
        }
        else{
            seguridad[0] = "0";
            seguridad[1] = "0";
        }

        con.Close();
        return seguridad;
    }

    protected void returnSecurity(string riscei, string estatus, DateTime tiempo, string evento, string mod)
    {
        string seguridad = string.Empty;
        ArrayList telegram = new ArrayList();
        con.Open();
        SqlCommand cmd = new SqlCommand("select Seguridad from Sitios where ID=(Select Cl_Sitio from UbiDis where " +
            "ID=(select UbiDis from DARS where RISCEI=@riscei))", con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            seguridad = Convert.ToString(dr[0]);
        }
        con.Close();

        if (seguridad == "Activado" && estatus == "Critico" && mod !="DAR-BIS-BP")
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand("select ID from Telegram where ID_Cliente = (select ID_Cliente from DARS where RISCEI=@riscei)", con);
            cmd2.Parameters.AddWithValue("@riscei", riscei);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                telegram.Add(Convert.ToString(dr2[0]));
            }
            con.Close();
            string dis = null, nivel3 = null, nivel2 = null, nivel1 = null;
            dis = obtenerDescripcion(riscei);
            nivel3 = obtenerNivel3(riscei);
            nivel2 = obtenerNivel2(riscei);
            nivel1 = obtenerNivel1(riscei);
            string token = "465931710:AAHAY4-x6ZozrHPWkLfy9t7UUrcJX6Q61bw";
            //string[] id = { "485219307", "401967737", "462385749" };
            string mensaje = "El dispositivo " + riscei + " \n Nombre: " + dis + " ha presentado una intrusion de nivel " + estatus +
                             " \n El dispositivo se encuentra en: " + nivel1 + " " + nivel2 + " " + nivel3 +
                             " \n" + " Descripcion del evento: " + " Dispositivo " + evento + " vulnerado\nCon fecha: " + tiempo;

            for (int i = 0; i < telegram.Count; i++)
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;
                WebRequest Peticion = default(WebRequest);
                Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + telegram[i] + "&text=" + mensaje);
                Peticion.GetResponse();
            }
        }

    }

    protected string[] returnModelo(string riscei)
    {
        string[] riscei2 = new string[2];
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT Modelo, ID_Cliente FROM DARS where RISCEI=@user", con);
        cmd.Parameters.AddWithValue("@user", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            riscei2[0] = Convert.ToString(dr[0]);
            riscei2[1] = Convert.ToString(dr[1]);
        }
        con.Close();
        return riscei2;
    }

    protected void saveRegister(string riscei, string evento, string estado, DateTime std)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "INSERT into DispositivosSensores (RISCEI, Evento, Estado, Fecha) VALUES (@macID, @evento, @estado, @std)";
        cmd.Parameters.AddWithValue("@macID", riscei);
        cmd.Parameters.AddWithValue("@evento", evento);
        cmd.Parameters.AddWithValue("@estado", estado);
        cmd.Parameters.AddWithValue("@std", std);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected void saveRegisterActive(string riscei, string evento, string estado, DateTime std)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "INSERT into DispositivosActuadores (RISCEI, Evento, Estado, Fecha) VALUES (@macID, @evento, @estado, @std)";
        cmd.Parameters.AddWithValue("@macID", riscei);
        cmd.Parameters.AddWithValue("@evento", evento);
        cmd.Parameters.AddWithValue("@estado", estado);
        cmd.Parameters.AddWithValue("@std", std);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected void sendTelegram(string riscei, string query, string evento, DateTime tiempo, string estado, string tipo)
    {
        ArrayList c = new ArrayList();
        int q = 0;
        if (tipo == "usuarios")
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                c.Add(Convert.ToString(dr[0]));
                q++;
            }
            con.Close();
        }
        else {
            c = returnCanales(query);
        }
        string dis = null, nivel3 = null, nivel2 = null, nivel1 = null, sitio = null;
        dis = obtenerDescripcion(riscei);
        nivel3 = obtenerNivel3(riscei);
        nivel2 = obtenerNivel2(riscei);
        nivel1 = obtenerNivel1(riscei);
        sitio = obtenerSitio(riscei);
        string token = "465931710:AAHAY4-x6ZozrHPWkLfy9t7UUrcJX6Q61bw";
        //string[] id = { "485219307", "401967737", "462385749" };
        string mensaje = "El dispositivo " + riscei + " \n Nombre: " + dis + " ha presentado un evento del tipo " + estado +
                         " \n El dispositivo se encuentra en: " + sitio + " " + nivel1 + " " + nivel2 +
                         " \n" + " Descripcion del evento: " + evento + ".\nCon fecha: " + tiempo;

        for (int i = 0; i < c.Count; i++)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + c[i] + "&text=" + mensaje);
            Peticion.GetResponse();
        }
    }

    protected void sendTelegramInitial(string riscei, string query, string evento, DateTime tiempo, string estado)
    {
        ArrayList c = new ArrayList();
        int q = 0;
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            c.Add(Convert.ToString(dr[0]));
            q++;
            //Response.Write(c[q]);
        }
        con.Close();
        string dis = null, nivel3 = null, nivel2 = null, nivel1 = null;
        dis = obtenerDescripcion(riscei);
        nivel3 = obtenerNivel3(riscei);
        nivel2 = obtenerNivel2(riscei);
        nivel1 = obtenerNivel1(riscei);
        string token = "465931710:AAHAY4-x6ZozrHPWkLfy9t7UUrcJX6Q61bw";
        //string[] id = { "485219307", "401967737", "462385749" };
        string mensaje = "El dispositivo " + riscei + " \n Nombre: " + dis + " ha tenido un evento del tipo " + evento +
                         " \n" + " Descripcion del evento: "+ estado + " \nCon fecha: " + tiempo;

        for (int i = 0; i < c.Count; i++)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + c[i] + "&text=" + mensaje);
            Peticion.GetResponse();
        }
    }

    protected void sendRequest(string riscei, string accion)
    {
        string dir = null;
        WebRequest Peticion = default(WebRequest);
        dir = "https://addar.mx/Especiales/peticion2.php?v1=" + returnNOIP(riscei) + "&v2="+riscei+"&v3=" + accion;
        Peticion = WebRequest.Create(dir);
        Peticion.GetResponseAsync();
        Response.Write("Recibido");
    }

    protected string returnNOIP(string riscei) {
        string noip = string.Empty;

        con.Open();
        SqlCommand cmd = new SqlCommand("select s.NOIP from (select Cl_Sitio from UbiDis where Id= " +
            "(select UbiDis from DARS where RISCEI =@riscei)) as a1 inner join Sitios s on a1.Cl_Sitio = s.ID",con);
        cmd.Parameters.AddWithValue("@riscei",riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            noip = Convert.ToString(dr[0]);
        }
        
        con.Close();
        return noip;
    }

    protected void sendEmail(string email, string riscei, string evento, DateTime tiempo)
    {
        SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
        client.Credentials = new NetworkCredential("alertaiotrisc@outlook.com", "Risc2018");
        client.EnableSsl = true;
        MailAddress from = new MailAddress("alertaiotrisc@outlook.com");
        MailAddress to = new MailAddress(email);
        MailMessage message = new MailMessage(from, to);
        message.Body = "Prueba de Drools en Email " + riscei + "Evento: " + evento + " con fecha: " + tiempo;
        message.Subject = "Testeo de reglas de negocio";
        client.Send(message);
    }

    protected string returnUsersTelegram(string telegram)
    {
        string usuarios = null;
        int i, j, k;
        ArrayList users = new ArrayList();

        for (i = 0, j = 0, k = 0; k < telegram.Length; k++, j++)
        {
            if (telegram[k] == '|')
            {
                users.Add(telegram.Substring(i, j));
                i = k + 1;
                j = -1;
            }
        }

        usuarios = "select ID from Telegram where usuario='" + users[0] + "'";
        for (int p = 1; p < users.Count; p++)
        {
            usuarios = usuarios + " or usuario='" + users[p] + "'";
        }
        //Response.Write(usuarios);
        return usuarios;
    }

    protected void checkRules()
    {
        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create("http://198.38.93.52:9999/deployrules");
        Peticion.GetResponseAsync();
    }

    public string obtenerDescripcion(string riscei)
    {
        con.Open();
        string s = null;
        SqlCommand cmd = new SqlCommand("SELECT descripcion FROM DARS where RISCEI=@riscei", con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            s = Convert.ToString(dr[0]);
        }
        con.Close();
        return s;
    }

    public string obtenerNivel3(string riscei)
    {
        con.Open();
        string s = null;
        SqlCommand cmd = new SqlCommand("SELECT n3.Nombre3, n3.descripcion FROM UbiDis ud, Nivel3 n3, Dars da, Clientes cli,  Nivel1 n1, Nivel2 n2 Where ud.nivel3 = n3.ID AND ud.Id = da.UbiDis AND ud.Cl_Cliente =  cli.ID AND ud.nivel2 = n2.ID AND ud.nivel1 = n1.ID AND da.RISCEI = @riscei", con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            s = Convert.ToString(dr[0]);
        }
        con.Close();
        return s;
    }

    public string obtenerNivel2(string riscei)
    {
        con.Open();
        string s = null;
        SqlCommand cmd = new SqlCommand("SELECT  n2.Nombre2 FROM UbiDis ud, Dars da, Clientes cli,  Nivel1 n1, Nivel2 n2 Where ud.Id = da.UbiDis AND ud.Cl_Cliente =  cli.ID AND ud.nivel2 = n2.ID AND ud.nivel1 = n1.ID AND da.RISCEI = @riscei", con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            s = Convert.ToString(dr[0]);
        }
        con.Close();
        return s;
    }

    public string obtenerNivel1(string riscei)
    {
        con.Open();
        string s = null;
        SqlCommand cmd = new SqlCommand("SELECT n1.Nombre FROM UbiDis ud, Dars da, Clientes cli,  Nivel1 n1, Nivel2 n2 Where ud.Id = da.UbiDis AND ud.Cl_Cliente =  cli.ID AND ud.nivel2 = n2.ID AND ud.nivel1 = n1.ID AND da.RISCEI = @riscei and da.UbiDis = ud.Id", con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            s = Convert.ToString(dr[0]);
        }
        con.Close();
        return s;
    }

    public string obtenerSitio(string riscei)
    {
        con.Open();
        string s = null;
        SqlCommand cmd = new SqlCommand("select s.Descripcion from Sitios s, UbiDis u, DARS d where d.UbiDis=u.Id and u.Cl_Sitio=s.ID and d.RISCEI=@riscei", con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            s = Convert.ToString(dr[0]);
        }
        con.Close();
        return s;
    }


    public class respuestaDrools
    {
        public string riscei { get; set; }
        public string estado { get; set; }
        public string comando { get; set; }
        public string identificador { get; set; }
        public string destinatario { get; set; }
        public string asunto { get; set; }
        public string cuerpo { get; set; }
        public float temperatura { get; set; }
        public float humedad { get; set; }
    }
}