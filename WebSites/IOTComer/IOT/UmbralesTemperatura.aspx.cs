using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_UmbralesTemperatura : System.Web.UI.Page
{

    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 44;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, 0) == "RISC")
        {
            BindGrid();
            if (!IsPostBack)
            {
                CargarSitio();
            }
        }
        else if (permiso.returnPermiso(usuario, pantalla) == "Umbrales")
        {

        }
        else
            Response.Redirect("~/IOT/Home");
    }

    public void BindGrid()
    {
        string usuario = User.Identity.Name;
        string sit = Sitio.SelectedValue;
        SqlConnection cn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn2.Open();
        SqlCommand cms = new SqlCommand("select ub.ID, ub.RISCEI, a1.Descripcion, ub.UmbralMenor, ub.UmbralMayor, ub.CanalTelegram from (select d.riscei, d.Descripcion from DARS d inner join UbiDis u on d.UbiDis=u.Id where u.Cl_Sitio= @sit) as a1 inner join Umbrales ub on a1.RISCEI = ub.RISCEI", cn2);
        cms.Parameters.AddWithValue("@sit", sit);
        SqlDataAdapter da = new SqlDataAdapter(cms);
        DataSet ds = new DataSet();
        da.Fill(ds);
        cn2.Close();
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
    protected void CargarDars(string sit)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select distinct riscei, Descripcion from dars d, UbiDis u where u.Cl_Sitio=@sit and d.Modelo = 'DAR-BIS-TH'", conn);
        cmd.Parameters.AddWithValue("@sit", sit);
        SqlDataReader dr = cmd.ExecuteReader();
        dar.DataSource = dr;
        dar.DataTextField = "Descripcion";
        dar.DataValueField = "RISCEI";
        dar.DataBind();
    }
    protected void CargarCanal()
    {
        string sitio = Sitio.SelectedValue;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select CanalTelegram from CanalTelegram where id_sitio = @sitio", conn);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        canalTelegram.DataSource = dr;      
        canalTelegram.DataTextField = "CanalTelegram";
        canalTelegram.DataValueField = "CanalTelegram";
        canalTelegram.DataBind();
        canalTelegram.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        conn.Close();
    }

    protected void CargarCanal2()
    {
        string sitio = Sitio.SelectedValue;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select CanalTelegram from CanalTelegram where id_sitio = @sitio", conn);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        canalTelegram1.DataSource = dr;
        canalTelegram1.DataTextField = "CanalTelegram";
        canalTelegram1.DataValueField = "CanalTelegram";
        canalTelegram1.DataBind();
        canalTelegram1.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }
    protected void CargarSitio()
    {
        Sitio.DataSource = Consultar("if(select 1 from PermisoRol where ID_Permiso = 36 and ID_Rol = (select ID_Rol from AspNetUsers where UserName = @usuario)) = 1 " +
                                     "select id, C_Sitio from sitios where ID_cliente = (select id_cliente from AspNetUsers where UserName = @usuario) " +
                                     "else select id, C_Sitio from sitios where ID = (select C_Sitio from AspNetUsers where UserName = @usuario)");
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

    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void BtnAddClick(object sender, EventArgs e)
    {
        sit.Text = Sitio.Text;
        CargarDars(sit.Text);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
    }

    protected void BtnSave_ClickS(object sender, EventArgs e)
    {
        string ris = dar.Text;
        double menor = Convert.ToDouble(txtMenor.Text);
        double mayor = Convert.ToDouble(txtMayor.Text);
        string canal = canalTelegram.SelectedValue;
        if (menor < mayor)
        {
            ExecuteInsert(ris, menor, mayor, canal);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Registro actualizado exitosamente');");
            sb.Append("$('#addModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
        }
        else {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Revisar umbrales');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
        }
       
        BindGrid();
    }
    /*Ejecuta el evento de actualizado a la base de datos*/
    private void ExecuteInsert(string ris, double menor, double mayor, string canal)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "insert into umbrales (RISCEI, UmbralMEnor, UmbralMAyor, CanalTelegram) values  (@ris, @menor, @mayor, @canal)";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@ris", ris);
        updatecmd.Parameters.AddWithValue("@menor", menor);
        updatecmd.Parameters.AddWithValue("@mayor", mayor);
        updatecmd.Parameters.AddWithValue("@canal", canal);
        updatecmd.ExecuteNonQuery();
        con.Close();
    }

    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("actualizar"))
        {           
            GridViewRow gvrow = GridView1.Rows[index];
            lblID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            lblRiscei.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString();
            lblDesc.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
            txtMenor1.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            txtMayor1.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
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
    }

    protected void BtnUpdate(object sender, EventArgs e)
    {
        string id = lblID.Text;
        string ris1 = lblRiscei.Text;
        double menor1 = Convert.ToDouble(txtMenor1.Text);
        double mayor1 = Convert.ToDouble(txtMayor1.Text);
        string canal1 = canalTelegram1.SelectedValue;
        if (menor1 < mayor1)
        {
            ExecuteUpdate(id,ris1, menor1, mayor1, canal1);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Registro actualizado exitosamente');");
            sb.Append("$('#updModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
        }
        else
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Revisar umbrales');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
        }          
        BindGrid();
    }
    /*Ejecuta el evento de actualizado a la base de datos*/
    private void ExecuteUpdate(string id, string ris1, double menor1, double mayor1, string canal1)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE umbrales SET UmbralMenor=@menor, UmbralMayor=@mayor, CanalTelegram=@canal WHERE ID=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@ris", ris1);
        updatecmd.Parameters.AddWithValue("@menor", menor1);
        updatecmd.Parameters.AddWithValue("@mayor", mayor1);
        updatecmd.Parameters.AddWithValue("@canal", canal1);
        updatecmd.ExecuteNonQuery();
        con.Close();
    }
    protected void Sitio_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarCanal();
        CargarCanal2();
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
            string updatecmd = "delete from Umbrales where ID=@id";
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