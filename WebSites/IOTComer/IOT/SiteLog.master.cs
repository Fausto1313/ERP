using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : MasterPage
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    protected void Page_Init(object sender, EventArgs e)
    {
        // The code below helps to protect against XSRF attacks
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    }

    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set Anti-XSRF token
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // Validate the Anti-XSRF token
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AppendHeader("Cache-Control", "no-store");
        Response.AppendHeader("Pragma", "no-cache");
        if (Session.IsNewSession)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/Account/Login");
        }
        Permisos permiso = new Permisos();
        if (!permiso.isCheckedAviso(Context.User.Identity.Name))
            Response.Redirect("~/IOT/AvisoPrivacidad");
        else
        {
            ConsultarIcono();
            checkPermisos();
        }
    }

    protected void checkPermisos() {
        string usuario = Context.User.Identity.GetUserName();
        int ide = -1;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand("select ID_Permiso from PermisoRol where ID_Rol = " +
            "(select ID_Rol from AspNetUsers where UserName = @usuario)", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ide = Convert.ToInt32(dr[0]);
            habilitaMenu(ide);
        }

    }

    protected void habilitaMenu(int id) {
        LoginView Logged = (LoginView)FindControl("barra");
        if (Logged != null)
        {
            switch (id) {
                case 0:
                    HyperLink clientes = (HyperLink)Logged.FindControl("ClientesP");
                    clientes.Visible = true;
                    HyperLink UsuariosClienteP = (HyperLink)Logged.FindControl("UsuariosClienteP");
                    UsuariosClienteP.Visible = true;
                    HyperLink RolClienteP = (HyperLink)Logged.FindControl("RolClienteP");
                    RolClienteP.Visible = true;
                    HyperLink ConfigurarPlanoP = (HyperLink)Logged.FindControl("ConfigurarPlanoP");
                    ConfigurarPlanoP.Visible = true;
                    HyperLink SubirPlanoP = (HyperLink)Logged.FindControl("SubirPlanoP");
                    SubirPlanoP.Visible = true;
                    HyperLink SitiosP = (HyperLink)Logged.FindControl("SitiosP");
                    SitiosP.Visible = true;
                    HyperLink DARSP = (HyperLink)Logged.FindControl("DARSP");
                    DARSP.Visible = true;
                    HyperLink ModelosP = (HyperLink)Logged.FindControl("ModelosP");
                    ModelosP.Visible = true;
                    HyperLink EventosP = (HyperLink)Logged.FindControl("EventosP");
                    EventosP.Visible = true;
                    HyperLink FabricantesP = (HyperLink)Logged.FindControl("FabricantesP");
                    FabricantesP.Visible = true;
                    HyperLink NivelesP = (HyperLink)Logged.FindControl("NivelesP");
                    NivelesP.Visible = true;
                    break;
                case 1:
                    HyperLink TelegramP = (HyperLink)Logged.FindControl("TelegramP");
                    TelegramP.Visible = true;
                    break;
                case 2:
                    HyperLink TelegramUsersP = (HyperLink)Logged.FindControl("TelegramUsersP");
                    TelegramUsersP.Visible = true;
                    break;
                case 3:
                    HyperLink UsuariosP = (HyperLink)Logged.FindControl("UsuariosP");
                    UsuariosP.Visible = true;
                    break;
                case 5:
                    HyperLink RolesP = (HyperLink)Logged.FindControl("RolesP");
                    RolesP.Visible = true;
                    break;
                case 6:

                    break;
                case 7:
                    HyperLink ControlMultibotonP = (HyperLink)Logged.FindControl("ControlMultibotonP");
                    ControlMultibotonP.Visible = true;
                    break;
                case 8:
                    HyperLink MisDispositivosP = (HyperLink)Logged.FindControl("MisDispositivosP");
                    MisDispositivosP.Visible = true;
                    break;
                case 9:
                    HyperLink ComandosAdministradorP = (HyperLink)Logged.FindControl("ComandosAdministradorP");
                    ComandosAdministradorP.Visible = true;
                    break;
                case 10:
                    HyperLink ComandosP = (HyperLink)Logged.FindControl("ComandosP");
                    ComandosP.Visible = true;
                    break;
                case 11:
                    HyperLink ProgramacionTareasP = (HyperLink)Logged.FindControl("ProgramacionTareasP");
                    ProgramacionTareasP.Visible = true;
                    break;
                case 12:
                    HyperLink ActivacionSistemaP = (HyperLink)Logged.FindControl("ActivacionSistemaP");
                    ActivacionSistemaP.Visible = true;
                    break;
                case 13:
                   
                    break;
                case 14:
                    HyperLink clientesP2 = (HyperLink)Logged.FindControl("ClientesP");
                    clientesP2.Visible = true;
                    break;
                case 15:
                    HyperLink usuariosCP = (HyperLink)Logged.FindControl("UsuariosClienteP");
                    usuariosCP.Visible = true;
                    break;
                case 16:
                    HyperLink RolClienteP2 = (HyperLink)Logged.FindControl("RolClienteP");
                    RolClienteP2.Visible = true;
                    break;
                case 17:
                    HyperLink ConfigurarPlanoP2 = (HyperLink)Logged.FindControl("ConfigurarPlanoP");
                    ConfigurarPlanoP2.Visible = true;
                    break;
                case 18:
                    HyperLink SubirPlanoP2 = (HyperLink)Logged.FindControl("SubirPlanoP");
                    SubirPlanoP2.Visible = true;
                    break;
                case 19:
                    HyperLink SitiosP2 = (HyperLink)Logged.FindControl("SitiosP");
                    SitiosP2.Visible = true;
                    break;
                case 20:
                    HyperLink DARSP2 = (HyperLink)Logged.FindControl("DARSP");
                    DARSP2.Visible = true;
                    break;
                case 21:
                    HyperLink ModelosP2 = (HyperLink)Logged.FindControl("ModelosP");
                    ModelosP2.Visible = true;
                    break;
                case 22:
                    HyperLink EventosP2 = (HyperLink)Logged.FindControl("EventosP");
                    EventosP2.Visible = true;
                    break;
                case 23:
                    HyperLink FabricantesP2 = (HyperLink)Logged.FindControl("FabricantesP");
                    FabricantesP2.Visible = true;
                    break;
                case 24:
                    HyperLink NivelesP2 = (HyperLink)Logged.FindControl("NivelesP");
                    NivelesP2.Visible = true;
                    break;
                case 27:
                    HyperLink AccionesP = (HyperLink)Logged.FindControl("DispositivosP");
                    AccionesP.Visible = true;
                    break;
                case 28:
                    HyperLink AmbienteP = (HyperLink)Logged.FindControl("AmbienteP");
                    AmbienteP.Visible = true;
                    break;
                case 29:
                    HyperLink SensoresP = (HyperLink)Logged.FindControl("SensoresP");
                    SensoresP.Visible = true;
                    break;
                case 30:
                    HyperLink HuellaDactilarP = (HyperLink)Logged.FindControl("HuellaDactilarP");
                    HuellaDactilarP.Visible = true;
                    break;
                case 31:
                    HyperLink ConteoPersonasP = (HyperLink)Logged.FindControl("ConteoPersonasP");
                    ConteoPersonasP.Visible = true;
                    break;
                case 32:
                    HyperLink ElectricoP = (HyperLink)Logged.FindControl("ElectricoP");
                    ElectricoP.Visible = true;
                    break;
                case 33:
                    HyperLink GraficasP = (HyperLink)Logged.FindControl("GraficasP");
                    GraficasP.Visible = true;
                    break;
            }
        }
    }

    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
        FormsAuthentication.SignOut();
        Response.AppendHeader("Cache-Control", "no-store");
        Response.AppendHeader("Pragma", "no-cache");
        Session.Remove("user2");
        Session.Abandon();
        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        System.Web.Security.FormsAuthentication.SignOut();
       
    }

    protected void ConsultarIcono()
    {
        
        string usuario = Context.User.Identity.GetUserName();
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT  icono FROM Clientes Where ID=(select ID_Cliente from AspNetUsers where username = @usuario)";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Connection = con;
        con.Open();
        DataTable imagenesBD = new DataTable();
        imagenesBD.Load(cmd.ExecuteReader());
        Repeater1.DataSource = imagenesBD;
        Repeater1.DataBind();
        con.Close();
    }


}
