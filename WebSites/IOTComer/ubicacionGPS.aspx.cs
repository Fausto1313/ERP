using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class ubicacionGPS : System.Web.UI.Page
{
    protected static string conection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    public SqlConnection cn = new SqlConnection(conection);

    protected void Page_Load(object sender, EventArgs e)
    {
        string cu = null, riscei=null, l=null, ln=null;
        float latitud = 0, longitud = 0;
        cu = Request["cu"];
        riscei = Request["v1"];
        l = Request["v2"];
        ln = Request["v3"];
        switch (cu) {
            case "1":
                insertCoords(riscei,l,ln);
                break;
            case "2":
                requestCoords(riscei);
                break;
        }
    }

    protected void insertCoords(string riscei, string lat, string lon) {
        DateTime std = DateTime.Now;
        if (searchDev(riscei))
        {
            cn.Open();
            string updateCmd = "UPDATE Coordenadas SET Latitud=@lat, Longitud=@lon, Fecha=fecha WHERE RISCEI=@riscei";
            SqlCommand updatecmd = new SqlCommand(updateCmd, cn);
            updatecmd.Parameters.AddWithValue("@lat", lat);
            updatecmd.Parameters.AddWithValue("@lon", lon);
            updatecmd.Parameters.AddWithValue("@riscei", riscei);
            updatecmd.Parameters.AddWithValue("@fecha", std);
            updatecmd.ExecuteNonQuery();
            cn.Close();
        }
        else {
            cn.Open();
            string updateCmd = "INSERT INTO Coordenadas (RISCEI, Latitud, Longitud, Fecha) values(@riscei, @lat, @lon, @fecha)";
            SqlCommand updatecmd = new SqlCommand(updateCmd, cn);
            updatecmd.Parameters.AddWithValue("@lat", lat);
            updatecmd.Parameters.AddWithValue("@lon", lon);
            updatecmd.Parameters.AddWithValue("@riscei", riscei);
            updatecmd.Parameters.AddWithValue("@fecha", std);
            updatecmd.ExecuteNonQuery();
            cn.Close();
        }

    }

    protected void requestCoords(string riscei) {
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT Latitud, Longitud FROM Coordenadas where RISCEI=@riscei", cn);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
           Response.Write(dr[0]+","+dr[1]);
            //Response.Write("Holi");
        }
        cn.Close();
    }

    protected bool searchDev(string riscei) {
        bool request = false;
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT Fecha FROM Coordenadas where RISCEI=@riscei", cn);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            request = true;
        }
        cn.Close();
        return request;
    }
}