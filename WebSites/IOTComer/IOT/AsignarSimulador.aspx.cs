using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_AsignarSimulador : System.Web.UI.Page
{
    protected string ev = null;
    protected string dar = null;
    string ide = string.Empty;
    string site = string.Empty;
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection con = new SqlConnection(conString);


    protected void Page_Load(object sender, EventArgs e)
    {    
        string usuario = User.Identity.Name;
        int pantalla = 13;
        Permisos permiso = new Permisos();
        
        if (permiso.returnPermiso(usuario, 0) == "RISC")
        {
            ide = Request.QueryString["ID"];
            site = Request.QueryString["Sitio"];
            if (!IsPostBack)
            {               
                CargaDars();
            }
            else if (permiso.returnPermiso(usuario, pantalla) == "Simulacion de Presencia")
            {

            }
            BindGrid(ide);
            BindGrid2(ide);
        }
        else
            Response.Redirect("~/IOT/Home");
    }

    protected void BindGrid(string id)
    {
        
        DataSet ds = new DataSet();
        if (id != null)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select s.ID, d.C_Sitio, s.Nombre from Simulador s, Sitios d where s.ID = @id and s.ID_Sitio = d.ID", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                DetalleTarea.DataSource = ds;
                DetalleTarea.DataBind();
               
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                DetalleTarea.DataSource = ds;
                DetalleTarea.DataBind();
                int columncount = DetalleTarea.Rows[0].Cells.Count;
                DetalleTarea.Rows[0].Cells.Clear();
                DetalleTarea.Rows[0].Cells.Add(new TableCell());
                DetalleTarea.Rows[0].Cells[0].ColumnSpan = columncount;
                DetalleTarea.Rows[0].Cells[0].Text = "No se encontraron Registros";
            }
        }

    }

    protected void BindGrid2(string id)
    {
        
        DataSet ds = new DataSet();
        if (id != null)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select r.ID_Simulador, r.ID_Dispositivo, d.Descripcion, r.Accion from DispositivoRegla r, DARS d where ID_Simulador=@id and d.RISCEI = r.ID_Dispositivo", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            da.Fill(ds);
            con.Close();
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                TareasDetalle.DataSource = ds;
                TareasDetalle.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                TareasDetalle.DataSource = ds;
                TareasDetalle.DataBind();
                int columncount = TareasDetalle.Rows[0].Cells.Count;
                TareasDetalle.Rows[0].Cells.Clear();
                TareasDetalle.Rows[0].Cells.Add(new TableCell());
                TareasDetalle.Rows[0].Cells[0].ColumnSpan = columncount;
                TareasDetalle.Rows[0].Cells[0].Text = "No se encontraron Registros";
            }
        }

    }

    public void CargaDars()
    {
       
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        con.Open();
        SqlCommand cmd = new SqlCommand("select Descripcion,RISCEI from DARS d, UbiDis u  where(d.Modelo = 'DAR-BIS-VA/LE/LU' or d.Modelo = 'DAR-BIS-HW' or d.Modelo = 'DAR-BIS-MP')and d.UbiDis = u.Id and u.Cl_Sitio = (select ID from Sitios where C_Sitio = @site )", con);
        cmd.Parameters.AddWithValue("@site", site);
        SqlDataReader dr = cmd.ExecuteReader();
        dis.DataSource = dr;
        dis.DataValueField = "RISCEI";
        dis.DataTextField = "Descripcion";
        dis.DataBind();
        dis.Items.Insert(0, new ListItem("Seleccionar dispositivo", "0"));
        dar = Convert.ToString(dis.SelectedValue);
  
    }

    private void ExecuteAdd()
    {

        string dispositivo = dis.SelectedValue;    
        
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);
        conn.Open();
        string updatecmd = "insert into DispositivoRegla (ID_Simulador,ID_Dispositivo) values (@ID,@dispositivo)";
        SqlCommand addCmd = new SqlCommand(updatecmd, conn);
        addCmd.Parameters.AddWithValue("@ID", ide);
        addCmd.Parameters.AddWithValue("@dispositivo", dispositivo);
        addCmd.ExecuteNonQuery();
        conn.Close();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Dispositivo agregado');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
        
    }


    protected void CreaTarea_Click(object sender, EventArgs e)
    {
        ExecuteAdd();
        BindGrid2(ide);
        dis.SelectedValue = "0";
        
    }


    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DetalleTarea.PageIndex = e.NewPageIndex;
        this.BindGrid(ide);
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TareasDetalle.PageIndex = e.NewPageIndex;
        this.BindGrid2(ide);

    }
}