using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_AdministracionExtras : System.Web.UI.Page
{
    DataTable dt;
    private SqlConnection conn = new SqlConnection("Data Source=DESKTOP-RLCKS57\\GERARD;Initial Catalog=IOT;User ID=sa;Password=gerard9310;Pooling=False");
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();

    }
    public void BindGrid()
    {
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select ID, Nombre, Precio from Extra where ID_Sitio = (select C_Sitio from AspNetUsers where UserName= @usuario)", conn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
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
            string IdEvento = GridView1.DataKeys[index].Value.ToString();
            IEnumerable<DataRow> query = from Extra in dt.AsEnumerable()
                                         where Extra.Field<String>("ID").Equals(ID)
                                         select Extra;
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
            txtNom.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString();
            txtPrec.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }
        else if (e.CommandName.Equals("delRecord"))
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


    //ScriptAgregar

    protected void BtnAddClick(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

    }
    //Metodo de Eliminar
    private void ExecuteDelete(string id)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
            sb.Append("<script type='text/javascript'>");
            string updatecmd = "delete from Extra where ID = @id";
            SqlCommand addCmd = new SqlCommand(updatecmd, con);
            addCmd.Parameters.AddWithValue("@id", id);
            addCmd.ExecuteNonQuery();
            sb.Append("$('#eliminaModal').modal('hide');");
            sb.Append("swal(\"Eliminado!\", \"Extra eliminado de forma correcta.\", \"success\");");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
            con.Close();
        }
        catch (SqlException e)
        {
            Console.WriteLine("Excepcion Ocurrida: ", e);
        }
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string id = hfID.Value;
        ExecuteDelete(id);
        BindGrid();
      
    }




    //ScriptActualizar
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        string id = lblID.Text;
        string nom = txtNom.Text;

        float prec = Convert.ToInt64(txtPrec.Text);

        ExecuteUpdate(id, nom, prec);
        BindGrid();


    }

 

    protected void BtnAddRecordClick(object sender, EventArgs e)

    {

        string Nombre = txtNombre.Text;
        float Precios = Convert.ToInt64(txtPrecios.Text);


        ExecuteAdd(Nombre, Precios);

        BindGrid();

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

    }
    //Metodo de agregar 
    private void ExecuteAdd(string Nombre, float Precios)
    {

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        string usuario = User.Identity.Name;
        con.Open();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        string updatecmd = "insert into Extra(Nombre, Precio, ID_Sitio) values(@nombre, @precio, " +
           "(select C_Sitio from AspNetUsers where UserName=@usuario))";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@nombre", Nombre);
        addCmd.Parameters.AddWithValue("@precio", Precios);
        addCmd.Parameters.AddWithValue("usuario", usuario);
        addCmd.ExecuteNonQuery();
        sb.Append("$('#addModal').modal('hide');");
        sb.Append("swal(\"Guardado!\", \"Extra agregada de forma correcta.\", \"success\");");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
        txtNombre.Text = "";
        txtPrecios.Text = "";
        con.Close();
    }

    //Metodo de Actualizar
    private void ExecuteUpdate(string id, string nom, float prec)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        string updateCmd = "UPDATE Extra SET Nombre=@nom,Precio=@precio WHERE ID=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@nom", nom);
        updatecmd.Parameters.AddWithValue("@precio", prec);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.ExecuteNonQuery();
        sb.Append("$('#updModal').modal('hide');");
        sb.Append("swal(\"Actualización!\", \"Extra actualizado de forma correcta.\", \"success\");");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
        txtNom.Text = "";
        txtPrec.Text = "";
        con.Close();

    }


    
    //protected void Guardar_Click(object sender, EventArgs e)
    //{
    //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //    sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
    //    sb.Append("<script type='text/javascript'>");
    //    SqlCommand cmd = new SqlCommand("insert into Extra(Nombre, Precio, ID_Sitio) values(@nombre, @precio, " +
    //        "(select C_Sitio from AspNetUsers where UserName=@usuario))");
    //    cmd.Parameters.AddWithValue("@nombre", txtCategoria.Text);
    //    cmd.Parameters.AddWithValue("@precio",Convert.ToInt64(txtPrecio.Text));
    //    cmd.Parameters.AddWithValue("@usuario", Context.User.Identity.Name);
    //    DBIOT db = new DBIOT();
    //    db.insert(cmd);
    //    sb.Append("swal(\"Guardado!\", \"Extra agregada de forma correcta.\", \"success\");");
    //    sb.Append(@"</script>");
    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
    //    txtCategoria.Text = "";
    //}

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //this.BindGrid();
    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

    {

        GridView1.PageIndex = e.NewPageIndex;

        //this.BindGrid();

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {



    }
}