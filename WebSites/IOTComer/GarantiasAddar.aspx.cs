using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

public partial class GarantiasAddar : System.Web.UI.Page
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string cu = string.Empty;
        cu = Request["cu"];
        switch (cu) {
            case "1":
                regresaSitiosCliente();
                break;
            case "2":
                regresaNivelesSitios();
                break;
            case "3":
                regresaDARSNivel();
                break;
            case "4":
                regresaDatosGarantia();
                break;
        }
    }
    public void regresaSitiosCliente() {
        string cliente = string.Empty, json = string.Empty;
        cliente = Request["RazonSocial"];
        json = regresaSitiosClienteSQL(cliente);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    public void regresaNivelesSitios() {
        int sitio = 0;
        string json = string.Empty;
        sitio = Convert.ToInt32(Request["IDSitio"]);
        json = regresaNivelesSitioSQL(sitio);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    public void regresaDARSNivel() {
        int nivel = 0;
        string json = string.Empty;
        nivel = Convert.ToInt32(Request["IDNivel"]);
        json = regresaDARSNivelSQL(nivel);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    public void regresaDatosGarantia() {
        string riscei = string.Empty, json = string.Empty;
        riscei = Request["riscei"];
        json = regresaDatosGarantiaSQL(riscei);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
    }
    public string regresaSitiosClienteSQL(string cliente) {
        string json = string.Empty;
        Sitios s = new Sitios();
        con.Open();
        SqlCommand cmd = new SqlCommand("select ID, Descripcion from Sitios where ID_cliente = (select ID from Clientes where RazonSocial = @cliente)",con);
        cmd.Parameters.AddWithValue("@cliente", cliente);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            s.IDSitio = Convert.ToInt32(dr[0]);
            s.NombreSitio = Convert.ToString(dr[1]);
        }
        con.Close();
        json = JsonConvert.SerializeObject(s);
        return json;
    }
    public string regresaNivelesSitioSQL(int sitio) {
        string json = string.Empty;
        List<Niveles> nivels = new List<Niveles>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select ID, Nombre from Nivel1 where UbiDispo = @id", con);
        cmd.Parameters.AddWithValue("@id", sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            Niveles niv = new Niveles();
            niv.IDNivel = Convert.ToInt32(dr[0]);
            niv.NombreNivel = Convert.ToString(dr[1]);
            nivels.Add(niv);
        }
        con.Close();
        json = JsonConvert.SerializeObject(nivels);
        return json;
    }
    public string regresaDARSNivelSQL(int nivel) {
        string json = string.Empty;
        List<DAR> dars = new List<DAR>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select d.RISCEI, d.Descripcion from DARS d inner join UbiDis u " +
            "on u.Id = d.UbiDis where u.nivel1 = @id",con);
        cmd.Parameters.AddWithValue("@id",nivel);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            DAR dar1 = new DAR();
            dar1.RISCEI = Convert.ToString(dr[0]);
            dar1.Descripcion = Convert.ToString(dr[1]);
            dars.Add(dar1);
        }
        con.Close();
        json = JsonConvert.SerializeObject(dars);
        return json;
    }
    public string regresaDatosGarantiaSQL(string riscei)
    {
        string json = string.Empty;
        Garantia gar = new Garantia();
        con.Open();
        SqlCommand cmd = new SqlCommand("select d.Descripcion, n1.Nombre, n2.Nombre2, n3.Nombre3, d.FechaInstalacion, " +
            "d.PeriodoGarantia from DARS d inner join UbiDis u on u.Id = d.UbiDis inner join Nivel1 n1 on " +
            "u.nivel1 = n1.ID inner join Nivel2 n2 on u.nivel2 = n2.ID inner join Nivel3 n3 on n3.ID = u.nivel3 " +
            "where d.RISCEI = @riscei", con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            gar.nombre = Convert.ToString(dr[0]);
            gar.ubicacion = Convert.ToString(dr[1]) + " " + Convert.ToString(dr[2]) + " " + Convert.ToString(dr[3]);
            if (Convert.ToString(dr[4]) == "")
            {
                gar.fechaInstalacion = new DateTime(2019, 1, 1, 0, 1, 0);
            }
            else
            {
                gar.fechaInstalacion = Convert.ToDateTime(dr[4]);
            }
            gar.periodoGarantia = Convert.ToString(dr[5]);
        }
        con.Close();
        json = JsonConvert.SerializeObject(gar);
        return json;
    }

    private class Garantia
    {
        public string nombre { get; set; }
        public string ubicacion { get; set; }
        public DateTime fechaInstalacion { get; set; }
        public string periodoGarantia { get; set; }
    }
    private class Sitios { 
        public int IDSitio { get; set; }
        public string NombreSitio { get; set; }
    }
    private class Niveles { 
        public int IDNivel { get; set; }
        public string NombreNivel { get; set; }
    }
    private class DAR { 
        public string RISCEI { get; set; }
        public string Descripcion { get; set; }
    }

}

