using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI;
using System.Collections;
using System.Net;

public partial class IOT_ControlMultiBoton : System.Web.UI.Page
{
    
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 7;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Control de Botones")
        {
            BindGrid();
            if (!IsPostBack)
                CargaSitio();
        }
        else
            Response.Redirect("~/IOT/Home");
      
    }

    // Los métodos manejadores de eventos tienen una estructura muy sencilla.
    // Son métodos como cualquier otro, pero (habitualmente) tienen dos parámetros de entrada.
    // "sender" es el objeto que ha lanzado el evento. Deberemos parsearlo al tipo que nosotros consideremos.
    // "e" son los argumentos del evento. Deberemos parsearlos al tipo que consideremos si lo quisieramos usar.
   
    public void BindGrid()

    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#updModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        string usuario = User.Identity.Name;
        string cliente = null;
        string clientes = ("Select u.ID_Cliente from Clientes c, dbo.AspNetUsers u  where c.ID=u.ID_Cliente and u.UserName=@usuario");
        SqlCommand cmd = new SqlCommand(clientes, cn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            cliente = Convert.ToString(dr[0]);
        }
        cn.Close();



        SqlConnection cnNivel5 = new SqlConnection(conString);
        cnNivel5.Open();
        Button bt;
        Label lt;
        Literal lt1;
        Image img;
        ArrayList myAL = new ArrayList();
        //string sitio = 
        string Descripcion = null;
        string ubiDisp = (Nivel1.Text);
        string sitio = Sitio.SelectedValue;
        int n = 0;
        string Nivel5 = ("SELECT DARS.DESCRIPCION FROM DARS,UbiDis,Nivel1 where DARS.UbiDis = UbiDis.ID and DARS.Modelo='DAR-BIS-VA/LE/LU/LS' and UbiDis.Nivel1 = Nivel1.ID and UbiDis.Cl_Cliente = '" + cliente + "' and Nivel1.Nombre = '" + ubiDisp + "' and UbiDis.Cl_Sitio =@sitio");
        SqlCommand cmDars = new SqlCommand(Nivel5, cnNivel5);
        cmDars.Parameters.AddWithValue("@sitio", sitio);
        SqlDataReader drDars = cmDars.ExecuteReader();
        while (drDars.Read())
        {
            Descripcion = Convert.ToString(drDars[n]);

            myAL.Add(Descripcion);
        }
        cnNivel5.Close();

        SqlConnection cndars1 = new SqlConnection(conString);
        cndars1.Open();
        ArrayList myId = new ArrayList();
        string Dars = null;
        int d = 0;
        string Nivel6 = ("SELECT DARS.RISCEI FROM DARS,UbiDis,Nivel1 where DARS.UbiDis = UbiDis.ID and DARS.Modelo='DAR-BIS-VA/LE/LU/LS' and UbiDis.Nivel1 = Nivel1.ID and UbiDis.Cl_Cliente = '" + cliente + "' and Nivel1.Nombre = '" + ubiDisp + "'and UbiDis.Cl_Sitio =@sitio");
        SqlCommand cmDars1 = new SqlCommand(Nivel6, cndars1);
        cmDars1.Parameters.AddWithValue("@sitio", sitio);
        SqlDataReader drDars1 = cmDars1.ExecuteReader();
        while (drDars1.Read())
        {
            Dars = Convert.ToString(drDars1[d]);

            myId.Add(Dars);
        }
        cndars1.Close();

        int array = myAL.Count;
        int arrayDars = myId.Count;
        for (int i = 0; i < myAL.Count * 2; i++)
        {

            if (i % 2 == 0)
            {
                img = new Image();
                img.ID = "imagen" + i;
                img.ImageUrl = "~/iconos/red.png";
                img.Visible = true;
                // Inicializamos el botón
                bt = new Button();

                // Le asignamos un text
                bt.ID =myId[i/2]+"/ON";
                //bt.Text = myId[i] + "/ON";
                bt.Text = "ON";
                bt.CssClass = "btn btn-success";
               

                lt = new Label();
                lt.Text = " ";
                lt.BorderStyle = BorderStyle.Outset;
                String onCli = "Bt_Clic" + i;
                // Hacemos que maneje el evento Click mediante la función bt_Click
                bt.Click += new EventHandler(Bt_Click);
                // Ubicamos ambos controles en el PlaceHolder que hemos puesto en nuestra página
                // El uso del PlaceHolder no es obligatorio ni mucho menos, 
                // podéis añadir los controles donde os haga falta: 
                // una Cell de un Table, un Panel, a la propia Page, etc.

            }
            else
            {
                img = new Image();
                img.ID = "imagen" + i;
                img.ImageUrl = "~/iconos/green.png";
                img.Visible =false;
                // Inicializamos el botón
                bt = new Button();

                // Le asignamos un text
                bt.ID = myId[i-((i+1)/2)] + "/OFF";
                //bt.Text = myId[i - 1] + "/OFF";
                bt.Text = "OFF";
                bt.CssClass = "btn btn-default";
                //inicializamos la etiqueta 
               

                // Hacemos que maneje el evento Click mediante la función bt_Click
                bt.Click += new EventHandler(Bt_Click);
                // Inicializamos el literal y hacemos que sea un salto de línea HTML
                string desc = null;
              
                lt = new Label();
                desc = myAL[i / 2].ToString();
                lt.Text ="  "+desc+"<br/><br/>";
             

                // Ubicamos ambos controles en el PlaceHolder que hemos puesto en nuestra página
                // El uso del PlaceHolder no es obligatorio ni mucho menos, 
                // podéis añadir los controles donde os haga falta: 
                // una Cell de un Table, un Panel, a la propia Page, etc.


                //this.Page.Form.Controls.Add(bt);
            }
            

            PlaceHolder1.Controls.Add(bt);


//            PlaceHolder1.Controls.Add(img);
            PlaceHolder1.Controls.Add(lt);
        }


    }

   

     //Metodo que ejecuta las acciones dell onclick
    protected void Bt_Click(object sender, EventArgs e)
    {
        // Como sabemos que quien lanza el evento es un Button, lo parseamos y lo recogemos en una variable
        Button bt = (Button)sender;
        string dis = bt.ID + bt.Text, dispositivo = string.Empty;
        dispositivo = dis.Substring(0,10); 
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        string usuario = User.Identity.Name;
        string noip1 = null;
        
        string clientes = ("if(select s.MultipleNOIP from Sitios s inner join UbiDis u on u.Cl_Sitio=s.ID inner join DARS d " +
            "on d.UbiDis = u.Id where d.RISCEI = @riscei) = 0 " +
            "begin select S.NOIP from Sitios s inner join UbiDis u on u.Cl_Sitio = s.ID inner join DARS d " +
            "on d.UbiDis = u.Id where d.RISCEI = @riscei end else select n1.NOIP from Nivel1 n1 where ID = " +
            "(select u.Nivel1 from UbiDis u inner join DARS d on d.UbiDis = u.Id where d.RISCEI = @riscei)");
        SqlCommand cmd = new SqlCommand(clientes, cn);
        cmd.Parameters.AddWithValue("@riscei", dispositivo);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            noip1 = Convert.ToString(dr[0]);
        }
        cn.Close();

        // Ahora podemos hacer lo que creamos conveniente con el Button. Ej:
        string idButton = bt.ID;
        Label1.Text = "Has hecho click en el botón "+bt.ID;

        string noip = noip1;
        //string noip = "risc-iot.ddns.net:4041";
        
       // string funcion = "http://" + noip + "/1710LE2005/" + bt.Text;
            //String variable = funcion;
            irServicio(noip,dis, bt.Text);
        Image img;
        if (bt.Text == "ON")
        {
            img = new Image();
            img.ID = "imagen1";
            img.ImageUrl = "~/iconos/green.png";
            img.Visible = true;

            PlaceHolder2.Controls.Add(img);
        }
        else
        {
            img = new Image();
            img.ID = "imagen2";
            img.ImageUrl = "~/iconos/red.png";
            img.Visible = true;
            PlaceHolder2.Controls.Add(img);
        }

    }
   
    //Metodo que me permite seleccionar y enviar unucamente el nivel del cual queremos ver los dispositivos que contiene el nivel
    public void GenerarBotones(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        cn.Open();
        string usuario = User.Identity.Name;
        string algo = null;
        string clientes = ("Select u.ID_Cliente from Clientes c, dbo.AspNetUsers u  where c.ID=u.ID_Cliente and u.UserName=@usuario");
        SqlCommand cmd = new SqlCommand(clientes, cn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            algo = Convert.ToString(dr[0]);
        }
        cn.Close();
        SqlConnection cnNivel5 = new SqlConnection(conString);
        cnNivel5.Open();
        string ubiDisp = (Nivel1.Text);

           }

    /* protected void irServicio(String variable)
     {
         WebRequest Peticion = default(WebRequest);
         Peticion = WebRequest.Create(variable);
         Peticion.GetResponseAsync();

     }*/
    protected void irServicio(string ip,string dispo, string accion)
    {
        string dis = string.Empty, url = string.Empty;
        dis = dispo.Substring(0, 10);
        WebRequest Peticion = default(WebRequest);
        url = "https://addar.mx/Especiales/peticion2.php?v1=" + ip + "&v2=" + dis + "&v3=" + accion;
        Peticion = WebRequest.Create(url);
        Peticion.GetResponseAsync();
    }

    //metodo que nos permite cargar los niveles de acuerdo al cliente
    //public void CargaUbicacionNivel1()
    //{
    //    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
    //    cn.Open();
    //    string usuario = User.Identity.Name;
    //    SqlCommand cms = new SqlCommand("select distinct Nivel1.Nombre from UbiDis,Nivel1 where UbiDis.nivel1=Nivel1.ID and Cl_Sitio=(select C_Sitio from AspNetUsers where UserName='" + usuario + "')",cn);
    //    SqlDataReader drs = cms.ExecuteReader();
    //    Nivel1.DataSource = drs;
    //    Nivel1.DataTextField = "Nombre";
    //    Nivel1.DataValueField = "Nombre";
    //    Nivel1.DataBind();
    //    cn.Close();
    //}
    protected void CargaSitio()
    {
        Sitio.DataSource = Consultar("if(select 1 from PermisoRol where ID_Permiso = 36 and ID_Rol = (select ID_Rol from AspNetUsers where UserName = @usuario)) = 1 " +
                                     "select id, C_Sitio from sitios where ID_cliente = (select id_cliente from AspNetUsers where UserName = @usuario) " +
                                     "else select id, C_Sitio from sitios where ID = (select C_Sitio from AspNetUsers where UserName = @usuario)");
        Sitio.DataValueField = "ID";
        Sitio.DataTextField = "C_Sitio";
        Sitio.DataBind();
        Sitio.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Nivel1.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }
    protected void CargaNivel()
    {
        string sit = Sitio.SelectedValue;
        string usuario = User.Identity.Name;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select distinct Nivel1.Nombre from UbiDis,Nivel1 where UbiDis.nivel1=Nivel1.ID and Cl_Sitio = (select C_Sitio from AspNetUsers where UserName =@usuario) and Nivel1.UbiDispo =@sit", conn);
        cmd.Parameters.AddWithValue("@sit", sit);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        Nivel1.DataSource = dr;
        Nivel1.DataTextField = "Nombre";
        Nivel1.DataValueField = "Nombre";
        Nivel1.DataBind();
        Nivel1.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

    }
    protected void Carga_select(object sender, EventArgs e)
    {
        CargaNivel();
    }

    protected DataSet Consultar(string consulta)
    {
        string usuario = Context.User.Identity.Name;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand(consulta, con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }

}
    