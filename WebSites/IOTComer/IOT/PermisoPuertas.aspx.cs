using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_PermisoPuertas : System.Web.UI.Page
{
    DataTable dt;
    string ide = string.Empty;
    string sitio = string.Empty;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection con = new SqlConnection(conString);
    private SqlConnection con2 = new SqlConnection(conString);
    private SqlConnection con3 = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla2 = 52;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla2) == "Alta de RFID")
        {
            sitio = Request.QueryString["sitio"];
            ide = Request.QueryString["usuario"];
            if (!IsPostBack)
            {
                llenarComboPermisos();
            }
            BindGrid(ide);
            BindGrid2(Convert.ToInt32(ide));
        }
        else
            Response.Redirect("~/IOT/Home");
    }
    protected void BindGrid(string id)
    {
        DataSet ds = new DataSet();
        if (id != null)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select ID, Nombre from UsuarioRFID where Id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                //BindGrid2(id);
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

    }
    protected void BindGrid2(int id)
    {
        DataSet ds = new DataSet();
        con2.Open();
        SqlCommand cmd = new SqlCommand("select a1.ID, d.Descripcion from DARS d, (select ru.ID, IDReglaRFID, u.ID as IDUsuario from ReglasRFIDUsuario ru " +
                                        "inner join UsuarioRFID u on ru.IDUsuario = u.ID where u.ID = @id) as a1 inner join ReglasRFID rf " +
                                        "on rf.ID = a1.IDReglaRFID where rf.RISCEI_P1 = d.RISCEI", con2);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con2.Close();
        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            PermisosDetalle.DataSource = ds;
            PermisosDetalle.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            PermisosDetalle.DataSource = ds;
            PermisosDetalle.DataBind();
            int columncount = PermisosDetalle.Rows[0].Cells.Count;
            PermisosDetalle.Rows[0].Cells.Clear();
            PermisosDetalle.Rows[0].Cells.Add(new TableCell());
            PermisosDetalle.Rows[0].Cells[0].ColumnSpan = columncount;
            PermisosDetalle.Rows[0].Cells[0].Text = "No se encontraron Registros";
        }
    }

    protected string returnNOIPRFID(string riscei) {
        string url = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("if(select s.MultipleNOIP from Sitios s inner join UbiDis u on u.Cl_Sitio=s.ID inner join " +
            "DARS d on d.UbiDis = u.Id where d.RISCEI = @riscei) = 0 begin select S.NOIP from Sitios s inner join UbiDis u on " +
            "u.Cl_Sitio = s.ID inner join DARS d on d.UbiDis = u.Id where d.RISCEI = @riscei end else select n1.NOIP from " +
            "Nivel1 n1 where ID = (select u.Nivel1 from UbiDis u inner join DARS d on d.UbiDis = u.Id where d.RISCEI = @riscei)",con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
            url = Convert.ToString(dr[0]);
        con.Close();
        return url;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lblID.Text = ide;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "AddShowModalScript", sb.ToString(), false);
    }

    protected void BtnAddRecord_Click(object sender, EventArgs e)
    {
        int Permiso = Convert.ToInt32(PermisoLista.Text);
        string accion = string.Empty;
        accion = PermisoRFIDDAR(Permiso,1);
        if (accion == "True")
        {
            if (insertPermiso(Permiso))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('Permiso insertado correctamente');");
                sb.Append("$('#addModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
                BindGrid2(Convert.ToInt32(ide));
            }
            else
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('El permiso ya existe');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditErrorModalScript", sb.ToString(), false);
            }
        }
        else if (accion == "Asigned")
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('El permiso ya existe en el DAR');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditError2ModalScript", sb.ToString(), false);
        }
        else {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Problemas para comunicar RFID con ADDAR. Intente más tarde.');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditError2ModalScript", sb.ToString(), false);
        }
    }
    protected bool insertPermiso(int Permiso)
    {
        //int dias = Convert.ToInt32(Dias.SelectedValue);
        string ident = lblID.Text;
        bool result = false;
        try
        {
            SqlCommand cmd = new SqlCommand("if(select Count(ID) from ReglasRFIDUsuario where IDUsuario = @user and IDReglaRFID = @regla) = 0 " +
                                            "insert into ReglasRFIDUsuario(IDUsuario, IDReglaRFID) values(@user, @regla) else select 'False'", con);
            cmd.Parameters.AddWithValue("@user", ident);
            cmd.Parameters.AddWithValue("@regla", Permiso);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                result = true;
            }
            con.Close();
        }
        catch
        {

        }
        return result;
    }

    protected string PermisoRFIDDAR(int permiso, int accion) {
        string respuesta = string.Empty;
        string riscei = string.Empty, url = string.Empty, codigo = string.Empty;
        con.Open();
        SqlCommand cmd;
        if (accion == 1)
        {
            cmd = new SqlCommand("select rf.RISCEI_P1, u.RFID from ReglasRFID rf, UsuarioRFID u where rf.ID = @id " +
            "and u.ID = @usuario", con);
            cmd.Parameters.AddWithValue("@id", permiso);
            cmd.Parameters.AddWithValue("@usuario", ide);
        }
        else {
            cmd = new SqlCommand("select rf.RISCEI_P1, u.RFID from ReglasRFID rf, UsuarioRFID u where rf.ID = (select IDReglaRFID " +
                "from ReglasRFIDUsuario where ID= @id) and u.ID = @usuario", con);
            cmd.Parameters.AddWithValue("@id", permiso);
            cmd.Parameters.AddWithValue("@usuario", ide);
        }
        
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            riscei = Convert.ToString(dr[0]);
            codigo = Convert.ToString(dr[1]);
        }
        con.Close();
        if (accion == 1)
            url = "https://addar.mx/Especiales/peticionRFID.php?v1=" + returnNOIPRFID(riscei) + "&v2=1&v3=" + codigo + "&v4=" + riscei;
        else if (accion == 2) {
            url = "https://addar.mx/Especiales/peticionRFID.php?v1=" + returnNOIPRFID(riscei) + "&v2=2&v3=" + codigo + "&v4=" + riscei;
            //respuesta = permiso + " "+url;
        }
            
        respuesta = returnResponseValue(url);
        return respuesta;
    }

    protected string returnResponseValue(string url)
    {
        HttpWebRequest peticion = (HttpWebRequest)WebRequest.Create(url);
        //peticion.KeepAlive= false;
        string json2 = string.Empty;
        //peticion = WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)peticion.GetResponse();
        Stream stream = response.GetResponseStream();
        StreamReader reader = new StreamReader(stream);
        json2 = reader.ReadToEnd();
        reader.Close();
        stream.Close();
        response.Close();
        //peticion.Abort();
        return json2;
    }

    protected void llenarComboPermisos()
    {
        con3.Open();
        SqlCommand cmd = new SqlCommand("select rf.ID, a1.Descripcion from ReglasRFID rf inner join " +
            "(select RISCEI, Descripcion from DARS where Modelo = 'DAR-BIS-P1' and UbiDis in " +
            "(select ID from UbiDis where Cl_Sitio = @sit)) as a1 on a1.RISCEI = rf.RISCEI_P1 " +
            "except select rf2.ID, a2.Descripcion from ReglasRFID rf2 inner join(select RISCEI, " +
            "Descripcion from DARS where Modelo = 'DAR-BIS-P1' and UbiDis in (select ID from UbiDis where " +
            "Cl_Sitio = @sit)) as a2 on a2.RISCEI = rf2.RISCEI_P1 inner join ReglasRFIDUsuario " +
            "rfu on rfu.IDReglaRFID = rf2.ID and rfu.IDUsuario = @usuario", con3);
        cmd.Parameters.AddWithValue("@sit", sitio);
        cmd.Parameters.AddWithValue("@usuario",ide);
        SqlDataReader dr = cmd.ExecuteReader();
        PermisoLista.DataSource = dr;
        PermisoLista.DataTextField = "Descripcion";
        PermisoLista.DataValueField = "ID";
        PermisoLista.DataBind();
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(hfID.Value); 
        string respuesta = string.Empty;
        respuesta = PermisoRFIDDAR(id,2);
        if (respuesta == "True")
        {
            ExecuteDelete(id);
            BindGrid2(id);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Registo Eliminado');");
            sb.Append("$('#eliminaModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
            BindGrid2(Convert.ToInt32(ide));
        }
        else {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Problemas al eliminar el permiso. Intente más tarde.');");
            sb.Append("$('#eliminaModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHide2ModalScript", sb.ToString(), false);
        }
        
    }
    private void ExecuteDelete(int id)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updatecmd = "delete from ReglasRFIDUsuario where ID=@id";
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
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("deleteRecord"))
        {
            string id = PermisosDetalle.DataKeys[index].Value.ToString();
            hfID.Value = id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#eliminaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
    }

    protected void Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/IOT/AltaRFID?sitio="+sitio);
    }
}