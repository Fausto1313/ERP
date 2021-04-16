using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_GraficasQlick : System.Web.UI.Page
{

    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 41;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, 0) == "RISC")
        {
            BindGrid();
            if (!IsPostBack)
            {

                CargaCliente();
               

            }
        }
        else if (permiso.returnPermiso(usuario, pantalla) == "GraficasQlick")
        {

        }
         
        else
            Response.Redirect("~/IOT/Home");
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

    public void BindGrid()
    {
        string cli = Clientes.SelectedValue;
        string sit = Sitio.SelectedValue;
        SqlConnection cn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn2.Open();
        SqlCommand cms = new SqlCommand("select distinct n.id,n.nombre, n.descripcion, n.link from nivel1 n inner join ubidis u on u.cl_sitio = n.UbiDispo where id_cliente =@cliente and n.UbiDispo =@sitio", cn2);
        cms.Parameters.AddWithValue("@cliente", cli);
        cms.Parameters.AddWithValue("@sitio", sit);
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

    protected void AgregarURL(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(lblID.Text);
        string url = txtURL.Text;
        ExecuteAdd(id,url);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
    }

    private void ExecuteAdd(int id,string url)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "UPDATE Nivel1 SET Link =@url where ID=" + id + "";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@url", url);
        addCmd.ExecuteNonQuery();
        con.Close();
    }

    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("btnAgregar"))
        {
            GridViewRow gvrow = GridView1.Rows[index];
            lblID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#addModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

        }
        else if (e.CommandName.Equals("btnActualizar"))
        {
            GridViewRow gvrow = GridView1.Rows[index];
            lblID1.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            lblURL.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "UpdShowModalScript", sb.ToString(), false);
        }

    }

    protected void ActualizarURL(object sender, EventArgs e)
   {
        int id = Convert.ToInt32(lblID1.Text);
        string url = txtURL1.Text;
        Executeupd(id, url);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('URL Actualizada');");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
    }

    private void Executeupd(int id, string url)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "UPDATE Nivel1 SET Link =@url where ID=" + id + "";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@url", url);
        addCmd.ExecuteNonQuery();
        con.Close();
    }




}