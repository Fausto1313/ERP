using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class IOT_AdministracionProducto : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            cargaCategorias();
            cargaCategoria();
        }
           
       // BindGrid();
    }
    public void BindGrid()
    {
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmds = new SqlCommand("select p.ID, p.Nombre, p.Descripcion,p.Tamaño,p.Precio from Producto p WHERE ID_Sub=@sub ", conn);
        cmds.Parameters.AddWithValue("@sub", Subcategoria.SelectedValue);
        SqlDataAdapter da = new SqlDataAdapter(cmds);
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            PaqueteAdmin.DataSource = ds;
            PaqueteAdmin.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            PaqueteAdmin.DataSource = ds;
            PaqueteAdmin.DataBind();
            int columncount = PaqueteAdmin.Rows[0].Cells.Count;
            PaqueteAdmin.Rows[0].Cells.Clear();
            PaqueteAdmin.Rows[0].Cells.Add(new TableCell());
            PaqueteAdmin.Rows[0].Cells[0].ColumnSpan = columncount;
            PaqueteAdmin.Rows[0].Cells[0].Text = "No se encontraron Registros";
        }
    }

    protected void PaquetesAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);


       if (e.CommandName.Equals("updRecord"))
        {
            string auxiliar = string.Empty;
            GridViewRow gvrow = PaqueteAdmin.Rows[index];
            lblID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtNomb.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString();
            txtDes.Text= HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
            Tama.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            auxiliar = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
            txtPrec.Text = auxiliar.Substring(1, auxiliar.Length - 2);
           
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }
        else if (e.CommandName.Equals("delRecord"))
        {
            string ide = PaqueteAdmin.DataKeys[index].Value.ToString();
            hfdf.Value = ide;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
    }


    protected void Cat_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = 0;
        DBIOT db = new DBIOT();
        i = Convert.ToInt32(Cat.SelectedValue);
        SqlCommand cmd = new SqlCommand("select ID, NombreSub from SubCategoria where ID_Categoria= @categoria");
        cmd.Parameters.AddWithValue("@categoria",i);
        Sub.DataSource = db.Consultar(cmd);
        Sub.DataValueField = "ID";
        Sub.DataTextField = "NombreSub";
        Sub.DataBind();
        Sub.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }
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
        Cat.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Sub.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
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
        int cate = 0, subca = 0;
        string Nombre = txtNombr.Text;
        //string Categoria = Cat.Text;
        //string subcategoria = Sub.Text;
        string tama = Tamaño.SelectedValue;
        string desc = txtDesc.Text;
        string fijo = Multiple.SelectedValue;
        float Precios = float.Parse(txtPre.Text);
        string alimento = Multiple.SelectedValue;
        cate = Convert.ToInt32(Cat.SelectedValue);
        subca = Convert.ToInt32(Sub.SelectedValue);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append(@"<script type='text/javascript'>");
        
        if (cate > 0 && subca > 0 && tama != "0" && fijo != "0")
        {
            ExecuteAdd(Nombre, cate, subca, tama, desc, Precios, alimento);
            sb.Append("swal(\"Registro.\", \"Producto guardado de forma correcta.\", \"success\");");
            sb.Append("$('#addModal').modal('hide');");
            BindGrid();
        }
        else {
            sb.Append("swal(\"Aviso.\", \"Selecciona todos los campos para continuar.\", \"warning\");");
        }
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
    }
    private void ExecuteAdd(string Nombre, int Categoria, int subcategoria,string tama,string desc, float Precios, string alimento)
    {

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        string usuario = User.Identity.Name;
        con.Open();
        string upda= "insert into Producto (Nombre, Descripcion, Tamaño, ID_Sub, Precio, Prod_Fijo) " +
            "values(@nombre, @desc, @tam, @sub, @precio, @fijo)";
        SqlCommand addCmd = new SqlCommand(upda, con);
        addCmd.Parameters.AddWithValue("@nombre", Nombre);
        addCmd.Parameters.AddWithValue("@precio", Precios);
        addCmd.Parameters.AddWithValue("@desc", desc);
        addCmd.Parameters.AddWithValue("@tam", tama);
        addCmd.Parameters.AddWithValue("@sub", subcategoria);
        addCmd.Parameters.AddWithValue("@fijo",alimento);
        addCmd.ExecuteNonQuery();
        txtDesc.Text = "";
        txtNombr.Text = "";
        txtPre.Text = "";
     
        con.Close();
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {

        string id = lblID.Text;
        string nom = txtNomb.Text;
        string desc = txtDes.Text;
        string tamas = Tama.Text;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        sb.Append("<script type='text/javascript'>");
        float prec = float.Parse(txtPrec.Text);
        if (tamas != "0")
        {
            ExecuteUpdate(id, nom, desc, tamas, prec);
            BindGrid();
            sb.Append("$('#updModal').modal('hide');");
            sb.Append("swal(\"Actualización!\", \"Producto actualizado de forma correcta.\", \"success\");");
            sb.Append(@"</script>");

        }
        else {
            sb.Append("swal(\"Aviso.\", \"Selecciona un tamaño para poder continuar.\", \"warning\");");
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
    }

    //Metodo de Actualizar
    private void ExecuteUpdate(string id, string nom, string desc,string tamas, float prec)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        
        string updateCmd = "UPDATE Producto SET Nombre=@nom,Descripcion=@des,Tamaño=@tama,Precio=@precio WHERE ID=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@nom", nom);
        updatecmd.Parameters.AddWithValue("@des", desc);
        updatecmd.Parameters.AddWithValue("@tama", tamas);
        updatecmd.Parameters.AddWithValue("@precio", prec);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.ExecuteNonQuery();
        txtNomb.Text = "";
        txtDes.Text = "";
        txtPrec.Text = "";
        con.Close();

    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string ide = hfdf.Value;
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
            string updatecmd = "delete from Producto where ID = @id";
            SqlCommand addCmd = new SqlCommand(updatecmd, con);
            addCmd.Parameters.AddWithValue("@id", ide);
            addCmd.ExecuteNonQuery();
            sb.Append("$('#eliminaModal').modal('hide');");
            sb.Append("swal(\"Eliminado!\", \"Producto eliminado de forma correcta.\", \"success\");");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
            con.Close();
        }
        catch (SqlException e)
        {
            Console.WriteLine("Excepcion Ocurrida: ", e);
        }
        //protected void Agregar_Click(object sender, EventArgs e)
        //{
        //    agregarProducto(txtNombre.Text,txtDesc.Text,Tamaño.SelectedValue,Convert.ToInt32(Sub.SelectedValue),
        //        Convert.ToInt64(Precio.Text),Multiple.SelectedValue);
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    sb.Append("<script src=\"//unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
        //    sb.Append("<script type='text/javascript'>");
        //    sb.Append("swal(\"Guardado!\", \"Registro agregado correctamente.\", \"success\");");
        //    sb.Append(@"</script>");
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddAlertInsert", sb.ToString(), false);
        //}

        //protected void agregarProducto(string nombre, string desc, string tam, int sub, float precio, string fijo) {

        //    SqlCommand cmd = new SqlCommand("insert into Producto (Nombre, Descripcion, Tamaño, ID_Sub, Precio, Prod_Fijo) " +
        //        "values(@nombre, @desc, @tam, @sub, @precio, @fijo)");
        //    cmd.Parameters.AddWithValue("@nombre",nombre);
        //    cmd.Parameters.AddWithValue("@desc",desc);
        //    cmd.Parameters.AddWithValue("@tam",tam);
        //    cmd.Parameters.AddWithValue("@sub",sub);
        //    cmd.Parameters.AddWithValue("@precio",precio);
        //    cmd.Parameters.AddWithValue("@fijo",fijo);
        //    DBIOT db = new DBIOT();
        //    db.insert(cmd);
        //}
    }
        protected void PaqueteAdmi_PageIndexChanged(object sender, GridViewPageEventArgs e)
    {
        PaqueteAdmin.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    public void cargaCategoria()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID,NombreCategoria FROM Categoria where Sitio= (select C_Sitio from AspNetUsers where UserName=@usuario) ", cn);
        cmd.Parameters.AddWithValue("@usuario", User.Identity.Name);
        SqlDataReader dr = cmd.ExecuteReader();
        Categoria.DataSource = dr;
        Categoria.DataTextField = "NombreCategoria";
        Categoria.DataValueField = "ID";
        Categoria.DataBind();
        Categoria.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Subcategoria.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }

   

    protected void Categoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        Subcategoria.Items.Clear();
        string cate = Categoria.SelectedValue;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("select ID,NombreSub from Subcategoria where ID_Categoria=@cate", cn);
        cmd.Parameters.AddWithValue("@cate", cate);
        SqlDataReader dr = cmd.ExecuteReader();
        Subcategoria.DataSource = dr;
        Subcategoria.DataValueField = "ID";
        Subcategoria.DataTextField = "NombreSub";
        Subcategoria.DataBind();
        Subcategoria.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }

    protected void Subcategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
}