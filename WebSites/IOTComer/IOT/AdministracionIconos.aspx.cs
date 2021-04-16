using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_AdministracionCatalogos : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Guardar_Click(object sender, EventArgs e)
    {
        int tamimg = Imagen.PostedFile.ContentLength;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        if (tamimg == 0 )
        {
            sb.Append("swal(\"Error!\", \"Subir imagen antes de continuar.\", \"warning\");");
        }
        else
        {
            //datos de la imagen
            byte[] imagenOriginal = new byte[tamimg];
            Imagen.PostedFile.InputStream.Read(imagenOriginal, 0, tamimg);
            Bitmap imgoriginalbinaria = new Bitmap(Imagen.PostedFile.InputStream);
            //recuperar valores para subirlos la alta en base de datos
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into repoIconos(Icono, Nombre) " +
                "values(@imagen, @nombre)", con);
            cmd.Parameters.AddWithValue("@imagen", SqlDbType.Image).Value = imagenOriginal;
            cmd.Parameters.AddWithValue("@nombre", txtCategoria.Text);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            sb.Append("swal(\"Guardado!\", \"Imagen agregada de forma correcta.\", \"success\");");
        }
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
    }
}