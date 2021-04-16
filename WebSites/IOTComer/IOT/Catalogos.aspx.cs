using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class IOT_HomeAdmin2 : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection con = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int ide = -1;
        con.Open();
        SqlCommand cmd = new SqlCommand("select ID_Permiso from PermisoRol where ID_Rol = " +
            "(select ID_Rol from AspNetUsers where UserName = @usuario)", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            ide = Convert.ToInt32(dr[0]);
            habilitarMenu(ide);
        }
        razon();
        ConsultarIcono();
    }

    protected void habilitarMenu(int id) {

        switch (id) {
            case 0:
                Clientes.Visible = true;
                UsuarioCliente.Visible = true;
                RolCliente.Visible = true;
                ConfigurarPlanos.Visible = true;
                SubirPlanos.Visible = true;
                Sitios.Visible = true;
                DARS.Visible = true;
                Modelos.Visible = true;
                Eventos.Visible = true;
                Fabricantes.Visible = true;
                Niveles.Visible = true;
                ReglasNegocio.Visible = true;
                AgregarCatalogo.Visible = true;
                HabilitarDispo.Visible = true;
                //Video.Visible = true;
                HabilitaCAM.Visible = true;
                BitacorasUsuarios.Visible = true;
                break;
            case 1:
                Telegram.Visible = true;
                break;
            case 2:
                UsuariosTelegram.Visible = true;
                break;
            case 3:
                Usuarios.Visible = true;
                break;
            case 4:
                CambiarContraseña.Visible = true;
                break;
            case 5:
                Roles.Visible = true;
                break;
            case 6:
                PlanosAdministrador.Visible = true;
                break;
            case 7:
                ControlBotones.Visible = true;
                break;
            case 8:
                MisDispositivos.Visible = true;
                break;
            case 9:
                ComandosVozAdministrador.Visible = true;
                break;
            case 10:
                ComandosVoz.Visible = true;
                break;
            case 11:
                ProgramacionTareas.Visible = true;
                break;
            case 12:
                ActivacionSistema.Visible = true;
                break;
            case 13:
                SimuladorPresencia.Visible = true;
                break;
            case 14:
                Clientes.Visible = true;
                break;
            case 15:
                UsuarioCliente.Visible = true;
                break;
            case 16:
                RolCliente.Visible = true;
                break;
            case 17:
                ConfigurarPlanos.Visible = true;
                break;
            case 18:
                SubirPlanos.Visible = true;
                break;
            case 19:
                Sitios.Visible = true;
                break;
            case 20:
                DARS.Visible = true;
                break;
            case 21:
                Modelos.Visible = true;
                break;
            case 22:
                Eventos.Visible = true;
                break;
            case 23:
                Fabricantes.Visible = true;
                break;
            case 24:
                Niveles.Visible = true;
                break;
            case 25:
                ReglasNegocio.Visible = true;
                break;
            case 26:
                AgregarCatalogo.Visible = true;
                break;
            case 27:
                Monitoreo.Visible = true;
                break;
            case 28:
                TelegramMonitoreo.Visible = true;
                break;
            case 40:
                HabilitarDispo.Visible = true;
                break;
            case 42:
                HabilitaCAM.Visible = true;
                break;
            case 43:
                Video.Visible = true;
                break;            
            case 44:
                HabilitaDispoUser.Visible = true;
                break;
            case 45:
                HabilitaCAMUser.Visible = true;
                break;
            case 46:
                Umbrales.Visible = true;
                break;
            case 47:
                ReglaSensorTemperatura.Visible = true;
                break;
            case 48:
                HuellaEmpleados.Visible = true;
                break;
            case 49:
                CanalTelegram.Visible = true;
                break;
            case 50:
                CanalTelegramEmpleado.Visible = true;
                break;
            case 51:
                BitacorasUsuarios.Visible = true;
                break;
            case 52:
                AltaRFID.Visible = true;
                break;
            case 53:
                AsignarRFID.Visible = true;
                break;
            case 54:
                BitacoraRFID.Visible = true;
                break;
            case 55:
                Restaurant.Visible = true;
                break;
        }
    }


    protected void razon()
    {
        string usuario = User.Identity.Name;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand("select RazonSocial from Clientes where ID = (select ID_cliente from AspNetUsers where UserName = @usuario)", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            cli.Text = Convert.ToString(dr[0]);
        }
        con.Close();
    }


    protected void ConsultarIcono()
    {
        string usuario = Context.User.Identity.GetUserName();
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT icono FROM Clientes Where ID=(select ID_Cliente from AspNetUsers where username = @usuario)";
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