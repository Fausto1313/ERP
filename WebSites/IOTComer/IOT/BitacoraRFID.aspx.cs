using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_BitacoraRFID : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    //protected int us = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 54;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Bitacora RFID")
        {
            if (!IsPostBack)
            {
                CargarSitio();
            }
        }
        else
        {
            Response.Redirect("~/IOT/Home");
        }
    }

    public void BindGrid()
    {
        string usuario = Cliente.SelectedValue;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select d.Descripcion, urf.Nombre, rf.Fecha from bitacoraRFID rf inner join Dars d on rf.RISCEIRFID = d.RISCEI " +
                                        "inner join usuarioRFID urf on rf.Usuario = urf.ID where rf.Usuario = @usuario", conn);
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

    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void CargarSitio()
    {
        Sitio.DataSource = Consultar("select ID, C_Sitio from Sitios where ID_cliente=(select ID_Cliente from AspNetUsers where UserName=@usuario)");
        Sitio.DataValueField = "ID";
        Sitio.DataTextField = "C_Sitio";
        Sitio.DataBind();
        Sitio.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Cliente.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
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
    protected void CargarCliente()
    {
        string sit = Sitio.SelectedValue;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select ID,Nombre from usuarioRFID where Sitio = @sitio", conn);
        cmd.Parameters.AddWithValue("@sitio", sit);
        SqlDataReader dr = cmd.ExecuteReader();
        Cliente.DataSource = dr;
        Cliente.DataTextField = "Nombre";
        Cliente.DataValueField = "ID";
        Cliente.DataBind();
        Cliente.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        conn.Close();
    }
    protected void Sitio_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarCliente();
    }

    protected void Cliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

}