using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

public partial class IOT_MonitoreoUsuario : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    string id;
    string urlid;
    DataTable dt;
    string telegramid;
    string ide = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        SqlCommand cmd = new SqlCommand("SELECT ID_Cliente FROM dbo.AspNetUsers WHERE UserName = @usuario", conn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                id = Convert.ToString(reader.GetInt32(0));
            }
        }
        conn.Close();
        ide = Request.QueryString["url"];
        if (!IsPostBack)
        {
            cargaTelegram();
            BindGrid();
            BindGrid2();
        }
       
    }
   
    public void cargaTelegram()
    {
        conn.Open();
        SqlCommand cms = new SqlCommand("select * From telegramMonitoreo where ID_Cliente=@id", conn);
        cms.Parameters.AddWithValue("@id", id);
        SqlDataReader drs = cms.ExecuteReader();
        telegramp.DataSource = drs;
        telegramp.DataValueField = "id";
        telegramp.DataTextField = "usuario";
        telegramp.DataBind();
        conn.Close();
    }


    protected void BindGrid()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT id, url FROM dbo.paginas where url ='"+ide+"' and ID_Cliente ="+ id, conn);
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
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT telegram,usuario FROM dbo.TelegramPagina INNER JOIN dbo.TelegramMonitoreo ON dbo.telegrampagina.Telegram = dbo.TelegramMonitoreo.ID inner Join dbo.paginas ON dbo.TelegramPagina.ID_Pagina = dbo.Paginas.ID where dbo.Paginas.URL = '"+ide+"'and dbo.TelegramMonitoreo.ID_Cliente ="+id, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView2.DataSource = ds;
            GridView2.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GridView2.DataSource = ds;
            GridView2.DataBind();
            int columncount = GridView1.Rows[0].Cells.Count;
            GridView2.Rows[0].Cells.Clear();
            GridView2.Rows[0].Cells.Add(new TableCell());
            GridView2.Rows[0].Cells[0].ColumnSpan = columncount;
            GridView2.Rows[0].Cells[0].Text = "No se encontraron Registros";
        }
    }

    public void Asignar(object sender, EventArgs e)
    {
        string tel = Convert.ToString(telegramp.Text);
        conn.Open();
        string insertCmd = "insert into TelegramPagina (Telegram,ID_Pagina) values(@telegram, (select ID from Paginas where URL = @pagina))";
        SqlCommand insertcmd = new SqlCommand(insertCmd, conn);
        insertcmd.Parameters.AddWithValue("@telegram",tel);
        insertcmd.Parameters.AddWithValue("@pagina",ide);
        insertcmd.ExecuteNonQuery();
        conn.Close();
        BindGrid2();
    }

    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
       
        if (e.CommandName.Equals("delRecord"))
        {
            string id = GridView2.DataKeys[index].Value.ToString();
 

            hfID.Value = id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string id = hfID.Value;
        ExecuteDelete(id);
        BindGrid2();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registo Eliminado');");
        sb.Append("$('#deleteModal').modal('hide');");
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
            string updatecmd = "delete from dbo.telegrampagina where telegram =@id";
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

    