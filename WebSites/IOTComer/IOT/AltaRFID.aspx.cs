using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_AltaRFID : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected int us = 0;
    protected int sitioID = 0;
    protected string sit = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;

        int pantalla = 52;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Alta de RFID")
        {
            sitioID = Convert.ToInt32(Request.QueryString["sitio"]);
            if (sitioID == 0)
            {
                if (!IsPostBack)
                {
                    CargarSitio();
                }
            }
            else
            {
                if (!IsPostBack)
                {
                    CargarSitio();
                }
                BindGrid();
            }
            
        }
        else
        {
            Response.Redirect("~/IOT/Home");
        }
    }

    public void BindGrid()
    {
        sit = Sitio.SelectedValue;
        if (sitioID > 0 && sit=="0")
            sit = Convert.ToString(sitioID);        
        conn.Open();
        SqlCommand cmd = new SqlCommand("select ID, Nombre, ApellidoPat, ApellidoMat, Correo, Telefono, RFID from UsuarioRFID where Sitio=@sit", conn);
        cmd.Parameters.AddWithValue("@sit", sit);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GridView1.DataSource = ds;
            GridView1.DataBind();
            int columncount = GridView1.Rows[0].Cells.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
            GridView1.Rows[0].Cells[0].Text = "No se encontraron Registros";
        }
    }
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        string nombre = Nombre.Text;
        string apellidoPat = ApellidoPat.Text;
        string apellidoMat = ApellidoMat.Text;
        string correo = Correo.Text;
        string telefono = Telefono.Text;
        string sitio = Sitio.SelectedValue;
        string rfid = RFID.Text;
        long r = Convert.ToInt64(rfid);
        string nuevoRfid = r.ToString("X8");
        string nuevoRfid2 = nuevoRfid.Substring(6,2) + nuevoRfid.Substring(4, 2) + nuevoRfid.Substring(2, 2) + nuevoRfid.Substring(0, 2);        
        string respuesta = ExecuteAdd(nombre,apellidoPat,apellidoMat,correo,telefono,sitio,nuevoRfid2);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        if (respuesta == "False")
        {
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Tarjeta RFID ya asignada. Ingresar otra tarjeta');");
            sb.Append(@"</script>");
        }
        else {
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Registro Agregado');");
            sb.Append("$('#addModal').modal('hide');");
            sb.Append(@"</script>");
            BindGrid();
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
    }
    private string ExecuteAdd(string nombre, string apellidoPat, string apellidoMat, string correo, string telefono, string sitio, string rfid)
    {
        string respuesta = string.Empty;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "if(select count(ID) from UsuarioRFID where RFID = @RFID) = 0 insert into UsuarioRFID " +
            "(Nombre, ApellidoPat, ApellidoMat, Correo, Telefono, Sitio, RFID) values(@Nombre, @ApellidoPat, @ApellidoMat, " +
            "@Correo, @Telefono, @Sitio, @RFID) else select 'False'";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@Nombre", nombre);
        addCmd.Parameters.AddWithValue("@ApellidoPat", apellidoPat);
        addCmd.Parameters.AddWithValue("@ApellidoMat", apellidoMat);
        addCmd.Parameters.AddWithValue("@Correo", correo);
        addCmd.Parameters.AddWithValue("@Telefono", telefono);
        addCmd.Parameters.AddWithValue("@Sitio", sitio);
        addCmd.Parameters.AddWithValue("@RFID", rfid);
        SqlDataReader dr = addCmd.ExecuteReader();
        if (dr.Read()) {
            respuesta = Convert.ToString(dr[0]);
        }
        con.Close();
        return respuesta;   
    }

    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("actualizar"))
        {
            GridViewRow gvrow = GridView1.Rows[index];
            lblID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text);
            txtNombre.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            txtPaterno.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
            txtMaterno.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            txtCorreo.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
            txtTelefono.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("deleteRecord"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            hfID.Value = id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("asignar"))
        {
            GridViewRow gvrow2 = GridView1.Rows[index];
            string id = HttpUtility.HtmlDecode(gvrow2.Cells[0].Text).ToString();
            string sitio = Sitio.SelectedValue;
            if (sitio == "0")
                sitio = sit;
            Response.Redirect("~/IOT/PermisoPuertas?usuario=" + id + "&sitio=" + sitio);
        }
    }
    protected void CargarSitio()
    {
        Sitio.DataSource = Consultar("select ID, C_Sitio from Sitios where ID_cliente=(select ID_Cliente from AspNetUsers where UserName=@usuario)");
        Sitio.DataValueField = "ID";
        Sitio.DataTextField = "C_Sitio";
        Sitio.DataBind();
        Sitio.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }
    protected DataSet Consultar(string consulta)
    {
        string usuario = Context.User.Identity.Name;    
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand(consulta, con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }

    protected void Sitio_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void BtnUpdate(object sender, EventArgs e)
    {
        string id = lblID.Text;
        string nom = txtNombre.Text;
        string pat = txtPaterno.Text;
        string mat = txtMaterno.Text;
        string mail = txtCorreo.Text;
        string tel = txtTelefono.Text;
        ExecuteUpdate(id, nom, pat, mat, mail, tel);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
        BindGrid();
    }

    protected string editInformation() {
        string respuesta = string.Empty;

        return respuesta;
    }

    /*protected string editRFID(int sitio, string codigo, int idUsuario) {
        string respuesta = string.Empty;
        string tagAnterior = anterior(idUsuario);
        conn.Open();
        SqlCommand cmd = new SqlCommand("if(select s.MultipleNOIP from Sitios s where s.ID = @id) = 0 begin " +
            "select S.NOIP from Sitios s where ID = @id end else select n1.NOIP from Nivel1 n1 where n1.UbiDispo = @id",conn);
        cmd.Parameters.AddWithValue("@id",sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            string url = "https://addar.mx/Especiales/peticionRFID.php?v1="+Convert.ToString(dr[0])+"&v2=4&v3="+tagAnterior+"&v4="+codigo;
            if(returnResponseValue(url)=="True")
                respuesta = returnResponseValue(url);
        }
        conn.Close();
        return respuesta;
    }*/

    /*protected string anterior(int usuario) {
        string RFID = string.Empty;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select RFID from UsuarioRFID where ID = @id");
        cmd.Parameters.AddWithValue("@id",usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            RFID = Convert.ToString(dr[0]);
        }
        conn.Close();
        return RFID;
    }*/

    /*protected string returnResponseValue(string url)
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
    }*/
    private void ExecuteUpdate(string id, string nom, string pat, string mat, string mail, string tel)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE UsuarioRFID SET Nombre=@nom, ApellidoPat=@pat, ApellidoMat=@mat, Correo=@mail, " +
            "Telefono=@tel WHERE ID=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@nom", nom);
        updatecmd.Parameters.AddWithValue("@pat", pat);
        updatecmd.Parameters.AddWithValue("@mat", mat);
        updatecmd.Parameters.AddWithValue("@mail", mail);
        updatecmd.Parameters.AddWithValue("@tel", tel);
        updatecmd.ExecuteNonQuery();
        con.Close();
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(hfID.Value);
        string validar = ExecuteDelete(id);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        if (validar == "False")
        {
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Usuario aún con permisos.');");
            //sb.Append("$('#eliminaModal').modal('hide');");
            sb.Append(@"</script>");
        }
        else {
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Registo Eliminado');");
            sb.Append("$('#eliminaModal').modal('hide');");
            sb.Append(@"</script>");
            BindGrid();
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
    }
    private string ExecuteDelete(int id)
    {
        string validacion = string.Empty;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updatecmd = "if(select COUNT(ID) from ReglasRFIDUsuario where IDUsuario = @id) = 0 delete from " +
                "UsuarioRFID where ID = @id else select 'False'";
            SqlCommand addCmd = new SqlCommand(updatecmd, con);
            addCmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = addCmd.ExecuteReader();
            if (dr.Read()) {
                validacion = Convert.ToString(dr[0]);
            }
            con.Close();

        }
        catch (SqlException e)
        {
            Console.WriteLine("Excepcion Ocurrida: ", e);
        }
        return validacion;
    }

    protected void volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/IOT/CatalogoAdminEm");
    }
}