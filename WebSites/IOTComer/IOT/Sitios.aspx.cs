using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sitios : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 19;
        Permisos permiso = new Permisos();

        if (permiso.returnPermiso(usuario, 0) == "RISC")
        {

            BindGrid2();
            if (!IsPostBack)
            {
                CargaClientes();
                CargaClientes2();
            }
            else if (permiso.returnPermiso(usuario, pantalla) == "Sitios")
            {

            }
        }
        else
            Response.Redirect("~/IOT/Home");
    }

    public void BindGrid()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Sitios", conn);
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






    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)

    {

        int index = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName.Equals("detail"))

        {

            string id = GridView1.DataKeys[index].Value.ToString();

            IEnumerable<DataRow> query = from Sitios in dt.AsEnumerable()

                                         where Sitios.Field<String>("ID").Equals(id)

                                         select Sitios;

            DataTable GridView1Table = query.CopyToDataTable<DataRow>();

            GridView1.DataSource = GridView1Table;

            GridView1.DataBind();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(@"<script type= 'text/javascript'>");

            sb.Append("$('detailmodal').modal('show');");

            sb.Append(@"</script>");

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DetailmodalScript", sb.ToString(), false);

        }

        else if (e.CommandName.Equals("updRecord"))

        {

            GridViewRow gvrow = GridView1.Rows[index];
            lblID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            Clientes.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            txtSitio.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
            textDescripcion.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            txtEstado.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
            txtCiudad.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
            txtCP.Text = HttpUtility.HtmlDecode(gvrow.Cells[6].Text);
            txtCalleNumero.Text = HttpUtility.HtmlDecode(gvrow.Cells[7].Text);
            txtColonia.Text = HttpUtility.HtmlDecode(gvrow.Cells[8].Text);
            txtTelefono.Text = HttpUtility.HtmlDecode(gvrow.Cells[9].Text);
            txtMail.Text = HttpUtility.HtmlDecode(gvrow.Cells[10].Text);
            Dstatus.Text = HttpUtility.HtmlDecode(gvrow.Cells[11].Text);
            txtNOIP.Text = HttpUtility.HtmlDecode(gvrow.Cells[13].Text);
            txtNOIPS.Text = HttpUtility.HtmlDecode(gvrow.Cells[14].Text);
            lblResult.Visible = false;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(@"<script type='text/javascript'>");

            sb.Append("$('#updModal').modal('show');");

            sb.Append(@"</script>");

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("sincSitio")) {
            GridViewRow gvrow = GridView1.Rows[index];
            string sitio = string.Empty, noip = string.Empty, respuesta = string.Empty, url = string.Empty, direccion = string.Empty;
            //cliente = Convert.ToInt32(HttpUtility.HtmlDecode(gvrow.Cells[1].Text));
            direccion = "Calle y número: "+HttpUtility.HtmlDecode(gvrow.Cells[7].Text) + " Colonia: "+ HttpUtility.HtmlDecode(gvrow.Cells[8].Text)
                +" Municipio: "+ HttpUtility.HtmlDecode(gvrow.Cells[5].Text) + " Estado: " +HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
            sitio = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            noip = "http://"+HttpUtility.HtmlDecode(gvrow.Cells[13].Text);
            url = "http://monitoreo.addar.mx/DarCtrl.php?noip=" + noip + "&descripciondar=" + sitio + "&ubicacion=" + direccion+
                "&accion=InserDar";
            respuesta = returnResponseValue(url);
            //Response.Write(respuesta);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (respuesta.Contains("True"))
            {
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("swal(\"Hecho!\", \"Sincronización exitosa\", \"success\");");
                sb.Append(@"</script>");
            }
            else {
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("swal(\"Error!\", \"Problema al sincronizar!"+respuesta+"\", \"error\");");
                sb.Append(@"</script>");
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SincScript", sb.ToString(), false);

        }

    }

    protected string returnResponseValue(string url)
    {
        string json2 = string.Empty;
        
            HttpWebRequest peticion = (HttpWebRequest)WebRequest.Create(url);
            //peticion.KeepAlive= false;
            //peticion = WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)peticion.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            json2 = reader.ReadToEnd();
            reader.Close();
            stream.Close();
            response.Close();
        
        //peticion.Abort();
        return json2;
    }

    protected void BtnSave_Click(object sender, EventArgs e)

    {

        int id = Convert.ToInt32(lblID.Text);
        int  cliente= Convert.ToInt32( Clientes.Text);
        string sitio = txtSitio.Text;
        string descripcion = textDescripcion.Text;
        string estado = txtEstado.Text;
        string ciudad = txtCiudad.Text;
        int CP = Convert.ToInt32(txtCP.Text);
        string CalleNumero = txtCalleNumero.Text;
        string Colonia = txtColonia.Text;
        double telefono = Convert.ToInt64(txtTelefono.Text);
        string Mail = txtMail.Text;
        string Estatus = Dstatus.Text;
        string noip = txtNOIP.Text;
        string noips = txtNOIPS.Text;
        int noipMulti = Convert.ToInt32(MultipleNOIP3.Text);
        ExecuteUpdate(id, cliente, sitio,descripcion, estado,ciudad, CP, CalleNumero, Colonia, telefono, Mail, Estatus,noip,noips,noipMulti);

        BindGrid2();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    }



    private void ExecuteUpdate(int id, int cliente, string sitio ,string descripcion, string estado,string ciudad, int CP, string CalleNumero, string Colonia, double telefono, string Mail, string Estatus, string noip, string noips, int multiple)

    {


        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);

        con.Open();

        string updateCmd = "UPDATE Sitios SET ID_cliente=@cliente, C_sitio=@sitio, descripcion=@descripcion, estado=@estado, ciudad=@ciudad, CP=@CP,CalleNumero=@CalleNumero,Colonia=@Colonia,telefono=@telefono, Mail=@Mail, Estatus=@Estatus, NOIP=@NOIP, NOIPS=@NOIPS, MultipleNOIP = @multiple WHERE ID=" + id + "";

        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@cliente", cliente);
        updatecmd.Parameters.AddWithValue("@sitio", sitio);
        updatecmd.Parameters.AddWithValue("@descripcion", descripcion);
        updatecmd.Parameters.AddWithValue("@estado", estado);
        updatecmd.Parameters.AddWithValue("@ciudad", ciudad);
        updatecmd.Parameters.AddWithValue("@CP", CP);
        updatecmd.Parameters.AddWithValue("@CalleNumero", CalleNumero);
        updatecmd.Parameters.AddWithValue("@Colonia", Colonia);
        updatecmd.Parameters.AddWithValue("@telefono", telefono);
        updatecmd.Parameters.AddWithValue("@Mail", Mail);
        updatecmd.Parameters.AddWithValue("@Estatus", Estatus);
        updatecmd.Parameters.AddWithValue("@noip", noip);
        updatecmd.Parameters.AddWithValue("@noips", noips);
        updatecmd.Parameters.AddWithValue("@multiple",multiple);
        updatecmd.ExecuteNonQuery();
        con.Close();


    }

     public void CargaClientes()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand consultaDisp = new SqlCommand("select RazonSocial,ID from Clientes", cn);
        SqlDataReader drs = consultaDisp.ExecuteReader();
        Clientes.DataSource = drs;
        Clientes.DataTextField = "RazonSocial";
        Clientes.DataValueField = "ID";
        Clientes.DataBind();

    }

    protected void BtnAddClick(object sender, EventArgs e)

    {

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
    }

    /*Metodo para insertar*/

    protected void BtnAddRecordClick(object sender, EventArgs e)

    {

        int cliente = Convert.ToInt32(Clientes2.Text);
        string sitio = txtSitio1.Text;
        string descripcion = textDescripcion1.Text;
        string estado = txtEstado1.Text;
        string ciudad = txtCiudad1.Text;
        int CP = Convert.ToInt32(txtCP1.Text);
        string CalleNumero = txtCalleNumero1.Text;
        string Colonia = txtColonia1.Text;
        double telefono = Convert.ToInt64(txtTelefono1.Text);
        string Mail = txtMail1.Text;
        string Estatus = Dstatus1.Text;
        string noip = txtNOIP1.Text;
        string noips = txtNOIP2.Text;
        int multiple = Convert.ToInt32(MultipleNOIP2.Text);
        ExecuteAdd(cliente, sitio, descripcion, estado, ciudad, CP, CalleNumero, Colonia, telefono, Mail, Estatus, noip, noips, multiple);

        BindGrid2();

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

    }

    private void ExecuteAdd(int cliente, string sitio,string descripcion, string estado,string ciudad, int CP, string CalleNumero, string Colonia, double telefono, string Mail, string Estatus, string noip, string noip2, int multiple)

    {

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);

        con.Open();

        string updatecmd = "insert into Sitios (ID_cliente, C_Sitio,Descripcion, Estado,Ciudad, CP,CalleNumero,Colonia,Telefono,Mail, Estatus,NOIP, NOIPS, MultipleNOIP ) values (@cliente,@sitio,@descripcion,@estado,@ciudad,@CP,@CalleNumero,@Colonia,@Telefono,@Mail,@Estatus,@noip,@noip2, @multiple)";

        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@cliente", cliente);
        addCmd.Parameters.AddWithValue("@sitio", sitio);
        addCmd.Parameters.AddWithValue("@descripcion", descripcion);
        addCmd.Parameters.AddWithValue("@estado", estado);
        addCmd.Parameters.AddWithValue("@ciudad", ciudad);
        addCmd.Parameters.AddWithValue("@CP", CP);
        addCmd.Parameters.AddWithValue("@CalleNumero", CalleNumero);
        addCmd.Parameters.AddWithValue("@Colonia", Colonia);
        addCmd.Parameters.AddWithValue("@telefono", telefono);
        addCmd.Parameters.AddWithValue("@Mail", Mail);
        addCmd.Parameters.AddWithValue("@Estatus", Estatus);
        addCmd.Parameters.AddWithValue("@noip", noip);
        addCmd.Parameters.AddWithValue("@noip2", noip2);
        addCmd.Parameters.AddWithValue("@multiple",multiple);
        addCmd.ExecuteNonQuery();
        con.Close();

    }

    public void CargaClientes2()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand consultaDisp = new SqlCommand("select RazonSocial,ID from Clientes", cn);
        SqlDataReader drs = consultaDisp.ExecuteReader();
        Clientes2.DataSource = drs;
        Clientes2.DataTextField = "RazonSocial";
        Clientes2.DataValueField = "ID";
        Clientes2.DataBind();

    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

    {

        GridView1.PageIndex = e.NewPageIndex;

        this.BindGrid2();

    }



    public void BindGrid2()


    {
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "SELECT * FROM Sitios  ";
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {



                    sql += "Where ( ID_cliente LIKE '%' + @Busqueda + '%' OR C_Sitio LIKE '%' + @Busqueda + '%' OR Estado LIKE '%' + @Busqueda + '%')";
                    cmd.Parameters.AddWithValue("@Busqueda", txtSearch.Text.Trim());
                }
                cmd.CommandText = sql;
                cmd.Connection = con;

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }

    protected void Search(object sender, EventArgs e)
    {

    }
}
