using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class IOT_PedidoDomic : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 55;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Restaurant")
        {
            //if (!IsPostBack)
            //{
            //    cargaEstatus();
            //}
            BindGrid();

        }
        else
        {
            Response.Redirect("~/IOT/Home");
        }
    }
    public void BindGrid()
    {
        //string Reg = Reasignar.SelectedValue;
        string es = Estatuss.SelectedValue;
        DateTime fecha = DateTime.Today;
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmd = new SqlCommand(" Select pd.ID, pd.Nombre, ur.Usuario, pd.Domicilio, pd.Telefono, pd.Total, pd.Estatus " +
            "from PedidoDomicilio pd inner join UsuarioRestaurant ur on ur.ID = pd.IDUsuario and pd.Estatus =@estatus" +
            " where ur.Sitio = (select C_Sitio from AspNetUsers where UserName =@usuario ) order by pd.ID desc ", conn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
       cmd.Parameters.AddWithValue("@estatus", es);
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
        if (e.CommandName.Equals("detail"))

        {

            string id = GridView1.DataKeys[index].Value.ToString();
            IEnumerable<DataRow> query = from PedidoDomicilio in dt.AsEnumerable()
                                         where PedidoDomicilio.Field<String>("ID").Equals(id)
                                         select PedidoDomicilio;

            DataTable GridView1Table = query.CopyToDataTable<DataRow>();
            GridView1.DataSource = GridView1Table;
            GridView1.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type= 'text/javascript'>");
            sb.Append("$('detailmodal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DetailmodalScript", sb.ToString(), false);

        }

        else if (e.CommandName.Equals("updDomi"))

        {

            GridViewRow gvrow = GridView1.Rows[index];
            lblID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            tipo2.SelectedValue = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }
        else if (e.CommandName.Equals("asignarpedido"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            Response.Redirect("~/IOT/DetalleDomicilio?rol=" + id);
        }
        else if (e.CommandName.Equals("deleteRecord"))
        {
            //string id = GridView1.DataKeys[index].Value.ToString();
            //hfID.Value = id;
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append(@"<script type='text/javascript'>");
            //sb.Append("$('#deleteModal').modal('show');");
            //sb.Append(@"</script>");
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("asignar"))
        {
            //GridViewRow gvrow2 = GridView1.Rows[index];
            //string id = HttpUtility.HtmlDecode(gvrow2.Cells[0].Text).ToString();
            //string sitio = Sitio.SelectedValue;
            //Response.Redirect("~/IOT/PermisoPuertas?usuario=" + id + "&sitio=" + sitio);
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(lblID.Text);
        string estatus = tipo2.SelectedValue;

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        if (estatus != "0")
        {
            ExecuteUpdate(id, estatus);
            BindGrid();
            sb.Append("$('#updModal').modal('hide');");
            sb.Append("swal(\"Actualización!\", \"Estatus actualizado de forma correcta.\", \"success\");");
            sb.Append(@"</script>");

        }
        else
        {

            sb.Append("swal(\"Aviso.\", \"Selecciona un estatus para poder continuar.\", \"warning\");");
            sb.Append(@"</script>");
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
    }


    private void ExecuteUpdate(int id, string estatus)

    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);

        con.Open();

        string updateCmd = "UPDATE PedidoDomicilio SET Estatus=@estatus WHERE ID=" + id + "";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@estatus", estatus);

        updatecmd.ExecuteNonQuery();
        con.Close();
    }

 

    //public void cargaEstatus()
    //{
    //    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
    //    cn.Open();
    //    SqlCommand cmd = new SqlCommand("Select pd.ID, pd.Estatus  from PedidoDomicilio pd inner join UsuarioRestaurant ur on ur.ID = pd.IDUsuario " +
    //        "where ur.Sitio = (select C_Sitio from AspNetUsers where UserName = @usuario)", cn);
    //    cmd.Parameters.AddWithValue("@usuario", User.Identity.Name);
    //    SqlDataReader dr = cmd.ExecuteReader();
    //    Estatuss.DataSource = dr;
    //    Estatuss.DataTextField = "Estatus";
    //    Estatuss.DataValueField = "ID";
    //    Estatuss.DataBind();
    //   Estatuss.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    //}
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
}
