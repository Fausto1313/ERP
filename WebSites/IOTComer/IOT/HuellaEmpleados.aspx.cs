using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_HuellaEmpleados : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected int us = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 48;

        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "HuellaEmpleados")
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
        SqlCommand cmd = new SqlCommand("select * from Empleado where Sitio=@sit", conn);
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
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("updRecord"))
        {
            GridViewRow gvrow = GridView1.Rows[index];
            lblID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtNombre1.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            txtApellidos.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
            txtHuella.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
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
        }else if (e.CommandName.Equals("InfoEmpleado"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            Response.Redirect("~/IOT/RegistroHuella?id=" +id);

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
        string nom = txtNombre.Text;
        string ap = txtApellido.Text;
        string estatus = Estatus.SelectedValue;
        string sitio = Sitio.SelectedValue;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);
        conn.Open();
        string updatecmd = "if(select COUNT(ID) from Empleado where Id_Checador = (select COUNT(ID) + 1 from Empleado where Sitio = @sitio) and Sitio = @sitio) > 0 " +
                           "begin insert into Empleado(Nombre, Apellidos, Estatus, Sitio, ID_Checador) values(@nombre, @apellido, @estatus, @sitio, (select MAX(ID_Checador) + 1 from Empleado where Sitio = @sitio)); " +
                           "end else insert into Empleado(Nombre, Apellidos, Estatus, Sitio, ID_Checador) values(@nombre, @apellido, @estatus, @sitio, (select COUNT(ID) + 1 from Empleado where Sitio = @sitio))";
        SqlCommand addCmd = new SqlCommand(updatecmd, conn);      
        addCmd.Parameters.AddWithValue("@nombre", nom);
        addCmd.Parameters.AddWithValue("@apellido", ap);
        addCmd.Parameters.AddWithValue("@estatus", estatus);
        addCmd.Parameters.AddWithValue("@sitio", sitio);
        addCmd.ExecuteNonQuery();
        conn.Close();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Empleado agregado');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "addHideModalScript", sb.ToString(), false);
        BindGrid();
    }
    protected void CreaUsuario_Click(object sender, EventArgs e)
    {
        ExecuteAdd();
    }
    protected void Upd_Guardar(object sender, EventArgs e)
    {
        string idH = txtHuella.Text;
        string nombre = txtNombre1.Text;
        string ape = txtApellidos.Text;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        if (ExecuteUpdate(nombre, ape, idH))
        {
            sb.Append("alert('Registro actualizado exitosamente');");
        }
        else {
            sb.Append("alert('El id ya existe');");
        }
        
        BindGrid();      
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
    }
    private bool ExecuteUpdate(string nombre, string ape, string idH)
    {
        string sitPrincipal = Sitio.SelectedValue;
        bool val = false;
        string id = lblID.Text;
        string est = Hab.Text;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "if(select COUNT(ID) from Empleado where Id_Checador = @idH and Sitio = @sitio and ID != @id) > 0" +
                            "select 'false';" +
                            "else UPDATE Empleado SET Nombre = @nombre, Apellidos = @apellido, ID_Checador = @idH, Estatus = @estatus WHERE ID = @id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@nombre", nombre);
        updatecmd.Parameters.AddWithValue("@apellido", ape);
        updatecmd.Parameters.AddWithValue("@estatus", est);
        updatecmd.Parameters.AddWithValue("@idH", idH);
        updatecmd.Parameters.AddWithValue("@sitio", sitPrincipal);
        //updatecmd.ExecuteNonQuery();
        SqlDataReader validation = updatecmd.ExecuteReader();
        if (!validation.Read())
        {
            val = true;
        }
        con.Close();
        return val;
    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
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
        BindGrid();
    }
    private void ExecuteDelete(string id)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updatecmd = "delete from Empleado where ID=@id";
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