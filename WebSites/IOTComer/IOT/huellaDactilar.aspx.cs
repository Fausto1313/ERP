using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_huellaDactilar : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 30;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Huella Dactilar")
        {
            if (!IsPostBack)
            {
                CargaSitio();
            }
            bindgrid();
        }
        else
            Response.Redirect("~/IOT/Home");
    }

    protected void bindgrid() {
        DateTime an, nueva, actual = DateTime.Now;
        string sit = Sitio.SelectedValue;
        an = new DateTime(actual.Year, actual.Month, actual.Day,0,0,0);
        nueva = new DateTime(actual.Year, actual.Month, actual.Day, 23, 59, 59);
        conn.Open();
        SqlCommand cmd = new SqlCommand("select E.ID, E.Nombre, E.Apellidos, D.Fecha, D.Estatus from controlDactilar D," +
            "Empleado E where(D.IDEmpleado = E.ID and D.Fecha between @an and @nueva and E.Sitio = @sitio) order by D.ID desc", conn);
        cmd.Parameters.AddWithValue("@an", an);
        cmd.Parameters.AddWithValue("@nueva", nueva);
        cmd.Parameters.AddWithValue("@sitio", sit);
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

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.bindgrid();
    }

    protected void CargaSitio()
    {
        Sitio.DataSource = Consultar("select id, C_Sitio from sitios where ID_cliente in (select id_cliente from AspNetUsers where UserName = @usuario)");
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
}