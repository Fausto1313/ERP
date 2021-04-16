using System;
using System.Collections.Generic;
using System.Net;
using System.Configuration;
using System.Data;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class IOT_RegistroHuella : System.Web.UI.Page
{
    DataTable dt;
    string ide = string.Empty;
    
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection con = new SqlConnection(conString);
    protected int us = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        ide = Request.QueryString["id"];
        string usuario = User.Identity.Name;
        int pantalla = 48;

        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "HuellaEmpleados")
        {
            ide = Request.QueryString["id"];
            BindGrid(ide);
            BindGrid2(ide);
            CargaNoip();
            //CargarNombre();
        }
        else
        {
            Response.Redirect("~/IOT/Home");
        }
    }

    protected void BindGrid(string id)
    {
        DataSet ds = new DataSet();
        if (id != null)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select nombre, Apellidos,ID_Nomina from empleado where Id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                IdNombre.DataSource = ds;
                IdNombre.DataBind();
               
                
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                IdNombre.DataSource = ds;
                IdNombre.DataBind();
                int columncount = IdNombre.Rows[0].Cells.Count;
                IdNombre.Rows[0].Cells.Clear();
                IdNombre.Rows[0].Cells.Add(new TableCell());
                IdNombre.Rows[0].Cells[0].ColumnSpan = columncount;
                IdNombre.Rows[0].Cells[0].Text = "No se encontraron Registros";
            }
        }

    }
   // protected void EnviarInfo(string ide)
        protected void Btnenviar_Click(object sender, EventArgs e)
    {
        if (!FlpArchivo.HasFile)
        {
            lblinformacion.Text = "Seleccione un archivo a subir";
        }
        else
        {   
            FlpArchivo.SaveAs("C:/DataIOT/HuellasPrueba/" + FlpArchivo.FileName);
            lblinformacion.Text = "El archivo " + FlpArchivo.FileName + " ha sido subido correctamente";
            string nombre_Archivo = FlpArchivo.FileName;
            

            ExecuteDoc(nombre_Archivo);
            BindGrid2(ide);
        }
    }
    protected void Btnenviar_ClickI(object sender, EventArgs e)
    {
        if (!FileUpload1.HasFile)
        {
            Label1.Text = "Seleccione una imagen a subir";
        }
        else
        {
            FileUpload1.SaveAs("~/iconos/" + FileUpload1.FileName);
            lblinformacion.Text = "La imagen " + FileUpload1.FileName + " se a subido correctamente";
            string nombre_Imagen = FileUpload1.FileName;


            ExecuteIma(nombre_Imagen);
            BindGrid2(ide);
        }
    }
    //public void CargarNombre()
    //{
    //  SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
    // cn.Open();
    //SqlCommand cmd = new SqlCommand("SELECT Nombre FROM Empleado", cn);
    //SqlDataReader dr = cmd.ExecuteReader();
    // Nombre.DataSource = dr;
    // Nombre.DataTextField = "Nombre";
    //Nombre.DataValueField = "Nombre";
    // Nombre.DataBind();
    //  }
    private void ExecuteDoc(string nombreA)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "Insert Into Archivos  (nombre_archivo, Nomina) values (@nombreA,@ide)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@nombreA", nombreA);
       
        addCmd.Parameters.AddWithValue("@ide", ide);
        addCmd.ExecuteNonQuery();
        con.Close();
        
}
    private void ExecuteIma(string nombreA)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "Update Archivos SET ImagenHuella=@nombreA where Nomina=@ide";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@nombreA", nombreA);

        addCmd.Parameters.AddWithValue("@ide", ide);
        addCmd.ExecuteNonQuery();
        con.Close();

    }
    private void ExecHuella(string v1, string id)
    {
     
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);
        string da = string.Empty;
        conn.Open();
        string query = "select nombre_archivo as archivo from Archivos where id = @id";
        SqlCommand addCmd = new SqlCommand(query, conn);
        addCmd.Parameters.AddWithValue("@id",id);
        SqlDataReader dr = addCmd.ExecuteReader();
        if (dr.Read()) {
            da = Convert.ToString(dr[0]);
        }
        string v2 = da;        
        conn.Close();
        string url;
        url = "http://" + v1 +"/phppython.php?v1=" + v2;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        //sb.Append("alert('Huella enviada.');");
        sb.Append("$('#EnviaHuellaModal').modal('hide');");
        sb.Append("@</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModal2Script", sb.ToString(), false);
        returnResponseValue(url);
    }
    protected string returnResponseValue(string url)
    {
        HttpWebRequest peticion = (HttpWebRequest)WebRequest.Create(url);
        //peticion.KeepAlive= false;
        string json2 = string.Empty;
        //peticion = WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)peticion.GetResponse();
        Stream stream = response.GetResponseStream();
        StreamReader reader = new StreamReader(stream);

        json2 = reader.ReadToEnd();
        reader.Close();
        stream.Close();
        response.Close();
        //peticion.Abort();
        return json2;
    }
    protected void BindGrid2(string id)
    {
        DataSet ds = new DataSet();
        if (id != null)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Id, nombre_archivo, Nomina, ImagenHuella from Archivos where nomina = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                Idmano.DataSource = ds;
                Idmano.DataBind();

            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                Idmano.DataSource = ds;
                Idmano.DataBind();
                int columncount = Idmano.Rows[0].Cells.Count;
                Idmano.Rows[0].Cells.Clear();
                Idmano.Rows[0].Cells.Add(new TableCell());
                Idmano.Rows[0].Cells[0].ColumnSpan = columncount;
                Idmano.Rows[0].Cells[0].Text = "No se encontraron Registros";
            }

        }
    }
    protected void Regresar(object sender, EventArgs e)
    {
        Response.Redirect("~/IOT/PermisoRisc");
    }
    protected void AgregarHuella_Click(object sender, EventArgs e)
    {

        BindGrid2(ide);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");    
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

    }

