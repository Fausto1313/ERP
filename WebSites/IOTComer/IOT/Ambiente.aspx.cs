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

public partial class IOT_Ambiente : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        Permisos permiso = new Permisos();
        int pantalla = 28;
        if (permiso.returnPermiso(usuario, pantalla) == "Ambiente")
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            
        }
        else
            Response.Redirect("~/IOT/Home");
    }

    protected void BindGrid()
    {
        string id = User.Identity.GetUserId();
        string usuario = User.Identity.Name;

        conn.Open();
        SqlCommand cmd = new SqlCommand("select top 20 s.ID, d.RISCEI, d.Descripcion , s.Temperatura, s.Humedad, " +
            "s.Fecha from UbiDis u, Sensado s inner join DARS d on d.RISCEI = s.RISCEI where " +
            "d.UbiDis = u.Id and u.Cl_Sitio = (select C_Sitio from Aspnetusers where UserName = @user) order by s.ID desc", conn);
        cmd.Parameters.AddWithValue("@user",usuario);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        { 
           
            Bitacora.DataSource = ds;
            Bitacora.DataBind();

        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            Bitacora.DataSource = ds;
            Bitacora.DataBind();
            int columncount = Bitacora.Rows[0].Cells.Count;
            Bitacora.Rows[0].Cells.Clear();
            Bitacora.Rows[0].Cells.Add(new TableCell());
            Bitacora.Rows[0].Cells[0].ColumnSpan = columncount;
            Bitacora.Rows[0].Cells[0].Text = "No se encontraron Registros";
        }

    }
    protected void confUmbrales(object sender, EventArgs e){
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
    }

    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Bitacora.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
}