using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class IOT_SubirImgPlano : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 18;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, 0) == "RISC")
        {
            if (!IsPostBack)
            {
                iniciarLlenadoDownList();
            }
            else if (permiso.returnPermiso(usuario, pantalla) == "Subir Planos")
            {

            }
            
        }
        else
            Response.Redirect("~/IOT/Home");
    }

    protected void BtnSubir(object sender, EventArgs e)
    {
        //datos de la imagen
        int tamimg = fuploadimagen.PostedFile.ContentLength;
        byte[] imagenOriginal = new byte[tamimg];
        fuploadimagen.PostedFile.InputStream.Read(imagenOriginal, 0, tamimg);
        Bitmap imgoriginalbinaria = new Bitmap(fuploadimagen.PostedFile.InputStream);
        //recuperar valores para subirlos la alta en base de datos
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Insert into ImagenesPlano(titulo, imagen, idcliente, nivel1) Values (@titulo, @imagen, @idcliente, @nivel1)", con);
        cmd.Parameters.Add("@titulo", SqlDbType.Text).Value = txttitulo.Text;
        cmd.Parameters.AddWithValue("@imagen", SqlDbType.Image).Value = imagenOriginal;
        //int idcli = Convert.ToInt32(DropDownList1.SelectedValue);
        cmd.Parameters.Add("@idcliente", SqlDbType.Int).Value = Clientes.SelectedValue;
        cmd.Parameters.Add("@nivel1", SqlDbType.Int).Value = Nilveles.SelectedValue;
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
        con.Close();
        string imgDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(imagenOriginal);
        imgPreview.ImageUrl = imgDataURL64;

    }

    protected void BtnUpdate(object sender, EventArgs e)
    {
        //datos de la imagen
        int tamimg = fuploadimagen.PostedFile.ContentLength;
        byte[] imagenOriginal = new byte[tamimg];
        fuploadimagen.PostedFile.InputStream.Read(imagenOriginal, 0, tamimg);
        Bitmap imgoriginalbinaria = new Bitmap(fuploadimagen.PostedFile.InputStream);

        //recuperar valores para subirlos la alta en base de datos
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand("update ImagenesPlano set titulo=@titulo, imagen=@imagen, idcliente=@idcliente where nivel1=@nivel1", con);
        cmd.Parameters.Add("@titulo", SqlDbType.Text).Value = txttitulo.Text;
        cmd.Parameters.AddWithValue("@imagen", SqlDbType.Image).Value = imagenOriginal;
        //int idcli = Convert.ToInt32(DropDownList1.SelectedValue);
        cmd.Parameters.Add("@idcliente", SqlDbType.Int).Value = Clientes.SelectedValue;
        cmd.Parameters.Add("@nivel1", SqlDbType.Int).Value = Nilveles.SelectedValue;
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
        con.Close();

        string imgDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(imagenOriginal);
        imgPreview.ImageUrl = imgDataURL64;
    }

    protected void iniciarLlenadoDownList()
    {
        Clientes.DataSource = Consultar("SELECT * FROM CLIENTES ");
        Clientes.DataValueField = "ID";
        Clientes.DataTextField = "RazonSocial";
        Clientes.DataBind();
        Clientes.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Sitios.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Nilveles.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }

    protected void ClienteSelecionado(object sender, EventArgs e)
    {
        int cliente = Convert.ToInt32(Clientes.SelectedValue);
        Sitios.DataSource = Consultar("Select * FROM Sitios Where ID_cliente =" + cliente);
        Sitios.DataValueField = "ID";
        Sitios.DataTextField = "C_Sitio";
        Sitios.DataBind();
        Sitios.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

    }

    protected void SitioSeleccionado(object sender, EventArgs e)
    {
        int sitio = Convert.ToInt32(Sitios.SelectedValue);
        Nilveles.DataSource = Consultar("Select * From nivel1 n1, ubidis ud, sitios s where n1.ID = ud.nivel1 And s.ID = ud.Cl_Sitio AND s.ID = " + sitio);
        Nilveles.DataValueField = "ID";
        Nilveles.DataTextField = "Nombre";
        Nilveles.DataBind();
        Nilveles.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }
    protected void Nivel_Seleccionado(object sender, EventArgs e)
    {
    }
   
    protected DataSet Consultar(string consulta)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand(consulta, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }
}