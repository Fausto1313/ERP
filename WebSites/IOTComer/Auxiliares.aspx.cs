using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auxiliares : System.Web.UI.Page
{
    protected static string conection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    public SqlConnection con = new SqlConnection(conection);

    protected void Page_Load(object sender, EventArgs e)
    {
        string cu = string.Empty;
        cu = Request["cu"];
        switch (cu) {
            case "1":
                checkSecurity();
                break;
            case "2":
                encryptString();
                break;
            default:
                Response.Write("False");
                break;
        }
    }

    protected void encryptString() {
        string cadena = string.Empty;

        cadena = Request["cadena"];
        Response.Write(Encrypt.Encriptar(cadena));
    }
    protected void checkSecurity() {

        string riscei = string.Empty;
        riscei = Request["riscei"];
        Response.Write(checkSecuritySQL(riscei));
    }

    protected string checkSecuritySQL(string riscei) {
        string resultado = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select Seguridad from Sitios where ID=(select Cl_Sitio from UbiDis " +
            "where ID=(select UbiDis from DARS where RISCEI = @riscei))",con);
        cmd.Parameters.AddWithValue("@riscei",riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            resultado = Convert.ToString(dr[0]);
        }
       if(resultado == "") 
            resultado = "Desactivado";
        con.Close();
        return resultado;
    }
}