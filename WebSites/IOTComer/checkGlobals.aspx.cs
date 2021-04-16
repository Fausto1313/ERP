using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data.SqlClient;
public partial class checkGlobals : System.Web.UI.Page
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string variable = string.Empty;

        variable = Request["variable"];

        switch (variable) {
            case "NOIP":
                Response.ContentType = "application/json; charset=utf-8";
                Response.Write(returnDataNOIP());
                break;
            case "Upd":
                string usuario = string.Empty, contraseña = string.Empty;
                usuario = Request["usuario"];
                contraseña = Request["contraseña"];
                updateNOIPData(usuario, contraseña);
                break;                
            default:
                break;
        }
    }

    protected string returnDataNOIP() {
        NOIP nop = new NOIP();
        string json = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select Valor from Globales where (Campo = 'UsuarioNOIP' or Campo = " +
            "'ContraseñaNOIP')",con);
        int i = 0;
        SqlDataReader dr = cmd.ExecuteReader();
        while(dr.Read()) {
            if (i == 0)
                nop.usuario = Convert.ToString(dr[0]);
            else
                nop.contraseña = Convert.ToString(dr[0]);
            i++;
        }
        json = JsonConvert.SerializeObject(nop);
        con.Close();
        return json;
    }

    protected void updateNOIPData(string usuario, string contraseña) {
        con.Open();
        string userEnc = Encrypt.Encriptar(usuario);
        string passEnc = Encrypt.Encriptar(contraseña);
        SqlCommand cmd = new SqlCommand("update Globales set Valor = @usuario where Campo = 'UsuarioNOIP';" +
            "update Globales set Valor = @pass where Campo = 'ContraseñaNOIP'; ",con);
        cmd.Parameters.AddWithValue("@usuario",userEnc);
        cmd.Parameters.AddWithValue("@pass", passEnc);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public class NOIP {
        public string usuario { get; set; }
        public string contraseña { get; set; }
    }
}