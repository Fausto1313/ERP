using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_AgregarPermi : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 26;
        Permisos permiso = new Permisos();

        if (permiso.returnPermiso(usuario, 0) == "RISC")
        {
            BindGrid();
        }
        else if (permiso.returnPermiso(usuario, pantalla) == "Agregar Catalogo")
        {

        }
        else
            Response.Redirect("~/IOT/Home");
    }
    public void BindGrid()
    {

        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID, Modulo From Permisos", conn);
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
            IEnumerable<DataRow> query = from Permisos in dt.AsEnumerable()
                                         where Permisos.Field<String>("ID").Equals(ID)
                                         select Permisos;
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

            lblId.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
           
            //txtRazonSocial.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
            //txtNombre.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }
        else if (e.CommandName.Equals("delRecord"))
           
        {

            string id = GridView1.DataKeys[index].Value.ToString();
            hfModulo.Value = id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#deleteModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }

      
            //lblModu.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            ////txtcliente.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            //lblResultt.Visible = false;
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append(@"<script type='text/javascript'>");
            //sb.Append("$('#updModalc').modal('show');");
            //sb.Append(@"</script>");
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        

    }
    //protected void BtnSave_ClickS(object sender, EventArgs e)
    //{
    //    string id = lblId.Text;
    //    string Modulo = txtModulo.Text;

    //    ExecuteUpdate(id, Modulo);
    //    BindGrid();
    //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //    sb.Append(@"<script type='text/javascript'>");
    //    sb.Append("alert('Registro actualizado exitosamente');");
    //    sb.Append("$('#updModalc').modal('hide');");
    //    sb.Append(@"</script>");
    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    //}
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string id = lblId.Text;
        string Modulo = txtModulo.Text;


        ExecuteUpdate(id, Modulo);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    }
    private void ExecuteUpdate(string id, string Modulo)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE Permisos SET Modulo=@modu WHERE ID=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@modu", Modulo);

        updatecmd.ExecuteNonQuery();
        con.Close();

    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string id = hfModulo.Value;
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
            string updatecmd = "delete Permisos where ID=@id";
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
    protected void BtnAddClick(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

    }
    /*Metodo para insertar*/
    protected void BtnAddRecordClick(object sender, EventArgs e)
    {

        string Modulos = txtMod.Text;
        string id = txtID.Text;
        ExecuteAdd(id,Modulos);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
    }

    private void ExecuteAdd(string id ,string Modulos)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "insert into Permisos(ID,Modulo) values (@id, @Modulo)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@id", id);
        addCmd.Parameters.AddWithValue("@Modulo", Modulos);
        addCmd.ExecuteNonQuery();
        con.Close();
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

    {

        GridView1.PageIndex = e.NewPageIndex;

        this.BindGrid();

    }
}

