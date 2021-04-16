using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Net;

public partial class controDactilar : System.Web.UI.Page
{
   protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string estatus = string.Empty, ide = string.Empty, riscei = string.Empty;
        int id = 0;
        List<ReglasEmpleado> empleado = new List<ReglasEmpleado>();
        DateTime std = DateTime.Now;
        riscei = Request["v1"];
        id = Convert.ToInt32(Request["v2"]);
        estatus = Request["v3"];

        insertarAp(id, std, estatus, riscei);
            empleado = checkRuleEmployee(riscei, id);
            int a = empleado.Count;
            if (a > 0) {
                for (int i = 0; i < a; i++) {
                    Response.Write(sendTelegramChannel(empleado[i].Nombre, empleado[i].Apellido, empleado[i].Telegram, std, empleado[i].Sitio));
                    if (empleado[i].Tipo == "Unico") {
                        updateStatus(empleado[i].ID);
                    }
                }    
            }
        /*if (estatus == "Acceso_Permitido" || estatus == "Acceso_permitido" || estatus == "acceso_permitido")
        {
            insertarAp(id, std, estatus, riscei);
            empleado = checkRuleEmployee(riscei, id);
            int a = empleado.Count;
            if (a > 0) {
                for (int i = 0; i < a; i++) {
                    sendTelegramChannel(empleado[i].Nombre, empleado[i].Apellido, empleado[i].Telegram, std, empleado[i].Sitio);
                    if (empleado[i].Tipo == "Unico") {
                        updateStatus(empleado[i].ID);
                    }
                }    
            }
        }*/
    }

    protected void updateStatus(int id) {
        con.Open();
        string updatecmd = "update CanalEmpleados set Estatus = 'Deshabilitado' where ID = @id";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@id", id);
        addCmd.ExecuteNonQuery();
        con.Close();
    }

    protected bool sendTelegramChannel(string nombre, string apellidos, string canal, DateTime tiempo, string sitio) {
        try
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;
            string token = "465931710:AAHAY4-x6ZozrHPWkLfy9t7UUrcJX6Q61bw";
            string mensaje = "La persona " + nombre + " " + apellidos + " ha llegado al sitio " + sitio + ".\nFecha: " + tiempo;
            WebRequest Peticion = default(WebRequest);
            Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + canal + "&text=" + mensaje);
            Peticion.GetResponse();
            //Response.Write(mensaje);
            return true;
        }
        catch {
            return false;
        }
    }

    protected void insertarAp(int IDEmpleado, DateTime Fecha, string Estado, string riscei) {
        con.Open();
        string updatecmd = "insert into controlDactilar (IDEmpleado, Fecha, Estatus) values ((select " +
            "ID from Empleado where ID_Checador = @idH AND Sitio = " +
            "(select u.Cl_Sitio from DARS d inner join UbiDis u on d.UbiDis = u.Id where d.RISCEI = @riscei)),@fecha,@estatus)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@idH", IDEmpleado);
        addCmd.Parameters.AddWithValue("@fecha", Fecha);
        addCmd.Parameters.AddWithValue("@estatus", Estado);
        addCmd.Parameters.AddWithValue("@riscei", riscei);
        addCmd.ExecuteNonQuery();
        con.Close();
    }

    protected List<ReglasEmpleado> checkRuleEmployee(string riscei, int empleado) {
        List<ReglasEmpleado> reglas = new List<ReglasEmpleado>();
        int i = 0;
        con.Open();
        SqlCommand cmd = new SqlCommand("select e.Nombre, e.Apellidos, ce.ID_Telegram, s.Descripcion, ce.ID, ce.Tipo from sitios s, " +
            "(select u.Cl_Sitio from UbiDis u where Id = (select UbiDis from DARS where RISCEI = @riscei)) as a1, " +
            "CanalEmpleados ce inner join Empleado e on ce.ID_Empleado = e.ID " +
            "where e.ID_Checador = @id and ce.ID_SItio = a1.Cl_Sitio and e.Sitio = a1.Cl_Sitio and e.Sitio = s.ID " +
            "and ce.Estatus = 'Habilitado'", con);
        cmd.Parameters.AddWithValue("@riscei",riscei);
        cmd.Parameters.AddWithValue("@id",empleado);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ReglasEmpleado re = new ReglasEmpleado();
            re.Nombre = Convert.ToString(dr[0]);
            re.Apellido = Convert.ToString(dr[1]);
            re.Telegram = Convert.ToString(dr[2]);
            re.Sitio = Convert.ToString(dr[3]);
            re.ID = Convert.ToInt32(dr[4]);
            re.Tipo = Convert.ToString(dr[5]);
            reglas.Add(re);
        }
        con.Close();
        return reglas;

    }

    protected class ReglasEmpleado {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telegram { get; set; }
        public string Sitio { get; set; }
        public int ID { get; set; }
        public string Tipo { get; set; }

    }
}