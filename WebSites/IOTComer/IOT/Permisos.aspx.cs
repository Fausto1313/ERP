using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
public partial class IOT_Permisos : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected int cliente = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 5;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario,pantalla) == "Roles")
        {
            cliente = consultaide();
            if (!Page.IsPostBack)
            {
                cargaRoles(cliente);
            }
            BindGrid();
        }
        else
            Response.Redirect("~/IOT/Home");
    }

    public void BindGrid()
    {
        string usuario = User.Identity.Name;
        conn.Open();        
        SqlCommand cmds = new SqlCommand("SELECT r.Id, r.Name from AspNetRoles r where r.ID_Cliente = (select ID_Cliente from AspNetUsers where UserName = @user) and r.Id != 87", conn);
        cmds.Parameters.AddWithValue("@user", usuario);
        SqlDataAdapter da = new SqlDataAdapter(cmds);
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
        if (e.CommandName.Equals("updRecord"))
        {
            GridViewRow gvrow = GridView1.Rows[index];
            lblID.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtNombre12.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);
        }

        else if (e.CommandName.Equals("asignarPermiso"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            Response.Redirect("~/IOT/DetallePermiso?rol="+id);
        }
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
            string updatecmd = "delete from dbo.AspNetRoles where Id=@id";
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

    /*Metodo para agregar permiso*/
    protected void BtnAddClick(object sender, EventArgs e)
    {

        // ExecuteUpdate(id, Name, algo);

        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

    }
    /*Metodo para insertar*/

    protected void BtnAddRecordClick(object sender, EventArgs e)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);
        conn.Open();

        string usuario = User.Identity.Name;

        int alg = 0;
        string clientes = ("Select u.ID_Cliente from Clientes c, dbo.AspNetUsers u  where c.ID=u.ID_Cliente and u.UserName=@usuario");
        SqlCommand cmd = new SqlCommand(clientes, conn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            alg = Convert.ToInt32(dr[0]);
        }


        string nom = txtNombre1.Text;

        ExecuteAdd(nom, alg);


    }


    /*Metodo para agregar permiso*/
    private void ExecuteAdd(string nom, int alg)

    {

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);

        conn.Open();

        string updatecmd = "insert into dbo.AspNetRoles (Name,ID_Cliente) values (@nom,@alg)";
                            

        SqlCommand addCmd = new SqlCommand(updatecmd, conn);
        addCmd.Parameters.AddWithValue("@nom", nom);
        addCmd.Parameters.AddWithValue("@alg", alg);

        addCmd.ExecuteNonQuery();
        conn.Close();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Rol Creado');");
        sb.Append("$('#deleteModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
    }

    /*Ejecuta el evento de actualizado a la base de datos*/


    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();

    }
 

    protected void Permiso(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModals').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
    }

    protected void BtnAddRecordClick1(object sender, EventArgs e)
    {
        int nom = Convert.ToInt32(Roles.Text);
        string Acciones = chkAcciones.Checked ? "1" : "0";
        string Perifericos = chkPerifericos.Checked ? "2" : "0";
        string Ambiente = chkAmbiente.Checked ? "3" : "0";
        string Telegram = chkTelegram.Checked ? "4" : "0";
        string Usuarios = chkUsuarios.Checked ? "5" : "0";
        string Rol = chkNuevoRol.Checked ? "6" : "0";
        string UsuariosTelegram = chkUsuariosTelegram.Checked ? "7" : "0";
        string Niveles = chkNiveles.Checked ? "8" : "0";
        string Planos = chkPlanos.Checked ? "9" : "0";
        string Automatizado = chkAutomatizado.Checked ? "10" : "0";
        string NuevoAuto = chkNuevoAuto.Checked ? "11" : "0";
        string RegistroAuto = chkRegistroAuto.Checked ? "12" : "0";
        string RISC = chkRISC.Checked ? "13" : "0";
        string Huella = chkHuella.Checked ? "14" : "0";
        string Conteo = chkConteo.Checked ? "15" : "0";
        string Botones = chkBotones.Checked ? "16" : "0";
        string Activacion = chkActivacion.Checked ? "17" : "0";
        string AdminApp = chkAdminApp.Checked ? "18" : "0";
        string DARC = chkDARC.Checked ? "19" : "0";
        string Drools = chkDrools.Checked ? "20" : "0";


        if (Acciones == "1")

        {
            int valor = 1;
            ExecuteRole(nom, valor);
        }
        else
        {
            int valor = 1;
            ExecutedeleteRole(nom, valor);
        }
        if (Perifericos == "2")

        {
            int valor = 2;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 2;
            ExecutedeleteRole(nom, valor);
        }

        if (Ambiente == "3")

        {
            int valor = 3;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 3;
            ExecutedeleteRole(nom, valor);
        }

        if (Telegram == "4")

        {
            int valor = 4;
            ExecuteRole(nom, valor);



        } else {
            int valor = 4;
            ExecutedeleteRole(nom, valor);
        }
        if (Usuarios == "5")

        {
            int valor = 5;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 5;
            ExecutedeleteRole(nom, valor);
        }
        if (Rol == "6")

        {
            int valor = 6;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 6;
            ExecutedeleteRole(nom, valor);
        }
        if (UsuariosTelegram == "7")

        {
            int valor = 7;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 7;
            ExecutedeleteRole(nom, valor);
        }
        if (Niveles == "8")

        {
            int valor = 8;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 8;
            ExecutedeleteRole(nom, valor);
        }
        if (Planos == "9")

        {
            int valor = 9;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 9;
            ExecutedeleteRole(nom, valor);
        }
        if (Automatizado == "10")

        {
            int valor = 10;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 10;
            ExecutedeleteRole(nom, valor);
        }
        if (NuevoAuto == "11")

        {
            int valor = 11;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 11;
            ExecutedeleteRole(nom, valor);
        }
        if (RegistroAuto == "12")

        {
            int valor = 12;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 12;
            ExecutedeleteRole(nom, valor);
        }
        if (RISC == "13")

        {
            int valor = 13;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 13;
            ExecutedeleteRole(nom, valor);
        }
        if (Huella == "14")

        {
            int valor = 14;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 14;
            ExecutedeleteRole(nom, valor);
        }
        if (Conteo == "15")

        {
            int valor = 15;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 15;
            ExecutedeleteRole(nom, valor);
        }
        if (Botones == "16")

        {
            int valor = 16;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 16;
            ExecutedeleteRole(nom, valor);
        }
        if (Activacion == "17")

        {
            int valor = 17;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 17;
            ExecutedeleteRole(nom, valor);
        }
        if (AdminApp == "18")

        {
            int valor = 18;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 18;
            ExecutedeleteRole(nom, valor);
        }
        if (DARC == "19")

        {
            int valor = 19;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 20;
            ExecutedeleteRole(nom, valor);
        }
        if (Drools == "20")

        {
            int valor = 20;
            ExecuteRole(nom, valor);



        }
        else
        {
            int valor = 20;
            ExecutedeleteRole(nom, valor);
        }

    }


    public void cargaRoles(int cliente)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();

        string usuario = User.Identity.Name;
        SqlCommand cmd = new SqlCommand("SELECT R.Id,R.Name FROM dbo.AspNetRoles R where R.Id != 87 and R.ID_Cliente=@cliente", cn);
        cmd.Parameters.AddWithValue("@cliente", cliente);
        SqlDataReader dr = cmd.ExecuteReader();
        Roles.DataSource = dr;
        Roles.DataTextField = "Name";
        Roles.DataValueField = "Id";
        Roles.DataBind();
    }


    private void ExecuteRole(int nom, int valor)

    {

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);

        con.Open();

        string updatecmd = "insert into PermisoRol (ID_Rol,ID_Permiso ) values (@nom,@valor)";

        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@nom", nom);
        addCmd.Parameters.AddWithValue("@valor", valor);
        addCmd.ExecuteNonQuery();
        con.Close();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registo Agregado');");
        sb.Append("$('#deleteModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
    }

    private void ExecutedeleteRole(int nom, int valor)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);


        con.Open();
        string updatecmd = "delete from dbo.PermisoRol where ID_Rol=@nom and ID_Permiso=@valor";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@nom", nom);
        addCmd.Parameters.AddWithValue("@valor", valor);
        addCmd.ExecuteNonQuery();
        con.Close();
    }

    protected void BtnAddRecordClickrole(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(lblID.Text);

        string nombre = txtNombre12.Text;
        ExecuteUpdateRole(id, nombre);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
            
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    }
    /*Ejecuta el evento de actualizado a la base de datos*/
    private void ExecuteUpdateRole(int id, string nombre)       
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE AspNetRoles SET Name=@nombre WHERE Id=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@nombre", nombre);
        updatecmd.ExecuteNonQuery();
        con.Close();

    }

    protected int consultaide(){
        int cliente=0;
        string id = User.Identity.GetUserId();
        string usuario = User.Identity.Name;
        conn.Open();
        string algo = null;
        string clientes = ("Select u.ID_Cliente from Clientes c, dbo.AspNetUsers u  where c.ID=u.ID_Cliente and u.UserName=@usuario");
        SqlCommand cmd = new SqlCommand(clientes, conn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            algo = Convert.ToString(dr[0]);
        }
        conn.Close();
        cliente = Convert.ToInt32(algo);
        return cliente;
    }


    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        
    }
}
