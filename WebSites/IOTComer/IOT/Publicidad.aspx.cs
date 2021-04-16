using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Publicidad : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        ConsultarImagenes();
        cargaInfo();
        setImage();
    }

    protected void cargaInfo() {
        int f = 0, flag = 1;
        string usuario = User.Identity.Name;
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from TextoClientes where IDCliente = (select ID_Cliente from AspNetUsers " +
            "where UserName = @user) order by OrdenTexto",con);
        cmd.Parameters.AddWithValue("@user",usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while(dr.Read()) {
            f = Convert.ToInt32(dr["OrdenTexto"]);
            switch (f) {
                case 1:
                    Head1.Text = Convert.ToString(dr["TextoEncabezado"]);
                    Cont1.Text = Convert.ToString(dr["TextoContenido"]);
                    break;
                case 2:
                    Head2.Text = Convert.ToString(dr["TextoEncabezado"]);
                    Cont2.Text = Convert.ToString(dr["TextoContenido"]);
                    break;
                case 3:
                    Head3.Text = Convert.ToString(dr["TextoEncabezado"]);
                    Cont3.Text = Convert.ToString(dr["TextoContenido"]);
                    break;
                case 4:
                    Head4.Text = Convert.ToString(dr["TextoEncabezado"]);
                    Cont4.Text = Convert.ToString(dr["TextoContenido"]);
                    break;
                case 5:
                    Head5.Text = Convert.ToString(dr["TextoEncabezado"]);
                    Cont5.Text = Convert.ToString(dr["TextoContenido"]);
                    break;
                case 6:
                    Head6.Text = Convert.ToString(dr["TextoEncabezado"]);
                    Cont6.Text = Convert.ToString(dr["TextoContenido"]);
                    break;
                case 7:
                    Head7.Text = Convert.ToString(dr["TextoEncabezado"]);
                    mapa.Src = Convert.ToString(dr["TextoContenido"]);
                    break;
            }
            if (f < flag) {
                switch (f) {
                    case 1:
                        d1.Visible = false;
                        break;
                    case 2:
                        d2.Visible = false;
                        break;
                    case 3:
                        d3.Visible = false;
                        break;
                    case 4:
                        d4.Visible = false;
                        break;
                    case 5:
                        d5.Visible = false;
                        break;
                    case 6:
                        d6.Visible = false;
                        break;
                }
                flag = f;
            }
            flag++;
        }
        con.Close();
        if (f == 0) {
            contenedor0.Visible = false;
            contenedor1.Visible = false;
            contenedor2.Visible = false;
            contenedor3.Visible = false;
            banner.Visible = true;
        }
        

    }
    protected void ConsultarImagenes()
    {
        byte[] icon;
        string usuario = User.Identity.Name;
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT icono from Clientes where ID=(select ID_Cliente from AspNetUsers where UserName = @user) ";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@user", usuario);
        cmd.Connection = con;
        con.Open();
        object result = cmd.ExecuteScalar();
        con.Close();
        try
        {
            icon = (byte[])result;
            icono.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(icon);
            con.Close();
        }
        catch { }
    }

    protected void setImage() {
        
        ArrayList imagenes= new ArrayList(), links = new ArrayList();
        string usuario = User.Identity.Name;
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT Imagen, Url from imagenCliente where IDCliente=(select ID_Cliente from AspNetUsers where " +
            "UserName = @user) order by Orden";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@user", usuario);
        cmd.Connection = con;
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            try
            {
                byte[] icon;
                object result = dr[0];
                icon = (byte[])result;
                imagenes.Add("data:image/jpeg;base64," + Convert.ToBase64String(icon));
                links.Add(Convert.ToString(dr[1]));
            }
            catch { }
        }
        try
        {
            Imagen1.ImageUrl = Convert.ToString(imagenes[0]);
            Imagen2.ImageUrl = Convert.ToString(imagenes[1]);
            Imagen3.ImageUrl = Convert.ToString(imagenes[2]);
            Imagen4.ImageUrl = Convert.ToString(imagenes[3]);
            Imagen5.ImageUrl = Convert.ToString(imagenes[4]);
            Url1.NavigateUrl = Convert.ToString(links[0]);
            Url2.NavigateUrl = Convert.ToString(links[1]);
            Url3.NavigateUrl = Convert.ToString(links[2]);
            Url4.NavigateUrl = Convert.ToString(links[3]);
            Url5.NavigateUrl = Convert.ToString(links[4]);
            con.Close();
        }
        catch {
            carruselP.Visible = false;
        }
    }
}