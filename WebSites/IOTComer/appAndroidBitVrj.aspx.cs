/********************************************************************************************
Desarrollado por: Luis Gerardo Verdiguel
Version: 1.0
Descripción: Servicio Web para la aplicación móvil de Android Multicliente.
Optimizado para: IOT
Fecha: 03/04/2018 
 ********************************************************************************************/
using Microsoft.AspNet.Identity;
using System;
using System.Data.SqlClient;
using IOTComer;
using System.Configuration;
using System.Collections.Generic;
using Newtonsoft.Json;

public partial class appAndroidBitVrj : System.Web.UI.Page
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);

    /*-------------------------------------------CATALOGO DE CASOS DE USO:---------------------------------------------
                                    1.- Login de la aplicacion
                                    2.- Logout de la aplicacion (Proximamente)
                                    3.- Consulta de ubicaciones por cliente
                                    4.- Consulta de Temperatura por sucursal y fechas
                                    5.- Consulta de eventos de sensor magnético y corriente
                                    6.- COnsulta de eventos generales
    -----------------------------------------------------------------------------------------------------------------*/
    /*-----------------------------------------------------------------------------------------------------------------
    ---------------------------------------SECCION PRINCIPAL DE DIRECCIONAMIENTO A CU----------------------------------
    -----------------------------------------------------------------------------------------------------------------*/
    protected void Page_Load(object sender, EventArgs e)
    {
        string cu = null;
        cu = Request["cu"];

        switch (cu)
        {
            case "1":
                Login();
                break;
            case "2":
                DARResponse();
                break;
            case "3":
                returnComboUbicacion();
                break;
            case "4":
                returnTemperaturaBitacora();
                break;
            case "4a":
                returnTemperaturaBitacoraA();
                break;
            case "5":
                returnDAROtros();
                break;
            case "5a":
                returnDAROtrosA();
                break;
            case "6":
                returnDARPrincipal();
                break;
            case "6a":
                returnDARPrincipalA();
                break;
        }
    }

    /*----------------------------------------------------------------------------------------------------------------
    -------------------------------------SECCION DE FUNCIONES DE CASOS DE USO-----------------------------------------
    ----------------------------------------------------------------------------------------------------------------*/
    //Caso de uso 1
    protected void Login()
    {
        string usuario = null, password = null;

        usuario = Request["v1"];
        password = Request["v2"];
        // Validate the user password
        var manager = new UserManager();
        ApplicationUser user = manager.Find(usuario, password);
        if (user != null)
        {
            Response.Write(returnCliente(usuario));
        }
        else
        {
            Response.Write("False");
        }
    }
    //Caso de uso 2
    protected void DARResponse()
    {
        int cliente = 0;
        string response = null;
        cliente = Convert.ToInt32(Request["v1"]);
        response = returnDAR(cliente);
        Response.Write(response);
    }

    //Caso de uso 3
    protected void returnComboUbicacion() {
        int cliente = 0;
        string response = string.Empty;
        cliente = Convert.ToInt32(Request["v1"]);
        response = returnUbicaciones(cliente);
        Response.Write(response);
    }

    //Caso de uso 4
    protected void returnTemperaturaBitacora() {
        int cliente = 0, añoIni=0, mesIni=0, diaIni=0, añoFin=0,mesFin=0, diaFin=0;
        string response = string.Empty, sucursal = null;
        cliente = Convert.ToInt32(Request["v1"]);
        sucursal = Convert.ToString(Request["v2"]);
        diaIni = Convert.ToInt32(Request["v3"]);
        mesIni = returnMes(Request["v4"]);
        añoIni = Convert.ToInt32(Request["v5"]);
        diaFin = Convert.ToInt32(Request["v6"]);
        mesFin = returnMes(Request["v7"]);
        añoFin = Convert.ToInt32(Request["v8"]);
        DateTime inicial = new DateTime(añoIni, mesIni, diaIni), final = new DateTime(añoFin, mesFin, diaFin);
        //Response.Write(inicial+" "+final);
        response = returnTemperaturas(cliente,sucursal,inicial,final);
        Response.Write(response);
    }

    //Caso de uso 5
    protected void returnDAROtros() {
        int cliente = 0, añoIni = 0, mesIni = 0, diaIni = 0, añoFin = 0, mesFin = 0, diaFin = 0;
        string response = string.Empty, sucursal = null;
        cliente = Convert.ToInt32(Request["v1"]);
        sucursal = Convert.ToString(Request["v2"]);
        diaIni = Convert.ToInt32(Request["v3"]);
        mesIni = returnMes(Request["v4"]);
        añoIni = Convert.ToInt32(Request["v5"]);
        diaFin = Convert.ToInt32(Request["v6"]);
        mesFin = returnMes(Request["v7"]);
        añoFin = Convert.ToInt32(Request["v8"]);
        DateTime inicial = new DateTime(añoIni, mesIni, diaIni), final = new DateTime(añoFin, mesFin, diaFin);
        //Response.Write(inicial+" "+final);
        response = returnDAROt(cliente, sucursal, inicial, final);
        Response.Write(response);
    }

    //Caso de uso 6
    protected void returnDARPrincipal()
    {
        int cliente = 0, añoIni = 0, mesIni = 0, diaIni = 0, añoFin = 0, mesFin = 0, diaFin = 0;
        string response = string.Empty, sucursal = null;
        cliente = Convert.ToInt32(Request["v1"]);
        sucursal = Convert.ToString(Request["v2"]);
        diaIni = Convert.ToInt32(Request["v3"]);
        mesIni = returnMes(Request["v4"]);
        añoIni = Convert.ToInt32(Request["v5"]);
        diaFin = Convert.ToInt32(Request["v6"]);
        mesFin = returnMes(Request["v7"]);
        añoFin = Convert.ToInt32(Request["v8"]);
        DateTime inicial = new DateTime(añoIni, mesIni, diaIni), final = new DateTime(añoFin, mesFin, diaFin);
        //Response.Write(inicial+" "+final);
        response = returnDARPrin(cliente, sucursal, inicial, final);
        Response.Write(response);
    }

    //Caso de uso 4a
    protected void returnTemperaturaBitacoraA()
    {
        int cliente = 0;
        string response = string.Empty, sucursal = null;
        cliente = Convert.ToInt32(Request["v1"]);
        sucursal = Convert.ToString(Request["v2"]);
        DateTime inicial = new DateTime(), final = new DateTime();
        inicial = Convert.ToDateTime(Request["v3"]);
        final = Convert.ToDateTime(Request["v4"]);
        //Response.Write(inicial+" "+final);
        response = returnTemperaturas(cliente, sucursal, inicial, final);
        Response.Write(response);
    }

    //Caso de uso 5a
    protected void returnDAROtrosA()
    {
        int cliente = 0;
        string response = string.Empty, sucursal = null;
        cliente = Convert.ToInt32(Request["v1"]);
        sucursal = Convert.ToString(Request["v2"]);
        DateTime inicial = new DateTime(), final = new DateTime();
        inicial = Convert.ToDateTime(Request["v3"]);
        final = Convert.ToDateTime(Request["v4"]);
        //Response.Write(inicial+" "+final);
        response = returnDAROt(cliente, sucursal, inicial, final);
        Response.Write(response);
    }

    //Caso de uso 6a
    protected void returnDARPrincipalA()
    {
        int cliente = 0;
        string response = string.Empty, sucursal = null;
        cliente = Convert.ToInt32(Request["v1"]);
        sucursal = Convert.ToString(Request["v2"]);
        DateTime inicial = new DateTime(), final = new DateTime();
        inicial = Convert.ToDateTime(Request["v3"]);
        final = Convert.ToDateTime(Request["v4"]);
        //Response.Write(inicial+" "+final);
        response = returnDARPrin(cliente, sucursal, inicial, final);
        Response.Write(response);
    }

    /*--------------------------------------------------------------------------------------------------
    -----------------------------------------SECCION DE CONSULTAS---------------------------------------
    --------------------------------------------------------------------------------------------------*/
    //Consulta de clientes a partir del nombre de usuario
    protected int returnCliente(string user)
    {
        int id = 0;
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID_Cliente FROM AspNetUsers where UserName=@user", con);
        cmd.Parameters.AddWithValue("@user", user);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            id = Convert.ToInt32(dr[0]);
        }
        con.Close();
        return id;
    }

    //Consulta de DAR con nombres por cliente
    protected string returnDAR(int cliente)
    {
        List<DAR> lista = new List<DAR>();
        string json = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select RISCEI, Descripcion from dars where ID_Cliente=@cliente and (Modelo='DAR - BIS  – LU/VA/LE' or Modelo='DAR - BIS  – HW' or Modelo='DAR - BIS  – P1')", con);
        cmd.Parameters.AddWithValue("@cliente", cliente);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            DAR Object = new DAR();
            Object.riscei = (string)dr["RISCEI"];
            Object.nombre = (string)dr["Descripcion"];
            lista.Add(Object);
        }
        con.Close();

        json = JsonConvert.SerializeObject(lista);
        return json;
    }

    //Consulta de ubicaciones por cliente
    protected string returnUbicaciones(int cliente) {
        string json = String.Empty;
        List<Ubicaciones> ubicacion = new List<Ubicaciones>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select Descripcion from Sitios where ID_Cliente=@cliente", con);
        cmd.Parameters.AddWithValue("@cliente", cliente);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Ubicaciones Object = new Ubicaciones();
            Object.nombre = (string)dr["Descripcion"];
            ubicacion.Add(Object);
        }
        con.Close();

        json = JsonConvert.SerializeObject(ubicacion);
        return json;
    }

    //Consulta de registros de temperaturas por sucursal
    protected string returnTemperaturas(int id, string sucursal, DateTime inicial, DateTime final) {
        string json = String.Empty;
        List<temperatura> temper = new List<temperatura>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select TOP 50 Sensado.RISCEI, sensado.Fecha, sensado.Hora, sensado.Temperatura, sensado.Humedad from Sensado "+ 
        "right join(select DARS.riscei from DARS left join UbiDis on Dars.UbiDis = UbiDis.Id where UbiDis.Cl_Sitio = (select ID from Sitios where Descripcion " +
        "=@sucursal and ID_Cliente =@cliente)) as res1 on Sensado.RISCEI = res1.RISCEI where sensado.Fecha>=@inicial and sensado.Fecha<= @final order by Sensado.Id desc", con);
        cmd.Parameters.AddWithValue("@cliente", id);
        cmd.Parameters.AddWithValue("@sucursal",sucursal);
        cmd.Parameters.AddWithValue("@inicial", inicial);
        cmd.Parameters.AddWithValue("@final",final);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            DateTime aux;
            temperatura Object = new temperatura();
            Object.Riscei = (string)dr["RISCEI"];
            aux = (DateTime)dr["Fecha"];
            Object.Fecha = aux.ToString("dd/MM/yyyy");
            Object.Hora = (string)dr["Hora"];
            Object.Temperatura = (float)dr["Temperatura"];
            Object.Humedad = (float)dr["Humedad"];
            temper.Add(Object);
        }
        con.Close();

        json = JsonConvert.SerializeObject(temper);
        return json;
    }

    protected string returnDAROt(int id, string sucursal, DateTime inicial, DateTime final) {
        string json = string.Empty;
        List<DARSOt> otros = new List<DARSOt>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select top 50 controlSensado.RISCEI, controlSensado.Evento, controlSensado.Estado, controlSensado.Fecha from controlSensado "+ 
        "right join(select DARS.riscei from DARS left join UbiDis on Dars.UbiDis = UbiDis.Id where UbiDis.Cl_Sitio = (select ID from Sitios "+
        "where Descripcion = @sucursal and ID_Cliente = @cliente)) as res1 on controlSensado.RISCEI = res1.RISCEI where controlSensado.Fecha >= @inicial "+
        "and controlSensado.Fecha <= dateadd(dd,1,@final) order by controlSensado.Id desc", con);
        cmd.Parameters.AddWithValue("@cliente", id);
        cmd.Parameters.AddWithValue("@sucursal", sucursal);
        cmd.Parameters.AddWithValue("@inicial", inicial);
        cmd.Parameters.AddWithValue("@final", final);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            DateTime aux;
            DARSOt Object = new DARSOt();
            Object.Riscei = (string)dr["RISCEI"];
            Object.Evento = (string)dr["Evento"];
            Object.Estado = (string)dr["Estado"];
            aux = (DateTime)dr["Fecha"];
            Object.Fecha = aux.ToString("dd/MM/yyyy HH:mm");
            otros.Add(Object);
        }
        con.Close();

        json = JsonConvert.SerializeObject(otros);
        return json;
    }

    protected string returnDARPrin(int id, string sucursal, DateTime inicial, DateTime final) {
        string json = string.Empty;
        List<DARGen> otros = new List<DARGen>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select dispositivos.macID, dispositivos.Evento, dispositivos.Estado, dispositivos.Fecha from dispositivos "+
        "right join(select DARS.riscei from DARS left join UbiDis on Dars.UbiDis = UbiDis.Id where UbiDis.Cl_Sitio = (select ID from Sitios "+
        "where Descripcion = @sucursal and ID_Cliente = @cliente)) as res1 on dispositivos.macID = res1.RISCEI where " +
        "dispositivos.Fecha >= @inicial and dispositivos.Fecha <= dateadd(dd, 1, @final) order by dispositivos.Id desc", con);
        cmd.Parameters.AddWithValue("@cliente", id);
        cmd.Parameters.AddWithValue("@sucursal", sucursal);
        cmd.Parameters.AddWithValue("@inicial", inicial);
        cmd.Parameters.AddWithValue("@final", final);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            DateTime aux;
            DARGen Object = new DARGen();
            Object.Riscei = (string)dr["macID"];
            Object.Evento = (string)dr["Evento"];
            Object.Estado = (string)dr["Estado"];
            aux = (DateTime)dr["Fecha"];
            Object.Fecha = aux.ToString("dd/MM/yyyy HH:mm");
            otros.Add(Object);
        }
        con.Close();

        json = JsonConvert.SerializeObject(otros);
        return json;
    }
    

    /*-----------------------------------------------------------------------------------------------------------
    -----------------------------------------------SECCION DE OBJETOS--------------------------------------------
    -----------------------------------------------------------------------------------------------------------*/
    public class DAR
    {
        public string riscei { get; set; }
        public string nombre { get; set; }
    }

    public class Ubicaciones {
        public string nombre { get; set; }
    }

    public class temperatura {
        public string Riscei { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public float Temperatura { get; set; }
        public float Humedad { get; set; }
    }

    public class DARSOt {
        public string Riscei { get; set; }
        public string Evento { get; set; }
        public string Estado { get; set; }
        public string Fecha { get; set; }
    }

    public class DARGen {
        public string Riscei { get; set; }
        public string Evento { get; set; }
        public string Estado { get; set; }
        public string Fecha { get; set; }
    }

    /*-----------------------------------------------------------------------------------------------------------
    -----------------------------------------------FUNCIONES MISCELANEA------------------------------------------
    -----------------------------------------------------------------------------------------------------------*/
    //Conversion de Mes a Mes numérico
    protected int returnMes(string mes)
    {
        int mess = 0;

        switch (mes)
        {
            case "Enero":
                mess = 1;
                break;
            case "Febrero":
                mess = 2;
                break;
            case "Marzo":
                mess = 3;
                break;
            case "Abril":
                mess = 4;
                break;
            case "Mayo":
                mess = 5;
                break;
            case "Junio":
                mess = 6;
                break;
            case "Julio":
                mess = 7;
                break;
            case "Agosto":
                mess = 8;
                break;
            case "Septiembre":
                mess = 9;
                break;
            case "Octubre":
                mess = 10;
                break;
            case "Noviembre":
                mess = 11;
                break;
            case "Diciembre":
                mess = 12;
                break;
        }
        return mess;
    }
}