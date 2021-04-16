using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

public partial class AccionesHS : System.Web.UI.Page
{

    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        string usuario = User.Identity.Name;
        Permisos permiso = new Permisos();
        int pantalla = 29;
        if (permiso.returnPermiso(usuario, pantalla) == "Sensores")
        {
            //BindGrid();
            if(!IsPostBack)
            CargaDispositivos();
        }
        else
            Response.Redirect("~/IOT/Home");
    }
    public void BindGrid()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select d.ID, d.RISCEI, d1.Descripcion, d.Evento, d.Estado, d.Fecha FROM " +
            "DispositivosSensores D inner join DARS d1 on d1.RISCEI = d.RISCEI where d.RISCEI = @riscei order by d.Fecha desc", conn);
        cmd.Parameters.AddWithValue("@riscei", Dis.SelectedValue);
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

    protected void Dis_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(Dis.SelectedValue!="0")
        BindGrid();
    }

    protected void CargaDispositivos()
    {
        string usuario = User.Identity.Name;
        Dis.DataSource = Consultar("select RISCEI, Descripcion from DARS where UbiDis in (select ID from UbiDis where Cl_Sitio = " +
            "(select C_Sitio from AspNetUsers where UserName = @usuario)) and(Modelo = 'DAR-BIS-BP/MG' or Modelo = 'DAR' " +
            "or Modelo = 'DAR-BIS-MV/SP/HU' or Modelo = 'DAR-BIS-SU/HS')");
        Dis.DataValueField = "RISCEI";
        Dis.DataTextField = "Descripcion";
        Dis.DataBind();
        Dis.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        BindGrid();
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