using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       /* int i = 0;
        string esta = "Activo";
        SqlConnection cn = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=IOTComer;User ID=sa;Password=sa+LANSA!;Pooling=False");
        cn.Open();
        DateTime[] ini = new DateTime[100];
        DateTime[] fin = new DateTime[100];
        DateTime now = DateTime.Now;
        SqlCommand cmd = new SqlCommand("SELECT FechaInicio,FechaFin FROM Activador where Estatus=@estas", cn);
        cmd.Parameters.AddWithValue("@estas", esta);
        SqlDataReader dr = cmd.ExecuteReader();
        while(dr.Read())
        {
            ini[i] = Convert.ToDateTime(dr[0]);
            fin[i] = Convert.ToDateTime(dr[1]);
            i++;
        }
        cn.Close();
    
        Response.Write("<script language=\"javascript\">alert(\"Tu estatus es" + ini[2] + "\");</script>");
   */ }
    /*
    protected void descargar_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=IOTComer;User ID=sa;Password=sa+LANSA!;Pooling=False");
        cn.Open();
        string modelo = "DAR-BIS";
        string documento = null;
        SqlCommand cmd = new SqlCommand("SELECT Documento FROM Modelos where Modelo=@modelo", cn);
        cmd.Parameters.AddWithValue("@modelo", modelo);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            documento  = Convert.ToString(dr[0]);
        }
        cn.Close();

        Response.Clear();
        // Con esto le decimos al browser que la salida sera descargable
        Response.ContentType = "application/octet-stream";
        // esta linea es opcional, en donde podemos cambiar el nombre del fichero a descargar (para que sea diferente al original)
        Response.AddHeader("Content-Disposition", "attachment; filename="+documento+"");
        // Escribimos el fichero a enviar 
        Response.WriteFile("C:/DataIOT/"+documento+"");
        // volcamos el stream 
        Response.Flush();
        // Enviamos todo el encabezado ahora
        Response.End();
    }*/

    protected void irServicio(String variable)
    {
        // Create a request using a URL that can receive a post. 
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(variable);
        request.GetResponseAsync();
       /* Stream objStream;
        objStream = request.GetResponse().GetResponseStream();
        */
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        String variable = "http://risc-iot.ddns.net:4041/1710LE2005/ON";
        try
        {
            irServicio(variable);
        }
        catch (Exception ef) {
            Response.Redirect("~/Default5");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        String variable = "http://risc-iot.ddns.net:4041/1710LE2005/OFF";
        try
        {
            irServicio(variable);
        }
        catch (Exception xe) {

            Response.Redirect("~/Default5");
        }
    }
}