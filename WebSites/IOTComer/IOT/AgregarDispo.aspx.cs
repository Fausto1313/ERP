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

public partial class IOT_AgregarDispo : System.Web.UI.Page
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
        ide = Request.QueryString["ID"];
        site = Request.QueryString["Sitio"];
        if (!IsPostBack)
        {
            iniciarLlenadoDownLisst();
        }
        BindGrid(ide);
        BindGrid2(ide);
    }

    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("delRecord"))
        {
            string id =TareaDetalle.DataKeys[index].Value.ToString();
            hfss.Value = id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
      

    }
    protected void BindGrid(string id)
    {

        DataSet ds = new DataSet();
        if (id != null)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select e.ID, d.C_Sitio, e.Comando from AgrupadosGeneral e, Sitios d where e.ID = @id and e.ID_Sitio = d.ID", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                DetalleEvento.DataSource = ds;
                DetalleEvento.DataBind();

            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                DetalleEvento.DataSource = ds;
                DetalleEvento.DataBind();
                int columncount = DetalleEvento.Rows[0].Cells.Count;
                DetalleEvento.Rows[0].Cells.Clear();
                DetalleEvento.Rows[0].Cells.Add(new TableCell());
                DetalleEvento.Rows[0].Cells[0].ColumnSpan = columncount;
                DetalleEvento.Rows[0].Cells[0].Text = "No se encontraron Registros";
            }
        }

    }
    protected void BindGrid2(string id)
    {

        DataSet ds = new DataSet();

        if (id != null)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(" select a.ID,a.RISCEI, a.Accion from Agrupados_DARS a , dars d  where a.ID_AgrupadosGeneral=@id and d.RISCEI=a.RISCEI", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);
            con.Close();
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                TareaDetalle.DataSource = ds;
                TareaDetalle.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                TareaDetalle.DataSource = ds;
                TareaDetalle.DataBind();
                int columncount = TareaDetalle.Rows[0].Cells.Count;
                TareaDetalle.Rows[0].Cells.Clear();
                TareaDetalle.Rows[0].Cells.Add(new TableCell());
                TareaDetalle.Rows[0].Cells[0].ColumnSpan = columncount;
                TareaDetalle.Rows[0].Cells[0].Text = "No se encontraron Registros";
            }
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
    protected void iniciarLlenadoDownLisst()
    {
        nivel.DataSource = Consultar("select ID, Nombre from Nivel1 where UbiDispo = (select C_Sitio from AspNetUsers where UserName =@usuario)");
        nivel.DataValueField = "ID";
        nivel.DataTextField = "Nombre";
        nivel.DataBind();
        nivel.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        dispos.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

    }

    protected void NivelesSelecionado(object sender, EventArgs e)
    {
      
        int nivels = Convert.ToInt32(nivel.SelectedValue);
        dispos.DataSource = Consultar("select d.RISCEI, d.Descripcion from DARS d inner join UbiDis u on u.Id = d.UbiDis where u.nivel1 = " + nivels + " and d.Modelo ='DAR-BIS-VA/LE/LU/LS'");
        dispos.DataTextField = "Descripcion";
        dispos.DataValueField = "RISCEI";
        dispos.DataBind();
        dispos.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

    }

    protected void DispoSelecionado(object sender, EventArgs e)
    {

    }
    protected void AccionesSelecionado(object sender, EventArgs e)
    {

    }
    protected void CreaTarea_Click(object sender, EventArgs e)
    {
        ExecuteAdd();
        BindGrid2(ide);
        nivel.SelectedValue = "0";
        dispos.SelectedValue = "0";
    }
    private void ExecuteAdd()
    {
        string nivela =nivel.SelectedValue;
        string dis = dispos.SelectedValue;
        string acc = acciones.SelectedValue;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);

        conn.Open();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        string updatecmd = "insert into Agrupados_DARS (ID_AgrupadosGeneral,RISCEI,Accion) values (@ID,@dispositivo,@accion)";
        SqlCommand addCmd = new SqlCommand(updatecmd, conn);
        addCmd.Parameters.AddWithValue("@ID", ide);
        addCmd.Parameters.AddWithValue("@dispositivo", dis);
        addCmd.Parameters.AddWithValue("@accion", acc);
        addCmd.ExecuteNonQuery();
        conn.Close();
        sb.Append("$('#addModal').modal('hide');");
        sb.Append("swal(\"Guardado!\", \"Dispositivo agregado de forma correcta.\", \"success\");");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
        

    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string ides = hfss.Value;
        ExecuteDelete(ides);
        BindGrid2(ide);
    }
    private void ExecuteDelete(string ides)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
            sb.Append("<script type='text/javascript'>");
            string updatecmd = "delete from Agrupados_DARS where ID = @id";
            SqlCommand addCmd = new SqlCommand(updatecmd, con);
            addCmd.Parameters.AddWithValue("@id", ides);
            addCmd.ExecuteNonQuery();
            sb.Append("$('#eliminaModal').modal('hide');");
            sb.Append("swal(\"Eliminado!\", \"Dispositivo eliminado de forma correcta.\", \"success\");");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
            con.Close();

        }
        catch (SqlException e)
        {
            Console.WriteLine("Excepcion Ocurrida: ", e);
        }
    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DetalleEvento.PageIndex = e.NewPageIndex;
        this.BindGrid(ide);
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TareaDetalle.PageIndex = e.NewPageIndex;
        this.BindGrid2(ide);

    }
}