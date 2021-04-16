using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class notificacionesPush : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string cu = string.Empty;

        cu = Request["cu"];
        switch (cu) {
            case "1":
                guardaSolicitud();
                break;
            case "2":
                consultaSolicitud();
                break;
            case "3":
                actualizaSolicitud();
                break;
            case "0":
                Response.Write("Online");
                break;
        }
    }

    protected void guardaSolicitud() {
        string usuario = string.Empty, tipoServicio = string.Empty;
        usuario = Request["usuario"];
        tipoServicio = Request["tipoServicio"];
        guardaSolicitudSQL(usuario,tipoServicio);
        Response.Write("True");
    }
    protected void actualizaSolicitud()
    {
        string usuario = string.Empty, ID = string.Empty, estatus = string.Empty, comentario = string.Empty;
        usuario = Request["usuario"];
        ID = Request["ID"];
        estatus = Request["estatus"];
        actualizaSolicitudSQL( ID, estatus);
        Response.Write(estatus);
    }
    protected void consultaSolicitud()
    {
        string usuario = string.Empty, json = string.Empty;
        usuario = Request["usuario"];
        json = consultaSolicitudSQL(usuario);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    protected void guardaSolicitudSQL(string usuario, string tipoServicio) {
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into Notificaciones (Usuario, TipoServicio, Estatus)" +
            " values(@usuario, @tipoServicio, 'En Espera')",con);
        cmd.Parameters.AddWithValue("@usuario",usuario);
        cmd.Parameters.AddWithValue("@tipoServicio", tipoServicio);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected string consultaSolicitudSQL(string usuario)   {
        con.Open();
        List<Notificaciones> notificacion = new List<Notificaciones>();
        string json = string.Empty;
        SqlCommand cmd = new SqlCommand("select * from Notificaciones where Usuario in(select Usuario from UsuarioRestaurant " +
            "where Sitio = (select C_Sitio from AspNetUsers where UserName = @usuario)) and Estatus = " +
            "'En Espera' ", con);

        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            Notificaciones noti = new Notificaciones();
            noti.ID = Convert.ToInt32(dr["ID"]);
            noti.Usuario = Convert.ToString(dr["Usuario"]);
            noti.TipoServicio = Convert.ToString(dr["TipoServicio"]);
            noti.Estatus = Convert.ToString(dr["Estatus"]);
            notificacion.Add(noti);
        }
        con.Close();
        json = JsonConvert.SerializeObject(notificacion);
        return json;
    }
    protected void actualizaSolicitudSQL(string id, string estatus) {
        con.Open();
        SqlCommand cmd = new SqlCommand("update Reservacions set estatus = @estatus where ID = @id",con);
        cmd.Parameters.AddWithValue("@estatus", estatus);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public class Notificaciones { 
        public int ID { get; set; }
        public string Usuario { get; set; }
        public string TipoServicio { get; set; }
        public string Estatus { get; set; }
    }
}