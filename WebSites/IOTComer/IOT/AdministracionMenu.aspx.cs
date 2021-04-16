using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_AdministracionMenu : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 55;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "AdministracionMenu")
        {
            if (!IsPostBack)
            {
                CargaNombre();
            }
            BindGrid();
           
        }
        else
        {
            Response.Redirect("~/IOT/Home");
        }
    }

    public void BindGrid()
    {
        string Reg = Reasignar.SelectedValue;
        DateTime fecha = DateTime.Today;
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select ID, Nombre, Descripcion, Categoria from Productos where Fecha = @fecha and Sitio = (select C_Sitio from AspNetUsers where UserName = @usuario) order by Categoria desc", conn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@fecha", fecha);
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
            IEnumerable<DataRow> query = from Productos in dt.AsEnumerable()
                                         where Productos.Field<String>("ID").Equals(id)
                                         select Productos;

            DataTable GridView1Table = query.CopyToDataTable<DataRow>();
            GridView1.DataSource = GridView1Table;
            GridView1.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type= 'text/javascript'>");
            sb.Append("$('detailmodal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DetailmodalScript", sb.ToString(), false);

        }

        else if (e.CommandName.Equals("updMenu"))

        {

            GridViewRow gvrow = GridView1.Rows[index];
            lblID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtNombre.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            txtDesc.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
            tipo2.SelectedValue = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
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
            sb.Append("$('#deleteModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("asignar"))
        {
            //GridViewRow gvrow2 = GridView1.Rows[index];
            //string id = HttpUtility.HtmlDecode(gvrow2.Cells[0].Text).ToString();
            //string sitio = Sitio.SelectedValue;
            //Response.Redirect("~/IOT/PermisoPuertas?usuario=" + id + "&sitio=" + sitio);
        }
    }
    protected void BtnAddClick(object sender, EventArgs e)

    {

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
    }
    protected void BtnAddClick2(object sender, EventArgs e)
    {
        CargaNombre();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal2').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript2", sb.ToString(), false);
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(lblID.Text);
        string Nombre = txtNombre.Text;
        string Desc = txtDesc.Text;
        string Cat = tipo2.SelectedValue;
        ExecuteUpdate(id, Nombre, Desc, Cat);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
    }


    private void ExecuteUpdate(int id, string Nombre, string Desc, string Cat)

    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);

        con.Open();

        string updateCmd = "UPDATE Productos SET Nombre=@Nombre,Descripcion=@desc, Categoria=@cat WHERE ID=" + id + "";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@Nombre", Nombre);
        updatecmd.Parameters.AddWithValue("@desc", Desc);
        updatecmd.Parameters.AddWithValue("@cat", Cat);
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
        sb.Append("alert('Registo eliminado');");
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
            string updatecmd = "delete from Productos where ID=@id";
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
    protected void BtnAddRecordClick(object sender, EventArgs e)

    {
        string Nom = txtNom1.Text;
        string Desc = txtDesc1.Text;
        string Cat = Tipo.SelectedValue;
        ExecuteAdd(Nom, Desc, Cat);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

    }

    private void ExecuteAdd(string Nom, string Desc, string Cat)

    {
        DateTime fec = DateTime.Today;
        string usuario = User.Identity.Name;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);

        con.Open();

        string updatecmd = "insert into Productos (Nombre,Descripcion,Categoria,fecha,Sitio ) values (@nom,@desc,@cat,@fec, (select c_Sitio from AspNetUsers where UserName=@usuario))";

        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@nom", Nom);
        addCmd.Parameters.AddWithValue("@desc", Desc);
        addCmd.Parameters.AddWithValue("@cat", Cat);
        addCmd.Parameters.AddWithValue("@fec", fec);
        addCmd.Parameters.AddWithValue("@usuario", usuario);
        addCmd.ExecuteNonQuery();
        con.Close();

    }


    protected void BtnAddRecordClick2(object sender, EventArgs e)
    {

        DateTime fech = DateTime.Today;
        int id = Convert.ToInt32(Reasignar.SelectedValue);
        ExecuteAdd2(fech,id);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal2').modal('hide');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);


    }

    private void ExecuteAdd2(DateTime fech, int id)

    {
        
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
      
        con.Open();

        string updatecmd = "UPDATE Productos SET Fecha=@fecha where ID=@id";

        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@fecha", fech);
        addCmd.Parameters.AddWithValue("@id", id);

        addCmd.ExecuteNonQuery();
        con.Close();

    }
    private void CargaNombre()
    {
       Reasignar.DataSource = Consultar("select ID, Nombre from Productos where Sitio = (select C_Sitio from AspNetUsers where UserName = @usuario) and Fecha != @fecha");
       Reasignar.DataValueField = "ID";
       Reasignar.DataTextField = "Nombre";
       Reasignar.DataBind();
      Reasignar.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }

    protected DataSet Consultar(string consulta)
    {
        string usuario = Context.User.Identity.Name;
        DateTime fecha = DateTime.Today;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand(consulta, con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@fecha", fecha);
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

    protected void Categoria_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Subcategoria_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
