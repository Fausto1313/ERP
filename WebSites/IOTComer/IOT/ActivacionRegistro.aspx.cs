using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class IOT_ActivacionRegistro : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 12;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Activacion de Sistema")
        {
            BindGrid2();
         
        }
        else
            Response.Redirect("~/IOT/Home");
       
    }
    protected void volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/IOT/Activado");
    }
    public void BindGrid2()
    {
        string id = User.Identity.Name;
        string usuario = User.Identity.Name;
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select a.Fecha, a.Estatus, a.Usuario from Activador a, Sitios s where s.ID=a.Sitio and " +
            "s.ID=(select C_Sitio from AspNetUsers where UserName =@user) ";
                cmd.Parameters.AddWithValue("@user", id);
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    sql += "Where ( a.Fecha LIKE '%' + @Busqueda + '%' OR a.estatus LIKE '%' + @Busqueda + '%' OR a.usuario LIKE '%' + @Busqueda + '%' )";
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
    protected void BindGrid() {
        string id = User.Identity.Name;
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select a.Fecha, a.Estatus, a.Usuario from Activador a, Sitios s where s.ID=a.Sitio and " +
            "s.ID=(select C_Sitio from AspNetUsers where UserName =@user) order by a.Fecha desc", conn);
        cmd.Parameters.AddWithValue("@user", id);
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

    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

    {

        GridView1.PageIndex = e.NewPageIndex;

        this.BindGrid();

    }
}