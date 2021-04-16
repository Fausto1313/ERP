using System;
using System.IO;
public partial class Default4 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string a = documento();
        Response.Write("<script language=\"javascript\">alert(\""+a+"\");</script>");

    }

    public string documento() {
        string fn = null;
        if ((flimage.PostedFile != null) && (flimage.PostedFile.ContentLength > 0)) //nos aseguramos que el usuario haya cargado un archivo
        {
            if (flimage.Value.EndsWith(".PDF") || flimage.Value.EndsWith(".pdf")) //revisamos el tipo de archivo que nos interese, en este caso solo dejamos imagenes

            {
                if (flimage.PostedFile.ContentLength <= 50000000) //tambien podemos revisar el tamaño, en este ejemplo 500Kb

                {
                    fn = System.IO.Path.GetFileName(flimage.PostedFile.FileName);
                    string SaveLocation = Server.MapPath(@"~\Data") + "\\" + fn;
                    try
                    {
                        flimage.PostedFile.SaveAs(SaveLocation);
                        this.lblmessage.Text = "El archivo se ha cargado.";
                        
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }
                else
                    this.lblmessage.Text = "El tamaño del archivo debe ser menor a 5 mbs";
            }
            else
                this.lblmessage.Text = "No se pudo cargar el archivo seleccionado, por favor seleccione un PDF";
        }
        else
        {
            this.lblmessage.Text = "Seleccione un archivo que cargar.";
        }
        return fn;

    }
}