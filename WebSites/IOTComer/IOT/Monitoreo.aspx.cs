using System;
using System.Net;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI;

public partial class IOT_Monitoreo : System.Web.UI.Page
{
    DataTable dt;
    string id;
    int total;
    int total2;
    string respuesta;
    string respuesta2;
    string url;
    string url2;
    string destinatario;
    string idTelegram;
    int idPagina;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        SqlCommand cmd = new SqlCommand("SELECT ID_Cliente FROM dbo.AspNetUsers WHERE Username ='" + usuario + "'", conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        int pantalla = 37;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Monitoreo")
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = Convert.ToString(reader.GetInt32(0));
                }
            }
            conn.Close();
            BindGrid();
        }
        else
            Response.Redirect("~/IOT/Home");
    }

    protected void BindGrid()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM paginas where ID_Cliente ='" + id + "'", conn);
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

    protected void Ping(object sender, EventArgs e)
    {
        conn.Open();
        SqlCommand cmd2 = new SqlCommand("SELECT count(url) as total from dbo.paginas where id_cliente=" + id, conn);
        SqlDataReader reader2 = cmd2.ExecuteReader();
        if (reader2.HasRows)
        {
            while (reader2.Read())
            {
                total = reader2.GetInt32(0);
            }
        }
        conn.Close();

        conn.Open();
        SqlCommand cmd = new SqlCommand("select url from dbo.paginas where ID_Cliente=" + id, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        String[] array;
        int index = 0;
        array = new String[total];

        while (reader.Read())
        {
            array[index] = reader.GetString(0);
            index++;
        }
        conn.Close();

        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[2] { new DataColumn("URL", typeof(string)), new DataColumn("Estado", typeof(string)) });

        int top = 0;
        for (int i = 0; array.Length > i; i++)
        {

            if (top < array.Length)
            {
                WebRequest request = WebRequest.Create(array[top]);
                request.Credentials = CredentialCache.DefaultCredentials;
                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    respuesta = "Activo";

                }
                catch (WebException ex)
                {
                    respuesta = "Error: " + ex.Message;
                }
                url = array[top];
                dt.Rows.Add(url, respuesta);
                top++;
            }
        }
        GridView2.DataSource = dt;
        GridView2.DataBind();
        Telegram();
    }

    protected void Agregar(object sender, EventArgs e)
    {
        conn.Open();
        string insertCmd = "insert into Paginas(URL,ID_Cliente) values(@url,@id)";
        SqlCommand insertcmd = new SqlCommand(insertCmd, conn);
        insertcmd.Parameters.AddWithValue("@url",Url.Text);
        insertcmd.Parameters.AddWithValue("@id",id);
        insertcmd.ExecuteNonQuery();
        conn.Close();
        BindGrid();
    }

    protected void Telegram()
    {
        conn.Open();
        SqlCommand cmd2 = new SqlCommand("SELECT count(url) as total from dbo.Telegrampagina INNER JOIN dbo.Paginas ON dbo.telegrampagina.id_pagina = dbo.Paginas.id where dbo.Paginas.ID_Cliente =" + id, conn);

        SqlDataReader reader2 = cmd2.ExecuteReader();
        if (reader2.HasRows)
        {
            while (reader2.Read())
            {
                total2 = reader2.GetInt32(0);
            }
        }
        conn.Close();

        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT url , telegram from dbo.Telegrampagina INNER JOIN dbo.Paginas ON dbo.telegrampagina.id_pagina = dbo.Paginas.id where dbo.Paginas.ID_Cliente=" + id, conn);
        SqlDataReader reader = cmd.ExecuteReader();
        String[] arrayUrl;
        String[] arrayTelegram;
        int index = 0;
        arrayUrl = new String[total2];
        arrayTelegram = new String[total2];
        while (reader.Read())
        {
            arrayUrl[index] = reader.GetString(0);
            arrayTelegram[index] = reader.GetString(1);
            index++;
        }
        conn.Close();

        int top = 0;
        for (int i = 0; arrayUrl.Length > i; i++)
        {

            if (top < arrayUrl.Length)
            {
                WebRequest request = WebRequest.Create(arrayUrl[top]);
                request.Credentials = CredentialCache.DefaultCredentials;
                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    respuesta2 = "Activo";

                }
                catch (WebException ex)
                {
                    respuesta2 = "Error: " + ex.Message;
                }
                url2 = arrayUrl[top];
                destinatario = arrayTelegram[top];
                sendTelegram();
                top++;
            }
        }
    }

    protected void sendTelegram()
    {
        string token = "659734075:AAG0WQX6tow-_cKxxuVX9hzPz1dkIl1nfxA";

        string mensaje = "Se ha monitoreado la dirrección " + url2 + " Cuyo estado es " + respuesta2;

        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + destinatario + "&text=" + mensaje);
        Peticion.GetResponse();
    }

    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("Asignar"))
        {
            GridViewRow gvrow2 = GridView1.Rows[index];
            string id = HttpUtility.HtmlDecode(gvrow2.Cells[0].Text);
            Response.Redirect("~/IOT/MonitoreoUsuario?url=" + id);
        }
        else if (e.CommandName.Equals("Eliminar"))
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
        conn.Open();
        SqlCommand cmd2 = new SqlCommand("select id from dbo.Paginas where url ='"+id+"'", conn);

        SqlDataReader reader2 = cmd2.ExecuteReader();
        if (reader2.HasRows)
        {
            while (reader2.Read())
            {
                idPagina = reader2.GetInt32(0);
            }
        }
        conn.Close();


        
        conn.Open();
        string deletecmd = "delete from dbo.telegrampagina where id_pagina =@id";
        SqlCommand Cmd = new SqlCommand(deletecmd, conn);
        Cmd.Parameters.AddWithValue("@id", idPagina);
        Cmd.ExecuteNonQuery();
        conn.Close();


        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updatecmd = "delete from dbo.paginas where url=@id";
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



       