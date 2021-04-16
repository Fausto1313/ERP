using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Fabricantes : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 23, pantallaPrincipal = 0;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantallaPrincipal) == "RISC") {
            BindGrid();
        }
        else if (permiso.returnPermiso(usuario, pantalla) == "Fabricantes")
        {
            BindGrid2();
        }
        else
            Response.Redirect("~/IOT/Home");
    }
    public void BindGrid2()
    {

        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "SELECT * from Fabricantes  ";
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    sql += "Where ( ID LIKE '%' + @Busqueda + '%' OR Fabricante LIKE '%' + @Busqueda + '%' OR Pais LIKE '%')";
                    cmd.Parameters.AddWithValue("@Busqueda", txtSearch.Text.Trim());
                }
                cmd.CommandText = sql;
                cmd.Connection = con;

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }
    protected void Search(object sender, EventArgs e)
    {
        this.BindGrid2();
    }

    public void BindGrid()
    {


        conn.Open();
        SqlCommand cmd = new SqlCommand("Select * FROM Fabricantes", conn);
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

            string id = GridView1.DataKeys[index].Value.ToString();
            IEnumerable<DataRow> query = from Fabricantes in dt.AsEnumerable()
                                         where Fabricantes.Field<String>("ID").Equals(id)
                                         select Fabricantes;

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
            lblID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtFabricante.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            txtPais.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
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



    }

    /*Recoge el id donde se da click en el evento actualizar lo guarda y envia*/

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(lblID.Text);
        string Fabricante = txtFabricante.Text;
        string Pais = txtPais.Text;
        DateTime Fecha = DateTime.Now;
        ExecuteUpdate(id, Fabricante, Pais);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
    }

    /*Ejecuta el evento de actualizado a la base de datos*/

    private void ExecuteUpdate(int id, string Fabricante, string Pais)

    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);

        con.Open();

        string updateCmd = "UPDATE Fabricantes SET Fabricante=@Fabricante, Pais=@Pais WHERE ID=" + id + "";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@Fabricante", Fabricante);
        updatecmd.Parameters.AddWithValue("@Pais", Pais);
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
            string updatecmd = "delete from Fabricantes where ID=@id";
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

    /*Metodo para agregar nuevo dispositivo*/

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
        string Fabricante = txtFabricante1.Text;
        string Pais = txtPais1.Text;
        DateTime Fecha = DateTime.Now;
        ExecuteAdd(Fabricante, Pais);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

    }

    private void ExecuteAdd(string Fabricante, string Pais)

    {

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);

        con.Open();

        string updatecmd = "insert into Fabricantes (Fabricante, Pais ) values (@Fabricante,@Pais)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@Fabricante", Fabricante);
        addCmd.Parameters.AddWithValue("@Pais", Pais);
        addCmd.ExecuteNonQuery();
        con.Close();

    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
}

