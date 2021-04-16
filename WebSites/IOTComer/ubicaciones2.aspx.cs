using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ubicaciones2 : System.Web.UI.Page
{
    DataTable dt;
    private SqlConnection conn = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=IOT;User ID=sa;Password=sa+LANSA!;Pooling=False");

    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();

    }


    public void BindGrid()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select * from Ubicaciones", conn);
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
            IEnumerable<DataRow> query = from UBICACIONES in dt.AsEnumerable()
                                         where UBICACIONES.Field<String>("ID_Seccion").Equals(lblID_Seccion)
                                         select UBICACIONES;
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

            lblID_Seccion.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtDescripcion.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            txtPais.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
            txtEdificio.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            txtNivel.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
            txtNDIP.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
            txtRazonSocial.Text = HttpUtility.HtmlDecode(gvrow.Cells[6].Text);
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }

        else if (e.CommandName.Equals("deleteRecord"))
        {
            string id_seccion = GridView1.DataKeys[index].Value.ToString();
            hfidEvento.Value = id_seccion;
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
        int id_seccion = Convert.ToInt32(lblID_Seccion.Text);
        string descripcion = txtDescripcion.Text;
        string pais = txtPais.Text;
        string edificio = txtEdificio.Text;
        string nivel = txtNivel.Text;
        string ndip = txtNDIP.Text;
        int razonsocial = Convert.ToInt32(txtRazonSocial.Text);
        ExecuteUpdate(id_seccion, descripcion, pais, edificio, nivel, ndip, razonsocial);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Actualizado');");
        sb.Append("$('#editModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    }
    /*Ejecuta el evento de actualizado a la base de datos*/
    private void ExecuteUpdate(int id_seccion, string descripcion, string pais, string edificio, string nivel, string ndip, int razonsocial)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE UBICACIONES SET Descripcion=@descripcion, Pais=@pais, Edificio=@edificio, Nivel=@nivel, NDIP=@no_ip ,ID_Cliente=@razonsocial WHERE ID_Seccion=" + id_seccion + "";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@descripcion", descripcion);
        updatecmd.Parameters.AddWithValue("@pais", pais);
        updatecmd.Parameters.AddWithValue("@edificio", edificio);
        updatecmd.Parameters.AddWithValue("@nivel", nivel);
        updatecmd.Parameters.AddWithValue("@no_ip", ndip);
        updatecmd.Parameters.AddWithValue("@razonsocial", razonsocial);
        updatecmd.ExecuteNonQuery();
        con.Close();

    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string id_seccion = hfidEvento.Value;
        ExecuteDelete(id_seccion);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registo Eliminado');");
        sb.Append("$('#deleteModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);


    }
    private void ExecuteDelete(string id_seccion)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updatecmd = "delete from UBICACIONES where ID_Seccion=@id_seccion";
            SqlCommand addCmd = new SqlCommand(updatecmd, con);
            addCmd.Parameters.AddWithValue("@id_seccion", id_seccion);
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

        string descripcion = txtDescripcion1.Text;
        string pais = txtPais1.Text;
        string edificio = txtTipo1.Text;
        string nivel = txtNivel1.Text;
        string no_ip = txtNDIP1.Text;
        int razonsocial = Convert.ToInt32(txtRazonSocial1.Text);
        ExecuteAdd(descripcion, pais, edificio, nivel, no_ip, razonsocial);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);


    }
    private void ExecuteAdd(string descripcion, string pais, string edificio, string nivel, string no_ip, int razonsocial)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "insert into UBICACIONES (Descripcion, Pais, Edificio, Nivel, NO_IP, ID_Cliente) values (@descripcion,@pais,@edificio,@nivel,@no_ip,@razonsocial)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);

        addCmd.Parameters.AddWithValue("@descripcion", descripcion);
        addCmd.Parameters.AddWithValue("@pais", pais);
        addCmd.Parameters.AddWithValue("@edificio", edificio);
        addCmd.Parameters.AddWithValue("@nivel", nivel);
        addCmd.Parameters.AddWithValue("@no_ip", no_ip);
        addCmd.Parameters.AddWithValue("@razonsocial", razonsocial);
        addCmd.ExecuteNonQuery();
        con.Close();

    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
}