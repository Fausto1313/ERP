using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_AsignarRFID : System.Web.UI.Page
{

    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected int us = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 53;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Asignar RFID")
        {
            if (!IsPostBack)
            {
                CargarSitio();
            }
            //BindGrid();
        }
        else
        {
            Response.Redirect("~/IOT/Home");
        }
    }

     public void BindGrid()
    {
        string sit = Sitio.SelectedValue;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select r.id, a1.Descripcion, a2.DescripcionPuerta from (select RISCEI, Descripcion from DARS where Modelo = 'DAR-BIS-RF/HD' and UbiDis in" +
                                         "(select ID from UbiDis where Cl_Sitio = @sit)) as a1, (select RISCEI, Descripcion as DescripcionPuerta from DARS where Modelo = 'DAR-BIS-P1'" +
                                         "and UbiDis in (select ID from UbiDis where Cl_Sitio = @sit)) as a2, ReglasRFID r where r.RISCEI_RFID = a1.RISCEI and r.RISCEI_P1 = a2.RISCEI", conn);
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
    protected void CargarSitio()
    {
        Sitio.DataSource = Consultar("select ID, C_Sitio from Sitios where ID_cliente=(select ID_Cliente from AspNetUsers where UserName=@usuario)");
        Sitio.DataValueField = "ID";
        Sitio.DataTextField = "C_Sitio";
        Sitio.DataBind();
        Sitio.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        RF.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        P1.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
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
    protected void CargaRFID()
    {
        string sit = Sitio.SelectedValue;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select RISCEI, Descripcion from DARS d, UbiDis u  where d.RISCEI like '%RF%' and d.UbiDis = u.Id and u.Cl_Sitio =  @sit", conn);
        cmd.Parameters.AddWithValue("@sit", sit);
        SqlDataReader dr = cmd.ExecuteReader();
        RF.DataSource = dr;
        RF.DataTextField = "Descripcion";
        RF.DataValueField = "RISCEI";
        RF.DataBind();
        RF.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        conn.Close();
    }

    protected void CargaP1()
    {
        string riscei = RF.SelectedValue;
        string sit = Sitio.SelectedValue;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select a2.RISCEI, d.Descripcion from (select a1.RISCEI from (select RISCEI, Descripcion, UbiDis from DARS d, UbiDis u " +   
                                        "where d.RISCEI like '%P1%' and d.UbiDis = u.Id and u.Cl_Sitio = @sit and d.UbiDis = (select UbiDis from DARS where RISCEI = @riscei)) as a1 except select " +
                                        "RISCEI_P1 from ReglasRFID) as a2 inner join DARS d on d.RISCEI = a2.RISCEI", conn);
        cmd.Parameters.AddWithValue("@sit", sit);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        P1.DataSource = dr;
        P1.DataTextField = "Descripcion";
        P1.DataValueField = "RISCEI";
        P1.DataBind();
        conn.Close();
    }

    protected void Carga_select(object sender, EventArgs e)
    {
        CargaRFID();

    }

    protected void Carga_P1(object sender, EventArgs e)
    {
        CargaP1();
        BindGrid();
    }

    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("deleteRecord"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            hfID.Value = id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
    }

    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void Crea_Regla(object sender, EventArgs e)
    {
        string rfid = RF.Text;
        string puerta = P1.Text;
        ExecuteAdd(rfid, puerta);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        CargaP1();
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

    }
    private void ExecuteAdd(string rfid, string puerta)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "insert into ReglasRFID (RISCEI_RFID, RISCEI_P1) values (@RFID, @Puerta)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@Puerta", puerta);
        addCmd.Parameters.AddWithValue("@RFID", rfid);
        addCmd.ExecuteNonQuery();
        con.Close();
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string id = hfID.Value;
        ExecuteDelete(id);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registo Eliminado');");
        sb.Append("$('#eliminaModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
    }
    private void ExecuteDelete(string id)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updatecmd = "delete from ReglasRFID where ID=@id";
            SqlCommand addCmd = new SqlCommand(updatecmd, con);
            addCmd.Parameters.AddWithValue("@id", id);
            addCmd.ExecuteNonQuery();
            con.Close();

        }
        catch (SqlException e)
        {
            Console.WriteLine("Excepcion Ocurrida: ", e);
        }
    }

}