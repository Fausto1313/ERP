using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class modelos : System.Web.UI.Page

{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 21;
        Permisos permiso = new Permisos();

        if (permiso.returnPermiso(usuario, 0) == "RISC")
        {
           if(!IsPostBack){
                cargaFabricantes();
                cargaFabricantes2();
                CargarModelos();
           }
           BindGrid2();

        }
        else if (permiso.returnPermiso(usuario, pantalla) == "Modelos")
        {

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
                string sql = "SELECT M.Modelo, M.Documento, M.Descripcion, F.Fabricante from  Modelos M, Fabricantes F ";
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {                                       
                    sql += "Where ( M.Modelo LIKE '%' + @Busqueda + '%' OR M.Documento LIKE '%' + @Busqueda + '%' OR M.Descripcion LIKE '%' + @Busqueda + '%' OR F.Fabricante LIKE '%' + @Busqueda + '%' AND F.ID=ID_Fabricante)";
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
        this.BindGrid2();
    }   
    public void BindGrid()
    {

        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT M.Modelo, M.Documento, M.Descripcion, F.Fabricante from  Modelos M, Fabricantes F WHERE F.ID=ID_Fabricante", conn);
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

        /*else if (e.CommandName.Equals("deleteRecord"))
        {
            string modelo = GridView1.DataKeys[index].Value.ToString();
            hfidEvento.Value = modelo;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#deleteModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }*/
        else if (e.CommandName.Equals("descargar"))
        {
            string modelo = GridView1.DataKeys[index].Value.ToString();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            Descargar_Click(modelo);
            BindGrid();

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
        sb.Append("$('#updModal').modal('hide');");
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
        string modelo = txtModelo1.Text;
        string descripcion = txtDescripcion1.Text;
        string documento = "Sin asignar";
        int nombre = Convert.ToInt32(Fabricantes2.Text);
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
        addCmd.Parameters.AddWithValue("@descripcion", descripcion);
        addCmd.Parameters.AddWithValue("@documento", documento);
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

    protected void Btnenviar_Click(object sender, EventArgs e)
    {
        if (!FlpArchivo.HasFile)
        {
            lblinformacion.Text = "Seleccione un archivo a subir";
        }
        else
        {
            FlpArchivo.SaveAs("C:/DataIOT/" + FlpArchivo.FileName);
            lblinformacion.Text = "El archivo " + FlpArchivo.FileName + " ha sido subido correctamente";
            string nombre = FlpArchivo.FileName;
            string modelo = Modelo.Text;
            ExecuteDoc(nombre, modelo);
            BindGrid();
        }
    }
    private void ExecuteDoc(string nombre, string modelo)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "UPDATE Modelos SET  Documento = @nombre WHERE Modelo = @modelo";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@modelo", modelo);
        addCmd.Parameters.AddWithValue("@nombre", nombre);
        addCmd.ExecuteNonQuery();
        con.Close();

    }

    public void CargarModelos()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT Modelo FROM Modelos", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        Modelo.DataSource = dr;
        Modelo.DataTextField = "Modelo";
        Modelo.DataValueField = "Modelo";
        Modelo.DataBind();
    }
    protected void Descargar_Click(string modelo)
    {
        SqlConnection cn = new SqlConnection(conString);
        cn.Open();

        string documento = null;
        SqlCommand cmd = new SqlCommand("SELECT Documento FROM Modelos where Modelo='" + modelo + "'", cn);


        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            documento = Convert.ToString(dr[0]);
        }
        cn.Close();
        Response.Redirect("~/IOT/descarga?v1=" + documento + "");
    }

}