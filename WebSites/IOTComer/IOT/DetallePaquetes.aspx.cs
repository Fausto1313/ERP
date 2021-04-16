using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_DetallePaquetes : System.Web.UI.Page
{
    DataTable dt;
    string ide = string.Empty;
    string global1 = string.Empty;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection con = new SqlConnection(conString);
    private SqlConnection con2 = new SqlConnection(conString);
    private SqlConnection con3 = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        ide = Request.QueryString["id"];
        BindGrid(ide);
        if (!IsPostBack) {
            cargaCategorias();
            cargaExtras();
        }
            
    }
    protected void BindGrid(string id)
    {
        DataSet ds = new DataSet();
        if (id != null)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select ID, Nombre, Precio from Paquete where ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                PaqueteInfo.DataSource = ds;
                PaqueteInfo.DataBind();
                BindGrid2(id);
                BindGrid3(id);
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                PaqueteInfo.DataSource = ds;
                PaqueteInfo.DataBind();
                int columncount = PaqueteInfo.Rows[0].Cells.Count;
                PaqueteInfo.Rows[0].Cells.Clear();
                PaqueteInfo.Rows[0].Cells.Add(new TableCell());
                PaqueteInfo.Rows[0].Cells[0].ColumnSpan = columncount;
                PaqueteInfo.Rows[0].Cells[0].Text = "No se encontraron Registros";
            }
        }

    }
    protected void BindGrid2(string id)
    {
        DataSet ds = new DataSet();
        con2.Open();
        SqlCommand cmd = new SqlCommand("select pp.ID, p.Nombre, p.Tamaño from ProductoPaquete pp inner join Producto p " +
            "on p.ID = pp.ID_Producto where pp.ID_Paquete = @id ", con2);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con2.Close();
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
    protected void BindGrid3(string id)
    {
        DataSet ds = new DataSet();
        con2.Open();
        SqlCommand cmd = new SqlCommand("select ep.ID, e.Nombre, e.Precio from ExtraPaquete ep inner join Extra e " +
            "on e.ID = ep.ID_Extra where ep.ID_Paquete = @id", con2);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con2.Close();
        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            Extras.DataSource = ds;
            Extras.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            Extras.DataSource = ds;
            Extras.DataBind();
            int columncount = Extras.Rows[0].Cells.Count;
            Extras.Rows[0].Cells.Clear();
            Extras.Rows[0].Cells.Add(new TableCell());
            Extras.Rows[0].Cells[0].ColumnSpan = columncount;
            Extras.Rows[0].Cells[0].Text = "No se encontraron Registros";
        }
    }
    protected void PaquetesDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        PaquetesDetalle.PageIndex = e.NewPageIndex;
        this.BindGrid2(ide);
    }
    protected void Extras_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Extras.PageIndex = e.NewPageIndex;
        this.BindGrid3(ide);
    }
    protected void PaquetesDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("delRecord"))
        {
            GridViewRow gvrow = PaquetesDetalle.Rows[index];
            Producto_Borrar.Value = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModalProducto').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
    }
    protected void Extras_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("delRecord"))
        {
            GridViewRow gvrow = Extras.Rows[index];
            IDExtra.Value = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModalExtras').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
    }

    //--------------------------------------------Productos-------------------------------------------------------------
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModalProducto').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "AddShowModalScript", sb.ToString(), false);
    }
    protected void BtnAddRecord_Click(object sender, EventArgs e)
    {
        DBIOT db = new DBIOT();
        SqlCommand cmd = new SqlCommand("insert into ProductoPaquete (ID_Paquete, ID_Producto) values(@paq, @prod)");
        cmd.Parameters.AddWithValue("@paq", ide);
        cmd.Parameters.AddWithValue("@prod", Convert.ToInt32(Producto.SelectedValue));
        db.insert(cmd);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        sb.Append("swal(\"Guardado!\", \"Producto agregado correctamente.\", \"success\");");
        sb.Append(@"</script>");
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModalProducto').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
        BindGrid2(ide);
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        con.Open();
        int Rol = Convert.ToInt32(Producto_Borrar.Value);
        try
        {
            SqlCommand cmd = new SqlCommand("delete ProductoPaquete where ID=@id", con);
            cmd.Parameters.AddWithValue("@id", Rol);
            cmd.ExecuteNonQuery();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
            sb.Append("<script type='text/javascript'>");
            sb.Append("swal(\"Guardado!\", \"Registro agregado correctamente.\", \"success\");");
            sb.Append(@"</script>");
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModalProducto').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteHideModalScript", sb.ToString(), false);
            BindGrid2(ide);
        }
        catch { }
        con.Close();
    }

    //-------------------------------------------Extras-----------------------------------------------------------------
    protected void ExtraBoton_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModalExtras').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "AddShowModalScript", sb.ToString(), false);
    }
    protected void AddExtras_Click(object sender, EventArgs e)
    {
        DBIOT db = new DBIOT();
        SqlCommand cmd = new SqlCommand("insert into ExtraPaquete (ID_Paquete, ID_Extra) values(@paq, @prod)");
        cmd.Parameters.AddWithValue("@paq", ide);
        cmd.Parameters.AddWithValue("@prod", Convert.ToInt32(ExtraList.SelectedValue));
        db.insert(cmd);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        sb.Append("swal(\"Guardado!\", \"Extra agregado correctamente.\", \"success\");");
        sb.Append(@"</script>");
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModalExtras').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModal21Script", sb.ToString(), false);
        BindGrid3(ide);
    }
    protected void EliminarExtra_Click(object sender, EventArgs e)
    {   
        con.Open();
        int Rol = Convert.ToInt32(IDExtra.Value);
        try
        {
            SqlCommand cmd = new SqlCommand("delete ExtraPaquete where ID=@id", con);
            cmd.Parameters.AddWithValue("@id", Rol);
            cmd.ExecuteNonQuery();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
            sb.Append("<script type='text/javascript'>");
            sb.Append("swal(\"Eliminado!\", \"Extra eliminado correctamente.\", \"success\");");
            sb.Append(@"</script>");
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModalExtras').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteHideModal2Script", sb.ToString(), false);
            BindGrid3(ide);
        }
        catch { }
        con.Close();
    }

    //--------------------------------------------Llenado de DropDownLists----------------------------------------------
    protected void cargaCategorias()
    {
        DBIOT db = new DBIOT();
        string usuario = Context.User.Identity.Name;
        SqlCommand cmd = new SqlCommand("select ID, NombreCategoria from Categoria where Sitio = (select C_Sitio from AspNetUsers where " +
            "UserName = @usuario)");
        cmd.Parameters.AddWithValue("@usuario", usuario);
        Cat.DataSource = db.Consultar(cmd);
        Cat.DataValueField = "ID";
        Cat.DataTextField = "NombreCategoria";
        Cat.DataBind();
        Sub.Items.Clear();
        Cat.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Sub.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Producto.Items.Clear();
        Producto.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }
    protected void cargaExtras() {
        DBIOT db = new DBIOT();
        string usuario = Context.User.Identity.Name;
        SqlCommand cmd = new SqlCommand("select ID, Nombre from Extra where ID_Sitio = (select C_Sitio from AspNetUsers where" +
            " UserName = @usuario)");
        cmd.Parameters.AddWithValue("@usuario", usuario);
        ExtraList.DataSource = db.Consultar(cmd);
        ExtraList.DataValueField = "ID";
        ExtraList.DataTextField = "Nombre";
        ExtraList.DataBind();
        ExtraList.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }
    protected void Cat_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = 0;
        DBIOT db = new DBIOT();
        global1 = Cat.SelectedValue;
        i = Convert.ToInt32(Cat.SelectedValue);
        SqlCommand cmd = new SqlCommand("select ID, NombreSub from SubCategoria where ID_Categoria= @categoria");
        cmd.Parameters.AddWithValue("@categoria", i);
        Sub.DataSource = db.Consultar(cmd);
        Sub.DataValueField = "ID";
        Sub.DataTextField = "NombreSub";
        Sub.DataBind();
        Sub.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Producto.Items.Clear();
        Producto.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }
    protected void Sub_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = 0;
        DBIOT db = new DBIOT();
        i = Convert.ToInt32(Sub.SelectedValue);
        SqlCommand cmd = new SqlCommand("select ID, Nombre from Producto where ID_Sub=@id and Tamaño = 'Unico' union  " +
            "select ID, CONCAT(Nombre, ' ', Tamaño) as Nombre from Producto where ID_Sub = @id and Tamaño != 'Unico'");
        cmd.Parameters.AddWithValue("@id", i);
        Producto.DataSource = db.Consultar(cmd);
        Producto.DataValueField = "ID";
        Producto.DataTextField = "Nombre";
        Producto.DataBind();
        Producto.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }
    protected void ExtraList_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("select Precio from Extra where ID = @id");
        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(ExtraList.SelectedValue));
        DBIOT db = new DBIOT();
        PrecioExtra.Text = db.consultaUnDato(cmd);
    }
}