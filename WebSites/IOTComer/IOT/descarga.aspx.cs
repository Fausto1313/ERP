using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_descarga : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string documento = Request.QueryString["v1"];
        Response.Clear();
        // Con esto le decimos al browser que la salida sera descargable
        Response.ContentType = "application/octet-stream";
        // esta linea es opcional, en donde podemos cambiar el nombre del fichero a descargar (para que sea diferente al original)
        Response.AddHeader("Content-Disposition", "attachment; filename=" + documento + "");
        // Escribimos el fichero a enviar 
        Response.WriteFile("C:/Users/PC/Downloads/" + documento + "");
        Response.Write("Prueba");
        // volcamos el stream 
        Response.Flush();
        // Enviamos todo el encabezado ahora
        Response.End();
    }
}