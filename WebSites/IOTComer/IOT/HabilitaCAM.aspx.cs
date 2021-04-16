using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_HabilitaCAM : System.Web.UI.Page
{

    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 42;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, 0) == "RISC")
        {
            BindGrid();
            if (!IsPostBack)
            {
                CargaCliente();
            }
        }
        else if (permiso.returnPermiso(usuario, pantalla) == "HabilitarCAM")
        {

        }

        else
            Response.Redirect("~/IOT/Home");
    }

    public void BindGrid()
    {
        string cli = Clientes.SelectedValue;
        string sit = Sitio.SelectedValue;
        SqlConnection cn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn2.Open();
        SqlCommand cms = new SqlCommand("select distinct d.riscei, d.descripcion, d.estatus, d.ubidis from dars d, ubidis u where d.ubidis in (select u.id where cl_cliente = @cliente and cl_sitio = @sitio) and d.modelo = 'DAR-BIS-CC'", cn2);
        cms.Parameters.AddWithValue("@sitio", sit);
        cms.Parameters.AddWithValue("@cliente", cli);
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

    protected DataSet Consultar(string consulta)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand(consulta, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }

    protected void CargaCliente()
    {
        Clientes.DataSource = Consultar("SELECT * FROM CLIENTES ");
        Clientes.DataValueField = "ID";
        Clientes.DataTextField = "RazonSocial";
        Clientes.DataBind();
        Clientes.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Sitio.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

    }

    protected void CargaSitio(object sender, EventArgs e)
    {
        int cliente = Convert.ToInt32(Clientes.SelectedValue);
        Sitio.DataSource = Consultar("Select * FROM Sitios Where ID_cliente =" + cliente);
        Sitio.DataValueField = "ID";
        Sitio.DataTextField = "C_Sitio";
        Sitio.DataBind();
        Sitio.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

    }

    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }


    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("habilitado"))
        {
            GridViewRow gvrow = GridView1.Rows[index];
            dis.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            est.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text).ToString();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#habilita').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "HabiModalScript", sb.ToString(), false);
        }

    }


    protected void BtnHabilitado(object sender, EventArgs e)
    {
        string dispo = dis.Text;
        string est = Hab.SelectedValue;
        ExecuteHab(dispo, est);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Estatus Actualizado');");
        sb.Append("$('#habilita').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
    }

    private void ExecuteHab(string dispo, string est)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE dars SET Estatus=@est WHERE RISCEI=@dis";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@dis", dispo);
        updatecmd.Parameters.AddWithValue("@est", est);
        updatecmd.ExecuteNonQuery();
        con.Close();

    }

}