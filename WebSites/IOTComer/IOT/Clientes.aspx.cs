using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clientes : System.Web.UI.Page
{
    DataTable dt;
   static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);
        conn.Open();
        string usuario = User.Identity.Name;
        Permisos permiso = new Permisos();
        int pantalla = 14;
        if (permiso.returnPermiso(usuario, 0) == "RISC") {
            if(!IsPostBack)
            {
            client();
            }else if (permiso.returnPermiso(usuario, pantalla) == "Clientes")
            {

            }

            BindGrid2();
            
        }
        else
            Response.Redirect("~/IOT/Home");
    }

    public void BindGrid2()


    {
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "SELECT * FROM Clientes  ";
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {



                    sql += "Where ( RazonSocial LIKE '%' + @Busqueda + '%' OR Estado LIKE '%' + @Busqueda + '%' OR Contacto LIKE '%' + @Busqueda + '%')";
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

    public void BindGrid()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("Select C.ID, C.RazonSocial, C.Pais, C.Estado, C.CP, C.CalleNumero, C.Colonia, C.Contacto, C.Telefono, C.Mail, C.Estatus FROM Clientes C where ID != 3020", conn);
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

            IEnumerable<DataRow> query = from Clientes in dt.AsEnumerable()

                                         where Clientes.Field<String>("ID").Equals(id)

                                         select Clientes;

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
            txtRazonSocial.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            txtPais.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
            txtEstado.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            txtCP.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
            txtCalleNumero.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
            txtColonia.Text = HttpUtility.HtmlDecode(gvrow.Cells[6].Text);
            txtContacto.Text = HttpUtility.HtmlDecode(gvrow.Cells[7].Text);
            txtTelefono.Text = HttpUtility.HtmlDecode(gvrow.Cells[8].Text);
            txtMail.Text = HttpUtility.HtmlDecode(gvrow.Cells[9].Text);
            Status2.Text = HttpUtility.HtmlDecode(gvrow.Cells[10].Text);
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);
        }
    }

    

    protected void BtnSave_Click(object sender, EventArgs e)

    {

        int id = Convert.ToInt32(lblID.Text);
        string RazonSocial = txtRazonSocial.Text;
        string Pais = txtPais.Text;
        string Estado = txtEstado.Text;
        int CP = Convert.ToInt32(txtCP.Text);
        string CalleNumero = txtCalleNumero.Text;
        string Colonia = txtColonia.Text;
        string Contacto = txtContacto.Text;
        string Telefono = txtTelefono.Text;
        string Mail = txtMail.Text;
        string Estatus = Status2.Text;
        DateTime Fecha = DateTime.Now;

        ExecuteUpdate(id, RazonSocial, Pais, Estado, CP, CalleNumero, Colonia, Contacto, Telefono, Mail, Estatus);

        BindGrid2();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    }



    private void ExecuteUpdate(int id, string RazonSocial, string Pais, string Estado, int CP, string CalleNumero, string Colonia, string Contacto, string Telefono, string Mail, string Estatus)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE Clientes SET RazonSocial=@RazonSocial, Pais=@Pais, Estado=@Estado, CP=@CP,CalleNumero=@CalleNumero,Colonia=@Colonia,Contacto=@Contacto,Telefono=@Telefono, Mail=@Mail, Estatus=@Estatus WHERE ID=" + id + "";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@RazonSocial", RazonSocial);
        updatecmd.Parameters.AddWithValue("@Pais", Pais);
        updatecmd.Parameters.AddWithValue("@Estado", Estado);
        updatecmd.Parameters.AddWithValue("@CP", CP);
        updatecmd.Parameters.AddWithValue("@CalleNumero", CalleNumero);
        updatecmd.Parameters.AddWithValue("@Colonia", Colonia);
        updatecmd.Parameters.AddWithValue("@Contacto", Contacto);
        updatecmd.Parameters.AddWithValue("@Telefono", Telefono);
        updatecmd.Parameters.AddWithValue("@Mail", Mail);
        updatecmd.Parameters.AddWithValue("@Estatus", Estatus);
        updatecmd.ExecuteNonQuery();
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
            string updatecmd = "delete from Clientes where ID=@id";
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
        string RazonSocial = txtRazonSocial1.Text;
        string Pais = txtPais1.Text;
        string Estado = txtEstado1.Text;
        int CP = Convert.ToInt32(txtCP1.Text);
        string CalleNumero = txtCalleNumero1.Text;
        string Colonia = txtColonia1.Text;
        string Contacto = txtContacto1.Text;
        string Telefono = txtTelefono1.Text;
        string Mail = txtMail1.Text;
        string Estatus = Status.Text;
        DateTime Fecha = DateTime.Now;
        ExecuteAdd(RazonSocial, Pais, Estado, CP, CalleNumero, Colonia, Contacto, Telefono, Mail, Estatus);

        BindGrid2();

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

    }

    private void ExecuteAdd(string RazonSocial, string Pais, string Estado, int CP, string CalleNumero, string Colonia, string Contacto, string Telefono, string Mail, string Estatus)

    {

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "insert into Clientes (RazonSocial, Pais, Estado, CP,CalleNumero,Colonia,Contacto,Telefono,Mail, Estatus ) values (@RazonSocial,@Pais,@Estado,@CP,@CalleNumero,@Colonia,@Contacto,@Telefono,@Mail,@Estatus)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@RazonSocial", RazonSocial);
        addCmd.Parameters.AddWithValue("@Pais", Pais);
        addCmd.Parameters.AddWithValue("@Estado", Estado);
        addCmd.Parameters.AddWithValue("@CP", CP);
        addCmd.Parameters.AddWithValue("@CalleNumero", CalleNumero);
        addCmd.Parameters.AddWithValue("@Colonia", Colonia);
        addCmd.Parameters.AddWithValue("@Contacto", Contacto);
        addCmd.Parameters.AddWithValue("@Telefono", Telefono);
        addCmd.Parameters.AddWithValue("@Mail", Mail);
        addCmd.Parameters.AddWithValue("@Estatus", Estatus);
        addCmd.ExecuteNonQuery();
        con.Close();
    }

    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid2();
    }



    protected void BtnIcono(object sender, EventArgs e)
    {
        int tamimg = fuploadimagen.PostedFile.ContentLength;
        if (tamimg==0)
        {          
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Seleccione un icono');");
            sb.Append("$('#addModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
        }
        else
        {
            //datos de la imagen
            string cliente = Cli.SelectedValue;
            byte[] imagenOriginal = new byte[tamimg];
            fuploadimagen.PostedFile.InputStream.Read(imagenOriginal, 0, tamimg);
            Bitmap imgoriginalbinaria = new Bitmap(fuploadimagen.PostedFile.InputStream);
            //recuperar valores para subirlos la alta en base de datos
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Clientes SET icono=@icono where ID = @ID", con);
            cmd.Parameters.AddWithValue("@icono", SqlDbType.Image).Value = imagenOriginal;
            cmd.Parameters.AddWithValue("@ID", cliente);
            cmd.Parameters.Add("@RazonSocial", SqlDbType.Int).Value = Cli.SelectedValue;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            string imgDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(imagenOriginal);
            imgPreview.ImageUrl = imgDataURL64;

        }

    }
    protected void client()
    {
        Cli.DataSource = Consultar("SELECT * FROM CLIENTES ");
        Cli.DataValueField = "ID";
        Cli.DataTextField = "RazonSocial";
        Cli.DataBind();
        Cli.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
       
    }

    protected DataSet Consultar(string consulta)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand(consulta, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }


    
}
