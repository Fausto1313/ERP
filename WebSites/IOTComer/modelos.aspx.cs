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

public partial class modelos : System.Web.UI.Page
{
    DataTable dt;
    private SqlConnection conn = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=multicliente;User ID=sa;Password=sa+LANSA!;Pooling=False");
    public string docu = null;
    protected void Page_Load(object sender, EventArgs e)
    {

        BindGrid();
        if (!IsPostBack)
        {
            cargaFabricantes();
            cargaFabricantes2();
        }

    }

    public void BindGrid()
    {

        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT M.Modelo, M.Documento, M.Descripcion, F.Fabricante FROM multicliente.dbo.Modelos M, multicliente.dbo.Fabricantes F WHERE F.ID=ID_Fabricante", conn);
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




    /*Metodo que contiene la vista, actualizacion y o eliminacion de una fila segun sea el evento, atraves de un modal.*/
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
        else if (e.CommandName.Equals("updRecord"))
        {


            GridViewRow gvrow = GridView1.Rows[index];

            lblModelo.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtDescripcion.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            txtDocumento.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
            //txtRazonSocial.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
            //TextFabricante.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }

        else if (e.CommandName.Equals("deleteRecord"))
        {
            string modelo = GridView1.DataKeys[index].Value.ToString();
            hfidEvento.Value = modelo;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#deleteModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }


    }
    /*Recoge el id donde se da click en el evento actualizar lo guarda y envia*/
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string modelo = lblModelo.Text;
        string descripcion = txtDescripcion.Text;
        string documento = txtDocumento.Text;
        int nombre = Convert.ToInt32(Fabricantes.Text);
        ExecuteUpdate(modelo, descripcion, documento, nombre);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#editModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    }
    /*Ejecuta el evento de actualizado a la base de datos*/
    private void ExecuteUpdate(string modelo, string descripcion, string documento, int nombre)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE Modelos SET  Documento=@documento,  Descripcion=@descripcion, ID_Fabricante=@nombre WHERE Modelo=@modelo";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@modelo", modelo);
        updatecmd.Parameters.AddWithValue("@documento", documento);
        updatecmd.Parameters.AddWithValue("@descripcion", descripcion);
        updatecmd.Parameters.AddWithValue("@nombre", nombre);
        updatecmd.ExecuteNonQuery();
        con.Close();

    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string modelo = hfidEvento.Value;
        ExecuteDelete(modelo);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registo Eliminado');");
        sb.Append("$('#deleteModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);


    }
    private void ExecuteDelete(string modelo)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updatecmd = "delete from Modelos where Modelo=@modelo";
            SqlCommand addCmd = new SqlCommand(updatecmd, con);
            addCmd.Parameters.AddWithValue("@modelo", modelo);
            addCmd.ExecuteNonQuery();
            con.Close();

        }
        catch (SqlException e)
        {
            Console.WriteLine("Excepcion Ocurrida: ", e);
        }
    }

    /*Metodo para agregar nuevo dispositivo*/
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
        string documento = cargaDocumentos();
        //documento = HttpUtility.HtmlDecode(flimage);
        string modelo = txtModelo1.Text;
        string descripcion = txtDescripcion1.Text;
        int nombre = Convert.ToInt32(Fabricantes2.Text);
        //Response.Write("<script language=\"javascript\">alert(\"" + documentooo + "\");</script>");
        ExecuteAdd(modelo, descripcion, documento, nombre);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
    }
    private void ExecuteAdd(string modelo, string descripcion, string documento, int nombre)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "insert into Modelos (Modelo, Documento, Descripcion, ID_Fabricante) values (@modelo,@documento,@descripcion,@nombre)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@modelo", modelo);
        addCmd.Parameters.AddWithValue("@documento", documento);
        addCmd.Parameters.AddWithValue("@descripcion", descripcion);
        addCmd.Parameters.AddWithValue("@nombre", nombre);
        addCmd.ExecuteNonQuery();
        con.Close();

    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    public void cargaFabricantes2()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID, Fabricante FROM Fabricantes", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        Fabricantes2.DataSource = dr;
        Fabricantes2.DataTextField = "Fabricante";
        Fabricantes2.DataValueField = "ID";
        Fabricantes2.DataBind();
    }

    public void cargaFabricantes()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID, Fabricante FROM Fabricantes", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        Fabricantes.DataSource = dr;
        Fabricantes.DataTextField = "Fabricante";
        Fabricantes.DataValueField = "ID";
        Fabricantes.DataBind();
    }

    protected string cargaDocumentos() {
        string fn = null;
        const string fic = @"C:\Users\Administrador\Desktop\Prueba.txt";
        System.IO.StreamWriter sw = new System.IO.StreamWriter(fic);
        sw.WriteLine("Entrando a la funcion");
        if ((flimage.PostedFile != null) && (flimage.PostedFile.ContentLength > 0)) //nos aseguramos que el usuario haya cargado un archivo
        {
            sw.WriteLine("1");
            if (flimage.Value.EndsWith(".PDF") || flimage.Value.EndsWith(".pdf")) //revisamos el tipo de archivo que nos interese, en este caso solo dejamos imagenes
            {
                sw.WriteLine("2");
                if (flimage.PostedFile.ContentLength <= 50000000) //tambien podemos revisar el tamaño, en este ejemplo 500Kb

                {
                    sw.WriteLine("Listo");
                    fn = System.IO.Path.GetFileName(flimage.PostedFile.FileName);
                    string SaveLocation = Server.MapPath(@"~\Data") + "\\" + fn;
                    docu = fn;
                    try
                    {
                        flimage.PostedFile.SaveAs(SaveLocation);
                        //this.lblmessage.Text = "El archivo se ha cargado.";
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }
            }
            //this.BtnAddRecord.Click += new EventHandler(this.BtnAddRecordClick);
        }
        sw.Close();
        return fn;
        
    }

}
