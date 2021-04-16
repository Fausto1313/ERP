using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Eventos2 : System.Web.UI.Page
{
    DataTable dt;
    private SqlConnection conn = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=multicliente;User ID=sa;Password=sa+LANSA!;Pooling=False");
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
    }


    public void BindGrid()
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from Eventos", conn);

            //SqlCommand cmd = new SqlCommand("SELECT E.Evento, E.Comando, E.Descripcion, R.AutorizacionEvento, E.Tipo_DAR FROM Eventos E, Dars D, Roles R WHERE E.NivelAutorizacion=R.AutorizacionEvento AND E.Tipo_DAR=D.Tipo", conn);
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

        catch (SqlException e)
        {
            Console.WriteLine("Excepcion Ocurrida: ", e);
        }

    }
    /*Metodo que contiene la vista, actualizacion y o eliminacion de una fila segun sea el evento, atraves de un modal.*/
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("detail"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            IEnumerable<DataRow> query = from Eventos in dt.AsEnumerable()
                                         where Eventos.Field<String>("ID").Equals(id)
                                         select Eventos;
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
            txtEvento.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            txtComando.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
            txtDescripcion.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            txtTipoDAR.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);


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
            hfID.Value = id;
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
        int id = Convert.ToInt32(lblID.Text);
        string Evento = txtEvento.Text;
        string Comando = txtComando.Text;
        string Descripcion = txtDescripcion.Text;
        string Tipo_DAR = txtTipoDAR.Text;

        ExecuteUpdate(id, Evento, Comando, Descripcion, Tipo_DAR);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#editModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    }
    /*Ejecuta el evento de actualizado a la base de datos*/
    private void ExecuteUpdate(int id, string Evento, string Comando, string Descripcion, string Tipos_DAR)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE Eventos SET Evento=@Evento, Comando=@Comando, Descripcion=@descripcion, Tipo_DAR=@TipoDAR WHERE ID=" + id + "";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@Evento", Evento);
        updatecmd.Parameters.AddWithValue("@Comando", Comando);
        updatecmd.Parameters.AddWithValue("@descripcion", Descripcion);
        updatecmd.Parameters.AddWithValue("@TipoDAR", Tipos_DAR);

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
            string updatecmd = "delete from Eventos where ID=@id";
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

        string Evento = txtEvento1.Text;
        string Comando = txtComando1.Text;
        string Descripcion = txtDescripcion1.Text;
        string Tipo_DAR = txtTipoDAR1.Text;
        DateTime Fecha = DateTime.Now;
        ExecuteAdd(Evento, Comando, Descripcion, Tipo_DAR);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);


    }
    private void ExecuteAdd(string Evento, string Comando, string Descripcion, string Tipo_DAR)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "insert into Eventos ( Evento, Comando, Descripcion,Tipo_DAR) values (@Evento,@Comando,@Descripcion,@TipoDAR)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);


        addCmd.Parameters.AddWithValue("@Evento", Evento);
        addCmd.Parameters.AddWithValue("@Comando", Comando);
        addCmd.Parameters.AddWithValue("@Descripcion", Descripcion);
        addCmd.Parameters.AddWithValue("@TipoDAR", Tipo_DAR);
        addCmd.ExecuteNonQuery();
        con.Close();

    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
}
