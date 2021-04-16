using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_MisDispositivos : System.Web.UI.Page
{
    DataTable dt;
    int sitio = 0;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 8;
        Permisos permiso = new Permisos();
        string per = permiso.returnPermiso(usuario, pantalla);
        if ( per == "Mis Dispositivos")
        {
            if (!IsPostBack)
            {
                cargaSitios();
            }
            //BindGrid(sitio);
        }
        else
            Response.Redirect("~/IOT/Home");
    }
    public void BindGrid()
    {
        conn.Open();
        sitio = Convert.ToInt32(Sitio.SelectedValue);
        string usuario = Context.User.Identity.Name;
        SqlCommand cmd = new SqlCommand("SELECT D.RISCEI, D.Descripcion, D.Modelo FROM DARS D  WHERE D.UbiDis in " +
            "(SELECT Id from UbiDis where Cl_Sitio = @sitio)", conn);
        cmd.Parameters.AddWithValue("@sitio",sitio);
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

    /*Metodo que contiene la vista, actualizacion y o eliminacion de una fila segun sea el evento, atraves de un modal.*/
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("detail"))
        {
            string IdEvento = GridView1.DataKeys[index].Value.ToString();
            IEnumerable<DataRow> query = from DARS in dt.AsEnumerable()
                                         where DARS.Field<String>("ID").Equals(ID)
                                         select DARS;
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
            txtRISCEI.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtDescripcion.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            //txtRazonSocial.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
            //txtNombre.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }
        else if (e.CommandName.Equals("clienterecord"))
        {
            /*GridViewRow gvrow = GridView1.Rows[index];

            lblRisc1.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            //txtcliente.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            lblResultt.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModalc').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);
            */
        }

    }
    /*Recoge el id donde se da click en el evento actualizar lo guarda y envia*/
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string id = txtRISCEI.Text;
        string descripcion = txtDescripcion.Text;
        ExecuteUpdate(id, descripcion);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    }
    /*Ejecuta el evento de actualizado a la base de datos*/
    private void ExecuteUpdate(string id, string descripcion)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE DARS SET Descripcion=@descripcion WHERE RISCEI=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@descripcion", descripcion);
        updatecmd.ExecuteNonQuery();
        con.Close();
    }
    
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    public void CargaClientes()
    {
        /*SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID, RazonSocial FROM Clientes  where ID != 2", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        //Clientes2.DataSource = dr;
        Clientes.DataSource = dr;
        //Clientes2.DataTextField = "RazonSocial";
        Clientes.DataTextField = "RazonSocial";
        //Clientes2.DataValueField = "ID";
        Clientes.DataValueField = "ID";
        Clientes.DataBind();
        //Clientes2.DataBind();*/
    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void Sitio_SelectedIndexChanged(object sender, EventArgs e)
    {
        //sitio = Convert.ToInt32(Sitio.SelectedValue);
        BindGrid();
    }
    protected void cargaSitios() {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID, Descripcion FROM Sitios where ID_cliente=(select ID_Cliente" +
            " from AspNetusers where UserName = @usuario)", cn);
        cmd.Parameters.AddWithValue("@usuario", User.Identity.Name);
        SqlDataReader dr = cmd.ExecuteReader();
        Sitio.DataSource = dr;
        Sitio.DataTextField = "Descripcion";
        Sitio.DataValueField = "ID";
        Sitio.DataBind();
        Sitio.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }
}