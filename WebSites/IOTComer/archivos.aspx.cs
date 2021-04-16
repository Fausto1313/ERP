using System;

using System.IO;


public partial class archivos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string rutaCompleta = @"C:\Scripts\testing.vbs";
        string texto = "objShell.Run \"curl risc-iot.ddns.net:4040/1710LE2005/ON\",vbhide";

        using (StreamWriter file = new StreamWriter(rutaCompleta, true))
        {
            file.WriteLine("Set objShell = CreateObject(\"WScript.Shell\")"); //se agrega información al documento
            file.WriteLine(texto);
            file.Close();
        }
    }
}