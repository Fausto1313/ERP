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
using IOTComer;
using Microsoft.AspNet.Identity.EntityFramework;
using TaskScheduler;

public partial class IOT_EventosAgrupados : System.Web.UI.Page
{

    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected int us = 0;
    protected string dar = null;
    protected string ev = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        if (!IsPostBack)
        {
            CargaSitios();
        }
        BindGrid();
    }
    public void CargaSitios()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        string usuario = User.Identity.Name;
        SqlCommand cmd = new SqlCommand("if(select 1 from PermisoRol where ID_Permiso = 36 and ID_Rol = (select ID_Rol from AspNetUsers where UserName = @usuario)) = 1 " +
                                        "select id, C_Sitio from sitios where ID_cliente = (select id_cliente from AspNetUsers where UserName = @usuario) " +
                                        "else select id, C_Sitio from sitios where ID = (select C_Sitio from AspNetUsers where UserName = @usuario)", cn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        Sitios.DataSource = dr;
        Sitios.DataTextField = "C_Sitio";
        Sitios.DataValueField = "ID";
        Sitios.DataBind();
        if (Sitios.Items.Count != 0)
        {
            Sitios.Items.Insert(0, new ListItem("Seleccionar sitio", "0"));
            us = Convert.ToInt32(Sitios.SelectedValue);
        }
        else
        {
            Sitios.Items.Clear();
        }

    }
    protected void BindGrid()
    {
        string id = User.Identity.GetUserId();
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select e.id,e.Comando, sit.C_Sitio from AgrupadosGeneral e, Sitios sit where e.ID_Sitio=sit.ID and sit.ID_Cliente= (select ID_Cliente from AspNetUsers where username=@usuario)", conn);
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
    protected void CreaTarea_Click(object sender, EventArgs e)
    {
        ExecuteAdd();
        Nombre.Text = "";
        Sitios.SelectedValue = "0";
        //Response.Redirect("~/IOT/SimuladorPresencia.aspx");

    }
    private void ExecuteAdd()
    {
        string nom = Nombre.Text;
        string lugar = Sitios.SelectedValue;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);
        conn.Open();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        string updatecmd = "insert into AgrupadosGeneral (Comando,ID_Sitio) values (@nom,@lugar)";
        SqlCommand addCmd = new SqlCommand(updatecmd, conn);
        addCmd.Parameters.AddWithValue("@nom", nom);
        addCmd.Parameters.AddWithValue("@lugar", lugar);
        addCmd.ExecuteNonQuery();
        conn.Close();
        sb.Append("$('#addModal').modal('hide');");
        sb.Append("swal(\"Guardado!\", \"Evento agregado de forma correcta.\", \"success\");");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
        BindGrid();
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string ide = hfs.Value;
        ExecuteDelete(ide);
        BindGrid();
    }
    private void ExecuteDelete(string ide)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
            sb.Append("<script type='text/javascript'>");
            string updatecmd = "delete from AgrupadosGeneral where ID = @id";
            SqlCommand addCmd = new SqlCommand(updatecmd, con);
            addCmd.Parameters.AddWithValue("@id", ide);
            addCmd.ExecuteNonQuery();
            sb.Append("$('#eliminaModal').modal('hide');");
            sb.Append("swal(\"Eliminado!\", \"Evento eliminado de forma correcta.\", \"success\");");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
            con.Close();
        }
        catch (SqlException e)
        {
            Console.WriteLine("Excepcion Ocurrida: ", e);
        }
    }


    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("delRecord"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            hfs.Value = id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("Asignar"))
        {
            GridViewRow gvrow2 = GridView1.Rows[index];
            string id = HttpUtility.HtmlDecode(gvrow2.Cells[0].Text).ToString();
            string sitio = HttpUtility.HtmlDecode(gvrow2.Cells[2].Text).ToString();
            Response.Redirect("~/IOT/AgregarDispo?ID=" + id + "&Sitio=" + sitio);
        }

    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
}
    