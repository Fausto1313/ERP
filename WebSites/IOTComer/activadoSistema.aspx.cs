using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;

public partial class activadoSistema : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string RISCEI = string.Empty, estado = string.Empty, estatus = string.Empty;

        RISCEI = Request["v1"];
        estatus = Request["v2"];
        estado = Request["v3"];
        updateStatus(RISCEI, estatus);
        sendTelegramSec(RISCEI, estatus);
        Response.Write("OK");
    }

    protected void updateStatus(string riscei, string estatus) {
        con.Open();
        SqlCommand cmd = new SqlCommand("update Sitios set Seguridad = @seguridad where ID=(select Cl_Sitio from UbiDis where " +
            "ID=(select UbiDis from DARS where RISCEI = @riscei))",con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        cmd.Parameters.AddWithValue("@seguridad", estatus);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected void sendTelegramSec(string riscei, string seguridad)
    {
        ArrayList lista = new ArrayList();
        string sitio = returnSitio(riscei);
        con.Open();
        SqlCommand cmd = new SqlCommand("select CanalTelegram from CanalTelegram where ID_Sitio = (select Cl_Sitio from UbiDis where ID =(select UbiDis from DARS where RISCEI = @riscei))" +
            " and Primario = 'Primario'", con);
        cmd.Parameters.AddWithValue("@usuario", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            lista.Add(Convert.ToString(dr[0]));
        }
        con.Close();

        string token = "465931710:AAHAY4-x6ZozrHPWkLfy9t7UUrcJX6Q61bw";
        //string[] id = { "485219307", "401967737", "462385749" };
        string mensaje = "El sistema ubicado en " + sitio+ " ha sido colocado en estado: "+ seguridad;

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
    protected string returnSitio(string riscei) {
        string sitio = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select Descripcion from Sitios where ID=(select Cl_Sitio from Ubidis where ID=" +
            "(select UbiDis from DARS where riscei = @riscei))",con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            sitio = Convert.ToString(dr[0]);
        }
        con.Close();
        return sitio;
    }
}