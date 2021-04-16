using Newtonsoft.Json;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

public partial class IOT_TelegramMonitoreo : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 1;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Telegram")
        {
            if (!IsPostBack)
            {
                CargaClientes();
            }
            BindGrid();
        }

        else
            Response.Redirect("~/IOT/Home");
    }
    public void BindGrid()
    {

        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID, Usuario FROM TelegramMonitoreo where ID_Cliente=7023", conn);
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
    public void leeSolicitud(object sender, EventArgs e)
    {
        string aux = null;
        int i = 0, k = 0, contador = 0;
        bool flag = false, flag2 = false;
        string json = consultaSolicitud();
        //RootObject prueba = JsonConvert.DeserializeObject<RootObject>(json);
        //Response.Write(json);

        JsonTextReader read = new JsonTextReader(new StringReader(json));
        //JTokenReader j = new JTokenReader("id");
        string ide = null;
        ArrayList array = new ArrayList();
        ArrayList arr2 = new ArrayList();
        string username = null;
        while (read.Read())
        {
            if ((flag == true) && (i < 1))
            {
                //Response.Write("id: " + read.Value);
                ide = Convert.ToString(read.Value);
                flag = false;
                arr2.Add(read.Value);
            }
            if ((flag2 == true) && (k < 1))
            {
                username = Convert.ToString(read.Value);
                flag2 = false;
                array.Add(username);
            }
            if (read.Value != null)
            {
                aux = Convert.ToString(read.Value);
                if (aux == "id")
                {
                    flag = true;
                    continue;
                }
                if (aux == "username")
                {
                    flag2 = true;
                    continue;
                }
                else
                    continue;
            }
        }
        int last = array.Count;
        for (int z = 0; z < last; z++)
        {
            try
            {
                registros(arr2[z].ToString(), array[z].ToString());
                //Response.Write(arr2[z].ToString());
            }
            catch (Exception x)
            {

            }
            z++;
        }
        BindGrid();
    }
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("detail"))
        {
            string IdEvento = GridView1.DataKeys[index].Value.ToString();
            IEnumerable<DataRow> query = from DARS in dt.AsEnumerable()
                                         where DARS.Field<String>("ID").Equals(ID)
                                         select DARS;
            DataTable GridView1Table = query.CopyToDataTable<DataRow>();
            GridView1.DataSource = GridView1Table;
            GridView1.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type= 'text/javascript'>");
            sb.Append("$('detailmodal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DetailmodalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("clienterecord"))
        {
            GridViewRow gvrow = GridView1.Rows[index];

            lblRisc1.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            //txtcliente.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            lblResultt.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModalc').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }

    }
    public void CargaClientes()
    {
        string usuario = Context.User.Identity.Name;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT RazonSocial, ID FROM CLIENTES WHERE ID = (SELECT ID_CLIENTE FROM AspNetUsers Where UserName = @usuario)", cn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        //Clientes2.DataSource = dr;
        Clientes.DataSource = dr;
        //Clientes2.DataTextField = "RazonSocial";
        Clientes.DataTextField = "RazonSocial";
        //Clientes2.DataValueField = "ID";
        Clientes.DataValueField = "ID";
        Clientes.DataBind();
        //Clientes2.DataBind();
    }
    protected void BtnSave_ClickS(object sender, EventArgs e)
    {
        string id = lblRisc1.Text;
        int cliente = Convert.ToInt32(Clientes.Text);
        ExecuteUpdateS(id, cliente);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModalc').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    }
    /*Ejecuta el evento de actualizado a la base de datos*/
    private void ExecuteUpdateS(string id, int cliente)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE TelegramMonitoreo SET ID_Cliente=@cliente WHERE ID=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@cliente", cliente);
        updatecmd.ExecuteNonQuery();
        con.Close();

    }
    public string consultaSolicitud()
    {
        string json = null;
        string token = "659734075:AAG0WQX6tow-_cKxxuVX9hzPz1dkIl1nfxA";
        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/getUpdates");
        Stream recibido;
        recibido = Peticion.GetResponse().GetResponseStream();
        StreamReader json1 = new StreamReader(recibido);
        json = json1.ReadToEnd();
        return json;
    }

    public void registros(string id, string usuario)
    {

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        int idc = 7023;
        cmd.CommandText = "INSERT TelegramMonitoreo (ID, usuario,ID_Cliente) VALUES (@ID, @usuario, @idc)";
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@idc", idc);
        cmd.Connection = con;
        con.Open();

        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

    {

        GridView1.PageIndex = e.NewPageIndex;

        this.BindGrid();

    }
}
