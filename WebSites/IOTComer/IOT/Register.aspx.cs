using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using IOTComer;
using Microsoft.AspNet.Identity.EntityFramework;

public partial class Account_Register : Page
{

    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)

    {
        string usuario = User.Identity.Name;
        int pantalla = 3;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario,pantalla) == "Usuarios")
        {
            BindGrid2();
            if (!IsPostBack){
                cargaRoles2();
                cargaRoles();
                CargaSitios();
                cargaDars();
            }
           
        }
       
        else
            Response.Redirect("~/IOT/Home");
    }
    protected void Search(object sender, EventArgs e)
    {

    }
    public void BindGrid2()


    {
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "SELECT  U.UserName, U.Nombre, U.Apellido, ar.Name, s.C_Sitio, u.Habilitado FROM AspNetUsers u, Sitios s, AspNetRoles ar   ";
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                   

                    sql += "Where ( U.UserName LIKE '%' + @Busqueda + '%' OR U.Nombre LIKE '%' + @Busqueda + '%' OR  U.Apellido LIKE '%' + @Busqueda + '%' OR  ar.Name LIKE '%' + @Busqueda + '%' OR  s.C_Sitio LIKE '%' + @Busqueda + '%' OR  u.Habilitado LIKE '%' + @Busqueda + '%' AND c.ID=u.ID_Cliente and u.UserName=@usuario)";
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
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        string dis = dar.Text;
        var manager = new UserManager();
        var user = new ApplicationUser() { UserName = UserName.Text + dis};
       
        string nombre = Nombre.Text;
        string apellido = Apellido.Text;
        string id = UserName.Text;

        ApplicationDbContext context = new ApplicationDbContext();
        var roeManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        SqlConnection conn = new SqlConnection(conString);
        conn.Open();
        int sitio = ObtenerSitio(dis);
        string usuario = User.Identity.Name;
        string algo = null;
        string clientes = ("Select u.ID_Cliente from Clientes c, dbo.AspNetUsers u  where c.ID=u.ID_Cliente and u.UserName=@usuario");
        SqlCommand cmd = new SqlCommand(clientes, conn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        //Response.Write(clientes);
        if (dr.Read())
        {
            algo = Convert.ToString(dr[0]);
        }
        conn.Close();

        int rol = Convert.ToInt32(Roles.Text);
        IdentityResult result = manager.Create(user, Password.Text);
        Executeadd(id + dis, nombre, apellido, algo, rol, sitio);
        if (result.Succeeded)
        {
            /////IdentityHelper.SignIn(manager, user, isPersistent: false);
            //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //   var result1 = UserManager.AddToRole(user.Id, rol);          
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro Exitoso')", true);
            BindGrid();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Registro agregado exitosamente');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddScript", sb.ToString(), false);
            
        }
        else
        {
            BindGrid();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('No se pudo completar el registro.');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddScript", sb.ToString(), false);
        }

    }
    private void Executeadd(string id, string nombre, string apellido, string algo, int rol, int sitio)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();

        string updateCmd = "UPDATE AspNetUsers SET Nombre=@nombre, C_sitio=@sitio, Apellido=@apellido,ID_Cliente=@algo, Id_Rol=@rol WHERE UserName=@id ";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@algo", algo);
        updatecmd.Parameters.AddWithValue("@nombre", nombre);
        updatecmd.Parameters.AddWithValue("@apellido", apellido);
        updatecmd.Parameters.AddWithValue("@rol", rol);
        updatecmd.Parameters.AddWithValue("@sitio", sitio);
        updatecmd.ExecuteNonQuery();
        con.Close();

    }

    public void cargaDars() 
    {
        string usuario = User.Identity.Name;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("select d.RISCEI, s.Descripcion from sitios s, dars d inner join UbiDis u on u.Id=d.UbiDis where u.Cl_Sitio = s.ID and s.ID_cliente = (select ID_Cliente from AspNetUsers where UserName = @user) and d.Modelo = 'DAR'", cn);
        cmd.Parameters.AddWithValue("@user", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        dar.DataSource = dr;
        dar.DataValueField = "RISCEI";
        dar.DataTextField = "Descripcion";
        dar.DataBind();
       
    }

    private int ObtenerSitio(string riscei)
    {
        int sitio = 0;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand("select u.Cl_Sitio from DARS d inner join UbiDis u on d.UbiDis = u.Id where d.RISCEI = @riscei", con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            sitio = Convert.ToInt32(dr[0]);
        }
        return sitio;
    }

    public void cargaRoles()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        string usuario = User.Identity.Name;
        SqlCommand cms = new SqlCommand("select R.Id, R.Name From AspNetRoles R where R.ID_Cliente=(select ID_Cliente from AspNetUsers where UserName = @usuario)", cn);
        cms.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader drs = cms.ExecuteReader();
       Roles.DataSource = drs;
      Roles.DataTextField = "Name";
        Roles.DataValueField = "Id";
        Roles.DataBind(); 
    }
    public void cargaRoles2()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        string usuario = User.Identity.Name;
        SqlCommand cms = new SqlCommand("select R.Id, R.Name From AspNetRoles R where R.ID_Cliente=(select ID_Cliente from AspNetUsers where UserName = @usuario)", cn);
        cms.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader drs = cms.ExecuteReader();

        Roles2.DataSource = drs;
        Roles2.DataTextField = "Name";
        Roles2.DataValueField = "Id";
        Roles2.DataBind();

    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BindGrid()
    {
        string id = User.Identity.GetUserId();
        string usuario = User.Identity.Name;
        conn.Open();
        string algo = null;
        string est = Habilitado.SelectedValue;
        string clientes = ("Select u.ID_Cliente from Clientes c, AspNetUsers u  where c.ID=u.ID_Cliente and u.UserName=@usuario");
        SqlCommand cmd = new SqlCommand(clientes, conn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        //Response.Write(clientes);
        if (dr.Read())
        {
            algo = Convert.ToString(dr[0]);
        }
        conn.Close();
        SqlCommand cmds = new SqlCommand("select U.UserName, U.Nombre, U.Apellido, ar.Name, s.C_Sitio, u.Habilitado from AspNetUsers u, Sitios s, AspNetRoles ar where(u.ID_Cliente =@algo and u.C_Sitio = s.ID and u.ID_Rol = ar.ID) union(select U.UserName, U.Nombre, U.Apellido, ar.Name, cast(u.C_Sitio as varchar), u.Habilitado from AspNetUsers u, AspNetRoles ar where u.ID_Cliente =@algo and u.C_Sitio is null and u.Id_Rol = ar.Id)", conn);
        SqlDataAdapter da = new SqlDataAdapter(cmds);
        cmds.Parameters.AddWithValue("@algo", algo);
        cmds.Parameters.AddWithValue("@est", est);
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
            GridView1.Rows[0].Cells[0].Text = "No se encont  raron Registros";
        }

    }
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("detail"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            IEnumerable<DataRow> query = from AspNetUsers in dt.AsEnumerable()
                                         where AspNetUsers.Field<String>("ID").Equals(id)
                                         select AspNetUsers;
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
            lblUsuario.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text);
            txtNombre.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            txtApellido.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("dispositivosrecord"))
        {
            GridViewRow gvrow = GridView1.Rows[index];
            lblUbiSit.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            lblUbiSit.Visible = true;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModalSitio').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("habilitado"))
        {
            GridViewRow gvrow = GridView1.Rows[index];
            Label1.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            Label2.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text).ToString();
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#habilita').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "HabiModalScript", sb.ToString(), false);
        }

    }
   
    /*Recoge el id donde se da click en el evento actualizar lo guarda y envia*/

    protected void BtnSave_Click(object sender, EventArgs e)
    {    
        string usuario = lblUsuario.Text;
        string nombre = txtNombre.Text;
        string apellido = txtApellido.Text;
        int rol = Convert.ToInt32(Roles2.Text);
        ExecuteUpdate(usuario,nombre, apellido, rol);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
    }

    /*Ejecuta el evento de actualizado a la base de datos*/

    private void ExecuteUpdate(string usuario,string nombre, string apellido, int rol)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE AspNetUsers SET Nombre=@nombre,Apellido=@apellido,Id_Rol=@rol WHERE UserName=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", usuario);
        updatecmd.Parameters.AddWithValue("@nombre", nombre);
        updatecmd.Parameters.AddWithValue("@apellido", apellido);
        updatecmd.Parameters.AddWithValue("@rol", rol);
        updatecmd.ExecuteNonQuery();
        con.Close();
    }

     protected void BtnSave_ClickSitio(object sender, EventArgs e)
     {       
        string id = lblUbiSit.Text;
        string sitios = Sitios.Text;
        ExecuteUpdateS(id, sitios);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModalSitio').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
     }
    /*Ejecuta el evento de actualizado a la base de datos*/
    private void ExecuteUpdateS(string id, string sitios)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE AspNetUsers SET C_Sitio=@sitios WHERE Username=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@sitios", sitios);
        updatecmd.ExecuteNonQuery();
        con.Close();
    }

    public void CargaSitios()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        string usuario = User.Identity.Name;
        string algo = null;
        string cliente = User.Identity.Name;
        string clientes = ("Select u.ID_Cliente from Clientes c, dbo.AspNetUsers u  where c.ID=u.ID_Cliente and u.UserName=@usuario");
        SqlCommand cmd = new SqlCommand(clientes, cn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            algo = Convert.ToString(dr[0]);
        }
        cn.Close();
        cn.Open();
        SqlCommand consultaDisp = new SqlCommand("select ID,C_Sitio from sitios where ID_cliente ='"+algo+"'", cn);
        consultaDisp.Parameters.AddWithValue("@algo", algo);
        SqlDataReader drs = consultaDisp.ExecuteReader();
        Sitios.DataSource = drs;
        Sitios.DataTextField = "C_Sitio";
        Sitios.DataValueField = "ID";
        Sitios.DataBind();

    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid2();
    }

    protected void BtnHabilitado(object sender, EventArgs e)
    {
        string usuario = Label1.Text;
        string est = Hab.SelectedValue;
        ExecuteHab(usuario, est);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Estatus Actualizado');");
        sb.Append("$('#habilita').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "HabHideModalScript", sb.ToString(), false);
    }

    private void ExecuteHab(string usuario, string est)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE AspNetUsers SET Habilitado=@est WHERE UserName=@usuario";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@usuario", usuario);
        updatecmd.Parameters.AddWithValue("@est", est);
        updatecmd.ExecuteNonQuery();
        con.Close();

    }



}

