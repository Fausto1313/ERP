using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_TelegramUsers : System.Web.UI.Page
{
    DataTable dt;
     static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        Permisos permiso = new Permisos();
        string usuario = User.Identity.Name;
        int pantalla = 2;
        if (permiso.returnPermiso(usuario, pantalla) == "Usuarios Telegram")
        {
            BindGrid2();
        }
        else
            Response.Redirect("~/IOT/Home");
    }
    protected void Search(object sender, EventArgs e)
    {

    }
    public void BindGrid2()


    {
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "SELECT * FROM Telegram  ";
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {



                    sql += "Where ( Usuario LIKE '%' + @Busqueda + '%' OR ID_Cliente LIKE '%' + @Busqueda + '%')";
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
    public void BindGrid()
    {
        conn.Open();
        string usuario = User.Identity.Name;
        SqlCommand cmd = new SqlCommand("select t.ID, t.usuario from Telegram t, AspNetUsers u where t.ID_Cliente=u.ID_Cliente and u.UserName=@usuario", conn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
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
        if (e.CommandName.Equals("deleteRecord"))
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

    protected void BtnDelete_Click(object sender, EventArgs e)

    {

        string id = hfID.Value;
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
            string updatecmd = "delete from Telegram where ID=@id";
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

    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

    {

        GridView1.PageIndex = e.NewPageIndex;

        this.BindGrid2();

    }

}