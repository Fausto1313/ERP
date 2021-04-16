using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_BitacorasUsuarios : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected int us = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string usuario = User.Identity.Name;
        int pantalla = 51;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, 0) == "RISC")
        {
            if (!IsPostBack)
            {
                cargaClientes();
            }
            
        }
        else if (permiso.returnPermiso(usuario, pantalla) == "BitacorasUsuarios")
        {
            if (!IsPostBack)
            {
                cargaClientes();
            }
        }
        else
            Response.Redirect("~/IOT/Home");
    }
    protected void BindGrid()
    {
        string sit = Sitio.SelectedValue;
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select TOP 50 d.ID, d.RISCEI, d1.Descripcion, d.Evento, d.Estado, d.Fecha FROM UbiDis u, " +
                                        "DispositivosActuadores D inner join dars d1 on d.RISCEI = d1.RISCEI where " +
                                        "d1.UbiDis = u.Id and u.Cl_Sitio = @sit and(d1.Modelo = 'DAR-BIS-VA/LE/LU/LS' or d1.Modelo = 'DAR-BIS-HW')" +
                                        "order by d.Fecha desc", conn);
        cmd.Parameters.AddWithValue("@sit", sit);
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
    protected void BindGrid2()
    {
        string sit = Sitio.SelectedValue;
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select TOP 50 d.ID, d.RISCEI, d1.Descripcion, d.Evento, d.Estado, d.Fecha FROM UbiDis u, " + 
                                        "DispositivosSensores D inner join dars d1 on d.RISCEI = d1.RISCEI where " +
                                        "d1.UbiDis = u.Id and u.Cl_Sitio = @sit and(d1.Modelo = 'DAR-BIS-BP/MG' or " +
                                        "d1.Modelo = 'DAR' or d1.Modelo = 'DAR-BIS-MV/SP/HU' or d1.Modelo = 'DAR-BIS-SU/HS') order by d.Fecha desc", conn);
        cmd.Parameters.AddWithValue("@sit", sit);
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
    public void cargaClientes()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT Id,RazonSocial FROM dbo.Clientes", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        Cliente.DataSource = dr;
        Cliente.DataTextField = "RazonSocial";
        Cliente.DataValueField = "Id";
        Cliente.DataBind();
        Cliente.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Sitio.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        

    }
    protected void CargaSitio()
    {
        string cliente = Cliente.SelectedValue;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("select ID, C_Sitio from sitios where ID_cliente=@cliente", cn);
        cmd.Parameters.AddWithValue("@cliente", cliente);
        SqlDataReader dr = cmd.ExecuteReader();     
        Sitio.DataSource = dr;       
        Sitio.DataValueField = "ID";
        Sitio.DataTextField = "C_Sitio";
        Sitio.DataBind();
        Sitio.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }

    protected void Carga_select(object sender, EventArgs e)
    {
        CargaSitio();
    }

    protected void Carga_Bind(object sender, EventArgs e) {

        if (Tipo.SelectedValue=="1")
        {
            BindGrid();
        }
        else if(Tipo.SelectedValue == "2")
        {
            BindGrid2();
        }
    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        if (Tipo.SelectedValue=="1")
        {
            this.BindGrid();
        }
        else if(Tipo.SelectedValue == "2")
        {
            this.BindGrid2();
        }
        //this.BindGrid();
    }


    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
       
    }

}