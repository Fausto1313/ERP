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

public partial class IOT_AdministracionPagina : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Insertar_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        string usuario = User.Identity.Name;
        con.Open();
        SqlCommand cmd = new SqlCommand("if(select COUNT(ID) from TextoClientes where IDCliente=(select ID_Cliente from " +
            "AspNetUsers where UserName=@usuario) and OrdenTexto = @orden) > 0 begin update TextoClientes set " +
            "TextoEncabezado = @inicial, TextoContenido = @contenido where IDCliente = (select ID_Cliente from " +
            "AspNetUsers where UserName = @usuario) and OrdenTexto = @orden end else begin insert into TextoClientes" +
            "(TextoEncabezado, TextoContenido, OrdenTexto, IDCliente) values(@inicial, @contenido, @orden, (select " +
            "ID_Cliente from AspNetUsers where UserName = @usuario)) end",con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@orden", Convert.ToInt32(Categoria.SelectedValue));
        cmd.Parameters.AddWithValue("@inicial", txtEncabezado.Text);
        cmd.Parameters.AddWithValue("@contenido", txtContenido.Text);
        cmd.ExecuteNonQuery();
        con.Close();
        sb.Append("swal(\"Guardado!\", \"Registro agregado correctamente.\", \"success\");");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddAlertInsert", sb.ToString(), false);
    }

    protected void GuardaImagen_Click(object sender, EventArgs e)
    {
        int tamimg = Imagen.PostedFile.ContentLength;
        int imag = Convert.ToInt32(NumeroImagen.SelectedValue);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        if (tamimg == 0 || imag == 0)
        {
            sb.Append("swal(\"Error!\", \"Subir imagen antes de continuar o seleccionar posición.\", \"warning\");");
        }
        else
        {
            //datos de la imagen
            byte[] imagenOriginal = new byte[tamimg];
            Imagen.PostedFile.InputStream.Read(imagenOriginal, 0, tamimg);
            Bitmap imgoriginalbinaria = new Bitmap(Imagen.PostedFile.InputStream);
            //recuperar valores para subirlos la alta en base de datos
            con.Open();
            SqlCommand cmd = new SqlCommand("if(select count(ID) from ImagenCliente where IDCliente=(select ID_Cliente from AspNetUsers" +
                " where UserName = @usuario) and Orden = @orden) > 0 " +
                "begin update ImagenCliente set Imagen = @imagen, Url = @url where IDCliente = (select ID_Cliente from AspNetUsers " +
                "where UserName = @usuario) and Orden = @orden end else insert into ImagenCliente(Orden, Imagen, Url, IDCliente) values(@orden, @imagen, @url, (select ID_Cliente" +
                " from AspNetUsers where UserName = @usuario))", con);
            cmd.Parameters.AddWithValue("@orden",imag);
            cmd.Parameters.AddWithValue("@imagen", SqlDbType.Image).Value = imagenOriginal;
            if(txtURL.Text!="")
            cmd.Parameters.AddWithValue("@url", txtURL.Text);
            cmd.Parameters.AddWithValue("@usuario", User.Identity.Name);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            sb.Append("swal(\"Guardado!\", \"Imagen agregada de forma correcta.\", \"success\");");
        }
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
    }
}