using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_AdministracionPaquetes : System.Web.UI.Page
{

    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void PaquetesDetalle_PageIndexChanged(object sender, GridViewPageEventArgs e)
    {
        PaquetesDetalle.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void PaquetesDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("AddProducto"))
        {
            string id = PaquetesDetalle.DataKeys[index].Value.ToString();
            Response.Redirect("~/IOT/DetallePaquetes?ID=" + id);

        }
        //else if (e.CommandName.Equals("detail"))
        //{
        //    string ID = PaquetesDetalle.DataKeys[index].Value.ToString();
        //    IEnumerable<DataRow> query = from paquete in dt.AsEnumerable()
        //                                 where paquete.Field<String>("ID").Equals(ID)
        //                                 select paquete;
        //    DataTable GridView1Table = query.CopyToDataTable<DataRow>();
        //    PaquetesDetalle.DataSource = GridView1Table;
        //    PaquetesDetalle.DataBind();
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    sb.Append(@"<script type= 'text/javascript'>");
        //    sb.Append("$('detailmodal').modal('show');");
        //    sb.Append(@"</script>");
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DetailmodalScript", sb.ToString(), false);
        //}
        else if (e.CommandName.Equals("updRecord"))
        {
            string auxiliar = string.Empty;
            GridViewRow gvrow = PaquetesDetalle.Rows[index];
            lblID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtNomb.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString();
            auxiliar = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
            txtPrec.Text = auxiliar.Substring(1,auxiliar.Length-1);
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }
        else if (e.CommandName.Equals("delRecord"))
        {
            string ide = PaquetesDetalle.DataKeys[index].Value.ToString();
            hf.Value = ide;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
    }

    public void BindGrid()
    {
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmds = new SqlCommand("select ID, Nombre, Precio from Paquete where ID_Sitio = (select C_Sitio from AspNetUsers" +
            " where UserName= @user)", conn);
        cmds.Parameters.AddWithValue("@user", usuario);
        SqlDataAdapter da = new SqlDataAdapter(cmds);
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            PaquetesDetalle.DataSource = ds;
            PaquetesDetalle.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            PaquetesDetalle.DataSource = ds;
            PaquetesDetalle.DataBind();
            int columncount = PaquetesDetalle.Rows[0].Cells.Count;
            PaquetesDetalle.Rows[0].Cells.Clear();
            PaquetesDetalle.Rows[0].Cells.Add(new TableCell());
            PaquetesDetalle.Rows[0].Cells[0].ColumnSpan = columncount;
            PaquetesDetalle.Rows[0].Cells[0].Text = "No se encontraron Registros";
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
    protected void BtnAddRecordClick(object sender, EventArgs e)

    {

        string Nombre = txtNombres.Text;
        double Precios = Convert.ToDouble(txtPrecios.Text);


        ExecuteAdd(Nombre, Precios);

        BindGrid();

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

    }

    private void ExecuteAdd(string Nombre, double Precios)
    {

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        string usuario = User.Identity.Name;
        con.Open();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        string updatecmd = "insert into Paquete(Nombre, Precio, ID_Sitio) " +
            "values(@nombre, @precio,(select C_Sitio from AspNetUsers where UserName=@user))";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@nombre", Nombre);
        addCmd.Parameters.AddWithValue("@precio", Precios);
        addCmd.Parameters.AddWithValue("@user", usuario);
        addCmd.ExecuteNonQuery();
        sb.Append("$('#addModal').modal('hide');");
        sb.Append("swal(\"Guardado!\", \"Paquete agregada de forma correcta.\", \"success\");");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
        txtNombres.Text = "";
        txtPrecios.Text = "";
        con.Close();
    }


    //Actualizar

    protected void BtnSave_Click(object sender, EventArgs e)
    {

        string id = lblID.Text;
        string nom = txtNomb.Text;
        double prec = Convert.ToDouble(txtPrec.Text);

        ExecuteUpdate(id, nom, prec);
        BindGrid();
        }

    //Metodo de Actualizar
    private void ExecuteUpdate(string id, string nom, double prec)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        string updateCmd = "UPDATE Paquete SET Nombre=@nom,Precio=@precio WHERE ID=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@nom", nom);
        updatecmd.Parameters.AddWithValue("@precio", prec);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.ExecuteNonQuery();
        sb.Append("$('#updModal').modal('hide');");
        sb.Append("swal(\"Actualización!\", \"Paquete actualizado de forma correcta.\", \"success\");");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
        txtNomb.Text = "";
        txtPrec.Text = "";
        con.Close();

    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string ide = hf.Value;
        ExecuteDelete(ide);
        BindGrid();

    }
    private void ExecuteDelete(string ide)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
            sb.Append("<script type='text/javascript'>");
            string updatecmd = "delete from Paquete where ID = @id";
            SqlCommand addCmd = new SqlCommand(updatecmd, con);
            addCmd.Parameters.AddWithValue("@id", ide);
            addCmd.ExecuteNonQuery();
            sb.Append("$('#eliminaModal').modal('hide');");
            sb.Append("swal(\"Eliminado!\", \"Paquete eliminado de forma correcta.\", \"success\");");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
            con.Close();
        }
        catch (SqlException e)
        {
            Console.WriteLine("Excepcion Ocurrida: ", e);
        }
    }
}