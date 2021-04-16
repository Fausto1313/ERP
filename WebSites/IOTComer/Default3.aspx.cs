using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        TextoPrueba.Text = "Hola Josh";

    }

    /*private void Submit1_ServerClick(object sender, System.EventArgs e)
    {
        if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
        {
            string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
            string SaveLocation = Server.MapPath("Data") + "\\" + fn;
            try
            {
                File1.PostedFile.SaveAs(SaveLocation);
                Response.Write("<script language=\"javascript\">alert(\"" + SaveLocation + "\");</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert(\"" + SaveLocation + "\");</script>");
                //Note: Exception.Message returns a detailed message that describes the current exception. 
                //For security reasons, we do not recommend that you return Exception.Message to end users in 
                //production environments. It would be better to put a generic error message. 
            }
        }
        else
        {
            Response.Write("Please select a file to upload.");
        }

    }
    */


    protected void BotonPrueba_Click(object sender, EventArgs e)
    {
        TextoPrueba.Text = "Adios Josh";
    }

    protected void prueba2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(conString);

        SqlCommand consulta = new SqlCommand("select * from DARS where tipo = @dar",con);
        consulta.Parameters.AddWithValue("@dar","DAR");
        con.Open();
        SqlDataReader lector = consulta.ExecuteReader();
        if (lector.Read()) { 
            
        }
        con.Close();

    }
}