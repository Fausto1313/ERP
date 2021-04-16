using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_AdministracionPromociones : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void PromocionesDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        PromocionesDetalle.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void PromocionesDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("AddProducto"))
        {
            string id = PromocionesDetalle.DataKeys[index].Value.ToString();
            Response.Redirect("~/IOT/DetallePromociones?ID=" + id);
        }
    }

    public void BindGrid()
    {
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmds = new SqlCommand("select ID, Nombre, Precio from Promocion where ID_Sitio = (select C_Sitio from AspNetUsers" +
            " where UserName= @user)", conn);
        cmds.Parameters.AddWithValue("@user", usuario);
        SqlDataAdapter da = new SqlDataAdapter(cmds);
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            PromocionesDetalle.DataSource = ds;
            PromocionesDetalle.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            PromocionesDetalle.DataSource = ds;
            PromocionesDetalle.DataBind();
            int columncount = PromocionesDetalle.Rows[0].Cells.Count;
            PromocionesDetalle.Rows[0].Cells.Clear();
            PromocionesDetalle.Rows[0].Cells.Add(new TableCell());
            PromocionesDetalle.Rows[0].Cells[0].ColumnSpan = columncount;
            PromocionesDetalle.Rows[0].Cells[0].Text = "No se encontraron Registros";
        }
    }

    protected void Agregar_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("insert into Promocion(Nombre, Precio, ID_Sitio) " +
            "values(@nombre, @precio,(select C_Sitio from AspNetUsers where UserName=@user))");
        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
        cmd.Parameters.AddWithValue("@precio", Convert.ToInt64(Precio.Text));
        cmd.Parameters.AddWithValue("@user", User.Identity.Name);
        DBIOT db = new DBIOT();
        db.insert(cmd);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        sb.Append("swal(\"Guardado!\", \"Paquete agregado correctamente.\", \"success\");");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddAlertInsert", sb.ToString(), false);
        BindGrid();
    }
}