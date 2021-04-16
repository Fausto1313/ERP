using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ipDAR : System.Web.UI.Page
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string riscei = string.Empty, ip = string.Empty;

        riscei = Request["riscei"];
        ip = Request["ip"];
        subirDatos(riscei,ip);

    }

    protected void subirDatos(string riscei, string ip) {
        con.Open();
        SqlCommand cmd = new SqlCommand("if(select ID from IPDAR where RISCEI = @riscei) = 1 begin update IPDAR set IP=@ip where" +
            " RISCEI = @riscei end else insert into IPDAR (RISCEI, IP) values(@riscei,@ip) ",con);
        cmd.Parameters.AddWithValue("@riscei",riscei);
        cmd.Parameters.AddWithValue("@ip",ip);
        cmd.ExecuteNonQuery();
    }
}