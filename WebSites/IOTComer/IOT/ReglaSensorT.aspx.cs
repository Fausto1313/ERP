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
using Microsoft.AspNet.Identity.EntityFramework;
using TaskScheduler;
public partial class IOT_ReglaSensorT : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected int us = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 47;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "ReglaSensorTemperatura")
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
        SqlCommand cmd = new SqlCommand("select ru.id, ru.nombre, d.riscei, d.descripcion, ru.ComandoVoz,ru.umbral, ru.estatus, " +
            "ru.CanalTelegram from ReglaUmbral ru, dars d inner join ubidis ub on " +
            "d.UbiDis = ub.Id where ub.Cl_Sitio = @sit and d.Modelo = 'DAR-BIS-TH' and d.RISCEI = " +
            "ru.RISCEI and ru.CanalTelegram in (select CanalTelegram from CanalTelegram where Usuario = @usuario)", conn);
        cmd.Parameters.AddWithValue("@sit", sit);
        cmd.Parameters.AddWithValue("@usuario",usuario);
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
    protected void CargarDar()
    {
        string sit = Sitio.SelectedValue;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select  riscei, Descripcion from dars d, UbiDis u where u.Cl_Sitio = @sit and d.ubidis = u.id and d.Modelo = 'DAR-BIS-TH'", conn);
        cmd.Parameters.AddWithValue("@sit", sit);
        SqlDataReader dr = cmd.ExecuteReader();
        Dar.DataSource = dr;
        Dar.DataTextField = "Descripcion";
        Dar.DataValueField = "RISCEI";
        Dar.DataBind();
        Dar.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        conn.Close();

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
        Dar.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Canal.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
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
    private void ExecuteAdd()
    {
        string dispo = Dar.SelectedValue;
        string nom = txtNombre.Text;
        double um = Convert.ToDouble(txtUmbral.Text);
        string hab = Estatus.SelectedValue;
        string canal = Canal.SelectedValue;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);
        conn.Open();
        string updatecmd = "insert into ReglaUmbral (RISCEI,Nombre,Umbral,Estatus,CanalTelegram) values (@dar,@nom,@um,@est,@canal)";
        SqlCommand addCmd = new SqlCommand(updatecmd, conn);
        addCmd.Parameters.AddWithValue("@dar", dispo);
        addCmd.Parameters.AddWithValue("@nom", nom);
        addCmd.Parameters.AddWithValue("@um", um);
        addCmd.Parameters.AddWithValue("@est", hab);
        addCmd.Parameters.AddWithValue("@canal", canal);
        addCmd.ExecuteNonQuery();
        conn.Close();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Tarea agregada');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
        BindGrid();
    }

    protected void CreaTarea_Click(object sender, EventArgs e)
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
            lblID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtTarea.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            lblSensor.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);            
            txtUmbralT.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
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
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string id = lblID.Text;
        string tarea = txtTarea.Text;
        string umbral = txtUmbralT.Text;
        string estatus = Hab.SelectedValue;
        ExecuteUpdate(id, tarea, umbral, estatus);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
    }
    private void ExecuteUpdate(string id, string tarea, string umbral, string estatus)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE ReglaUmbral SET Nombre=@tarea, Umbral=@umbral, Estatus=@estatus WHERE ID=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@tarea", tarea);
        updatecmd.Parameters.AddWithValue("@umbral", umbral);
        updatecmd.Parameters.AddWithValue("@estatus", estatus);
        updatecmd.ExecuteNonQuery();
        con.Close();
    }

    protected void Carga_select(object sender, EventArgs e)
    {
        CargarDar();
        CargaCanales();
    }

    private void ExecuteDelete(string id)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updatecmd = "delete from ReglaUmbral where Id=@id";
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

}