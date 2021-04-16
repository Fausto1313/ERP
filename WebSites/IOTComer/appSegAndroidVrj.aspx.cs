using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class appSegAndroidVrj : System.Web.UI.Page
{
    private SqlConnection con = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=appAndroid;User ID=sa;Password=sa+LANSA!;Pooling=False");
    private SqlConnection con2 = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=IOTComer;User ID=sa;Password=sa+LANSA!;Pooling=False");
    protected void Page_Load(object sender, EventArgs e)
    {
        int diaIni = 0, añoIni = 0, diaFin = 0, añoFin = 0, horaIni=0, horaFin=0, minIni=0,minFin=0, messIni=0,messFin=0;
        string user=null, pass=null;
        int aux = Convert.ToInt32(Request["v1"]);
        if (aux == 1)
        {
            //Fecha inicial de activación
            añoIni = Convert.ToInt32(Request["v2"]);
            messIni = returnMes(Request["v3"]);
            diaIni = Convert.ToInt32(Request["v4"]);
            horaIni = Convert.ToInt32(Request["v5"]);
            minIni= Convert.ToInt32(Request["v6"]);
            //Fecha final de activación
            añoFin = Convert.ToInt32(Request["v7"]);
            messFin = returnMes(Request["v8"]);
            diaFin = Convert.ToInt32(Request["v9"]);
            horaFin = Convert.ToInt32(Request["v10"]);
            minFin = Convert.ToInt32(Request["v11"]);
            insertarSeguridad(añoIni, messIni, diaIni, horaIni, minIni, añoFin, messFin, diaFin, horaFin, minFin);/*
            System.IO.StreamWriter sw = new System.IO.StreamWriter("C:/Pruebas/pruebaVariables.txt");
            sw.WriteLine(Request["v2"]);
            sw.WriteLine(Request["v3"]);
            sw.WriteLine(Request["v4"]);
            sw.WriteLine(Request["v5"]);
            sw.WriteLine(Request["v6"]);
            sw.WriteLine(Request["v7"]);
            sw.WriteLine(Request["v8"]);
            sw.WriteLine(Request["v9"]);
            sw.WriteLine(Request["v10"]);
            sw.WriteLine(Request["v11"]);
            sw.Close();*/
        }
        else {
            user = Request["v2"];
            pass = Request["v3"];
            if(comprueba(user,pass)){
                actualizar();
                Response.Write("true");
            }
            else
                Response.Write("false");
        }
    }

    protected void insertarSeguridad(int añoIni, int mesIni, int diaIni, int horaIni, int minIni, int añoFin, int mesFin, int diaFin, int horaFin, int minFin){
        DateTime inicial= new DateTime(añoIni,mesIni,diaIni,horaIni,minIni,0), final = new DateTime(añoFin,mesFin,diaFin,horaFin,minFin,0);
        string estado = "Activo";
        //Prueba de fechas
        /*System.IO.StreamWriter sw = new System.IO.StreamWriter("C:/Pruebas/prueba.txt");
        sw.WriteLine(inicial);
        sw.WriteLine(final);
        sw.Close();*/
        
        con2.Open();
        string updatecmd = "insert into Activador (FechaInicio, FechaFin, Estatus ) values (@FechaInicio,@FechaFin,@Estatus)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con2);
        addCmd.Parameters.AddWithValue("@FechaInicio", inicial);
        addCmd.Parameters.AddWithValue("@FechaFin", final);
        addCmd.Parameters.AddWithValue("@Estatus", estado);
        try {
            addCmd.ExecuteNonQuery();
        }
        catch (Exception e) {
            
        }
        con2.Close();
        Response.Write("true");
    }

    protected int returnMes(string mes) {
        int mess = 0;

        switch (mes) {
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

    private bool comprueba(string user, string password){
        bool context = false;
        string pss = null;
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT Password FROM Login where UserName=@user", con);
        cmd.Parameters.AddWithValue("@user", user);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            pss = Convert.ToString(dr[0]);
        }
        con.Close();
        if (pss != null)
        {
            if (password == pss)
            {
                context = true;
            }
        }
        else
            context = false;
        return context;
    }

    private void actualizar(){
        DateTime nombre = DateTime.Now;
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "update Activador set Estatus='Inactivo' where (FechaInicio <= @nombre and FechaFin >= @nombre) or (FechaInicio >= @nombre)";
        cmd.Parameters.AddWithValue("@nombre", nombre);
        cmd.Connection = con2;
        con2.Open();
        cmd.ExecuteNonQuery();
        con2.Close();
    }
}