using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;

public partial class peticionRefrigeradores : System.Web.UI.Page
{

    protected static string conection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    public SqlConnection cn = new SqlConnection(conection);
    protected void Page_Load(object sender, EventArgs e)
    {
        string riscei = null;
        int tempe = 0;
        DateTime std = DateTime.Now;
        Temperatura ank = new Temperatura();
        riscei = Request["v1"];
        tempe = Convert.ToInt32(Request["v2"]);
        try
        {
            ank = returnUmbral(riscei);
        }
        catch {
            Response.Write("NULL");
        }
        
        if (ank.estatus == "OK") {
            if (tempe == ank.umbral) {
                telegramTemp(ank.canalTelegram, ank.descripcion, tempe, std);
                updateStatus(riscei);
                saveRegister(riscei, Convert.ToString(tempe), "Testeo Temperatura", std);
            }
            
        }
        saveRegister(riscei, Convert.ToString(tempe), "Testeo Temperatura", std);

    }

    protected void saveRegister(string riscei, string evento, string estado, DateTime std)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "INSERT temporal (macID, evento, estado, fecha) VALUES (@macID, @evento, @estado, @std)";
        cmd.Parameters.AddWithValue("@macID", riscei);
        cmd.Parameters.AddWithValue("@evento", evento);
        cmd.Parameters.AddWithValue("@estado", estado);
        cmd.Parameters.AddWithValue("@std", std);
        cmd.Connection = cn;
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
    }

    protected void telegramTemp(string canal, string nombre, int temp, DateTime fecha)
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
               | SecurityProtocolType.Tls11
               | SecurityProtocolType.Tls12
               | SecurityProtocolType.Ssl3;
        string token = "465931710:AAHAY4-x6ZozrHPWkLfy9t7UUrcJX6Q61bw";
        string mensaje = "El dispositivo " + nombre + " ha llegado a la temperatura deseada de" +
            " " + temp + "°C\n" +
            "Evento con fecha " + fecha;
        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + canal + "&text=" + mensaje);
        Peticion.GetResponse();
    }

    protected void updateStatus(string riscei) {
        cn.Open();
        SqlCommand cmd = new SqlCommand("update ReglaUmbral set Estatus = 'Deshabilitado' where " +
            "RISCEI = @riscei",cn);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        cmd.ExecuteNonQuery();
        cn.Close();
    }

    protected Temperatura returnUmbral(string riscei) {
        Temperatura t = new Temperatura();
        cn.Open();
        SqlCommand cmd = new SqlCommand("select ru.Umbral, ru.CanalTelegram, d.Descripcion from ReglaUmbral ru, " +
            "DARS d where ru.RISCEI = @riscei and ru.Estatus = 'Habilitado' and d.RISCEI = @riscei", cn);
        cmd.Parameters.AddWithValue("@riscei",riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            t.estatus = "OK";
            t.umbral = Convert.ToInt32(dr[0]);
            t.canalTelegram = Convert.ToString(dr[1]);
            t.descripcion = Convert.ToString(dr[2]);
        }
        else {
            t.estatus = "NR";
        }
        cn.Close();

        return t;
    }
    protected class Temperatura {
        public string estatus { get; set; }
        public int umbral { get; set; }
        public string canalTelegram { get; set; }
        public string descripcion { get; set; }
    }
}