using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class temporal : System.Web.UI.Page
{
    protected static string conection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    public SqlConnection con = new SqlConnection(conection);

    protected void Page_Load(object sender, EventArgs e)
    {
        string riscei = null, estado = null, evento = null;
        DateTime std = DateTime.Now;
        riscei = Request["v1"];
        evento = Request["v2"];
        estado = Request["v3"];
        saveRegister(riscei, evento, estado, std);
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
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
}