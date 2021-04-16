using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_DetallePermiso : System.Web.UI.Page
{
    DataTable dt;
    string ide = string.Empty;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection con = new SqlConnection(conString);
    private SqlConnection con2 = new SqlConnection(conString);
    private SqlConnection con3 = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 16;
        int pantalla2 = 5;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, 0) == "RISC")
        {
            if (!IsPostBack)
            {
                llenarComboPermisos();
            }
            ide = Request.QueryString["rol"];
            BindGrid(ide);
        }
        else if (permiso.returnPermiso(usuario, pantalla2) == "Roles")
        {
        	if (!IsPostBack)
            {
                llenarComboPermisos2();
            }
            ide = Request.QueryString["rol"];
            BindGrid(ide);
        }
        else
            Response.Redirect("~/IOT/Home");

    }

    protected void BindGrid(string id){
        DataSet ds = new DataSet();
        if (id != null) {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Id, Name from AspNetRoles where Id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                DetalleRol.DataSource = ds;
                DetalleRol.DataBind();
                BindGrid2(id);
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                DetalleRol.DataSource = ds;
                DetalleRol.DataBind();
                int columncount = DetalleRol.Rows[0].Cells.Count;
                DetalleRol.Rows[0].Cells.Clear();
                DetalleRol.Rows[0].Cells.Add(new TableCell());
                DetalleRol.Rows[0].Cells[0].ColumnSpan = columncount;
                DetalleRol.Rows[0].Cells[0].Text = "No se encontraron Registros";
            }
        }

    }

    protected void BindGrid2(string id) {
        DataSet ds = new DataSet();
        con2.Open();
        SqlCommand cmd = new SqlCommand("select distinct p.* from Permisos p inner join PermisoRol pr on p.ID = pr.ID_Permiso where  pr.ID_Rol = @rol", con2);
        cmd.Parameters.AddWithValue("@rol", id);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con2.Close();
        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            PermisosDetalle.DataSource = ds;
            PermisosDetalle.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            PermisosDetalle.DataSource = ds;
            PermisosDetalle.DataBind();
            int columncount = PermisosDetalle.Rows[0].Cells.Count;
            PermisosDetalle.Rows[0].Cells.Clear();
            PermisosDetalle.Rows[0].Cells.Add(new TableCell());
            PermisosDetalle.Rows[0].Cells[0].ColumnSpan = columncount;
            PermisosDetalle.Rows[0].Cells[0].Text = "No se encontraron Registros";
        }
    }

    protected void PermisosDetalle_PageIndexChanged(object sender, GridViewPageEventArgs e)
    {
        PermisosDetalle.PageIndex = e.NewPageIndex;
        this.BindGrid(ide);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "AddShowModalScript", sb.ToString(), false);
    }

    protected void llenarComboPermisos() {
        con3.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID, Modulo FROM Permisos", con3);
        SqlDataReader dr = cmd.ExecuteReader();
        PermisoLista.DataSource = dr;
        PermisoLista.DataTextField = "Modulo";
        PermisoLista.DataValueField = "ID";
        PermisoLista.DataBind();

    }

    protected void llenarComboPermisos2()
    {
        con3.Open();
        string usuario = User.Identity.Name;
        SqlCommand cmd = new SqlCommand("select p.ID, p.Modulo from Permisos p inner join PermisoRol pr " +
            "on p.ID = pr.ID_Permiso where pr.ID_Rol = (select ID_Rol from AspNetUsers where UserName = @usuario) " +
            "order by p.ID", con3);
        cmd.Parameters.AddWithValue("@usuario",usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        PermisoLista.DataSource = dr;
        PermisoLista.DataTextField = "Modulo";
        PermisoLista.DataValueField = "ID";
        PermisoLista.DataBind();

    }

    protected void Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/IOT/PermisoRisc");
    }

    protected void BtnAddRecord_Click(object sender, EventArgs e)
    {
        int Permiso = Convert.ToInt32(PermisoLista.Text);
        if (insertPermiso(Permiso))
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Permiso insertado correctamente');");
            sb.Append("$('#addModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
            BindGrid2(ide);
        }
        else {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('El permiso ya existe');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditErrorModalScript", sb.ToString(), false);
        }
    }

    protected bool insertPermiso(int Permiso) {
        bool result = false;
        try
        {
            SqlCommand cmd = new SqlCommand("if(select count(ID_Permiso) from PermisoRol where ID_Rol=@rol and ID_Permiso=@permiso) >= 1" +
                " select 'False' else insert into PermisoRol(ID_Rol, ID_Permiso) values(@rol, @permiso)", con);
            cmd.Parameters.AddWithValue("@rol", ide);
            cmd.Parameters.AddWithValue("@permiso", Permiso);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read()) {
                result = true;
            }
            con.Close();
        }
        catch {

        }
        return result;
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        con.Open();
        int Rol = Convert.ToInt32(Rol_Borrar.Value);
        int permiso = Convert.ToInt32(Permiso_Borrar.Value);
        try
        {
            SqlCommand cmd = new SqlCommand("delete PermisoRol where ID_Rol=@rol and ID_Permiso=@permiso", con);
            cmd.Parameters.AddWithValue("@rol", Rol);
            cmd.Parameters.AddWithValue("@permiso", permiso);
            cmd.ExecuteNonQuery();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Permiso eliminado correctamente');");
            sb.Append("$('#eliminaModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteHideModalScript", sb.ToString(), false);
            BindGrid2(ide);
        }
        catch { }
        con.Close();
    }

    protected void PermisosDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("delRecord"))
        {
            GridViewRow gvrow = PermisosDetalle.Rows[index];
            Permiso_Borrar.Value = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            Rol_Borrar.Value = ide;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
    }
}