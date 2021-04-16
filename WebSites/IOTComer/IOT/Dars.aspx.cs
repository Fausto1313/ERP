using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dars : System.Web.UI.Page
{
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 20;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario,0) == "RISC")
        {
           if(!IsPostBack){
             CargaModelo();
            //Response.Write("<script language=\"javascript\">alert(\"Página en proceso de produccion\");</script>");
            CargaModelo2();
            CargaClientes();
            cargaClientes2();
           }
            BindGrid();
        }
        else if (permiso.returnPermiso(usuario, pantalla) == "DARS")
            {
                BindGrid2();
            }
        else
            Response.Redirect("~/IOT/Home");
    }
    public void BindGrid2()


    {
        string cli = Cli.SelectedValue;
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "SELECT  d.RISCEI, d.descripcion, c.RazonSocial, d.modelo from DARS d inner join Clientes c on d.ID_Cliente = c.ID ";
                cmd.Parameters.AddWithValue("@cli", cli);
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {



                    sql += "Where ( d.RISCEI LIKE '%' + @Busqueda + '%' OR d.descripcion LIKE '%' + @Busqueda + '%' OR c.RazonSocial LIKE '%' + @Busqueda + '%' OR d.modelo LIKE '%' + @Busqueda + '%' AND id=@cli)";
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
        public void BindGrid()
    {
        string cli = Cli.SelectedValue;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select d.RISCEI, d.descripcion, c.RazonSocial, d.modelo from DARS d inner join Clientes c on d.ID_Cliente = c.ID where id=@cli", conn);
        cmd.Parameters.AddWithValue("@cli", cli);
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

    /*Metodo que contiene la vista, actualizacion y o eliminacion de una fila segun sea el evento, atraves de un modal.*/
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("detail"))
        {
            string IdEvento = GridView1.DataKeys[index].Value.ToString();
            IEnumerable<DataRow> query = from DARS in dt.AsEnumerable()
                                         where DARS.Field<String>("ID").Equals(ID)
                                         select DARS;
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

            txtRISCEI.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            txtDescripcion.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
            lblResult.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "upModalScript", sb.ToString(), false);

        }
        else if (e.CommandName.Equals("clienterecord"))
        {
            GridViewRow gvrow = GridView1.Rows[index];

            lblRisc1.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
            //txtcliente.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            lblResultt.Visible = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updModalc').modal('show');");
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
    private void ExecuteDelete(string id)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string updatecmd = "delete from dars where RISCEI = @id";
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
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string id = hfID.Value;
        ExecuteDelete(id);
        BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registo Eliminado');");
        sb.Append("$('#eliminaModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
    }


    /*Recoge el id donde se da click en el evento actualizar lo guarda y envia*/
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string id = txtRISCEI.Text;

        string descripcion = txtDescripcion.Text;
 
        string modelo = Modelo2.Text;
        ExecuteUpdate(id, descripcion,  modelo);
        //BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    }
    /*Ejecuta el evento de actualizado a la base de datos*/
    private void ExecuteUpdate(string id, string descripcion, string modelo)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE DARS SET RISCEI=@id, Descripcion=@descripcion, Modelo=@modelo WHERE RISCEI=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@descripcion", descripcion);
      
        updatecmd.Parameters.AddWithValue("@modelo", modelo);
        updatecmd.ExecuteNonQuery();
        con.Close();

    }
    protected void BtnSave_ClickS(object sender, EventArgs e)
    {
        string id = lblRisc1.Text;
        int cliente = Convert.ToInt32(Clientes.Text);
        ExecuteUpdateS(id, cliente);
        //BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro actualizado exitosamente');");
        sb.Append("$('#updModalc').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

    }
    /*Ejecuta el evento de actualizado a la base de datos*/
    private void ExecuteUpdateS(string id, int cliente)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updateCmd = "UPDATE DARS SET ID_Cliente=@cliente WHERE RISCEI=@id";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@id", id);
        updatecmd.Parameters.AddWithValue("@cliente", cliente);
        updatecmd.ExecuteNonQuery();
        con.Close();

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

        string RISCEI = txtTipo1.Text;
        string descripcion = txtDescripcion1.Text;
        int cliente = 7023;
        string modelo = Modelo.Text;
        string htmltoogle = null;
        string htmlNoaction = null;
        string csstoggle = null;
        string cssNoaction = null;
        string jsscr = null;
        string jsscd = null;
        ArrayList list = new ArrayList();

        string familia = Family(RISCEI);
        string icono = icon(familia);
        //ExecuteAdd(RISCEI, descripcion, cliente, modelo);
        csstoggle = "<style type='text/css'>" +
                           "#F" + RISCEI + " {position: relative; z-index:10;  float: left; opacity: 1;" +
                           "transition: opacity 1.5s linear;  -webkit-transition: opacity 0.5s linear; cursor: pointer; border: 0px; " +
                           "width: 15px; height: 15px; display: block;  background: #fff;    border-radius: 50%;" +
                           " text-align: center;  line-height: 15px; font-size: 15px;  color: #777;" +
                           "box-shadow: 0 12px 30px rgba(255,0,255,0.7); }" +
                           "#R" + RISCEI + ":checked + #F" + RISCEI + " {background: #eee; box-shadow: inset 0 12px 35px rgba(0,0,0,0.5);" +
                           " color: rgba(0,255,0,0.8); transition: opacity 0.5s linear; -webkit-transition: opacity 0.5s linear;" +
                           " opacity: 1.8;}" +
                           "</style>";
        htmltoogle = "<div class=\"context-menu-one\">" +
                     "<input type='checkbox' id='R" + RISCEI + "' onclick='checkFluency(this.id)'" + RISCEI + "' class='C" + RISCEI + "' style='display:none;'/>" +
                     "<label for='R" + RISCEI + "' id='F" + RISCEI + "' class='" + icono + "' title='" + descripcion + "'></label>" +
                     "</div>";

        jsscr = "";

        htmlNoaction = "<div class=\"context-menu-one\">" +
                        "<input type='checkbox' onclick='return false;' id='R" + RISCEI + "' onclick='checkFluency(this.id)'" + RISCEI + "' class='C" + RISCEI + "' style='display:none;'/>" +
                        "<label for='R" + RISCEI + "' id='F" + RISCEI + "' class='" + icono + "' title='" + descripcion + "'></label>" +
                        "</div>";
        cssNoaction = "<style type='text/css'>" +
                           "#F" + RISCEI + " {position: relative; z-index:10;  float: left; opacity: 1;" +
                           "transition: opacity 1.5s linear;  -webkit-transition: opacity 0.5s linear; cursor: pointer; border: 0px; " +
                           "width: 15px; height: 15px; display: block;  background: #fff;    border-radius: 50%;" +
                           " text-align: center;  line-height: 15px; font-size: 15px;  color: #777;" +
                           "box-shadow: 0 12px 30px rgba(255,0,255,0.7); }" +
                           "#R" + RISCEI + ":checked + #F" + RISCEI + " {background: #eee; box-shadow: inset 0 12px 35px rgba(0,0,0,0.5);" +
                           " color: rgba(0,0,255,0.8); transition: opacity 0.5s linear; -webkit-transition: opacity 0.5s linear;" +
                           " opacity: 1.8;}" +
                           "</style>";
 
        jsscd = "";

        list = ConsultarAcciones(modelo);
        /* SENSORES ACTUADORES ***************************************************************************************************/
        if (modelo == "DAR-BIS-VA/LE/LU/LS") /*Luces-LEDS-Ventilador*/
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
            insertarScripts(RISCEI, htmltoogle, csstoggle, jsscr);
            insertarScriptsClientes(RISCEI, htmltoogle, csstoggle, jsscr);
        }
        else if (modelo == "DAR-BIS-HW") /*Aire acondicionado*/
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
            insertarScripts(RISCEI, htmltoogle, csstoggle, jsscr);
            insertarScriptsClientes(RISCEI, htmltoogle, csstoggle, jsscr);
        }
        else if (modelo == "DAR-BIS-MP") /*MP3*/
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
            insertarScripts(RISCEI, htmltoogle, csstoggle, jsscr);
            insertarScriptsClientes(RISCEI, htmltoogle, csstoggle, jsscr);
        }
        /* SENSORES SIN PETICIONES ***********************************************************************************************/
        else if (modelo == "DAR-BIS-P1") /*Puerta*/
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
            insertarScriptsNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
            insertarScriptsClientesNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
        }
        else if (modelo == "DAR-BIS-CP") /*Clapper*/
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
            insertarScriptsNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
            insertarScriptsClientesNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
        }
        else if (modelo == "DAR") /*DAR*/
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
            insertarScriptsNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
            insertarScriptsClientesNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
        }
        else if (modelo == "AL") /*Alarma*/
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
            insertarScriptsNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
            insertarScriptsClientesNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
        }
        else if (modelo == "ED") /*Expansor de dispositivos*/
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
            insertarScriptsNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
            insertarScriptsClientesNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
        }
        else if (modelo == "DAR-BIS-RF/HD") /*RFID y Huella Digital*/
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
            insertarScriptsNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
            insertarScriptsClientesNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
        }
        else if (modelo == "DAR-BIS-BP/MG") /*Boton de panico y sensor magnetico*/
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
            insertarScriptsNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
            insertarScriptsClientesNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
        }
        else if (modelo == "DAR-BIS-SU/HS") /*Sensor Ultrasonico y Humedad del suelo */
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
            insertarScriptsNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
            insertarScriptsClientesNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
        }
        else if (modelo == "DAR-BIS-TH") /*Sensor de Temperatura */
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
            insertarScriptsNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
            insertarScriptsClientesNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
        }
        else if (modelo == "DAR-BIS-SC") /*Sensor de corriente, Temperatura, Ultrasonico y Humedad del suelo */
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
            insertarScriptsNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
            insertarScriptsClientesNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
        }
        else if (modelo == "DAR-BIS-MV/SP/HU") /*Sensor de movimiento, Presencia y Humo*/
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
            insertarScriptsNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
            insertarScriptsClientesNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
        }
        else if (modelo == "DAR-BIS-CC") /*CAMARAS*/
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
            insertarScriptsNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
            insertarScriptsClientesNoaction(RISCEI, htmlNoaction, cssNoaction, jsscd);
        }
        else
        {
            ExecuteAdd(RISCEI, descripcion, cliente, modelo);
        }
        //BindGrid();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('Registro Agregado');");
        sb.Append("$('#addModal').modal('hide');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
        BindGrid();
    }

    private void ExecuteAdd(string RISCEI, string descripcion, int cliente, string modelo)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string updatecmd = "insert into DARS (RISCEI, Descripcion, ID_Cliente, Modelo) values (@RISCEI,@descripcion,@Cliente,@Modelo)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);

        addCmd.Parameters.AddWithValue("@RISCEI", RISCEI);
        addCmd.Parameters.AddWithValue("@descripcion", descripcion);
        addCmd.Parameters.AddWithValue("@cliente", cliente);
        addCmd.Parameters.AddWithValue("@modelo", modelo);

        addCmd.ExecuteNonQuery();
        con.Close();

    }


    protected void insertarScripts(string riscei, string htmltoogle, string csstoggle, string jsscr)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string risce = Convert.ToString(riscei);
        string insercmd = "insert into Scripts (idscript,shtml, scss,sjs,posx,posY,estatus ) values (@risce,@htmltoogle,@csstoggle,@jsscr, 0,0,'Comprado')";

        SqlCommand addCmd = new SqlCommand(insercmd, con);
        addCmd.Parameters.AddWithValue("@risce", risce);
        addCmd.Parameters.AddWithValue("@htmltoogle", htmltoogle);
        addCmd.Parameters.AddWithValue("@csstoggle", csstoggle);
        addCmd.Parameters.AddWithValue("@jsscr", jsscr);
        addCmd.ExecuteNonQuery();
        con.Close();
    }
    protected void insertarScriptsClientes(string riscei, string htmltoogle, string csstoggle, string jsscr)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string risce = Convert.ToString(riscei);
        string insercmd = "insert into ScriptsCliente (idscriptcli,htmlcli, csscli,jscli,posX,posY,estatus ) values (@risce,@htmltoogle,@csstoggle,@jsscr, 0,0,'Configurado')";

        SqlCommand addCmd = new SqlCommand(insercmd, con);
        addCmd.Parameters.AddWithValue("@risce", risce);
        addCmd.Parameters.AddWithValue("@htmltoogle", htmltoogle);
        addCmd.Parameters.AddWithValue("@csstoggle", csstoggle);
        addCmd.Parameters.AddWithValue("@jsscr", jsscr);
        addCmd.ExecuteNonQuery();
        con.Close();
    }

    protected void insertarScriptsNoaction(string riscei, string htmlNoaction, string cssNoaction, string jsscd)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string risce = Convert.ToString(riscei);
        string insercmd = "insert into Scripts (idscript,shtml, scss,sjs,posx,posY,estatus ) values (@risce,@htmlNoaction,@cssNoaction,@jsscd, 0,0,'Comprado')";

        SqlCommand addCmd = new SqlCommand(insercmd, con);
        addCmd.Parameters.AddWithValue("@risce", risce);
        addCmd.Parameters.AddWithValue("@htmlNoaction", htmlNoaction);
        addCmd.Parameters.AddWithValue("@cssNoaction", cssNoaction);
        addCmd.Parameters.AddWithValue("@jsscd", jsscd);
        addCmd.ExecuteNonQuery();
        con.Close();
    }
    protected void insertarScriptsClientesNoaction(string riscei, string htmlNoaction, string cssNoaction, string jsscd)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string risce = Convert.ToString(riscei);
        string insercmd = "insert into ScriptsCliente (idscriptcli,htmlcli, csscli,jscli,posX,posY,estatus ) values (@risce,@htmlNoaction,@cssNoaction,@jsscd, 0,0,'Configurado')";

        SqlCommand addCmd = new SqlCommand(insercmd, con);
        addCmd.Parameters.AddWithValue("@risce", risce);
        addCmd.Parameters.AddWithValue("@htmlNoaction", htmlNoaction);
        addCmd.Parameters.AddWithValue("@cssNoaction", cssNoaction);
        addCmd.Parameters.AddWithValue("@jsscd", jsscd);
        addCmd.ExecuteNonQuery();
        con.Close();
    }
    internal class Dispositivos
    {
        public string riscei { get; set; }
        public string nombre { get; set; }
        public string familia { get; set; }
        public string icono { get; set; }
    }

    protected string Family(string Modelo)
    {
        string model = string.Empty;

        if (Modelo.Contains("VA"))
            model = "Ventilador";
        else if (Modelo.Contains("LE"))
            model = "LEDS";
        else if (Modelo.Contains("LU"))
            model = "Luces";
        else if (Modelo.Contains("HW"))
            model = "Aire";
        else if (Modelo.Contains("BP"))
            model = "Panico";
        else if (Modelo.Contains("MG"))
            model = "Magnetico";
        else if (Modelo.Contains("MV"))
            model = "Movimiento";
        else if (Modelo.Contains("TH"))
            model = "Temperatura";
        else if (Modelo.Contains("HS"))
            model = "Humedad";
        else if (Modelo.Contains("SP"))
            model = "Presencia";
        else if (Modelo.Contains("HM"))
            model = "Humo";
        else if (Modelo.Contains("HD"))
            model = "Huella";
        else if (Modelo.Contains("RF"))
            model = "RFID";
        else if (Modelo.Contains("SC"))
            model = "Corriente";
        else if (Modelo.Contains("SU"))
            model = "UltraSonico";
        else if (Modelo.Contains("DA"))
            model = "DAR";
        else if (Modelo.Contains("P1"))
            model = "Puerta";
        else if (Modelo.Contains("MP"))
            model = "MP3";
        else if (Modelo.Contains("CC"))
            model = "CAM";
        else if (Modelo.Contains("LS"))
            model = "Escalera";    
        return model;
    }

    protected string icon(string family)
    {
        string icons = string.Empty;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select icono from Iconos where nombre=@family", conn);
        cmd.Parameters.AddWithValue("@family", family);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            icons = Convert.ToString(dr[0]);
        }
        conn.Close();
        return icons;
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
            //Response.Write(acciones);
        }
        con.Close();
        return acciones;
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //this.BindGrid();
    }

    public void CargaModelo()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT Modelo FROM Modelos", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        Modelo.DataSource = dr;
        Modelo.DataTextField = "Modelo";
        Modelo.DataValueField = "Modelo";
        Modelo.DataBind();
    }

    public void CargaClientes()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID, RazonSocial FROM Clientes  where ID != 2", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        Clientes.DataSource = dr;
        Clientes.DataTextField = "RazonSocial";
        Clientes.DataValueField = "ID";
        Clientes.DataBind();
    }
    
     public void cargaClientes2()
     {
         SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
         cn.Open();
         SqlCommand cmd = new SqlCommand("SELECT ID, RazonSocial FROM Clientes", cn);
         SqlDataReader dr = cmd.ExecuteReader();
         Cli.DataSource = dr;
         Cli.DataSource = dr;
         Cli.DataTextField = "RazonSocial";
         Cli.DataValueField = "ID";
         Cli.DataBind();
         Cli.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }

    public void CargaModelo2()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT  Modelo FROM Modelos", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        Modelo2.DataSource = dr;
        Modelo2.DataTextField = "Modelo";
        Modelo2.DataValueField = "Modelo";
        Modelo2.DataBind();
    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)

    {

        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid2();
        //this.BindGrid();

    }




    protected void Search(object sender, EventArgs e)
    {
        this.BindGrid2();
    }


   

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
      


    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }

  



}