using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_AsistenteVoz : System.Web.UI.Page
{
    DataTable dt;
    int sitio = 0;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            cargaClientes();
        //BindGrid();
    }

    protected void Cliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        int cliente = Convert.ToInt32(Cliente.SelectedValue);
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID, Descripcion FROM Sitios where ID_cliente=@id", con);
        cmd.Parameters.AddWithValue("@id", cliente);
        SqlDataReader dr = cmd.ExecuteReader();
        Sitio.DataSource = dr;
        Sitio.DataValueField = "ID";
        Sitio.DataTextField = "Descripcion";
        Sitio.DataBind();
        Sitio.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        con.Close();
    }

    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        string riscei = string.Empty;
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("asistente"))
        {
            GridViewRow gvrow = GridView1.Rows[index];
            riscei = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            cargaComandos(riscei);
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }
    }

    protected void cargaComandos(string riscei) {
        int a = 1;
        string encendido = string.Empty, apagado = string.Empty, aux = string.Empty, aux1 = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select d.RISCEI, e.Evento, e.Comando from DARS d inner join Eventos e on e.Modelo = d.Modelo " +
            "where d.RISCEI = @riscei and (d.Modelo='DAR-BIS-VA/LE/LU/LS' or d.Modelo='DAR-BIS-HW') order by e.Comando desc ", con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            switch (a) {
                case 1:
                    aux = Convert.ToString(dr["RISCEI"]);
                    aux1 = Convert.ToString(dr["Comando"]);
                    aux = Encrypt.Encriptar(aux);
                    aux1 = Encrypt.Encriptar(aux1);
                    encendido = "https://addar.mx/IFTTTService?lust=" + aux+"&dh="+aux1;
                    Accion1.Text = Convert.ToString(dr["Evento"]);
                    txtuno.Text = encendido;
                    tres.Visible = false;
                    cuatro.Visible = false;
                    cinco.Visible = false;
                    seis.Visible = false;
                    break;
                case 2:
                    aux = Convert.ToString(dr["RISCEI"]);
                    aux1 = Convert.ToString(dr["Comando"]);
                    aux = Encrypt.Encriptar(aux);
                    aux1 = Encrypt.Encriptar(aux1);
                    encendido = "https://addar.mx/IFTTTService?lust=" + aux + "&dh=" + aux1;
                    Accion2.Text = Convert.ToString(dr["Evento"]);
                    txtdos.Text = encendido;
                    tres.Visible = false;
                    cuatro.Visible = false;
                    cinco.Visible = false;
                    seis.Visible = false;
                    break;
                case 3:
                    Accion3.Visible = true;
                    txttres.Visible = true;
                    aux = Convert.ToString(dr["RISCEI"]);
                    aux1 = Convert.ToString(dr["Comando"]);
                    aux = Encrypt.Encriptar(aux);
                    aux1 = Encrypt.Encriptar(aux1);
                    encendido = "https://addar.mx/IFTTTService?lust=" + aux + "&dh=" + aux1;
                    Accion3.Text = Convert.ToString(dr["Evento"]);
                    txttres.Text = encendido;
                    tres.Visible = true;
                    cuatro.Visible = false;
                    cinco.Visible = false;
                    seis.Visible = false;
                    break;
                case 4:
                    Accion4.Visible = true;
                    txtcuatro.Visible = true;
                    aux = Convert.ToString(dr["RISCEI"]);
                    aux1 = Convert.ToString(dr["Comando"]);
                    aux = Encrypt.Encriptar(aux);
                    aux1 = Encrypt.Encriptar(aux1);
                    encendido = "https://addar.mx/IFTTTService?lust=" + aux + "&dh=" + aux1;
                    Accion4.Text = Convert.ToString(dr["Evento"]);
                    txtcuatro.Text = encendido;
                    tres.Visible = true;
                    cuatro.Visible = true;
                    cinco.Visible = false;
                    seis.Visible = false;
                    break;
                case 5:
                    Accion5.Visible = true;
                    txtcinco.Visible = true;
                    aux = Convert.ToString(dr["RISCEI"]);
                    aux1 = Convert.ToString(dr["Comando"]);
                    aux = Encrypt.Encriptar(aux);
                    aux1 = Encrypt.Encriptar(aux1);
                    encendido = "https://addar.mx/IFTTTService?lust=" + aux + "&dh=" + aux1;
                    Accion5.Text = Convert.ToString(dr["Evento"]);
                    txtcinco.Text = encendido;
                    tres.Visible = true;
                    cuatro.Visible = true;
                    cinco.Visible = true;
                    seis.Visible = false;
                    break;
                case 6:
                    Accion6.Visible = true;
                    txtseis.Visible = true;
                    aux = Convert.ToString(dr["RISCEI"]);
                    aux1 = Convert.ToString(dr["Comando"]);
                    aux = Encrypt.Encriptar(aux);
                    aux1 = Encrypt.Encriptar(aux1);
                    encendido = "https://addar.mx/IFTTTService?lust=" + aux + "&dh=" + aux1;
                    Accion6.Text = Convert.ToString(dr["Evento"]);
                    txtseis.Text = encendido;
                    tres.Visible = true;
                    cuatro.Visible = true;
                    cinco.Visible = true;
                    seis.Visible = true;
                    break;
            }
            aux = string.Empty;
            encendido = string.Empty;
            a++;
        }
        con.Close();
    }

    protected void Sitio_SelectedIndexChanged(object sender, EventArgs e)
    {
        sitio = Convert.ToInt32(Cliente.SelectedValue);
        BindGrid();
    }
    protected void cargaClientes() {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID, RazonSocial FROM Clientes  where ID != 2", con);
        SqlDataReader dr = cmd.ExecuteReader();
        Cliente.DataSource = dr;
        Cliente.DataTextField = "RazonSocial";
        Cliente.DataValueField = "ID";
        Cliente.DataBind();
        Cliente.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        con.Close();
    }

    public void BindGrid()
    {
        con.Open();
        sitio = Convert.ToInt32(Sitio.SelectedValue);
        string usuario = Context.User.Identity.Name;
        SqlCommand cmd = new SqlCommand("SELECT D.RISCEI, D.Descripcion, D.Modelo FROM DARS D  WHERE D.UbiDis in " +
            "(SELECT Id from UbiDis where Cl_Sitio = @sitio) and (d.Modelo='DAR-BIS-VA/LE/LU/LS' or d.Modelo='DAR-BIS-HW')", con);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
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
        this.BindGrid();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
    }
}