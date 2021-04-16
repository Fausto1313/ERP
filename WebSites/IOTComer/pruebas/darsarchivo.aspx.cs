using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dars : System.Web.UI.Page
{
    DataTable dt;
    private SqlConnection conn = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=IOTComer;User ID=sa;Password=sa+LANSA!;Pooling=False");

    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();

        CargaModelo();
        //Response.Write("<script language=\"javascript\">alert(\"Página en proceso de produccion\");</script>");
        CargaModelo2();

    }

    public void BindGrid()
    {

        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT D.RISCEI, D.Descripcion, M.Modelo FROM IOTComer.dbo.DARS D, IOTComer.dbo.Clientes C, IOTComer.dbo.Modelos M WHERE  D.ID_Cliente=C.ID AND M.Modelo=D.Modelo", conn);
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

            txtRISCEI.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtDescripcion.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

            //txtRazonSocial.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
            //txtNombre.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }

        else if (e.CommandName.Equals("deleteRecord"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            hfRISCEI.Value = id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#deleteModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        } else if (e.CommandName.Equals("clienterecord"))
        {
            GridViewRow gvrow = GridView1.Rows[index];

            lblRisc1.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtcliente.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            lblResultt.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModalc').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }

    }
    /*Recoge el id donde se da click en el evento actualizar lo guarda y envia*/
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string id = txtRISCEI.Text;

        string descripcion = txtDescripcion.Text;
        int cliente = 3018;
        string modelo = Modelo.Text;
        ExecuteUpdate(id, descripcion, cliente, modelo);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Records Updated Successfully');");
        sb.Append("$('#editModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    }
    /*Ejecuta el evento de actualizado a la base de datos*/
    private void ExecuteUpdate(string id, string descripcion, int cliente, string modelo)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE DARS SET id=@id, descripcion=@descripcion, cliente=@Id_Cliente, Modelo=@Modelo WHERE RISCEI=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@descripcion", descripcion);
        updatecmd.Parameters.AddWithValue("@cliente", cliente);
        updatecmd.Parameters.AddWithValue("@Modelo", Modelo);
        updatecmd.ExecuteNonQuery();
        con.Close();

    }
    protected void BtnSave_ClickS(object sender, EventArgs e)
    {
        string id = lblRisc1.Text;
        int cliente = Convert.ToInt32(txtcliente.Text);
        ExecuteUpdateS(id, cliente);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Records Updated Successfully');");
        sb.Append("$('#editModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    }
    /*Ejecuta el evento de actualizado a la base de datos*/
    private void ExecuteUpdateS(string id, int cliente)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE DARS SET ID_Cliente=@cliente WHERE RISCEI=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@cliente", cliente);
        updatecmd.ExecuteNonQuery();
        con.Close();

    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string id = hfRISCEI.Value;
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
            string updatecmd = "delete from DARS where RISCEI=@id";
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

        string RISCEI = txtTipo1.Text;
        string descripcion = txtDescripcion1.Text;
        int cliente = 3018;
        string modelo = Modelo.Text;

        ExecuteAdd(RISCEI, descripcion, cliente, modelo);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);


    }
    private void ExecuteAdd(string RISCEI, string descripcion, int cliente, string modelo)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "insert into DARS (RISCEI, Descripcion, ID_Cliente, Modelo) values (@RISCEI,@descripcion,@Cliente,@Modelo)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);

        addCmd.Parameters.AddWithValue("@RISCEI", RISCEI);
        addCmd.Parameters.AddWithValue("@descripcion", descripcion);
        addCmd.Parameters.AddWithValue("@cliente", cliente);
        addCmd.Parameters.AddWithValue("@modelo", modelo);

        addCmd.ExecuteNonQuery();
        con.Close();

    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    public void CargaModelo()
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

    /* public void CargaClientes()
     {
         SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
         cn.Open();
         SqlCommand cmd = new SqlCommand("SELECT ID, RazonSocial FROM Clientes", cn);
         SqlDataReader dr = cmd.ExecuteReader();
         Clientes2.DataSource = dr;
         Cliente.DataSource = dr;
         Clientes2.DataTextField = "RazonSocial";
         Cliente.DataTextField = "RazonSocial";
         Clientes2.DataValueField = "ID";
         Cliente.DataValueField = "ID";
         Cliente.DataBind();
         Clientes2.DataBind();
     }

     public void cargaClientes2()
     {
         SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
         cn.Open();
         SqlCommand cmd = new SqlCommand("SELECT ID, RazonSocial FROM Clientes", cn);
         SqlDataReader dr = cmd.ExecuteReader();
         Clientes2.DataSource = dr;
         Cliente.DataSource = dr;
         Clientes2.DataTextField = "RazonSocial";
         Clientes2.DataValueField = "ID";
         Clientes2.DataBind();
     }*/

    public void CargaModelo2()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT  Modelo FROM Modelos", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        Modelo2.DataSource = dr;
        Modelo2.DataTextField = "Modelo";
        Modelo2.DataValueField = "Modelo";
        Modelo2.DataBind();
    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

    {

        GridView1.PageIndex = e.NewPageIndex;

        this.BindGrid();

    }
    protected void Cargar_Click(object sender, EventArgs e)
    {
        try
        {
            if (fileUploader1.HasFile)
            {
                // Se verifica que la extensión sea de un formato válido
                string ext = fileUploader1.PostedFile.FileName;
                ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower();
                string[] formatos =
                  new string[] { "pdf", "doc" };

            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }

}