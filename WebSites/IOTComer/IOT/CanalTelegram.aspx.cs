using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_CanalTelegram : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected int us = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 49;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "CanalTelegram")
        {
            if (!IsPostBack)
            {
                CargaSitio();
            }
            BindGrid();
        }
        else
        {
            Response.Redirect("~/IOT/Home");
        }
    }
    protected void BindGrid()
    {
      
        string sit = Sitio.SelectedValue;
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select CanalTelegram, NombreCanal, Primario from CanalTelegram where ID_Sitio=@sit and Usuario = @usuario", conn);
        cmd.Parameters.AddWithValue("@sit", sit);
        cmd.Parameters.AddWithValue("@usuario", usuario);
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
    protected void CargaSitio()
    {
        Sitio.DataSource = Consultar("if(select 1 from PermisoRol where ID_Permiso = 36 and ID_Rol = (select ID_Rol from AspNetUsers where UserName = @usuario)) = 1 " +
                                      "select id, C_Sitio from sitios where ID_cliente = (select id_cliente from AspNetUsers where UserName = @usuario) " +
                                      "else select id, C_Sitio from sitios where ID = (select C_Sitio from AspNetUsers where UserName = @usuario)");
        Sitio.DataValueField = "ID";
        Sitio.DataTextField = "C_Sitio";
        Sitio.DataBind();
        Sitio.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }

    private void ExecuteAdd()
    {
        string res = null;
        string usuario = User.Identity.Name;
        string prim = primario.Checked ? "Primario" : "Secundario";
        string sit = Sitio.SelectedValue;
        string canal = "@" + txtCanal.Text;
        string nombre = txtNombre.Text;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);
        conn.Open();
        string updatecmd = "if(select COUNT(CanalTelegram) from CanalTelegram where CanalTelegram =@canal) <1 begin " +
                            "if (@primario != 'Secundario') begin if (select COUNT(CanalTelegram) from CanalTelegram where Usuario = @usuario and " +
                            "ID_Sitio = @sitio and Primario = @primario) < 1 begin insert into CanalTelegram(CanalTelegram, NombreCanal, ID_Sitio, Usuario, Primario)" +
                            "values(@canal, @nombre, @sitio, @usuario, @primario) select 'OK'; end " +
                            "else select 'Asignado'; end else begin insert into CanalTelegram(CanalTelegram, NombreCanal, ID_Sitio, Usuario, Primario)" +
                            "values(@canal, @nombre, @sitio, @usuario, @primario)" +
                            "select 'OK' end end else select 'Existente'";
        SqlCommand addCmd = new SqlCommand(updatecmd, conn);
        addCmd.Parameters.AddWithValue("@canal", canal);
        addCmd.Parameters.AddWithValue("@sitio", sit);
        addCmd.Parameters.AddWithValue("@nombre", nombre);
        addCmd.Parameters.AddWithValue("@usuario", usuario);
        addCmd.Parameters.AddWithValue("@primario", prim);
        SqlDataReader dr = addCmd.ExecuteReader();
        if (dr.Read())
        {
            res = Convert.ToString(dr[0]);
        }
        conn.Close();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        if (res == "OK")
        {
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Canal Agregado');");
            sb.Append(@"</script>");
            BindGrid();
        }
        else if (res == "Existente")
        {
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('El canal ya existe');");
            sb.Append(@"</script>");
        }
        else if (res == "Asignado")
        {
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('El canal ya primario ya esta asignado');");
            sb.Append(@"</script>");
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "addHideModalScript", sb.ToString(), false);            
    }
    protected void Agregar_Canal(object sender, EventArgs e)
    {
        ExecuteAdd();
    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("Actualizar"))
        {
            GridViewRow gvrow = GridView1.Rows[index];
            lblCanal.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtNombre1.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }
        else if (e.CommandName.Equals("Eliminar"))
        {
            GridViewRow gvrow = GridView1.Rows[index];
            string id = HttpUtility.HtmlDecode(gvrow.Cells[0].Text);
            hfID.Value = id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
    }
    private void ExecuteDelete(string id)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updatecmd = "delete from CanalTelegram where CanalTelegram=@id";
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
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string id = hfID.Value;
        ExecuteDelete(id);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registo Eliminado');");
        sb.Append("$('#eliminaModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string canal = lblCanal.Text;
        string nombre = txtNombre1.Text;
        string tipo = Tipo.SelectedValue;
        ExecuteUpdate(canal, nombre, tipo);
        BindGrid();
    }
    private void ExecuteUpdate(string canal, string nombre, string tipo)
    {
        string res = null;
        string usuario = User.Identity.Name;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "if(@tipo = 'Primario') begin if (select COUNT(CanalTelegram) as a1 from CanalTelegram where Primario = 'Primario' and CanalTelegram != @canal and " +
                            "ID_Sitio = (select ID_Sitio from AspNetUsers where UserName = @usuario) and Usuario = @usuario) < 1 begin UPDATE CanalTelegram SET NombreCanal = @nombre, Primario = @tipo WHERE CanalTelegram = @canal " + 
                            "select 'OK' end else select 'Asignado' end else begin " +
                            "UPDATE CanalTelegram SET NombreCanal = @nombre, Primario = @tipo WHERE CanalTelegram = @canal select 'OK' end";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@canal", canal);
        updatecmd.Parameters.AddWithValue("@nombre", nombre);
        updatecmd.Parameters.AddWithValue("@tipo", tipo);
        updatecmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = updatecmd.ExecuteReader();
        if (dr.Read())
        {
            res = Convert.ToString(dr[0]);
        }
        con.Close();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        if (res == "Asignado")
        {
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Ya existe un canal primario');");
            sb.Append("$('#updModal').modal('hide');");
            sb.Append(@"</script>");
        }
        else if (res == "OK")
        {
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Registro actualizado exitosamente');");
            sb.Append("$('#updModal').modal('hide');");
            sb.Append(@"</script>");
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "addHideModalScript", sb.ToString(), false);
    }

}