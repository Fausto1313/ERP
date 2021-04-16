using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using IOTComer;

public partial class IOT_usuariocliente : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected int us = 0;
    protected string role = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            cargaClientes();
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);
        conn.Open();
        string usuario = User.Identity.Name;
        int pantalla = 15;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario,pantalla) == "Usuarios Cliente")
        {
            BindGrid2();
        }
        else
            Response.Redirect("~/IOT/Home");
    }
    public void BindGrid2()
    {

        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "Select UserName, Nombre, Apellido, Habilitado from AspNetUsers ";
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    sql += "Where ( UserName LIKE '%' + @Busqueda + '%' OR Nombre LIKE '%' + @Busqueda + '%' OR Apellido LIKE '%' + @Busqueda + '%' OR Habilitado LIKE '%' + @Busqueda + '%')";
                    cmd.Parameters.AddWithValue("@Busqueda", txtSearch.Text.Trim());
                }
                cmd.CommandText = sql;
                cmd.Connection = con;

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }
    protected void Search(object sender, EventArgs e)
    {
        this.BindGrid2();
    }

    protected void CreateUser_Click(object sender, EventArgs e)
    {
        string dis = dar.Text;
        var manager = new UserManager();
        var user = new ApplicationUser() { UserName = UserName.Text + dis };
        string nombre = Nombre.Text;
        string apellido = Apellido.Text;
        string id = UserName.Text;    
        int clientes = Convert.ToInt32(Clientes.Text);
        int roless = Convert.ToInt32(Roles.Text);
        string usuario = User.Identity.Name;
        IdentityResult result = manager.Create(user, Password.Text);
        int sitio = ObtenerSitio(dis);
        Executeadd(id + dis, nombre, apellido, clientes, roless, sitio);
        if (result.Succeeded)
        {
            BindGrid();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Registro agregado exitosamente');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddScript", sb.ToString(), false);
            
        }
        else
        {
            BindGrid();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('No se pudo completar el registro.');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddScript", sb.ToString(), false);
        }

    }
     
    private int ObtenerSitio(string riscei)
    {
        int sitio = 0;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand("select u.Cl_Sitio from DARS d inner join UbiDis u on d.UbiDis = u.Id where d.RISCEI = @riscei", con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            sitio = Convert.ToInt32(dr[0]);
        }
        return sitio;
    }

    private void Executeadd(string id, string nombre, string apellido, int clientes, int rol, int sitio)
    {
        string estatus = Habilitado.SelectedValue;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE AspNetUsers SET C_sitio=@sitio, Nombre=@nombre,Apellido=@apellido,ID_Cliente=@clientes, Id_Rol=@rol, Habilitado=@estatus WHERE UserName=@id ";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@clientes", clientes);
        updatecmd.Parameters.AddWithValue("@rol", rol);
        updatecmd.Parameters.AddWithValue("@nombre", nombre);
        updatecmd.Parameters.AddWithValue("@apellido", apellido);
        updatecmd.Parameters.AddWithValue("@sitio", sitio);
        updatecmd.Parameters.AddWithValue("@estatus", estatus);
        updatecmd.Parameters.AddWithValue("@id", id);

        updatecmd.ExecuteNonQuery();
        con.Close();

    }
    public void cargaRoles(int id)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT Id,Name FROM dbo.AspNetRoles where ID_Cliente=@id", cn);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader dr = cmd.ExecuteReader();
        Roles.DataSource = dr;
        Roles.DataTextField = "Name";
        Roles.DataValueField = "Id";
        Roles.DataBind();
        if (Clientes.Items.Count != 0)
        {
            role = Convert.ToString(Roles.SelectedValue);
        }
        else
        {
            Roles.Items.Clear();
        }
    }

    public void cargaDars(int id)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("select d.RISCEI, s.Descripcion from sitios s, dars d inner join UbiDis u on u.Id=d.UbiDis where u.Cl_Sitio = s.ID and s.ID_cliente = @cliente and d.Modelo = 'DAR'", cn);
        cmd.Parameters.AddWithValue("@cliente", id);
        SqlDataReader dr = cmd.ExecuteReader();
        dar.DataSource = dr;
        dar.DataValueField = "RISCEI";
        dar.DataTextField = "Descripcion";
        dar.DataBind();
        if (Clientes.Items.Count != 0)
        {
            role = Convert.ToString(dar.SelectedValue);
        }
        else
        {
            dar.Items.Clear();
        }
    }


    public void cargaClientes()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT Id,RazonSocial FROM dbo.Clientes", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        Clientes.DataSource = dr;
        Clientes.DataTextField = "RazonSocial";
        Clientes.DataValueField = "Id";
        Clientes.DataBind();
        if (Clientes.Items.Count != 0)
        {
            us = Convert.ToInt32(Clientes.SelectedValue);
            cargaRoles(us);
            cargaDars(us);
        }
        else
        {
            Roles.Items.Clear();
            dar.Items.Clear();
            Clientes.Items.Clear();
        }
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BindGrid()
    {
        string id = User.Identity.GetUserId();
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmd = new SqlCommand("Select UserName, Nombre, Apellido, Habilitado from AspNetUsers ", conn);
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
            GridView1.Rows[0].Cells[0].Text = "No se encont  raron Registros";
        }

    }
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName.Equals("detail"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            IEnumerable<DataRow> query = from Clientes in dt.AsEnumerable()
                                         where Clientes.Field<String>("ID").Equals(id)
                                         select Clientes;
            DataTable GridView1Table = query.CopyToDataTable<DataRow>();
            GridView1.DataSource = GridView1Table;
            GridView1.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type= 'text/javascript'>");
            sb.Append("$('detailmodal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DetailmodalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("updRecord"))
        {
            GridViewRow gvrow = GridView1.Rows[index];
            txtUsuario.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text);
            txtNombre.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            txtApellido.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("habilitado"))
        {
            GridViewRow gvrow = GridView1.Rows[index];
            Label1.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            Label2.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString();
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#habilita').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "HabiModalScript", sb.ToString(), false);
        }
    }
    /*Recoge el id donde se da click en el evento actualizar lo guarda y envia*/

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string Usuario = txtUsuario.Text;
        string Nombre = txtNombre.Text;
        string Apellido = txtApellido.Text;
        string pass = Password.Text;
        ExecuteUpdate(Usuario, Nombre, Apellido);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
    }

    /*Ejecuta el evento de actualizado a la base de datos*/

    private void ExecuteUpdate(string Usuario, string Nombre, string Apellido)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE AspNetUsers SET Nombre=@Nombre, Apellido=@Apellido WHERE UserName=@Usuario";   
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        //updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@Usuario", Usuario);
        updatecmd.Parameters.AddWithValue("@Nombre", Nombre);
        updatecmd.Parameters.AddWithValue("@Apellido", Apellido);
        updatecmd.ExecuteNonQuery();
        con.Close();
    }

    protected void BtnHabilitado(object sender, EventArgs e)
    {
        string usuario = Label1.Text;
        string est = Hab.SelectedValue;
        ExecuteHab(usuario, est);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Estatus Actualizado');");
        sb.Append("$('#habilita').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
    }

    private void ExecuteHab(string usuario, string est)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE AspNetUsers SET Habilitado=@est WHERE UserName=@usuario";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@usuario", usuario);
        updatecmd.Parameters.AddWithValue("@est", est);
        updatecmd.ExecuteNonQuery();
        con.Close();

    }


    /*Ejecuta el evento de actualizado a la base de datos*/

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string id = hfID.Value;
        ExecuteDelete(id);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registo Eliminado');");
        sb.Append("$('#deleteModal').modal('hide');");
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
            string updatecmd = "delete from AspNetUsers where Id=@id";
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

    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void Clientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        us = Convert.ToInt32(Clientes.Text);
        cargaRoles(us);
        cargaDars(us);
    }
}