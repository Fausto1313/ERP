using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_AdministracionVIP : System.Web.UI.Page
{

    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 55;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Restaurant")
        {
            
            BindGrid();

        }
        else
        {
            Response.Redirect("~/IOT/Home");
        }
    }
    public void BindGrid()
    {
        //string Reg = Reasignar.SelectedValue;
        //DateTime fecha = DateTime.Today;
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmd = new SqlCommand("Select * From UsuarioRestaurant where Sitio=(Select C_Sitio from AspNetUsers where UserName=@user)", conn);
       cmd.Parameters.AddWithValue("@user", usuario);
        //cmd.Parameters.AddWithValue("@fecha", fecha);
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
            IEnumerable<DataRow> query = from UsuarioRestaurant in dt.AsEnumerable()
                                         where UsuarioRestaurant.Field<String>("ID").Equals(id)
                                         select UsuarioRestaurant;

            DataTable GridView1Table = query.CopyToDataTable<DataRow>();
            GridView1.DataSource = GridView1Table;
            GridView1.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type= 'text/javascript'>");
            sb.Append("$('detailmodal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DetailmodalScript", sb.ToString(), false);

        }

        else if (e.CommandName.Equals("updUser"))

        {

            GridViewRow gvrow = GridView1.Rows[index];
            lblUser.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtNombre.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            txtAP.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text).ToString();
            txtAM.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString();
            txtDir.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text).ToString();
            txtTelefono.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text).ToString();
            txtCon.Text = HttpUtility.HtmlDecode(gvrow.Cells[6].Text).ToString();
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
        else if (e.CommandName.Equals("asignar"))
        {
            //GridViewRow gvrow2 = GridView1.Rows[index];
            //string id = HttpUtility.HtmlDecode(gvrow2.Cells[0].Text).ToString();
            //string sitio = Sitio.SelectedValue;
            //Response.Redirect("~/IOT/PermisoPuertas?usuario=" + id + "&sitio=" + sitio);
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
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string us = lblUser.Text;
        string Nombre = txtNombre.Text;
        string Ap = txtAP.Text;
        string Ame = txtAM.Text;
        string Dir = txtDir.Text;
        string Tel = txtTelefono.Text;
        string Cont = txtCon.Text;
        Cont = Encrypt.Encriptar(Cont);
        ExecuteUpdate( us,Nombre,Ap,Ame,Dir,Tel,Cont);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
    }
    private void ExecuteUpdate(string us,string Nombre, string Ap, string Ame, string Dir, string Tel,string Cont)

    {

        string usuarios = User.Identity.Name;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);

        con.Open();

        string updateCmd = "UPDATE UsuarioRestaurant SET  Nombre=@Nombre,ApePat=@ap,ApeMat=@am,Direccion=@direccion,Telefono=@tel,Contraseña=@contra WHERE Usuario=@user";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@Nombre", Nombre);
        updatecmd.Parameters.AddWithValue("@ap", Ap);
        updatecmd.Parameters.AddWithValue("@am",Ame);
        updatecmd.Parameters.AddWithValue("@direccion", Dir);
        updatecmd.Parameters.AddWithValue("@tel",Tel);
        updatecmd.Parameters.AddWithValue("@contra", Cont);
        updatecmd.Parameters.AddWithValue("@user",us);
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
        sb.Append("alert('Registo eliminado');");
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
            string updatecmd = "delete from UsuarioRestaurant where ID=@id";
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
    protected string returnUsuarioConcat(string usuario)
    {
        string user = User.Identity.Name, concatenado = string.Empty;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select d.RISCEI from DARS d inner join UbiDis u on u.ID=d.UbiDis where u.Cl_Sitio = (select C_Sitio from AspNetUsers where UserName = @usuario) and d.Modelo ='DAR'", conn);
        cmd.Parameters.AddWithValue("@usuario", user);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
            concatenado = usuario + Convert.ToString(dr[0]);
        conn.Close();
        return concatenado;
    }
    protected void BtnAddRecordClick(object sender, EventArgs e)

    {
        string Usere = txtUser.Text;
        string Nom = txtNom.Text;
        string Apep = txtAP1.Text;
        string Apm = txtAM1.Text;
        string Dire = txtDirec.Text;
        string Tele = txtTelefono1.Text;
        string Con = txtCon1.Text;
        Con = Encrypt.Encriptar(Con);
        if (ExecuteAdd(Usere, Nom, Apep, Apm, Dire, Tele,Con))
        {
            BindGrid();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Registro Agregado');");
            sb.Append("$('#addModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
        }
        else
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Usuario Existente');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

        }
       

    }
    private bool ExecuteAdd( string Usere,string Nom, string Apep, string Apm, string Dire, string Tele, string Con)

    {
        bool bl = false;
        string usuarios = User.Identity.Name;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
       Usere = returnUsuarioConcat(Usere);
        con.Open();

        string updatecmd = "if(select COUNT(ID) from UsuarioRestaurant where Usuario = @user) = 0 begin " +
            "if (select COUNT(UserName) from AspNetUsers where UserName = @user ) = 0 begin insert into " +
            "UsuarioRestaurant(Usuario, Nombre, ApePat, ApeMat, Direccion, Telefono, Contraseña, Sitio ) values " +
            "(@user, @nom, @ap, @apm, @dire, @tel, @contra, (select C_Sitio from AspNetUsers where UserName = @use)) " +
            "end else select 'False2' end else select 'False1'";

        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@user",Usere);
        addCmd.Parameters.AddWithValue("@nom", Nom);
        addCmd.Parameters.AddWithValue("@ap", Apep);
        addCmd.Parameters.AddWithValue("@apm", Apm);
        addCmd.Parameters.AddWithValue("@dire", Dire);
        addCmd.Parameters.AddWithValue("@tel", Tele);
        addCmd.Parameters.AddWithValue("@contra", Con);
        addCmd.Parameters.AddWithValue("@use", usuarios);
        SqlDataReader dr = addCmd.ExecuteReader();
        if (dr.Read())
            bl = false;
        else
            bl = true;

        con.Close();
        return bl;

    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
}