protected void BtnAddRecordClick(object sender, EventArgs e)
    {
       

       }
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {

        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("deleteRecord"))
        {
            string id = Idmano.DataKeys[index].Value.ToString();
            hfID.Value = id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
        if (e.CommandName.Equals("EnviarRecord"))
        {
            GridViewRow gvrow = Idmano.Rows[index];
            string id = Idmano.DataKeys[index].Value.ToString();
            lblID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#EnviaHuellaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
        if (e.CommandName.Equals("HuellaRecord"))
        {
            GridViewRow gvrow = Idmano.Rows[index];
            string id = Idmano.DataKeys[index].Value.ToString();
            lblID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#MuestraHuellaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string id = hfID.Value;
        ExecuteDelete(id);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registo Eliminado');");
        sb.Append("$('#eliminaModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
        ide = Request.QueryString["id"];
        BindGrid2(ide);
    }
    protected void BtnEnvia_Click(object sender, EventArgs e)
    {
        string noips = Noip.Text;
        string id = lblID.Text;
        ExecHuella(noips,id);
    }
    public void CargaNoip()
    {
        int cliente = 4;
        
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT NOIPS, Descripcion FROM Sitios where ID_cliente = @cliente", cn);
        cmd.Parameters.AddWithValue("@cliente", cliente);
        SqlDataReader dr = cmd.ExecuteReader();

        Noip.DataSource = dr;
        
        Noip.DataTextField = "Descripcion";
      
        Noip.DataValueField = "NOIPS";
        Noip.DataBind();
      
    }
    private void ExecuteDelete(string id)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try

        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updatecmd = "Delete From Archivos where Id=@id";
            SqlCommand addCmd = new SqlCommand(updatecmd, con);
            addCmd.Parameters.AddWithValue("@id", id);
            addCmd.ExecuteNonQuery();
            con.Close();

        }
        catch (SqlException e)
        {
            Console.WriteLine("Excepcion Ocurrida: ", e);
        }
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Idmano.PageIndex = e.NewPageIndex;
        this.BindGrid2(ide);
    }

}