
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_Nivelees : System.Web.UI.Page
{
   

    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected int us = 0;
    protected string nivel = null;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 24;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, 0) == "RISC")
        {
            BindGrid();
            if (!IsPostBack)
            {
                CargaCliente();
                CargaUbicacionNivel1();
                CargaUbicacionNivel2();
                CargaUbicacionNivel3();
                CargaUbicacionNivel4();
                
                
            }
        }
        else if (permiso.returnPermiso(usuario, pantalla) == "Niveles")
        {

        }
        
        else
            Response.Redirect("~/IOT/Home");
    }
    //Metodo que consulta y muestra los datos de la base en una tabla 
    public void BindGrid()
    {
        string cli = Clientes.SelectedValue;
        string sit = Sitio.SelectedValue;
        SqlConnection cn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn2.Open();
        SqlCommand cms = new SqlCommand("SELECT u.Id,u.Cl_Cliente,n1.Nombre,n2.Nombre2,n3.Nombre3,n4.Nombre4,n5.Nombre5 FROM UbiDis u LEFT JOIN Nivel1 n1 ON u.nivel1 = n1.ID LEFT JOIN Nivel2 n2 ON u.nivel2 = n2.ID LEFT JOIN Nivel3 n3 ON u.nivel3 = n3.ID LEFT JOIN Nivel4 n4 on u.nivel4 = n4.ID LEFT JOIN Nivel5 n5 ON u.nivel5 = n5.ID WHERE Cl_Cliente = @cliente and u.Cl_Sitio = @sitio", cn2);
        cms.Parameters.AddWithValue("@cliente", cli);
        cms.Parameters.AddWithValue("@sitio", sit);
        SqlDataAdapter da = new SqlDataAdapter(cms);
        DataSet ds = new DataSet();
        da.Fill(ds);
        cn2.Close();
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
    //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
    //Metodos para insertar un nuevo nivel Nivel 1
    //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

    /*Metodo que re direcciona al formulario para insertar nuevo nivel1 dando click en el boton Nivel1*/
    protected void BtnAddClick(object sender, EventArgs e)
    {
        lblCliente1.Text = Convert.ToString(Clientes.SelectedItem);
        txtSitio.Text = Convert.ToString(Sitio.SelectedItem);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        int site = Convert.ToInt32(Sitio.Text);
        Permisos permiso = new Permisos();
        if (permiso.isMultipleNOIP(site)) {
            txtNOIP.Visible = true;
           
        } 
        else
            txtNOIP.Visible = false;
        txtNOIP.Text = "";
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
    }
    //Metodo que ejecuta las acciones para insertar en la base , este metodo ejecutta otros metodos
    protected void BtnAddRecordClick(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        string usuario = User.Identity.Name;
        string id_cliente = null;
        string cliente = User.Identity.Name;
        string clientes = ("Select u.ID_Cliente from Clientes c, dbo.AspNetUsers u  where c.ID=u.ID_Cliente and u.UserName=@usuario");
        SqlCommand cmd = new SqlCommand(clientes, cn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            id_cliente = Convert.ToString(dr[0]);
        }
        cn.Close();
        string cli = lblCliente1.Text;
        string sit = txtSitio.Text;
        string nombre = txtNom1.Text;
        string descripcion= txtDescripcion.Text;
        string noip = txtNOIP.Text;
        ExecuteAdd(cli, sit, nombre, descripcion, noip);
        InsertNivel1Ubidisp();
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

    }
    //Metodo que contiene el query para insertar los resgistros en nivel1
    private void ExecuteAdd(string cli, string sit, string nombre, string descripcion, string noip)
    { 
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "insert into Nivel1 (nombre, descripcion,id_cliente,UbiDispo, NOIP) values (@Nombre,@Descripcion,(select ID from Clientes where RazonSocial=@cli),(select ID from Sitios where C_Sitio = @sit), @noip)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@cli", cli);
        addCmd.Parameters.AddWithValue("@sit", sit);
        addCmd.Parameters.AddWithValue("@Nombre", nombre);
        addCmd.Parameters.AddWithValue("@Descripcion", descripcion );
        addCmd.Parameters.AddWithValue("@noip",noip);
        addCmd.ExecuteNonQuery();
        con.Close();
    }

    /*Metodo para llenar el DROPDOWLISTA DE SITIOS EN NIVEL 1 */
   
    //Metodo para insertar los datos del nivel 1 en la tabla ubicacion de dispositivos
   
     public void InsertNivel1Ubidisp()
    {

        string cli = Clientes.SelectedValue;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "INSERT INTO UbiDis(Cl_Cliente, Cl_Sitio, nivel1)SELECT ID_Cliente, UbiDispo, ID FROM Nivel1 where id = (SELECT MAX(ID) from Nivel1 where ID_Cliente =@cli)";
        SqlCommand cmd1 = new SqlCommand(updateCmd, con);
        cmd1.Parameters.AddWithValue("@cli", cli);
        cmd1.ExecuteNonQuery();
        con.Close();
    }
    //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
    //Metodos para insertar un nuevo nivel Nivel 2
    //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

    /*Metodo que re direcciona al formulario para insertar nuevo nivel2 dando click en el boton Nivel2*/
    protected void BtnAddClickNivel2(object sender, EventArgs e)
    {
        CargaUbicacionNivel1();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModalNivel2').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
    }
    protected void BtnAddRecordClickNivel1(object sender, EventArgs e)
    {
        string nombre = txtNom2.Text;
        string descripcion = txtDescripcion2.Text;
        int ID_nivel1= Convert.ToInt32(UbiNiv.Text);
        ExecuteAddNiv1(nombre, descripcion, ID_nivel1);
        InsertarNivel2Ubidisp();
      // InsertarNivel2Nivel1Nuevos();
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModalNivel2').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

    }
    //Metodo que contiene el query para insertar los resgistros en nivel2
    private void ExecuteAddNiv1(string nombre, string descripcion, int ID_nivel1)

    {

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "insert into Nivel2 (Nombre2, Descripcion,ID_nivel1) values (@Nombre,@Descripcion,@ID_Nivel1)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@Nombre", nombre);
        addCmd.Parameters.AddWithValue("@Descripcion", descripcion);
        addCmd.Parameters.AddWithValue("@ID_Nivel1",ID_nivel1);
        addCmd.ExecuteNonQuery();
        con.Close();

    }
    /*Metodo para llenar el DROPDOWLISTA DE los niveles1 EN el formulario del NIVEL 2 */
    public void CargaUbicacionNivel1()
    {
        string cli = Clientes.SelectedValue;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cms = new SqlCommand("select ID, Nombre FROM Nivel1 where ID_Cliente=@cli order by id desc", cn);
        cms.Parameters.AddWithValue("@cli", cli);
        SqlDataReader drs = cms.ExecuteReader();
        UbiNiv.DataSource = drs;
        UbiNiv.DataTextField = "Nombre";
        UbiNiv.DataValueField = "ID";
        UbiNiv.DataBind();
        cn.Close();
    }
    //Metodo que inserta nivel2 en  registro en Ubidisp cuando ya se inserto nivel1

        public void InsertarNivel2Ubidisp()
        {

        SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn1.Open();
        string cli = Clientes.SelectedValue;
        string nivel1 = "";
        string nivel2 = "";
        string id = null;
        string UltReg = ("SELECT id,nivel1,nivel2 FROM UbiDis where id = (SELECT MAX(ID) from UbiDis where Cl_Cliente =@cli)");
        SqlCommand cmU= new SqlCommand(UltReg, cn1);
        cmU.Parameters.AddWithValue("@cli", cli);
        SqlDataReader dr2 = cmU.ExecuteReader();
        if (dr2.Read())
        {
            nivel1 = Convert.ToString(dr2["nivel1"]);
            nivel2 = Convert.ToString(dr2["nivel2"]);
            id = Convert.ToString(dr2["id"]);
        }
        cn1.Close();
        if (nivel2==null||nivel2=="")
        {

            SqlConnection cnNivel12 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            cnNivel12.Open();
            string IdN1 = null;
            string IdN2 = null;
            string Nivel1 = ("select Top 1 Nivel2.ID,Nivel1.ID from Nivel1,Nivel2 where Nivel1.ID = Nivel2.ID_nivel1 and Nivel1.ID_Cliente =@cli order by Nivel2.ID desc");
            SqlCommand cmdNivel1 = new SqlCommand(Nivel1, cnNivel12);
            cmdNivel1.Parameters.AddWithValue("@cli", cli);
            SqlDataReader drNivel12 = cmdNivel1.ExecuteReader();
            if (drNivel12.Read())
            {
                IdN2 = Convert.ToString(drNivel12[0]);
                IdN1 = Convert.ToString(drNivel12[1]);
            }
            cnNivel12.Close();
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updateCmd = "UPDATE UbiDis SET nivel2 ='" + IdN2 + "'  WHERE ID = '" + id + "'";
            SqlCommand cmd1 = new SqlCommand(updateCmd, con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }
        else
        {
            InsertarNivel2Nivel1Nuevos();
        }
        
    }
    //Metodo que inserta el nivel2 y el nivel1 desde el formulario del nivel2
    public void InsertarNivel2Nivel1Nuevos()
    {
    
        SqlConnection cnNivel1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cnNivel1.Open();
        string cli = Clientes.SelectedValue;
        string IdN1=null;
        string IdN2 =null;
        string Nivel1 = ("select Top 1 Nivel2.ID,Nivel1.ID from Nivel1,Nivel2 where Nivel1.ID = Nivel2.ID_nivel1 and Nivel1.ID_Cliente =@cli order by Nivel2.ID desc");
        SqlCommand cmdNivel1 = new SqlCommand(Nivel1, cnNivel1);
        cmdNivel1.Parameters.AddWithValue("@cli",cli);
        SqlDataReader drNivel1 = cmdNivel1.ExecuteReader();
        if (drNivel1.Read())
        {
            IdN2 = Convert.ToString(drNivel1[0]);
            IdN1 = Convert.ToString(drNivel1[1]);
        }
        cnNivel1.Close();

        string conStringN = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection conN = new SqlConnection(conStringN);
            conN.Open();
            string updateCmdN =( "INSERT INTO UbiDis(Cl_Cliente, Cl_Sitio, nivel1)SELECT ID_Cliente, UbiDispo, ID FROM Nivel1 where id = '" + IdN1 + "'");
            SqlCommand cmd1N = new SqlCommand(updateCmdN, conN);
            cmd1N.ExecuteNonQuery();
            conN.Close();

        string conStringUpdate = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection conUpd = new SqlConnection(conStringUpdate);
            conUpd.Open();
            string updateCmdNiv = "UPDATE UbiDis SET nivel2 ='" + IdN2 + "'  WHERE ID = (SELECT MAX(ID) from UbiDis where Cl_Cliente =@cli)";
            SqlCommand cmd1Niv = new SqlCommand(updateCmdNiv, conUpd);
        cmd1Niv.Parameters.AddWithValue("@cli",cli);
            cmd1Niv.ExecuteNonQuery();
        conUpd.Close();

    }
    //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
    //Metodos para insertar un nuevo nivel Nivel 3
    //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

    /*Metodo que re direcciona al formulario para insertar nuevo nivel3 dando click en el boton Nivel3*/
    protected void BtnAddClickNivel3(object sender, EventArgs e)
    {
        CargaUbicacionNivel2();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModalNivel3').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
    }
    //Metodo que realiza las funcienes requeridas para insertar en nivel 3 
    protected void BtnAddRecordClickNivel3(object sender, EventArgs e)
    {
        string nombre = txtNom3.Text;
        string descripcion = txtDescripcion3.Text;
        int ID_nivel2 = Convert.ToInt32(UbiNiv2.Text);
        ExecuteAddNiv3(nombre, descripcion, ID_nivel2);
        InsertarNivel3Ubidisp();
        // InsertarNivel2Nivel1Nuevos();
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModalNivel3').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

    }
    //Metodo que contiene el query para insertar los resgistros en nivel3
    private void ExecuteAddNiv3(string nombre, string descripcion, int ID_nivel2)

    {

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "insert into Nivel3 (Nombre3, Descripcion,ID_nivel2) values (@Nombre,@Descripcion,@ID_Nivel2)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@Nombre", nombre);
        addCmd.Parameters.AddWithValue("@Descripcion", descripcion);
        addCmd.Parameters.AddWithValue("@ID_Nivel2", ID_nivel2);
        addCmd.ExecuteNonQuery();
        con.Close();

    }
    //Metodo que inserta nivel3 en  registro en Ubidisp cuando ya se inserto nivel2 y nivel1

    public void InsertarNivel3Ubidisp()
    {

        SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn1.Open();
        string cli = Clientes.SelectedValue;
        string nivel1 = "";
        string nivel2 = "";
        string id = null;
        string nivel3 = "";
        string UltReg = ("SELECT id,nivel1,nivel2,nivel3 FROM UbiDis where id = (SELECT MAX(ID) from UbiDis where Cl_Cliente=@cli)");
        SqlCommand cmU = new SqlCommand(UltReg, cn1);
        cmU.Parameters.AddWithValue("@cli", cli);
        SqlDataReader dr2 = cmU.ExecuteReader();
        if (dr2.Read())
        {
            nivel1 = Convert.ToString(dr2["nivel1"]);
            nivel2 = Convert.ToString(dr2["nivel2"]);
            nivel3 = Convert.ToString(dr2["nivel3"]);
            id = Convert.ToString(dr2["id"]);
        }
        cn1.Close();
        if (nivel3 == null || nivel3 == "")
        {

            SqlConnection cnNivel13 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            cnNivel13.Open();
            string IdN3 = null;
            string Nivel2 = ("select top 1 Nivel3.ID from Nivel3,Nivel2,Nivel1 WHERE Nivel3.ID_nivel2=Nivel2.ID and Nivel2.ID_nivel1=Nivel1.ID and Nivel1.ID_Cliente=@cli order by Nivel3.ID Desc");
            SqlCommand cmdNivel3 = new SqlCommand(Nivel2, cnNivel13);
            cmdNivel3.Parameters.AddWithValue("@cli", cli);
            SqlDataReader drNivel13 = cmdNivel3.ExecuteReader();
            if (drNivel13.Read())
            {
                IdN3 = Convert.ToString(drNivel13[0]);
            }
            cnNivel13.Close();
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updateCmd = "UPDATE UbiDis SET nivel3 ='" + IdN3 + "'  WHERE ID = '" + id + "'";
            SqlCommand cmd1 = new SqlCommand(updateCmd, con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }
        else
        {
            InsertarNivel3Nivel1Nuevos();
        }

    }

    //Metodo que inserta el nivel3,nivel2 y nivel1 desde el formulario del nivel3
    public void InsertarNivel3Nivel1Nuevos()
    {
        SqlConnection cnNivel3 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cnNivel3.Open();
        string IdN1 = null;
        string IdN2 = null;
        string IdN3 = null;
        string cli = Clientes.SelectedValue;
        string Nivel3 = ("select top 1 Nivel3.ID,Nivel2.ID,Nivel1.ID from Nivel3,Nivel2,Nivel1 WHERE Nivel3.ID_nivel2=Nivel2.ID and Nivel2.ID_nivel1=Nivel1.ID and Nivel1.ID_Cliente=@cli order by Nivel3.ID Desc");
        SqlCommand cmdNivel3 = new SqlCommand(Nivel3, cnNivel3);
        cmdNivel3.Parameters.AddWithValue("@cli", cli);
        SqlDataReader drNivel3 = cmdNivel3.ExecuteReader();
        if (drNivel3.Read())
        {
            IdN3 = Convert.ToString(drNivel3[0]);
            IdN2 = Convert.ToString(drNivel3[1]);
            IdN1 = Convert.ToString(drNivel3[2]);
        }
        cnNivel3.Close();

        string conStringN = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conN = new SqlConnection(conStringN);
        conN.Open();
        string updateCmdN = ("INSERT INTO UbiDis(Cl_Cliente, Cl_Sitio, nivel1)SELECT ID_Cliente, UbiDispo, ID FROM Nivel1 where id = '" + IdN1 + "'");
        SqlCommand cmd1N = new SqlCommand(updateCmdN, conN);
        cmd1N.ExecuteNonQuery();
        conN.Close();

        string conStringUpdate = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conUpd = new SqlConnection(conStringUpdate);
        conUpd.Open();
        string updateCmdNiv = "UPDATE UbiDis SET nivel2 ='" + IdN2 + "',nivel3='" + IdN3 + "'  WHERE ID = (SELECT MAX(ID) from UbiDis where Cl_Cliente =@cli)";
        SqlCommand cmd1Niv = new SqlCommand(updateCmdNiv, conUpd);
        cmd1Niv.ExecuteNonQuery();
        conUpd.Close();

    }


    /*Metodo para llenar el DROPDOWLISTA DE los niveles2 EN el formulario del NIVEL 3 */
    public void CargaUbicacionNivel2()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        string cli = Clientes.SelectedValue;
        cn.Open();
        SqlCommand cms = new SqlCommand("select Nivel2.ID,Nivel2.Nombre2 from Nivel1,Nivel2 where Nivel1.ID = Nivel2.ID_nivel1 and Nivel1.ID_Cliente =@cli order by Nivel2.ID desc", cn);
        cms.Parameters.AddWithValue("@cli", cli);
        SqlDataReader drs = cms.ExecuteReader();
        UbiNiv2.DataSource = drs;
        UbiNiv2.DataTextField = "Nombre2";
        UbiNiv2.DataValueField = "ID";
        UbiNiv2.DataBind();

    }
    //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
    //Metodos para insertar un nuevo nivel Nivel 4
    //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

    /*Metodo que re direcciona al formulario para insertar nuevo nivel4 dando click en el boton Nivel4*/
    protected void BtnAddClickNivel4(object sender, EventArgs e)
    {
        CargaUbicacionNivel3();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModalNivel4').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
    }
    //Metodo que realiza las funcienes requeridas para insertar en nivel 4
    protected void BtnAddRecordClickNivel4(object sender, EventArgs e)
    {
        string nombre = txtNom4.Text;
        string descripcion = txtDescripcion4.Text;
        int ID_nivel3 = Convert.ToInt32(UbiNiv3.Text);
        ExecuteAddNiv4(nombre, descripcion, ID_nivel3);
       InsertarNivel4Ubidisp();
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModalNivel4').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

    }
    //Metodo que contiene el query para insertar los resgistros en nivel4
    private void ExecuteAddNiv4(string nombre, string descripcion, int ID_nivel3)

    {

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "insert into Nivel4 (Nombre4, Descripcion,ID_nivel3) values (@Nombre,@Descripcion,@ID_Nivel3)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@Nombre", nombre);
        addCmd.Parameters.AddWithValue("@Descripcion", descripcion);
        addCmd.Parameters.AddWithValue("@ID_Nivel3", ID_nivel3);
        addCmd.ExecuteNonQuery();
        con.Close();

    }
    //Metodo que inserta nivel4 en  registro en Ubidisp cuando ya se inserto nivel3, nivel2 y nivel1

    public void InsertarNivel4Ubidisp()
    {
        
        SqlConnection cn4 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn4.Open();
        string id = null;
        string nivel4 = "";
        string cli = Clientes.SelectedValue;
        string UltReg4 = ("SELECT id,nivel1,nivel2,nivel3,nivel4 FROM UbiDis where id = (SELECT MAX(ID) from UbiDis where Cl_Cliente =@cli)");
        SqlCommand cmU = new SqlCommand(UltReg4, cn4);
        cmU.Parameters.AddWithValue("@cli", cli);
        SqlDataReader dr4 = cmU.ExecuteReader();
        if (dr4.Read())
        {
            nivel4 = Convert.ToString(dr4["nivel4"]);
            id = Convert.ToString(dr4["id"]);
        }
        cn4.Close();
        if (nivel4 == null || nivel4 == "")
        {

            SqlConnection cnNivel14 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            cnNivel14.Open();
            string IdN4 = null;
            string Nivel4 = ("SELECT TOP 1 Nivel4.ID FROM Nivel4, Nivel3,Nivel2,Nivel1 WHERE Nivel4.ID_nivel3=Nivel3.ID and Nivel3.ID_nivel2=Nivel2.ID and Nivel2.ID_nivel1=Nivel1.ID and Nivel1.ID_Cliente=@cli ORDER BY Nivel4.ID DESC");
            SqlCommand cmdNivel4 = new SqlCommand(Nivel4, cnNivel14);
            cmdNivel4.Parameters.AddWithValue("@cli", cli);
            SqlDataReader drNivel14 = cmdNivel4.ExecuteReader();
            if (drNivel14.Read())
            {
                IdN4 = Convert.ToString(drNivel14[0]);
            }
            cnNivel14.Close();
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updateCmd = "UPDATE UbiDis SET nivel4 ='" + IdN4 + "'  WHERE ID = '" + id + "'";
            SqlCommand cmd1 = new SqlCommand(updateCmd, con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }
        else
        {
            InsertarNivel4Nivel1Nuevos();
        }

    }
    //Metodo que inserta el nivel4, nivel3,nivel2 y nivel1 desde el formulario del nivel4
    public void InsertarNivel4Nivel1Nuevos()
    {
        SqlConnection cnNivel4 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cnNivel4.Open();
        string IdN1 = null;
        string IdN2 = null;
        string IdN3 = null;
        string IdN4 = null;
        string cli = Clientes.SelectedValue;
        string Nivel4 = ("SELECT TOP 1 Nivel4.ID, Nivel3.ID,Nivel2.ID,Nivel1.ID FROM Nivel4, Nivel3,Nivel2,Nivel1 WHERE Nivel4.ID_nivel3 = Nivel3.ID and Nivel3.ID_nivel2 = Nivel2.ID and Nivel2.ID_nivel1 = Nivel1.ID and Nivel1.ID_Cliente =@cli ORDER BY Nivel4.ID DESC");
        SqlCommand cmdNivel4 = new SqlCommand(Nivel4, cnNivel4);
        SqlDataReader drNivel4 = cmdNivel4.ExecuteReader();
        if (drNivel4.Read())
        {
            IdN4 = Convert.ToString(drNivel4[0]);
            IdN3 = Convert.ToString(drNivel4[1]);
            IdN2 = Convert.ToString(drNivel4[2]);
            IdN1 = Convert.ToString(drNivel4[3]);
        }
        cnNivel4.Close();

        string conStringN4 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conN4 = new SqlConnection(conStringN4);
        conN4.Open();
        string updateCmdN4 = ("INSERT INTO UbiDis(Cl_Cliente, Cl_Sitio, nivel1)SELECT ID_Cliente, UbiDispo, ID FROM Nivel1 where id = '" + IdN1 + "'");
        SqlCommand cmd1N4 = new SqlCommand(updateCmdN4, conN4);
        cmd1N4.ExecuteNonQuery();
        conN4.Close();

        string conStringUpdate = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conUpd = new SqlConnection(conStringUpdate);
        conUpd.Open();
        string updateCmdNiv = "UPDATE UbiDis SET nivel2 ='" + IdN2 + "',nivel3='" + IdN3 + "',nivel4='" + IdN4 + "'  WHERE ID = (SELECT MAX(ID) from UbiDis where Cl_Cliente =@cli)";
        SqlCommand cmd1Niv = new SqlCommand(updateCmdNiv, conUpd);
        cmd1Niv.Parameters.AddWithValue("@cli", cli);
        cmd1Niv.ExecuteNonQuery();
        conUpd.Close();

    }
    /*Metodo para llenar el DROPDOWLISTA DE los niveles3 EN el formulario del NIVEL 4 */
    public void CargaUbicacionNivel3()
    {
        string cli = Clientes.SelectedValue;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cms = new SqlCommand("select Nivel3.ID,Nivel3.Nombre3 from Nivel1,Nivel2,Nivel3 where Nivel3.ID_nivel2 = Nivel2.ID and Nivel2.ID_nivel1 = Nivel1.ID and Nivel1.ID_Cliente=@cli order by Nivel3.ID desc ", cn);
        cms.Parameters.AddWithValue("@cli", cli);
        SqlDataReader drs = cms.ExecuteReader();
        UbiNiv3.DataSource = drs;
        UbiNiv3.DataTextField = "Nombre3";
        UbiNiv3.DataValueField = "ID";
        UbiNiv3.DataBind();

    }
    //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
    //Metodos para insertar un nuevo nivel Nivel 5
    //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

    /*Metodo que re direcciona al formulario para insertar nuevo nivel5 dando click en el boton Nivel5*/
    protected void BtnAddClickNivel5(object sender, EventArgs e)
    {
        CargaUbicacionNivel4();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModalNivel5').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
    }

    //Metodo que realiza las funcienes requeridas para insertar en nivel 5
    protected void BtnAddRecordClickNivel5(object sender, EventArgs e)
    {
        string nombre = txtNom5.Text;
        string descripcion = txtDescripcion5.Text;
        int ID_nivel4 = Convert.ToInt32(UbiNiv4.Text);
        ExecuteAddNiv5(nombre, descripcion, ID_nivel4);
        InsertarNivel5Ubidisp();
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModalNivel5').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

    }
    //Metodo que contiene el query para insertar los resgistros en nivel5
    private void ExecuteAddNiv5(string nombre, string descripcion, int ID_nivel4)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "insert into Nivel5 (Nombre5, Descripcion,ID_nivel4) values (@Nombre,@Descripcion,@ID_Nivel4)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@Nombre", nombre);
        addCmd.Parameters.AddWithValue("@Descripcion", descripcion);
        addCmd.Parameters.AddWithValue("@ID_Nivel4", ID_nivel4);
        addCmd.ExecuteNonQuery();
        con.Close();

    }
    //Metodo que inserta nivel5 en  registro en Ubidisp cuando ya se inserto nivel4, nivel3, nivel2 y nivel1

    public void InsertarNivel5Ubidisp()
    {
        SqlConnection cn5 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn5.Open();
        string id = null;
        string nivel5 = "";
        string cli = Clientes.SelectedValue;
        string UltReg5 = ("SELECT id,nivel5 FROM UbiDis where id = (SELECT MAX(ID) from UbiDis where Cl_Cliente =@cli)");
        SqlCommand cmU = new SqlCommand(UltReg5, cn5);
        cmU.Parameters.AddWithValue("@cli", cli);
        SqlDataReader dr4 = cmU.ExecuteReader();
        if (dr4.Read())
        {
            nivel5 = Convert.ToString(dr4["nivel5"]);
            id = Convert.ToString(dr4["id"]);
        }
        cn5.Close();
        if (nivel5 == null || nivel5 == "")
        {

            SqlConnection cnNivel15 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            cnNivel15.Open();
            string IdN5 = null;
            string Nivel5 = ("SELECT TOP 1 Nivel5.ID FROM Nivel5,Nivel4,Nivel3,Nivel2,Nivel1 WHERE Nivel5.ID_nivel4=Nivel4.ID AND Nivel4.ID_nivel3=Nivel3.ID AND Nivel3.ID_nivel2= Nivel2.ID AND Nivel2.ID_nivel1=Nivel1.ID AND Nivel1.ID_Cliente=@cli ORDER BY Nivel5.ID DESC");
            SqlCommand cmdNivel5 = new SqlCommand(Nivel5, cnNivel15);
            cmdNivel5.Parameters.AddWithValue("@cli", cli);
            SqlDataReader drNivel15 = cmdNivel5.ExecuteReader();
            if (drNivel15.Read())
            {
                IdN5 = Convert.ToString(drNivel15[0]);
            }
            cnNivel15.Close();
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updateCmd = "UPDATE UbiDis SET nivel5 ='" + IdN5 + "'  WHERE ID = '" + id + "'";
            SqlCommand cmd1 = new SqlCommand(updateCmd, con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }
        else
        {
            InsertarNivel5Nivel1Nuevos();
        }

    }
    //Metodo que inserta el nivel5,nivel4, nivel3,nivel2 y nivel1 desde el formulario del nivel5
    public void InsertarNivel5Nivel1Nuevos()
    {
        string cli = Clientes.SelectedValue;
        SqlConnection cnNivel5 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cnNivel5.Open();
        string IdN1 = null;
        string IdN2 = null;
        string IdN3 = null;
        string IdN4 = null;
        string IdN5 = null;       
        string Nivel5 = ("SELECT TOP 1 Nivel5.ID,Nivel4.ID,Nivel3.ID,Nivel2.ID,Nivel1.ID FROM Nivel5,Nivel4,Nivel3,Nivel2,Nivel1 WHERE Nivel5.ID_nivel4=Nivel4.ID AND Nivel4.ID_nivel3=Nivel3.ID AND Nivel3.ID_nivel2= Nivel2.ID AND Nivel2.ID_nivel1=Nivel1.ID AND Nivel1.ID_Cliente=@cli ORDER BY Nivel5.ID DESC");
        SqlCommand cmdNivel5 = new SqlCommand(Nivel5, cnNivel5);
        cmdNivel5.Parameters.AddWithValue("@cli", cli);
        SqlDataReader drNivel5 = cmdNivel5.ExecuteReader();
        if (drNivel5.Read())
        {
            IdN5 = Convert.ToString(drNivel5[0]);
            IdN4 = Convert.ToString(drNivel5[1]);
            IdN3 = Convert.ToString(drNivel5[2]);
            IdN2 = Convert.ToString(drNivel5[3]);
            IdN1 = Convert.ToString(drNivel5[4]);
        }
        cnNivel5.Close();

        string conStringN5 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conN5 = new SqlConnection(conStringN5);
        conN5.Open();
        string updateCmdN5 = ("INSERT INTO UbiDis(Cl_Cliente, Cl_Sitio, nivel1)SELECT ID_Cliente, UbiDispo, ID FROM Nivel1 where id = '" + IdN1 + "'");
        SqlCommand cmd1N5 = new SqlCommand(updateCmdN5, conN5);
        cmd1N5.ExecuteNonQuery();
        conN5.Close();

        string conStringUpdate = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conUpd = new SqlConnection(conStringUpdate);
        conUpd.Open();
        string updateCmdNiv = "UPDATE UbiDis SET nivel2 ='" + IdN2 + "',nivel3='" + IdN3 + "',nivel4='" + IdN4 + "',nivel5='" + IdN5 + "'  WHERE ID = (SELECT MAX(ID) from UbiDis where Cl_Cliente =@cli)";
        SqlCommand cmd1Niv = new SqlCommand(updateCmdNiv, conUpd);
        cmd1Niv.Parameters.AddWithValue("@cli", cli);
        cmd1Niv.ExecuteNonQuery();
        conUpd.Close();

    }

    /*Metodo para llenar el DROPDOWLISTA DE los niveles3 EN el formulario del NIVEL 4 */
    public void CargaUbicacionNivel4()
    {
        string cli = Clientes.SelectedValue;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cms4 = new SqlCommand("SELECT Nivel4.ID,Nivel4.Nombre4 FROM Nivel1,Nivel2,Nivel3,Nivel4 WHERE Nivel4.ID_nivel3=Nivel3.ID AND Nivel3.ID_nivel2=Nivel2.ID AND Nivel2.ID_nivel1=Nivel1.ID AND Nivel1.ID_Cliente=@cli ORDER BY Nivel4.ID DESC", cn);
        cms4.Parameters.AddWithValue("@cli", cli);
        SqlDataReader drs = cms4.ExecuteReader();
        UbiNiv4.DataSource = drs;
        UbiNiv4.DataTextField = "Nombre4";
        UbiNiv4.DataValueField = "ID";
        UbiNiv4.DataBind();
    }


    //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
    //Metodos para Asiganar dispositivos a una Ubicacion
    //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm


    /*Metodo que contiene la vista, actualizacion y o eliminacion de una fila segun sea el evento, atraves de un modal.*/
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("detail"))
        {
            string IdEvento = GridView1.DataKeys[index].Value.ToString();
            IEnumerable<DataRow> query = from UbiDis in dt.AsEnumerable()
                                         where UbiDis.Field<String>("ID").Equals(ID)
                                         select UbiDis;
            DataTable GridView1Table = query.CopyToDataTable<DataRow>();
            GridView1.DataSource = GridView1Table;
            GridView1.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type= 'text/javascript'>");
            sb.Append("$('detailmodal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DetailmodalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("dispositivosrecord"))
        {
            GridViewRow gvrow = GridView1.Rows[index];

            lblUbiDis1.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            lblResultt.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModalDars').modal('show');");
            CargaDispositivos();
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }
        else if (e.CommandName.Equals("Consulta"))
        {
            string id = GridView1.DataKeys[index].Value.ToString();
            hfID.Value = id;
            int Ids = Convert.ToInt32(hfID.Value);
            SqlCommand cmd = new SqlCommand("select distinct D.Descripcion from DARS D, UbiDis U, Nivel1 N, Sitios S, Clientes Cl where D.UbiDis = U.Id and U.nivel1 = N.ID and  S.Id_cliente = Cl.ID and U.Id = @id", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@id", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView2.DataSource = ds;
                GridView2.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView2.Rows[0].Cells.Clear();
                GridView2.Rows[0].Cells.Add(new TableCell());
                GridView2.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView2.Rows[0].Cells[0].Text = "No se encontraron Registros";
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#consultaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);

        }

    }

    protected void BtnSave_ClickDis(object sender, EventArgs e)
    {
        string idUbiDisp = lblUbiDis1.Text;
        string dispositivo = Dispositivos.Text;
       
        ArrayList list = new ArrayList();

        ExecuteUpdateS(idUbiDisp, dispositivo);
        ConsultarScriptsParaJS(dispositivo, Convert.ToInt32(idUbiDisp));
        //CrearArchivoBAT(Convert.ToInt32(idUbiDisp), dispositivo);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModalDars').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    }

    protected void CrearArchivoBAT(int UbiDis, string dispositivo) {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        conn.Open();
        string clientes = ("select s.NOIP, d.RISCEI , e.Comando from Sitios s, eventos e, dars d where s.ID=(Select Cl_Sitio from UbiDis " +
            "where ID=@ubidis) and d.RISCEI=@dispositivo and d.Modelo=e.Modelo");
        SqlCommand cmd = new SqlCommand(clientes, conn);
        cmd.Parameters.AddWithValue("@ubidis", UbiDis);
        cmd.Parameters.AddWithValue("@dispositivo", dispositivo);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            string[] lista = new string [3];
            lista[0] = Convert.ToString(dr[0]);
            lista[1] = Convert.ToString(dr[1]);
            lista[2] = Convert.ToString(dr[2]);
            string rutaCompleta = @"C:\Scripts\"+lista[1]+lista[2]+".vbs";
            string texto = "objShell.Run \"curl "+lista[0]+"/"+lista[1]+"/"+lista[2]+"\",vbhide";

            using (StreamWriter file = new StreamWriter(rutaCompleta, true))
            { 
                file.WriteLine("Set objShell = CreateObject(\"WScript.Shell\")"); //se agrega información al documento
                file.WriteLine(texto);
                file.Close();
            }
            
            cn.Open();
            string updateCmd = "insert into BAT (RISCEI, Comando, URL) values(@riscei, @comando, @url)";
            SqlCommand updatecmd = new SqlCommand(updateCmd, cn);
            updatecmd.Parameters.AddWithValue("@riscei", lista[1]);
            updatecmd.Parameters.AddWithValue("@comando", lista[2]);
            updatecmd.Parameters.AddWithValue("@url", rutaCompleta);
            updatecmd.ExecuteNonQuery();
            cn.Close();
        }
        conn.Close();

       
    }
    /*Ejecuta el evento de actualizado a la base de datos*/
    private void ExecuteUpdateS(string idUbiDisp, string dispositivo)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE DARS SET UbiDis=@idUbiDisp WHERE RISCEI=@dispositivo";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@idUbiDisp", idUbiDisp);
        updatecmd.Parameters.AddWithValue("@dispositivo", dispositivo);
        updatecmd.ExecuteNonQuery();
        con.Close();

    }

    public void CargaDispositivos()
    {
        string cli = Clientes.SelectedValue;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand consultaDisp = new SqlCommand("select RISCEI,Descripcion from DARS where ID_Cliente =@cli and UbiDis is null", cn);
        consultaDisp.Parameters.AddWithValue("@cli", cli);
        SqlDataReader drs = consultaDisp.ExecuteReader();
        Dispositivos.DataSource = drs;
        Dispositivos.DataTextField = "Descripcion";
        Dispositivos.DataValueField = "RISCEI";
        Dispositivos.DataBind();
        cn.Close();
    }

    /*
     * Dentro del update del script de javascript de la tabal Scripts tomar encuenta lo siguiente:
     * En la seccion de las peticiones sobre las acciones van en base al orden la base de datos 
     * de la tabla eventos
     * */
    protected void ConsultarScriptsParaJS(string dispositivo, int ubi)
    {

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        int coun = 0;
        string[,] dar = null;
        string jsscr = null;
        string jsscd = null;
        string jscli = null;
      ;
        string riscei = null;
        string modelo = null;
        ArrayList list = new ArrayList();
        string ip = ConsultarNoip(ubi);
        SqlCommand cmd = new SqlCommand("SELECT  idscript  FROM Scripts where estatus  = 'Comprado' and idscript = @dispositivo", con);
        cmd.Parameters.AddWithValue("@dispositivo",dispositivo);
        SqlDataReader dr = cmd.ExecuteReader();
        int i = 0;
        while (dr.Read())
        {
            riscei = Convert.ToString(dr[0]);


            string conString1 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString1);
            string conString2 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con2 = new SqlConnection(conString2);
            string conString3 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con3 = new SqlConnection(conString2);
            string conString4 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con4 = new SqlConnection(conString2);
            con1.Open();
            con2.Open();
            con3.Open();
            con4.Open();

            modelo = ConsultarModelo(riscei);

            list = ConsultarAcciones(modelo);
            if (modelo == "DAR-BIS-VA/LE/LU/LS" || modelo == "DAR-BIS-HW")  
            {
                 jsscr = "<script type = 'text/javascript' >" +
                 "$(document).ready(function() {" +
                 "$('.C" + riscei + "').click(function() {" +
                 "var xhr = new XMLHttpRequest();" +
                 "var c3 = document.getElementById('R" + riscei + "').checked;" +
                 "if (c3 === true){" +
                "xhr.open('GET', 'https://addar.mx/Especiales/peticion2.php?v1=" + ip + "&v2=" + riscei + "&v3=" + list[1] + "', true);" +
                 "xhr.send();" +
                 "function processRequest(e){" +
                 "if (xhr.readyState == 4 && xhr.status == 200){" +
                 "alert(xhr.response.ip); }}" +
                 "}else if (c3 === false){" +
                "xhr.open('GET', 'https://addar.mx/Especiales/peticion2.php?v1=" + ip + "&v2=" + riscei + "&v3=" + list[0] + "', true);" +
                 "xhr.send();" +
                 "function processRequest(e){" +
                 "if (xhr.readyState == 4 && xhr.status == 200){" +
                 "alert(xhr.response.ip); }}" +
                 "}});});" +
                 "$(window).load(function() {" +
       "var xhr1 = new XMLHttpRequest();" +
              "$('#F" + riscei + "').draggable({" +
           "drag: function() {" +
               "var offset = $(this).offset();" +
               "var xpos;" +
               "var ypos;" +
               "xpos = offset.left;" +
               "ypos = offset.top;" +
           "}," +
                "stop: function() {" +
               "var finalOffset = $(this).offset();" +
               "var riscei = '" + riscei + "';" +
               "var finalxPos = finalOffset.left;" +
               "var finalyPos = finalOffset.top;" +
               "console.log(' '+finalxPos+' '+finalyPos);" +
               "xhr1.open('GET', 'https://addar.mx/mapService?funcion=2a&riscei=' + riscei + '&posX=' + finalOffset.left + '&posY=' + finalOffset.top, true);" +
               "xhr1.onreadystatechange = function() {" +
                   "if (xhr1.readyState == 4 && xhr1.status == 200) { }" +
               "};" +
               "xhr1.send();" +
           "}" +
       "});" +
   "});" +
       " </script>";

                jscli = "<script type = 'text/javascript' >" +
                     "$(document).ready(function() {" +
                     "$('.C" + riscei + "').click(function() {" +
                     "var xhr = new XMLHttpRequest();" +
                     "var c3 = document.getElementById('R" + riscei + "').checked;" +
                     "if (c3 === true){" +
                    "xhr.open('GET', 'https://addar.mx/Especiales/peticion2.php?v1=" + ip + "&v2=" + riscei + "&v3=" + list[1] + "', true);" +
                     "xhr.send();" +
                     "function processRequest(e){" +
                     "if (xhr.readyState == 4 && xhr.status == 200){" +
                     "alert(xhr.response.ip); }}" +
                     "}else if (c3 === false){" +
                    "xhr.open('GET', 'https://addar.mx/Especiales/peticion2.php?v1=" + ip + "&v2=" + riscei + "&v3=" + list[0] + "', true);" +
                     "xhr.send();" +
                     "function processRequest(e){" +
                     "if (xhr.readyState == 4 && xhr.status == 200){" +
                     "alert(xhr.response.ip); }}" +
                     "}});});" +
                    " </script>";


                string updateCmd = "UPDATE Scripts SET sjs=@jsscr WHERE idscript=@riscei";
                string updateCliCmd = "UPDATE ScriptsCliente SET jscli=@jscli WHERE idscriptcli=@riscei";
                SqlCommand cmd1 = new SqlCommand(updateCmd, con1);
                SqlCommand cmd2 = new SqlCommand(updateCliCmd, con2);
                cmd1.Parameters.AddWithValue("@jsscr", jsscr);
                cmd2.Parameters.AddWithValue("@jscli", jscli);
                cmd1.Parameters.AddWithValue("@riscei", riscei);
                cmd2.Parameters.AddWithValue("@riscei", riscei);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                con1.Close();
                con2.Close();
            }
            else if(modelo == "DAR" || modelo == "DAR-BIS-BP/MG" || modelo == "DAR-BIS-SU/HS" || modelo == "DAR-BIS-MV/SP/HU" || modelo == "DAR-BIS-AL" || modelo == "DAR-BIS-ED" ||
                    modelo == "DAR-BIS-P1" || modelo == "DAR-BIS-CP" || modelo == "DAR-BIS-MP" || modelo == "DAR-BIS-RF/HD" || modelo == "DAR-BIS-TH" || modelo == "DAR-BIS-SC")
            {
                jsscd = "<script type = 'text/javascript' >" +
                  "$(window).load(function() {" +
        "var xhr1 = new XMLHttpRequest();" +
               "$('#F" + riscei + "').draggable({" +
            "drag: function() {" +
                "var offset = $(this).offset();" +
                "var xpos;" +
                "var ypos;" +
                "xpos = offset.left;" +
                "ypos = offset.top;" +
            "}," +
                 "stop: function() {" +
                "var finalOffset = $(this).offset();" +
                "var riscei = '" + riscei + "';" +
                "var finalxPos = finalOffset.left;" +
                "var finalyPos = finalOffset.top;" +
                "console.log(' '+finalxPos+' '+finalyPos);" +
                "xhr1.open('GET', 'https://addar.mx/mapService?funcion=2a&riscei=' + riscei + '&posX=' + finalOffset.left + '&posY=' + finalOffset.top, true);" +
                "xhr1.onreadystatechange = function() {" +
                    "if (xhr1.readyState == 4 && xhr1.status == 200) { }" +
                "};" +
                "xhr1.send();" +
            "}" +
        "});" +
    "});" +
        " </script>";

            

                jscli = "";

                string updateCmd = "UPDATE Scripts SET sjs=@jsscd WHERE idscript=@riscei";
                string updateCliCmd = "UPDATE ScriptsCliente SET jscli=@jscli WHERE idscriptcli=@riscei";
                SqlCommand cmd3 = new SqlCommand(updateCmd, con3);
                SqlCommand cmd4 = new SqlCommand(updateCliCmd, con4);
                cmd3.Parameters.AddWithValue("@jsscd", jsscd);
                cmd4.Parameters.AddWithValue("@jscli", jscli);
                cmd3.Parameters.AddWithValue("@riscei", riscei);
                cmd4.Parameters.AddWithValue("@riscei", riscei);
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                con3.Close();
                con4.Close();
            }
          
        }
        con.Close();
    }
    protected string ConsultarNoip(int ubi)
    {
        string ip = null;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string noip = "if(select MultipleNOIP from Sitios where ID=(select Cl_Sitio from UbiDis where ID=@ubi)) = 0 " +
            "begin select s.NOIP from Sitios s where ID = (select Cl_Sitio from UbiDis where ID = @ubi) end " +
            "else select n1.NOIP from Nivel1 n1 where ID = (select Nivel1 from UbiDis where ID = @ubi)";
        SqlCommand cmd = new SqlCommand(noip, con);
        cmd.Parameters.AddWithValue("@ubi", ubi);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            ip = Convert.ToString(dr[0]);
            //  Response.Write(ip);
        }
        con.Close();
        return ip;
    }
    protected string ConsultarModelo(string riscei)
    {
        string modelo = null;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string model = "select modelo from dars where riscei = @riscei";
        SqlCommand cmd = new SqlCommand(model, con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            modelo = Convert.ToString(dr[0]);
            modelo = Convert.ToString(dr[0]);
            // Response.Write(modelo);
        }
        con.Close();
        return modelo;
    }

    protected ArrayList ConsultarAcciones(string modelo)
    {
        ArrayList acciones = new ArrayList();
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string model = "select comando from Eventos where Modelo = @modelo";
        SqlCommand cmd = new SqlCommand(model, con);
        cmd.Parameters.AddWithValue("@modelo", modelo);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            acciones.Add(Convert.ToString(dr[0]));
            // Response.Write(acciones);
        }
        con.Close();
        return acciones;
    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

    {

        GridView1.PageIndex = e.NewPageIndex;

        this.BindGrid();

    }


    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.BindGrid();

    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string id = hfID.Value;
        ExecuteDelete(id);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registo con dependencias');");
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
            string updatecmd = "delete from dbo.AspeNetRoles where Id=@id";
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

    protected DataSet Consultar(string consulta)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand(consulta, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }

    protected void CargaCliente()
    {
        Clientes.DataSource = Consultar("SELECT * FROM CLIENTES ");
        Clientes.DataValueField = "ID";
        Clientes.DataTextField = "RazonSocial";
        Clientes.DataBind();
        Clientes.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Sitio.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
       
    }

    protected void CargaSitio(object sender, EventArgs e)
    {
        int cliente = Convert.ToInt32(Clientes.SelectedValue);
        Sitio.DataSource = Consultar("Select * FROM Sitios Where ID_cliente =" + cliente);
        Sitio.DataValueField = "ID";
        Sitio.DataTextField = "C_Sitio";
        Sitio.DataBind();
        Sitio.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

    }

}