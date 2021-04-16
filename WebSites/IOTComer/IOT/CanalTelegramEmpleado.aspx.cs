using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_CanalTelegramEmpleado : System.Web.UI.Page
{

    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected int us = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 50;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "CanalTelegramEmpleado")
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

        string sitio = Sitio.SelectedValue;
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select a1.ID, a1.Nombre, a1.Apellidos, ct.CanalTelegram, ct.NombreCanal, a1.Tipo, a1.Estatus from " +
            "CanalTelegram ct inner join(select ce.ID, e.Nombre, e.Apellidos, ce.ID_Telegram, ce.Tipo, ce.Estatus from " +
            "Empleado e inner join CanalEmpleados ce on e.ID = ce.ID_Empleado where e.Sitio = @sitio) as a1 " +
            "on ct.CanalTelegram = a1.ID_Telegram where ct.Usuario = @usuario", conn);
        cmd.Parameters.AddWithValue("@sitio", sitio);
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
        Empleado.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Canal.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }
    protected void CargaEmpleado()
    {
        string sit = Sitio.SelectedValue;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select id, nombre from Empleado where Sitio=@sit", conn);
        cmd.Parameters.AddWithValue("@sit", sit);
        SqlDataReader dr = cmd.ExecuteReader();
        Empleado.DataSource = dr;
        Empleado.DataTextField = "Nombre";
        Empleado.DataValueField = "id";
        Empleado.DataBind();
        Empleado.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        conn.Close();
    }
    protected void CargaCanales()
    {
        string user = User.Identity.Name;
        string sit = Sitio.SelectedValue;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select CanalTelegram from CanalTelegram where ID_Sitio = @sit and Usuario = @user", conn);
        cmd.Parameters.AddWithValue("@sit", sit);
        cmd.Parameters.AddWithValue("@user", user);
        SqlDataReader dr = cmd.ExecuteReader();
        Canal.DataSource = dr;
        Canal.DataTextField = "CanalTelegram";
        Canal.DataValueField = "CanalTelegram";
        Canal.DataBind();
        Canal.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        conn.Close();
    }

    protected void CargaCanalesModal()
    {
        string user = User.Identity.Name;
        string sit = Sitio.SelectedValue;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select CanalTelegram from CanalTelegram where ID_Sitio = @sit and Usuario=@user", conn);
        cmd.Parameters.AddWithValue("@sit", sit);
        cmd.Parameters.AddWithValue("@user", user);
        SqlDataReader dr = cmd.ExecuteReader();
        Can.DataSource = dr;
        Can.DataTextField = "CanalTelegram";
        Can.DataValueField = "CanalTelegram";
        Can.DataBind();
        conn.Close();
    }

    protected void Carga_select(object sender, EventArgs e)
    {
        CargaCanales();
        CargaEmpleado();
    }

    private void ExecuteAdd()
    {
        string sitio = Sitio.Text;
        string empleado = Empleado.SelectedValue;
        string canal = Canal.Text;
        string tipo = Tipo.SelectedValue;
        string estatus = Estatus.SelectedValue;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);
        conn.Open();
        string updatecmd = "insert into CanalEmpleados (ID_Sitio, ID_empleado, ID_Telegram, Tipo, Estatus) values (@sitio, @empleado, @canal, @tipo, @estatus)";
        SqlCommand addCmd = new SqlCommand(updatecmd, conn);
        addCmd.Parameters.AddWithValue("@sitio", sitio);
        addCmd.Parameters.AddWithValue("@empleado", empleado);
        addCmd.Parameters.AddWithValue("@canal", canal);
        addCmd.Parameters.AddWithValue("@tipo", tipo);
        addCmd.Parameters.AddWithValue("@estatus", estatus);
        addCmd.ExecuteNonQuery();
        conn.Close();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Canal asignado al empleado');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
        BindGrid();
    }

    protected void Asignar_Canal(object sender, EventArgs e)
    {
        ExecuteAdd();
    }
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("Actualizar"))
        {            
            GridViewRow gvrow = GridView1.Rows[index];
            lblID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            lblNombre.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            lblActual.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            CargaCanalesModal();
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("Eliminar"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            hfID.Value = id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string id = lblID.Text;
        string can = Can.Text;
        string tipo = tipo1.SelectedValue;
        string est = estatus1.SelectedValue;
        ExecuteUpdate(id, can, tipo, est);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Canal actualizado correctamente');");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
    }
    private void ExecuteUpdate(string id, string can,string tipo, string est)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE CanalEmpleados SET ID_Telegram = @can, Tipo = @tipo, Estatus = @est  WHERE ID=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@can", can);
        updatecmd.Parameters.AddWithValue("@tipo", tipo);
        updatecmd.Parameters.AddWithValue("@est", est);
        updatecmd.ExecuteNonQuery();
        con.Close();
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

    private void ExecuteDelete(string id)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updatecmd = "delete from CanalEmpleados where Id=@id";
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

}