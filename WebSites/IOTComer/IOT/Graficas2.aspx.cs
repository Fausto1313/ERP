using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_Graficas2 : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        cargaDatos();
    }
    protected void cargaDatos() {
        List<int> cantidades = new List<int>();
        List<string> dis = new List<string>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select COUNT(ds.ID) as Cuenta, d.RISCEI from DARS d inner join DispositivosSensores " +
            "ds on ds.RISCEI = d.RISCEI inner join UbiDis u on u.Id = d.UbiDis where u.Cl_Sitio = 7 group by d.RISCEI",con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            cantidades.Add(Convert.ToInt32(dr["Cuenta"]));
            dis.Add(Convert.ToString(dr["RISCEI"]));
        }
        con.Close();
        ctl00.Series["Series1"].Points.DataBindXY(dis,cantidades);
    }
}