using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
public partial class RFID : System.Web.UI.Page
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string riscei = string.Empty, usuario = string.Empty, json = string.Empty, cu = string.Empty;
        cu = Request["cu"];
        riscei = Request["riscei"];
        usuario = Request["codigo"];
        peticionRFID(riscei,usuario);
           
    }

    protected void peticionRFID(string riscei, string usuario) {
        string json = string.Empty;
        Response.ContentType = "application/json; charset=utf-8";
        if (riscei != null && usuario != null)
        {
            json = checkRulesRFID(usuario, riscei);
            if (json != "[]")
            {
                saveRegister(riscei, usuario);
                Response.Write(json);
            }
            else
                Response.Write(json);
        }
        else
            Response.Write("false");
    }

    protected void saveRegister(string riscei, string usuario) {
        DateTime fecha = DateTime.Now;
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into BitacoraRFID (RISCEIRFID, Usuario, Fecha) values" +
            "(@riscei, (select ID from UsuarioRFID where RFID = @usuario), @fecha)",con);
        cmd.Parameters.AddWithValue("@riscei",riscei);
        cmd.Parameters.AddWithValue("@usuario",usuario);
        cmd.Parameters.AddWithValue("@fecha",fecha);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected string checkRulesRFID(string rfid, string dar) {
        string json = string.Empty;
        //string dt = DateTime.Now.ToShortDateString();
        List<P1> lista = new List<P1>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select rf.RISCEI_P1 from ReglasRFID rf inner join " +
            "(select IDReglaRFID, FechaInicio, FechaFin from ReglasRFIDUsuario where IDReglaRFID in " +
            "(select ID from ReglasRFID where RISCEI_RFID = @dar) and IDUsuario = (select ID from " +
            "UsuarioRFID where RFID = @rfid)) as a1 on a1.IDReglaRFID = rf.ID and a1.FechaFin > @fecha and a1.FechaInicio " +
            "< @fecha", con);
        cmd.Parameters.AddWithValue("@rfid", rfid);
        cmd.Parameters.AddWithValue("@dar", dar);
        cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            P1 p = new P1();
            p.RISCEI_P1 = Convert.ToString(dr[0]);
            lista.Add(p);
        }
        con.Close();
        json = JsonConvert.SerializeObject(lista);
        return json;
    }
    private class P1 {
        public string RISCEI_P1 { get; set; }
    }
}