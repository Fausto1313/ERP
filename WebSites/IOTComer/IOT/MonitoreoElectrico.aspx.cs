using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class MonitoreoElectrico : System.Web.UI.Page
{

    protected static string conection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    public SqlConnection con = new SqlConnection(conection);

    protected void Page_Load(object sender, EventArgs e)
    {
        string riscei = null;
        double potencia = 0, watts = 0;
        DateTime std = DateTime.Now;
        riscei = Request["v1"];
        potencia = Convert.ToDouble(Request["v2"]);
        watts = Convert.ToDouble(Request["v3"]);
        insertRegister(riscei,potencia,watts,std);
    }

    protected void insertRegister(string riscei, double potencia, double watts, DateTime Fecha)
    {
        con.Open();
        string updateCmd = "INSERT INTO Electrico (RISCEI, Amperaje, Potencia, Fecha) values(@riscei, @potencia, @watts,@fecha)";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@riscei", riscei);
        updatecmd.Parameters.AddWithValue("@potencia", potencia);
        updatecmd.Parameters.AddWithValue("@watts", watts);
        updatecmd.Parameters.AddWithValue("@fecha", Fecha);
        updatecmd.ExecuteNonQuery();
        con.Close();
    }
}